using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    public partial class frmregistrovt : Form
    {
        // Cadena de conexión adaptada a la base de datos de tu proyecto actual
        private string conexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;Connect Timeout=30";

        public frmregistrovt()
        {
            InitializeComponent();
        }

        // Cargar los visitantes al abrir el formulario
        private void frmregistrovt_Load(object sender, EventArgs e)
        {
            CargarVisitantes();
        }

        // Mostrar los datos en la tabla (DataGridView) de forma limpia y sin duplicados
        private void CargarVisitantes()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    string consulta = @"SELECT id, hora_entrada, nombre_visitante, numero_casa, motivo, hora_salida 
                                        FROM Visitantes";

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cn))
                    {
                        DataTable tabla = new DataTable();

                        dataGridView1.DataSource = null;
                        dataGridView1.Columns.Clear();
                        dataGridView1.AutoGenerateColumns = true;

                        adaptador.Fill(tabla);

                        dataGridView1.DataSource = tabla;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.ReadOnly = true;
                        dataGridView1.AllowUserToAddRows = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los visitantes: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Registrar una nueva visita al hacer clic en el botón
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos requeridos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    string consulta = @"INSERT INTO Visitantes (hora_entrada, nombre_visitante, numero_casa, motivo, hora_salida)
                                        VALUES (@entrada, @nombre, @casa, @motivo, @salida)";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.Add("@entrada", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = textBox1.Text.Trim();
                        cmd.Parameters.Add("@casa", SqlDbType.VarChar, 30).Value = textBox2.Text.Trim();
                        cmd.Parameters.Add("@motivo", SqlDbType.VarChar, 100).Value = textBox3.Text.Trim();
                        cmd.Parameters.Add("@salida", SqlDbType.DateTime).Value = dateTimePicker2.Value;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                CargarVisitantes();

                MessageBox.Show("Visitante registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la visita: " + ex.Message, "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos de eventos
        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e) { }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click_1(object sender, EventArgs e) { }
    }
}