using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    // Ventana para registrar una aportación. Se construye por código,
    // así que no necesita diseñador.
    public class frmNuevaAportacion : Form
    {
        private readonly string cadenaConexion;

        private ComboBox cboHabitante = new ComboBox();
        private ComboBox cboConcepto = new ComboBox();
        private NumericUpDown numMonto = new NumericUpDown();
        private ComboBox cboEstado = new ComboBox();
        private DateTimePicker dtpFecha = new DateTimePicker();
        private TextBox txtComprobante = new TextBox();
        private Button btnGuardar = new Button();
        private Button btnCancelar = new Button();

        public frmNuevaAportacion(string cadena)
        {
            cadenaConexion = cadena;
            ConstruirInterfaz();
            CargarHabitantes();
        }

        private void ConstruirInterfaz()
        {
            Text = "Nueva aportación";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(390, 340);
            Font = new Font("Segoe UI", 10F);

            cboHabitante.DropDownStyle = ComboBoxStyle.DropDownList;

            cboConcepto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConcepto.Items.AddRange(new object[] { "Cuota ordinaria", "Cuota extraordinaria" });
            cboConcepto.SelectedIndex = 0;

            numMonto.DecimalPlaces = 2;
            numMonto.Minimum = 0.01M;
            numMonto.Maximum = 100000M;
            numMonto.Value = 10M;

            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.Items.AddRange(new object[] { "Solvente", "Pendiente" });
            cboEstado.SelectedIndex = 0;
            cboEstado.SelectedIndexChanged += CambioEstado;

            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Value = DateTime.Today;

            txtComprobante.MaxLength = 20;

            AgregarFila("Habitante", cboHabitante, 20);
            AgregarFila("Concepto", cboConcepto, 65);
            AgregarFila("Monto ($)", numMonto, 110);
            AgregarFila("Estado", cboEstado, 155);
            AgregarFila("Fecha", dtpFecha, 200);
            AgregarFila("N.° comprobante", txtComprobante, 245);

            btnGuardar.Text = "Guardar";
            btnGuardar.SetBounds(150, 295, 100, 32);
            btnGuardar.Click += Guardar;

            btnCancelar.Text = "Cancelar";
            btnCancelar.SetBounds(260, 295, 100, 32);
            btnCancelar.DialogResult = DialogResult.Cancel;

            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
        }

        private void AgregarFila(string texto, Control control, int y)
        {
            Label lbl = new Label();
            lbl.Text = texto;
            lbl.AutoSize = true;
            lbl.Location = new Point(20, y + 4);

            control.SetBounds(150, y, 210, 28);

            Controls.Add(lbl);
            Controls.Add(control);
        }

        // Si está pendiente, no tiene fecha de pago ni comprobante todavía
        private void CambioEstado(object sender, EventArgs e)
        {
            bool solvente = cboEstado.Text == "Solvente";
            dtpFecha.Enabled = solvente;
            txtComprobante.Enabled = solvente;
            if (!solvente) txtComprobante.Clear();
        }

        private void CargarHabitantes()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT idHabitantes, nombre FROM dbo.habitantes ORDER BY nombre", con);
                    da.Fill(dt);

                    cboHabitante.DisplayMember = "nombre";
                    cboHabitante.ValueMember = "idHabitantes";
                    cboHabitante.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Primero registra habitantes en el formulario de habitantes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnGuardar.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar habitantes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardar.Enabled = false;
            }
        }

        private void Guardar(object sender, EventArgs e)
        {
            if (cboHabitante.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un habitante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool solvente = cboEstado.Text == "Solvente";

            if (solvente && string.IsNullOrWhiteSpace(txtComprobante.Text))
            {
                MessageBox.Show("Ingrese el número de comprobante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComprobante.Focus();
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string query = @"INSERT INTO dbo.aportaciones (idHabitantes, fecha, concepto, monto, numComprobante, estado)
                                     VALUES (@idHabitante, @fecha, @concepto, @monto, @comprobante, @estado)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idHabitante", Convert.ToInt32(cboHabitante.SelectedValue));
                    cmd.Parameters.AddWithValue("@fecha", solvente ? (object)dtpFecha.Value.Date : DBNull.Value);
                    cmd.Parameters.AddWithValue("@concepto", cboConcepto.Text);
                    cmd.Parameters.AddWithValue("@monto", numMonto.Value);
                    cmd.Parameters.AddWithValue("@comprobante", solvente ? (object)txtComprobante.Text.Trim() : DBNull.Value);
                    cmd.Parameters.AddWithValue("@estado", cboEstado.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la aportación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmNuevaAportacion
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "frmNuevaAportacion";
            this.Load += new System.EventHandler(this.frmNuevaAportacion_Load);
            this.ResumeLayout(false);

        }

        private void frmNuevaAportacion_Load(object sender, EventArgs e)
        {

        }
    }
}