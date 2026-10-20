using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    public partial class frmInicio : Form
    {
        // 🔹 Cadena de conexión apuntando a la base existente SistemaDeRegistroMaferrer
        string cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=SistemaDeRegistroMaferrer;Integrated Security=True;";

        public frmInicio()
        {
            InitializeComponent();

            // Cargar indicadores de la base de datos al iniciar el formulario
            Load += (s, e) => CargarIndicadores();

            // Configurar los botones de accesos rápidos
            if (btnRapidoHabitante != null)
            {
                btnRapidoHabitante.Click += (s, e) =>
                {
                    using (frmhabitantes f = new frmhabitantes())
                    {
                        f.ShowDialog(this);
                        CargarIndicadores(); // Actualizar contadores al cerrar la ventana
                    }
                };
            }

            if (btnRapidoAportacion != null)
            {
                btnRapidoAportacion.Click += (s, e) => RegistrarAportacionRapida();
            }

            if (btnRapidoVisita != null)
            {
                btnRapidoVisita.Click += (s, e) => Proximamente("Visitas");
            }

            if (btnRapidoIncidente != null)
            {
                btnRapidoIncidente.Click += (s, e) => Proximamente("Incidentes");
            }
        }

        // Acceso rápido: abre la ventana de registro de nueva aportación
        private void RegistrarAportacionRapida()
        {
            try
            {
                using (frmNuevaAportacion f = new frmNuevaAportacion(cadenaConexion))
                {
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarIndicadores();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la pantalla de aportaciones: " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ---------- INDICADORES DE INICIO ----------
        public void CargarIndicadores()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    // Total de habitantes registrados
                    if (lblHabitantes != null)
                    {
                        lblHabitantes.Text = Escalar(con, "SELECT COUNT(*) FROM dbo.habitantes").ToString();
                    }

                    // Recaudado en el mes actual
                    if (lblRecaudado != null)
                    {
                        decimal recaudado = Convert.ToDecimal(Escalar(con,
                            "SELECT ISNULL(SUM(monto), 0) FROM dbo.aportaciones " +
                            "WHERE estado = 'Solvente' AND YEAR(fecha) = YEAR(GETDATE()) AND MONTH(fecha) = MONTH(GETDATE())"));
                        lblRecaudado.Text = recaudado.ToString("C2", new CultureInfo("en-US"));
                    }

                    // Pagos o aportaciones pendientes
                    if (lblPendientes != null)
                    {
                        lblPendientes.Text = Escalar(con, "SELECT COUNT(*) FROM dbo.aportaciones WHERE estado = 'Pendiente'").ToString();
                    }

                    // Indicadores para futuros módulos
                    if (lblVisitas != null) lblVisitas.Text = "0";
                    if (lblIncidentes != null) lblIncidentes.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los indicadores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private object Escalar(SqlConnection con, string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                object result = cmd.ExecuteScalar();
                return result ?? 0;
            }
        }

        private void Proximamente(string modulo)
        {
            MessageBox.Show("El módulo de " + modulo + " estará disponible próximamente.", "Próximamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Métodos de evento requeridos por el Designer
        private void Frmprincipal_Load(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void pnlInicio_Paint(object sender, PaintEventArgs e) { }
    }
}