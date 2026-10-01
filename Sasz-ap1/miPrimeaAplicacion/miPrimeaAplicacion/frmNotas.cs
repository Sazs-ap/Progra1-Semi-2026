using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace miPrimeaAplicacion
{
    public partial class frmNotas : Form
    {
        public frmNotas()
        {
            InitializeComponent();
        }

        Conexion objConexion = new Conexion();
        DataSet objDs = new DataSet();
        DataTable dtNotas = new DataTable();
        bool cargado = false;

        private void frmNotas_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet dsInicial = objConexion.obtenerDatos();

                // Cargar ComboBox de Alumnos
                if (dsInicial.Tables.Contains("alumnos"))
                {
                    cmbAlumno.DataSource = dsInicial.Tables["alumnos"];
                    cmbAlumno.DisplayMember = "nombre";
                    cmbAlumno.ValueMember = "idAlumno";
                }

                // Cargar ComboBox de Materias
                if (dsInicial.Tables.Contains("materias"))
                {
                    cmbMateria.DataSource = dsInicial.Tables["materias"];
                    cmbMateria.DisplayMember = "nombre";
                    cmbMateria.ValueMember = "idMateria";
                }

                // Cargar ComboBox de Períodos
                if (dsInicial.Tables.Contains("periodos"))
                {
                    cmbPeriodo.DataSource = dsInicial.Tables["periodos"];
                    cmbPeriodo.DisplayMember = "periodo";
                    cmbPeriodo.ValueMember = "idPeriodo";
                }

                cargado = true;
                actualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar datos iniciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarGrid()
        {
            if (!cargado) return;

            objDs.Clear();
            string query = "SELECT alumnos.nombre, materias.nombre AS materia, periodos.periodo, " +
                           "dnotas.idDetalle, dnotas.idNota, dnotas.idMateria, " +
                           "dnotas.lab1, dnotas.lab2, dnotas.parcial, " +
                           "ROUND((dnotas.lab1*0.3 + dnotas.lab2*0.3 + dnotas.parcial*0.4), 2) AS nf, " +
                           "CASE WHEN (dnotas.lab1*0.3 + dnotas.lab2*0.3 + dnotas.parcial*0.4) >= 6.0 THEN 'Aprobado' ELSE 'Reprobado' END AS estado " +
                           "FROM dnotas " +
                           "INNER JOIN notas ON (notas.idNota = dnotas.idNota) " +
                           "INNER JOIN alumnos ON (alumnos.idAlumno = notas.idAlumno) " +
                           "INNER JOIN materias ON (materias.idMateria = dnotas.idMateria) " +
                           "INNER JOIN periodos ON (periodos.idPeriodo = notas.idPeriodo)";

            objConexion.objAdaptador = new SqlDataAdapter(query, objConexion.objConexion);
            objConexion.objAdaptador.Fill(objDs, "notasAlumnos");

            if (objDs.Tables.Contains("notasAlumnos"))
            {
                dtNotas = objDs.Tables["notasAlumnos"];

                // Configuración de columnas del DataGridView
                grdNotas.AutoGenerateColumns = false;
                grdNotas.Columns.Clear();

                DataGridViewTextBoxColumn colAlumno = new DataGridViewTextBoxColumn();
                colAlumno.Name = "nombre";
                colAlumno.DataPropertyName = "nombre";
                colAlumno.HeaderText = "Alumno";
                colAlumno.Width = 150;
                grdNotas.Columns.Add(colAlumno);

                DataGridViewTextBoxColumn colMateria = new DataGridViewTextBoxColumn();
                colMateria.Name = "materia";
                colMateria.DataPropertyName = "materia";
                colMateria.HeaderText = "Materia";
                colMateria.Width = 120;
                grdNotas.Columns.Add(colMateria);

                DataGridViewTextBoxColumn colPeriodo = new DataGridViewTextBoxColumn();
                colPeriodo.Name = "periodo";
                colPeriodo.DataPropertyName = "periodo";
                colPeriodo.HeaderText = "Período";
                colPeriodo.Width = 90;
                grdNotas.Columns.Add(colPeriodo);

                DataGridViewTextBoxColumn colLab1 = new DataGridViewTextBoxColumn();
                colLab1.Name = "lab1";
                colLab1.DataPropertyName = "lab1";
                colLab1.HeaderText = "Nota 1 (30%)";
                colLab1.Width = 80;
                grdNotas.Columns.Add(colLab1);

                DataGridViewTextBoxColumn colLab2 = new DataGridViewTextBoxColumn();
                colLab2.Name = "lab2";
                colLab2.DataPropertyName = "lab2";
                colLab2.HeaderText = "Nota 2 (30%)";
                colLab2.Width = 80;
                grdNotas.Columns.Add(colLab2);

                DataGridViewTextBoxColumn colParcial = new DataGridViewTextBoxColumn();
                colParcial.Name = "parcial";
                colParcial.DataPropertyName = "parcial";
                colParcial.HeaderText = "Nota 3 (40%)";
                colParcial.Width = 80;
                grdNotas.Columns.Add(colParcial);

                DataGridViewTextBoxColumn colNF = new DataGridViewTextBoxColumn();
                colNF.Name = "nf";
                colNF.DataPropertyName = "nf";
                colNF.HeaderText = "Promedio";
                colNF.Width = 80;
                grdNotas.Columns.Add(colNF);

                DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
                colEstado.Name = "estado";
                colEstado.DataPropertyName = "estado";
                colEstado.HeaderText = "Estado";
                colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grdNotas.Columns.Add(colEstado);

                DataGridViewTextBoxColumn colIdDetalle = new DataGridViewTextBoxColumn();
                colIdDetalle.Name = "idDetalle";
                colIdDetalle.DataPropertyName = "idDetalle";
                colIdDetalle.Visible = false;
                grdNotas.Columns.Add(colIdDetalle);

                grdNotas.DataSource = dtNotas.DefaultView;
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double n1 = 0, n2 = 0, n3 = 0;

            double.TryParse(txtNota1.Text.Replace(',', '.'), out n1);
            double.TryParse(txtNota2.Text.Replace(',', '.'), out n2);
            double.TryParse(txtNota3.Text.Replace(',', '.'), out n3);

            double promedio = (n1 * 0.3) + (n2 * 0.3) + (n3 * 0.4);
            promedio = Math.Round(promedio, 2);

            lblResultadoPromedio.Text = promedio.ToString("0.0");
            lblResultadoEstado.Text = (promedio >= 6.0) ? "Aprobado" : "Reprobado";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbAlumno.SelectedValue == null || cmbMateria.SelectedValue == null || cmbPeriodo.SelectedValue == null)
            {
                MessageBox.Show("Seleccione Alumno, Materia y Período.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnCalcular_Click(sender, e);

            string idAlumno = cmbAlumno.SelectedValue.ToString();
            string idMateria = cmbMateria.SelectedValue.ToString();
            string idPeriodo = cmbPeriodo.SelectedValue.ToString();

            string lab1 = txtNota1.Text.Replace(',', '.');
            string lab2 = txtNota2.Text.Replace(',', '.');
            string parcial = txtNota3.Text.Replace(',', '.');

            // 1. Verificar/Crear registro maestro en la tabla 'notas'
            string sqlBuscarNota = "SELECT idNota FROM notas WHERE idAlumno='" + idAlumno + "' AND idPeriodo='" + idPeriodo + "'";
            DataSet dsNota = new DataSet();
            SqlDataAdapter daBuscar = new SqlDataAdapter(sqlBuscarNota, objConexion.objConexion);
            daBuscar.Fill(dsNota, "notaExistente");

            string idNota = "0";
            if (dsNota.Tables["notaExistente"].Rows.Count > 0)
            {
                idNota = dsNota.Tables["notaExistente"].Rows[0]["idNota"].ToString();
            }
            else
            {
                string sqlInsertNota = "INSERT INTO notas(idAlumno, idPeriodo) VALUES('" + idAlumno + "', '" + idPeriodo + "')";
                objConexion.ejecutarSQL(sqlInsertNota);

                DataSet dsUltimo = new DataSet();
                SqlDataAdapter daUltimo = new SqlDataAdapter("SELECT MAX(idNota) AS id FROM notas", objConexion.objConexion);
                daUltimo.Fill(dsUltimo, "ultimo");
                idNota = dsUltimo.Tables["ultimo"].Rows[0]["id"].ToString();
            }

            // 2. Verificar/Insertar/Actualizar en la tabla 'dnotas'
            string sqlBuscarDetalle = "SELECT idDetalle FROM dnotas WHERE idNota='" + idNota + "' AND idMateria='" + idMateria + "'";
            DataSet dsDetalle = new DataSet();
            SqlDataAdapter daDetalle = new SqlDataAdapter(sqlBuscarDetalle, objConexion.objConexion);
            daDetalle.Fill(dsDetalle, "detalleExistente");

            string sqlGuardar = "";
            if (dsDetalle.Tables["detalleExistente"].Rows.Count > 0)
            {
                string idDetalle = dsDetalle.Tables["detalleExistente"].Rows[0]["idDetalle"].ToString();
                sqlGuardar = "UPDATE dnotas SET lab1='" + lab1 + "', lab2='" + lab2 + "', parcial='" + parcial + "' WHERE idDetalle='" + idDetalle + "'";
            }
            else
            {
                sqlGuardar = "INSERT INTO dnotas(idNota, idMateria, lab1, lab2, parcial) VALUES('" + idNota + "', '" + idMateria + "', '" + lab1 + "', '" + lab2 + "', '" + parcial + "')";
            }

            string resp = objConexion.ejecutarSQL(sqlGuardar);
            if (resp == "1")
            {
                MessageBox.Show("La nota se guardó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarGrid();
            }
            else
            {
                MessageBox.Show(resp, "Error al guardar nota", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdNotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdNotas.CurrentRow != null && e.RowIndex >= 0)
            {
                txtNota1.Text = grdNotas.CurrentRow.Cells["lab1"].Value?.ToString() ?? "0";
                txtNota2.Text = grdNotas.CurrentRow.Cells["lab2"].Value?.ToString() ?? "0";
                txtNota3.Text = grdNotas.CurrentRow.Cells["parcial"].Value?.ToString() ?? "0";
                btnCalcular_Click(sender, e);
            }
        }
    }
}