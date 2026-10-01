using System;
using System.Data;
using System.Windows.Forms;

namespace miPrimeaAplicacion
{
    public partial class frmMateria : Form
    {
        public frmMateria()
        {
            InitializeComponent();
        }

        Conexion objConexion = new Conexion();
        DataSet objDs = new DataSet();
        DataTable objDt = new DataTable();
        public int posicion = 0;
        public string accion = "nuevo";

        private void actualizarDs()
        {
            objDs.Clear();
            objDs = objConexion.obtenerDatos();
            objDt = objDs.Tables["materias"];
            objDt.PrimaryKey = new DataColumn[] { objDt.Columns["idMateria"] };

            grdMaterias.DataSource = objDt.DefaultView;
            mostrarDatos();
        }

        private void mostrarDatos()
        {
            if (objDt.Rows.Count > 0)
            {
                txtCodigo.Text = objDt.Rows[posicion]["codigo"].ToString();
                txtNombre.Text = objDt.Rows[posicion]["nombre"].ToString();
                txtUV.Text = objDt.Rows[posicion]["uv"].ToString();
                lblRegistros.Text = (posicion + 1) + " de " + objDt.Rows.Count;
            }
        }

        private void frmMateria_Load(object sender, EventArgs e)
        {
            actualizarDs();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (posicion < objDt.Rows.Count - 1)
            {
                posicion++;
                mostrarDatos();
            }
            else
            {
                MessageBox.Show("Estás en el último registro.", "Navegación de Materias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrarDatos();
            }
            else
            {
                MessageBox.Show("Estás en el primer registro.", "Navegación de Materias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (objDt.Rows.Count > 0)
            {
                posicion = objDt.Rows.Count - 1;
                mostrarDatos();
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrarDatos();
        }

        private void estadoControles(Boolean estado)
        {
            txtCodigo.Enabled = estado;
            txtNombre.Enabled = estado;
            txtUV.Enabled = estado;
            btnEliminar.Enabled = !estado;
        }

        private void limpiarControles()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtUV.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text == "Nuevo")
            {
                btnNuevo.Text = "Guardar";
                btnModificar.Text = "Cancelar";
                estadoControles(true);
                accion = "nuevo";
                limpiarControles();
            }
            else
            { // Guardar
                string id = (objDt.Rows.Count > 0 && posicion < objDt.Rows.Count)
                    ? objDt.Rows[posicion]["idMateria"].ToString()
                    : "0";

                String[] materias = {
                    id,
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtUV.Text
                };

                String respuesta = objConexion.administrarDatosMaterias(materias, accion);
                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error al guardar materias.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    estadoControles(false);
                    btnNuevo.Text = "Nuevo";
                    btnModificar.Text = "Modificar";
                    actualizarDs();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnModificar.Text == "Modificar")
            {
                btnNuevo.Text = "Guardar";
                btnModificar.Text = "Cancelar";
                estadoControles(true);
                accion = "modificar";
            }
            else
            { // Cancelar
                mostrarDatos();
                estadoControles(false);
                btnNuevo.Text = "Nuevo";
                btnModificar.Text = "Modificar";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar a " + txtNombre.Text + "?",
                "Eliminando materia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string id = objDt.Rows[posicion]["idMateria"].ToString();

                String respuesta = objConexion.administrarDatosMaterias(
                    new String[] { id, "", "", "" }, "eliminar"
                );

                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error al eliminar materia.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    posicion = 0;
                    actualizarDs();
                }
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                filtrarDatos(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void filtrarDatos(String valor)
        {
            try
            {
                DataView objDv = objDt.DefaultView;
                objDv.RowFilter = "nombre like '%" + valor + "%' OR codigo like '%" + valor + "%'";
                grdMaterias.DataSource = objDv;
                seleccionarMateria();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void seleccionarMateria()
        {
            try
            {
                if (grdMaterias.CurrentRow == null) return;

                string id = grdMaterias.CurrentRow.Cells[0].Value.ToString();
                posicion = objDt.Rows.IndexOf(objDt.Rows.Find(id));
                mostrarDatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void grdMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarMateria();
        }

        private void grdMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Método auxiliar para eventos del diseñador
        }
    }
}