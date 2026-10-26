using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    public partial class frmregistrovt : Form
    {
        // Cadena de conexión a la base de datos
        private readonly string conexion =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database2.mdf;Integrated Security=True;Connect Timeout=30";

        public frmregistrovt()
        {
            InitializeComponent();
        }

        // Cargar visitantes al abrir el formulario
        private void frmregistrovt_Load(object sender, EventArgs e)
        {
            CargarVisitantes();
        }

        // Consultar y mostrar los visitantes
        private void CargarVisitantes()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    string consulta = @"
                        SELECT id, hora_entrada, nombre_visitante,
                               numero_casa, motivo, hora_salida
                        FROM Visitantes
                        ORDER BY id DESC";

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(consulta, cn))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        dataGridView1.DataSource = null;
                        dataGridView1.Columns.Clear();
                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = tabla;

                        dataGridView1.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        dataGridView1.ReadOnly = true;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.SelectionMode =
                            DataGridViewSelectionMode.FullRowSelect;
                        dataGridView1.MultiSelect = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los visitantes:\n" + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Registrar un visitante
        private void button1_Click(object sender, EventArgs e)
        {
            // Validar los campos de texto
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show(
                    "Completa el nombre, número de casa y motivo.",
                    "Campos vacíos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Validar las fechas
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show(
                    "La hora de salida no puede ser anterior a la hora de entrada.",
                    "Fechas incorrectas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    string consulta = @"
                        INSERT INTO Visitantes
                        (hora_entrada, nombre_visitante, numero_casa,
                         motivo, hora_salida)
                        VALUES
                        (@entrada, @nombre, @casa, @motivo, @salida)";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.Add("@entrada", SqlDbType.DateTime)
                            .Value = dateTimePicker1.Value;

                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100)
                            .Value = textBox1.Text.Trim();

                        cmd.Parameters.Add("@casa", SqlDbType.VarChar, 30)
                            .Value = textBox2.Text.Trim();

                        cmd.Parameters.Add("@motivo", SqlDbType.VarChar, 100)
                            .Value = textBox3.Text.Trim();

                        cmd.Parameters.Add("@salida", SqlDbType.DateTime)
                            .Value = dateTimePicker2.Value;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // Actualizar la tabla después de guardar
                CargarVisitantes();

                MessageBox.Show(
                    "Visitante registrado correctamente.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Limpiar los campos
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar la visita:\n" + ex.Message,
                    "Error de registro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Regresar al menú principal sin duplicarlo
        private void button2_Click(object sender, EventArgs e)
        {
            // Revisa si ya hay una instancia abierta del menú principal
            foreach (Form form in Application.OpenForms)
            {
                if (form is MENUPRINCIPAL)
                {
                    form.Show();
                    this.Close();
                    return;
                }
            }

            // Si por alguna razón no estuviera en memoria, crea una nueva
            MENUPRINCIPAL ventanaREGRESAR = new MENUPRINCIPAL();
            ventanaREGRESAR.Show();
            this.Close();
        }

        // Eventos del diseñador de Windows Forms
        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e) { }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click_1(object sender, EventArgs e) { }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}