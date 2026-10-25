using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    public partial class frmaportaciones : Form
    {
        // Conexión a Database2.mdf.
        private readonly string cadenaConexion =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database2.mdf;Integrated Security=True;Connect Timeout=30";

        private DataTable tablaAportaciones = new DataTable();

        public frmaportaciones()
        {
            InitializeComponent();
        }

        // Al abrir el formulario.
        private void frmaportaciones_Load(object sender, EventArgs e)
        {
            CargarAportaciones();
        }

        // Conectar directamente con la tabla aportaciones.
        private void CargarAportaciones()
        {
            try
            {
                using (SqlConnection conexion =
                    new SqlConnection(cadenaConexion))
                {
                    string consulta = @"
                        SELECT *
                        FROM dbo.aportaciones
                        ORDER BY idAportacion DESC;";

                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(consulta, conexion))
                    {
                        tablaAportaciones = new DataTable();
                        adaptador.Fill(tablaAportaciones);
                    }
                }

                grdAportaciones.DataSource = tablaAportaciones;

                grdAportaciones.ReadOnly = true;
                grdAportaciones.AllowUserToAddRows = false;
                grdAportaciones.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                grdAportaciones.MultiSelect = false;
                grdAportaciones.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                ActualizarIndicadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la tabla aportaciones.\n\n" +
                    "Verifica la conexión a Database2.mdf y el nombre " +
                    "de la tabla.\n\nDetalle: " + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Calcular los indicadores.
        private void ActualizarIndicadores()
        {
            int pendientes = 0;
            int solventes = 0;
            decimal totalRecaudado = 0;

            foreach (DataRow fila in tablaAportaciones.Rows)
            {
                string estado = "";

                if (tablaAportaciones.Columns.Contains("estado") &&
                    fila["estado"] != DBNull.Value)
                {
                    estado = fila["estado"].ToString().Trim();
                }

                if (estado.Equals(
                    "Solvente",
                    StringComparison.OrdinalIgnoreCase))
                {
                    solventes++;

                    if (tablaAportaciones.Columns.Contains("monto") &&
                        fila["monto"] != DBNull.Value)
                    {
                        decimal monto;

                        if (decimal.TryParse(
                            fila["monto"].ToString(), out monto))
                        {
                            totalRecaudado += monto;
                        }
                    }
                }
                else
                {
                    pendientes++;
                }
            }

            lblTotalRecaudado.Text = totalRecaudado.ToString("C2");
            lblPendientes.Text = pendientes.ToString();

            int total = tablaAportaciones.Rows.Count;

            decimal efectividad = total > 0
                ? (decimal)solventes / total * 100
                : 0;

            lblEfectividad.Text = efectividad.ToString("0.##") + "%";
        }

        // Botón para actualizar la tabla.
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarAportaciones();
        }

        // Botón para abrir el formulario de nueva aportación.
        private void btnNuevaAportacion_Click(
            object sender, EventArgs e)
        {
            try
            {
                using (frmNuevaAportacion formulario =
                    new frmNuevaAportacion(cadenaConexion))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarAportaciones();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo abrir el formulario de nueva aportación.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Botón para regresar al menú principal.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento del menú Regresar.
        private void rEGRESARToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }

        // Eventos que pueden estar asociados en el diseñador.
        private void grdAportaciones_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void lblPendientes_Paint(
            object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }
    }
}
