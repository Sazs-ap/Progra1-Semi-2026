using System;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    public partial class frmIniciarsesion : Form
    {
        public frmIniciarsesion()
        {
            InitializeComponent();

            // 🔥 ESTA LÍNEA CONECTA EL BOTÓN AUTOMÁTICAMENTE, 
            // ASí TE ASEGURAS DE QUE SÍ O SÍ FUNCIONE AL HACER CLIC
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }

        private void frmIniciarsesion_Load(object sender, EventArgs e)
        {
            // Oculta la contraseña con asteriscos
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Credenciales de prueba
            string usuarioFijo = "admin";
            string contrasenaFija = "1234";

            // Validar credenciales quitando espacios en blanco extra
            if (textBox1.Text.Trim() == usuarioFijo && textBox2.Text.Trim() == contrasenaFija)
            {
                MessageBox.Show("¡Acceso concedido!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abre tu Menú Principal
                MENUPRINCIPAL menu = new MENUPRINCIPAL();
                menu.Show();

                // Oculta la ventana de login
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox1.Focus();
            }
        }
    }
}