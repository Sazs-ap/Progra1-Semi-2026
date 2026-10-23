
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Incidentes
{
    public partial class incidentes : Form
    {
        private string cadena =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jonat\OneDrive\Escritorio\repos\Incidentes\Incidentes\Incidentes.mdf;Integrated Security=True";

        public incidentes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvIncidentes.AutoGenerateColumns = false;

            dgvIncidentes.Columns[0].DataPropertyName = "Id";
            dgvIncidentes.Columns[1].DataPropertyName = "Fecha";
            dgvIncidentes.Columns[2].DataPropertyName = "Tipo";
            dgvIncidentes.Columns[3].DataPropertyName = "Lugar";
            dgvIncidentes.Columns[4].DataPropertyName = "Descripcion";
            dgvIncidentes.Columns[5].DataPropertyName = "Estado";

            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    string sql = @"SELECT Id, Fecha, Tipo, Lugar,
                                   Descripcion, Estado
                                   FROM dbo.Incidentes";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgvIncidentes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los incidentes: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFecha.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text) ||
                string.IsNullOrWhiteSpace(txtLugar.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            DateTime fecha;

            if (!DateTime.TryParse(txtFecha.Text, out fecha))
            {
                MessageBox.Show(
                    "La fecha no es válida. Usa el formato dd/MM/aaaa.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    string sql = @"INSERT INTO dbo.Incidentes
                                   (Fecha, Tipo, Lugar, Descripcion, Estado)
                                   VALUES
                                   (@Fecha, @Tipo, @Lugar,
                                    @Descripcion, @Estado)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha;
                        cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 100).Value =
                            txtTipo.Text.Trim();
                        cmd.Parameters.Add("@Lugar", SqlDbType.VarChar, 150).Value =
                            txtLugar.Text.Trim();
                        cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value =
                            txtDescripcion.Text.Trim();
                        cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 50).Value =
                            txtEstado.Text.Trim();

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Incidente guardado correctamente.");

                CargarDatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar el incidente: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtFecha.Clear();
            txtTipo.Clear();
            txtLugar.Clear();
            txtDescripcion.Clear();
            txtEstado.Clear();

            txtFecha.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
