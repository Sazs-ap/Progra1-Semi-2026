using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    public partial class frmaportaciones : Form
    {
        string cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=SistemaDeRegistroMaferrer;Integrated Security=True;";

        public frmaportaciones()
        {
            InitializeComponent();

            // Se conectan los eventos aquí para no depender del diseñador.
            // No hagas doble clic en el botón ni en el formulario.
            Load += AlCargarFormulario;
            btnNuevaAportacion.Click += AbrirNuevaAportacion;
        }

        private void AlCargarFormulario(object sender, EventArgs e)
        {
            grdAportaciones.ReadOnly = true;
            grdAportaciones.AllowUserToAddRows = false;
            grdAportaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CargarAportaciones();
        }

        // Botón "Nueva Aportacion": abre la ventana para registrar
        private void AbrirNuevaAportacion(object sender, EventArgs e)
        {
            using (frmNuevaAportacion f = new frmNuevaAportacion(cadenaConexion))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargarAportaciones(); // refresca tabla e indicadores
                }
            }
        }

        // Carga la tabla y calcula los indicadores
        private void CargarAportaciones()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string query = @"
                        SELECT a.idAportacion AS Id,
                               ISNULL(CONVERT(varchar(10), a.fecha, 103), '—') AS Fecha,
                               h.nombre AS Habitante,
                               a.concepto AS Concepto,
                               a.monto AS Monto,
                               ISNULL(a.numComprobante, '—') AS [N.° Comprobante],
                               a.estado AS Estado,
                               a.fecha AS FechaReal
                        FROM dbo.aportaciones a
                        INNER JOIN dbo.habitantes h ON h.idHabitantes = a.idHabitantes
                        ORDER BY CASE WHEN a.fecha IS NULL THEN 1 ELSE 0 END, a.fecha";

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.Fill(dt);

                    // Se descartan las columnas del diseñador y se generan desde la consulta
                    grdAportaciones.Columns.Clear();
                    grdAportaciones.AutoGenerateColumns = true;
                    grdAportaciones.DataSource = dt;

                    grdAportaciones.Columns["Id"].Visible = false;
                    grdAportaciones.Columns["FechaReal"].Visible = false;
                    grdAportaciones.Columns["Monto"].DefaultCellStyle.Format = "$#,##0.00";
                    grdAportaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    ActualizarIndicadores(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las aportaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Calcula los 3 indicadores a partir de los datos de la tabla
        private void ActualizarIndicadores(DataTable dt)
        {
            decimal totalMes = 0;
            int pendientes = 0;
            int solventes = 0;
            DateTime hoy = DateTime.Today;

            foreach (DataRow fila in dt.Rows)
            {
                string estado = fila["Estado"].ToString();

                if (estado == "Solvente")
                {
                    solventes++;

                    // Solo suma lo cobrado en el mes y año actuales
                    if (fila["FechaReal"] != DBNull.Value)
                    {
                        DateTime fecha = Convert.ToDateTime(fila["FechaReal"]);
                        if (fecha.Month == hoy.Month && fecha.Year == hoy.Year)
                        {
                            totalMes += Convert.ToDecimal(fila["Monto"]);
                        }
                    }
                }
                else
                {
                    pendientes++;
                }
            }

            int totalFilas = dt.Rows.Count;
            double efectividad = totalFilas == 0 ? 0 : ((double)solventes / totalFilas) * 100;

            lblTotalRecaudado.Text = totalMes.ToString("C2", new CultureInfo("en-US"));
            lblPendientes.Text = pendientes.ToString();
            lblEfectividad.Text = Math.Round(efectividad, MidpointRounding.AwayFromZero) + "%";
        }

        // Manejadores vacíos que el diseñador (Designer.cs) espera encontrar
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void lblPendientes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grdAportaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmaportaciones_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rEGRESARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MENUPRINCIPAL ventanaREGRESAR = new MENUPRINCIPAL();
            ventanaREGRESAR.Show();
        }

        private void btnNuevaAportacion_Click(object sender, EventArgs e)
        {

        }
    }
}