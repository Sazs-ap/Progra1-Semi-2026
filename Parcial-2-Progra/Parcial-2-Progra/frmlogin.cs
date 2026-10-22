using System;
using System.Data;
using System.Windows.Forms;

namespace Parcial_2_Progra
{
    public partial class frmlogin : Form
    {
        Conexion_base_datos conexion = new Conexion_base_datos();

        public frmlogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (usuario == "" || clave == "")
            {
                MessageBox.Show("Escribe usuario y clave.");
                return;
            }

            conexion.crearDs();
            DataTable tabla = conexion.ds.Tables["usuarios"];
            if (tabla == null) return;

            bool valido = false;
            foreach (DataRow fila in tabla.Rows)
            {
                if (fila["usuario"].ToString() == usuario && fila["clave"].ToString() == clave)
                {
                    valido = true;
                    break;
                }
            }

            if (valido)
            {
                this.Hide();
                using (frm_usuario menu = new frm_usuario())
                {
                    menu.ShowDialog();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o clave incorrectos. Acceso denegado.");
                txtClave.Clear();
                txtClave.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}