using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Parcial_2_Progra
{
    public partial class frm_usuario : Form
    {
        Conexion_base_datos conexion = new Conexion_base_datos();
        int posicion = 0;
        bool modoNuevo = false;

        public frm_usuario()
        {
            InitializeComponent();
        }

        private DataTable Tabla
        {
            get { return conexion.ds.Tables["usuarios"]; }
        }

        private void frm_usuario_Load(object sender, EventArgs e)
        {
            conexion.crearDs();
            if (Tabla == null) return;

            grdUsuarios.Columns.Clear();
            grdUsuarios.AutoGenerateColumns = true;
            grdUsuarios.DataSource = Tabla;
            grdUsuarios.ReadOnly = true;
            grdUsuarios.AllowUserToAddRows = false;
            grdUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (grdUsuarios.Columns["clave"] != null) grdUsuarios.Columns["clave"].Visible = false;

            Mostrar(0);
        }

        // ---------- Utilidades ----------
        private void Mostrar(int indice)
        {
            if (Tabla == null || Tabla.Rows.Count == 0) { Limpiar(); return; }
            if (indice < 0) indice = 0;
            if (indice >= Tabla.Rows.Count) indice = Tabla.Rows.Count - 1;
            posicion = indice;

            DataRow f = Tabla.Rows[posicion];
            lblIdUsuario.Text = f["idUsuario"].ToString();
            txtUsuario.Text = f["usuario"].ToString();
            txtClave.Text = f["clave"].ToString();
            txtConfirmacion.Text = f["clave"].ToString();
            txtNombre.Text = f["nombre"].ToString();
            txtDireccion.Text = f["dirección"].ToString();
            txtTelefono.Text = f["teléfono"].ToString();

            grdUsuarios.ClearSelection();
            grdUsuarios.Rows[posicion].Selected = true;
            grdUsuarios.CurrentCell = grdUsuarios.Rows[posicion].Cells["usuario"];
        }

        private void Limpiar()
        {
            lblIdUsuario.Text = "0";
            txtUsuario.Clear();
            txtClave.Clear();
            txtConfirmacion.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }

        private string Esc(string texto)
        {
            return texto.Replace("'", "''");
        }

        private void SalirModoNuevo()
        {
            modoNuevo = false;
            btnNuevo.Text = "Nuevo";
            btnSalir.Text = "Salir";
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private bool Validar(int idActual)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (usuario == "" || clave == "" || txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Usuario, clave y nombre son obligatorios.");
                return false;
            }
            if (usuario.Length < 6 || usuario.Length > 16)
            {
                MessageBox.Show("El usuario debe tener entre 6 y 16 caracteres.");
                return false;
            }
            if (clave != txtConfirmacion.Text)
            {
                MessageBox.Show("La clave y su confirmación no coinciden.");
                return false;
            }
            if (!clave.Any(char.IsLetter) || !clave.Any(char.IsDigit))
            {
                MessageBox.Show("La clave debe llevar letras y números.");
                return false;
            }
            foreach (DataRow f in Tabla.Rows)
            {
                if (Convert.ToInt32(f["idUsuario"]) != idActual &&
                    string.Equals(f["usuario"].ToString(), usuario, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Ese usuario ya existe.");
                    return false;
                }
            }
            return true;
        }

        // ---------- Edición ----------
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!modoNuevo)
            {
                modoNuevo = true;
                Limpiar();
                btnNuevo.Text = "Guardar";
                btnSalir.Text = "Cancelar";
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                txtUsuario.Focus();
                return;
            }

            if (!Validar(0)) return;

            bool ok = conexion.mantenimiento_usuarios_usss013726(
                0, Esc(txtUsuario.Text.Trim()), Esc(txtClave.Text), Esc(txtNombre.Text.Trim()),
                Esc(txtDireccion.Text.Trim()), Esc(txtTelefono.Text.Trim()), 1);

            if (ok)
            {
                MessageBox.Show("Usuario guardado.");
                SalirModoNuevo();
                conexion.crearDs();
                Mostrar(Tabla.Rows.Count - 1);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el usuario.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(lblIdUsuario.Text, out id) || id == 0)
            {
                MessageBox.Show("Selecciona un usuario de la tabla.");
                return;
            }
            if (!Validar(id)) return;

            bool ok = conexion.mantenimiento_usuarios_usss013726(
                id, Esc(txtUsuario.Text.Trim()), Esc(txtClave.Text), Esc(txtNombre.Text.Trim()),
                Esc(txtDireccion.Text.Trim()), Esc(txtTelefono.Text.Trim()), 2);

            if (ok)
            {
                MessageBox.Show("Usuario actualizado.");
                conexion.crearDs();
                Mostrar(posicion);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el usuario.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(lblIdUsuario.Text, out id) || id == 0)
            {
                MessageBox.Show("Selecciona un usuario de la tabla.");
                return;
            }

            if (MessageBox.Show("¿Eliminar este usuario?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (conexion.mantenimiento_usuarios_usss013726(id, "", "", "", "", "", 3))
            {
                conexion.crearDs();
                Mostrar(posicion);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el usuario.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (modoNuevo)
            {
                SalirModoNuevo();
                Mostrar(posicion);
            }
            else
            {
                this.Close();
            }
        }

        // ---------- Navegación ----------
        private void btnPrimero_Click(object sender, EventArgs e) { if (!modoNuevo) Mostrar(0); }
        private void btnAnterior_Click(object sender, EventArgs e) { if (!modoNuevo) Mostrar(posicion - 1); }
        private void btnSiguiente_Click(object sender, EventArgs e) { if (!modoNuevo) Mostrar(posicion + 1); }
        private void btnUltimo_Click(object sender, EventArgs e) { if (!modoNuevo) Mostrar(Tabla.Rows.Count - 1); }

        private void grdUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!modoNuevo && e.RowIndex >= 0) Mostrar(e.RowIndex);
        }
    }
}