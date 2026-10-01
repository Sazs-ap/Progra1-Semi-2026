using System;
using System.Data;
using System.Windows.Forms;

namespace miPrimeaAplicacion
{
    public partial class frmPeriodos : Form
    {
        public frmPeriodos()
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

            // Si en tu DataSet la tabla se llama 'periodos', se asigna
            if (objDs.Tables.Contains("periodos"))
            {
                objDt = objDs.Tables["periodos"];
                objDt.PrimaryKey = new DataColumn[] { objDt.Columns["idPeriodo"] };
            }

            grdPeriodos.DataSource = objDt.DefaultView;
            mostrarDatos();
        }

        private void mostrarDatos()
        {
            if (objDt.Rows.Count > 0 && posicion < objDt.Rows.Count)
            {
                txtPeriodo.Text = objDt.Rows[posicion]["periodo"].ToString();
                lblRegistros.Text = (posicion + 1) + " de " + objDt.Rows.Count;
            }
        }

        private void frmPeriodos_Load(object sender, EventArgs e)
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
                MessageBox.Show("Estás en el último registro.", "Navegación de Períodos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Estás en el primer registro.", "Navegación de Períodos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtPeriodo.Enabled = estado;
            btnEliminar.Enabled = !estado;
        }

        private void limpiarControles()
        {
            txtPeriodo.Text = "";
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
                    ? objDt.Rows[posicion]["idPeriodo"].ToString()
                    : "0";

                String[] periodos = { id, txtPeriodo.Text, DateTime.Now.ToString("yyyy-MM-dd") };

                String respuesta = objConexion.ejecutarSQL(
                    accion == "nuevo"
                    ? "INSERT INTO periodos(periodo, fecha) VALUES('" + txtPeriodo.Text + "', GETDATE())"
                    : "UPDATE periodos SET periodo='" + txtPeriodo.Text + "' WHERE idPeriodo='" + id + "'"
                );

                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error al guardar período.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (MessageBox.Show("¿Está seguro de eliminar el período " + txtPeriodo.Text + "?",
                "Eliminando período", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string id = objDt.Rows[posicion]["idPeriodo"].ToString();
                String respuesta = objConexion.ejecutarSQL("DELETE FROM periodos WHERE idPeriodo='" + id + "'");

                if (respuesta != "1")
                {
                    MessageBox.Show(respuesta, "Error al eliminar período.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    posicion = 0;
                    actualizarDs();
                }
            }
        }

        private void seleccionarPeriodo()
        {
            try
            {
                if (grdPeriodos.CurrentRow == null) return;

                string id = grdPeriodos.CurrentRow.Cells[0].Value.ToString();
                posicion = objDt.Rows.IndexOf(objDt.Rows.Find(id));
                mostrarDatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void grdPeriodos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarPeriodo();
        }
    }
}