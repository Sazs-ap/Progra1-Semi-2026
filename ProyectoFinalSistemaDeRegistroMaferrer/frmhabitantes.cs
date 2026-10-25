using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    public partial class frmhabitantes : Form
    {
        // Conexión a la base de datos existente Database2.mdf.
        private readonly string cadenaConexion =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database2.mdf;Integrated Security=True;Connect Timeout=30";

        private int idSeleccionado = 0;

        public frmhabitantes()
        {
            InitializeComponent();
        }

        // Cargar habitantes al abrir el formulario.
        private void frmhabitantes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        // Mostrar y buscar habitantes.
        private void CargarDatos(string filtro = "")
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string query = @"
                        SELECT
                            idHabitantes,
                            nombre,
                            [código] AS casa,
                            direccion,
                            telefono
                        FROM dbo.habitantes";

                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        query += @"
                            WHERE nombre LIKE @filtro
                               OR [código] LIKE @filtro";
                    }

                    query += " ORDER BY idHabitantes DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (!string.IsNullOrWhiteSpace(filtro))
                        {
                            cmd.Parameters.Add(
                                "@filtro",
                                SqlDbType.VarChar,
                                100).Value = "%" + filtro + "%";
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            grdHabitantes.DataSource = dt;
                        }
                    }
                }

                grdHabitantes.ReadOnly = true;
                grdHabitantes.AllowUserToAddRows = false;
                grdHabitantes.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                grdHabitantes.MultiSelect = false;
                grdHabitantes.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                if (grdHabitantes.Columns.Contains("idHabitantes"))
                {
                    grdHabitantes.Columns["idHabitantes"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la tabla habitantes.\n\n" +
                    "Verifica Database2.mdf, la tabla dbo.habitantes " +
                    "y sus columnas.\n\nDetalle: " + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Agregar habitante.
        private void btnAgregarHabitante_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreHabitante.Text))
            {
                MessageBox.Show("Ingrese el nombre del habitante.");
                txtNombreHabitante.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodigoHabitante.Text))
            {
                MessageBox.Show("Ingrese el código o número de casa.");
                txtCodigoHabitante.Focus();
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string query = @"
                        INSERT INTO dbo.habitantes
                            ([código], nombre, direccion, telefono)
                        VALUES
                            (@casa, @nombre, @direccion, @telefono);";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@casa", SqlDbType.VarChar, 20)
                            .Value = txtCodigoHabitante.Text.Trim();

                        cmd.Parameters.Add(
                            "@nombre", SqlDbType.VarChar, 100)
                            .Value = txtNombreHabitante.Text.Trim();

                        cmd.Parameters.Add(
                            "@direccion", SqlDbType.VarChar, 200)
                            .Value = string.IsNullOrWhiteSpace(txtDireccionHabitante.Text)
                                ? (object)DBNull.Value
                                : txtDireccionHabitante.Text.Trim();

                        cmd.Parameters.Add(
                            "@telefono", SqlDbType.VarChar, 20)
                            .Value = string.IsNullOrWhiteSpace(txtTelefonoHabitante.Text)
                                ? (object)DBNull.Value
                                : txtTelefonoHabitante.Text.Trim();

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Habitante guardado correctamente.");
                LimpiarCampos();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Seleccionar una fila y mostrar sus datos en los controles (Usando Índices).
        private void grdHabitantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evita excepciones si se hace clic en los encabezados
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = grdHabitantes.Rows[e.RowIndex];

            if (fila.Cells[0].Value == null || fila.Cells[0].Value == DBNull.Value)
                return;

            idSeleccionado = Convert.ToInt32(fila.Cells[0].Value);      // ID (Columna 0)
            txtNombreHabitante.Text = Convert.ToString(fila.Cells[1].Value);    // Nombre (Columna 1)
            txtCodigoHabitante.Text = Convert.ToString(fila.Cells[2].Value);    // Casa (Columna 2)
            txtDireccionHabitante.Text = Convert.ToString(fila.Cells[3].Value); // Dirección (Columna 3)
            txtTelefonoHabitante.Text = Convert.ToString(fila.Cells[4].Value);  // Teléfono (Columna 4)
        }

        // Modificar habitante.
        private void btnModificarHabitante_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un habitante de la tabla.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreHabitante.Text) ||
                string.IsNullOrWhiteSpace(txtCodigoHabitante.Text))
            {
                MessageBox.Show(
                    "El nombre y el código de casa son obligatorios.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string query = @"
                        UPDATE dbo.habitantes
                        SET [código] = @casa,
                            nombre = @nombre,
                            direccion = @direccion,
                            telefono = @telefono
                        WHERE idHabitantes = @id;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(
                            "@casa", SqlDbType.VarChar, 20)
                            .Value = txtCodigoHabitante.Text.Trim();

                        cmd.Parameters.Add(
                            "@nombre", SqlDbType.VarChar, 100)
                            .Value = txtNombreHabitante.Text.Trim();

                        cmd.Parameters.Add(
                            "@direccion", SqlDbType.VarChar, 200)
                            .Value = string.IsNullOrWhiteSpace(txtDireccionHabitante.Text)
                                ? (object)DBNull.Value
                                : txtDireccionHabitante.Text.Trim();

                        cmd.Parameters.Add(
                            "@telefono", SqlDbType.VarChar, 20)
                            .Value = string.IsNullOrWhiteSpace(txtTelefonoHabitante.Text)
                                ? (object)DBNull.Value
                                : txtTelefonoHabitante.Text.Trim();

                        cmd.Parameters.Add(
                            "@id", SqlDbType.Int).Value = idSeleccionado;

                        con.Open();

                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show(
                                "No se encontró el habitante seleccionado.");
                            return;
                        }
                    }
                }

                MessageBox.Show("Habitante actualizado correctamente.");
                LimpiarCampos();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Eliminar habitante y sus aportaciones relacionadas.
        private void btnEliminarHabitante_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un habitante de la tabla.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar el habitante seleccionado?\n" +
                "También se eliminarán sus aportaciones relacionadas.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    using (SqlTransaction tx = con.BeginTransaction())
                    {
                        try
                        {
                            string borrarAportaciones = @"
                                DELETE FROM dbo.aportaciones
                                WHERE idHabitantes = @id;";

                            using (SqlCommand cmd = new SqlCommand(borrarAportaciones, con, tx))
                            {
                                cmd.Parameters.Add(
                                    "@id", SqlDbType.Int)
                                    .Value = idSeleccionado;

                                cmd.ExecuteNonQuery();
                            }

                            string borrarHabitante = @"
                                DELETE FROM dbo.habitantes
                                WHERE idHabitantes = @id;";

                            using (SqlCommand cmd = new SqlCommand(borrarHabitante, con, tx))
                            {
                                cmd.Parameters.Add(
                                    "@id", SqlDbType.Int)
                                    .Value = idSeleccionado;

                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    throw new Exception(
                                        "No se encontró el habitante.");
                                }
                            }

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Habitante eliminado correctamente.");
                LimpiarCampos();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Buscar mientras se escribe.
        private void txtBuscarHabitantes_TextChanged(object sender, EventArgs e)
        {
            CargarDatos(txtBuscarHabitantes.Text.Trim());
        }

        // Limpiar las cajas de texto.
        private void LimpiarCampos()
        {
            idSeleccionado = 0;

            txtNombreHabitante.Clear();
            txtCodigoHabitante.Clear();
            txtDireccionHabitante.Clear();
            txtTelefonoHabitante.Clear();

            grdHabitantes.ClearSelection();
        }

        // Regresar al menú principal.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Eventos requeridos por el diseñador de Visual Studio.
        private void grdHabitantes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void grbDatosHabitante_Enter(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}