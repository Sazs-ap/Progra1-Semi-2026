using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Incidentes
{
    public partial class incidentes : Form
    {
        private readonly string cadena =
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=|DataDirectory|\Database2.mdf;
              Integrated Security=True";

        public incidentes()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            this.BackColor = Color.AliceBlue;

            label1.Font = new Font("Arial Black", 18, FontStyle.Bold);
            label1.ForeColor = Color.DodgerBlue;

            btnAgregar.BackColor = Color.DodgerBlue;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.FlatStyle = FlatStyle.Flat;

            dgvIncidentes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvIncidentes.RowHeadersVisible = false;
            dgvIncidentes.AllowUserToAddRows = false;
            dgvIncidentes.ReadOnly = true;
        }

        private void incidentes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFecha.Text) ||
                string.IsNullOrWhiteSpace(txtTipo.Text) ||
                string.IsNullOrWhiteSpace(txtLugar.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            DateTime fecha;

            if (!DateTime.TryParse(txtFecha.Text, out fecha))
            {
                MessageBox.Show("Ingrese una fecha válida");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    string sql = @"INSERT INTO Incidentes
                                  (Fecha, Tipo, Lugar, Descripcion, Estado)
                                  VALUES
                                  (@Fecha, @Tipo, @Lugar, @Descripcion, @Estado)";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Tipo", txtTipo.Text);
                    cmd.Parameters.AddWithValue("@Lugar", txtLugar.Text);
                    cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@Estado", txtEstado.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Incidente guardado correctamente");

                LimpiarCampos();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    string sql = @"SELECT Id,
                                          Fecha,
                                          Tipo,
                                          Lugar,
                                          Descripcion,
                                          Estado
                                   FROM Incidentes
                                   ORDER BY Id DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    // Limpieza previa para evitar duplicados en el DataGridView
                    dgvIncidentes.DataSource = null;
                    dgvIncidentes.Columns.Clear();
                    dgvIncidentes.AutoGenerateColumns = true;

                    // Asignación de datos limpia
                    dgvIncidentes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
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
    }
}