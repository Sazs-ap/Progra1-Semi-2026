using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    public partial class frmInicio : Form
    {
        // 🔹 Conexión unificada a Database2.mdf para evitar conflictos
        string cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database2.mdf;Integrated Security=True;";

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
                btnRapidoVisita.Click += (s, e) =>
                {
                    using (frmregistrovt f = new frmregistrovt())
                    {
                        f.ShowDialog(this);
                        CargarIndicadores(); // Actualizar al cerrar
                    }
                };
            }

            if (btnRapidoIncidente != null)
            {
                btnRapidoIncidente.Click += (s, e) =>
                {
                    using (Incidentes.incidentes f = new Incidentes.incidentes())
                    {
                        f.ShowDialog(this);
                        CargarIndicadores(); // Actualizar al cerrar
                    }
                };
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

                    // Indicadores reales de Visitas e Incidentes
                    if (lblVisitas != null)
                    {
                        lblVisitas.Text = Escalar(con, "SELECT COUNT(*) FROM dbo.Visitantes").ToString();
                    }

                    if (lblIncidentes != null)
                    {
                        lblIncidentes.Text = Escalar(con, "SELECT COUNT(*) FROM dbo.Incidentes").ToString();
                    }
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

        // Métodos de evento requeridos por el Designer
        private void Frmprincipal_Load(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void pnlInicio_Paint(object sender, PaintEventArgs e) { }
        private void label10_Click_1(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void pnlInicio_Paint_1(object sender, PaintEventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            MENUPRINCIPAL ventanaREGRESAR = new MENUPRINCIPAL();
            ventanaREGRESAR.Show();
            this.Close();
        }
    }
}