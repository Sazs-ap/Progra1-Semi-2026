using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    public partial class frmhabitantes : Form
    {
        // Si tu cadena de conexión es distinta, deja aquí la tuya.
        string cadenaConexion = "Server=(localdb)\\MSSQLLocalDB; Database=SistemaDeRegistroMaferrer; Trusted_Connection=True;";
        int idSeleccionado = 0;

        public frmhabitantes()
        {
            InitializeComponent();
        }

        private void frmhabitantes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        // 1. Cargar datos de SQL Server a la tabla DataGridView
        private void CargarDatos(string filtro = "")
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string query = "SELECT idHabitantes, nombre, [código] AS casa, direccion, telefono FROM [dbo].[habitantes]";

                    if (!string.IsNullOrEmpty(filtro))
                    {
                        query += " WHERE nombre LIKE @filtro OR [código] LIKE @filtro";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grdHabitantes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Botón NUEVO (Insertar)
        private void btnAgregarHabitante_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreHabitante.Text))
            {
                MessageBox.Show("Ingrese el nombre del habitante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string query = "INSERT INTO [dbo].[habitantes] ([código], [nombre], [direccion], [telefono]) VALUES (@casa, @nombre, @direccion, @telefono)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@casa", txtCodigoHabitante.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", txtNombreHabitante.Text.Trim());
                    cmd.Parameters.AddWithValue("@direccion", txtDireccionHabitante.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefonoHabitante.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Habitante guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Seleccionar fila de la tabla para llenar las cajas de texto
        private void grdHabitantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView fila = grdHabitantes.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (fila == null) return;

                idSeleccionado = Convert.ToInt32(fila["idHabitantes"]);
                txtNombreHabitante.Text = fila["nombre"]?.ToString().Trim();
                txtCodigoHabitante.Text = fila["casa"]?.ToString().Trim();
                txtDireccionHabitante.Text = fila["direccion"]?.ToString().Trim();
                txtTelefonoHabitante.Text = fila["telefono"]?.ToString().Trim();
            }
        }

        // 4. Botón ACTUALIZA (Modificar)
        private void btnModificarHabitante_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un registro de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string query = "UPDATE [dbo].[habitantes] SET [código] = @casa, [nombre] = @nombre, [direccion] = @direccion, [telefono] = @telefono WHERE [idHabitantes] = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@casa", txtCodigoHabitante.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", txtNombreHabitante.Text.Trim());
                    cmd.Parameters.AddWithValue("@direccion", txtDireccionHabitante.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefonoHabitante.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Habitante actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. Botón ELIMINAR
        // Si el habitante tiene aportaciones, avisa cuántas son y las borra junto con él.
        private void btnEliminarHabitante_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un registro de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    // ¿Tiene aportaciones registradas?
                    int cantidad;
                    using (SqlCommand cmdContar = new SqlCommand("SELECT COUNT(*) FROM [dbo].[aportaciones] WHERE [idHabitantes] = @id", con))
                    {
                        cmdContar.Parameters.AddWithValue("@id", idSeleccionado);
                        cantidad = Convert.ToInt32(cmdContar.ExecuteScalar());
                    }

                    string mensaje = cantidad > 0
                        ? "Este habitante tiene " + cantidad + " aportación(es) registrada(s).\nSi continúa, también se eliminarán esas aportaciones.\n\n¿Desea eliminarlo de todas formas?"
                        : "¿Está seguro de eliminar este registro?";

                    if (MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    {
                        return;
                    }

                    // Se borran las aportaciones y el habitante juntos: o se hace todo o nada
                    using (SqlTransaction tx = con.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmdAportaciones = new SqlCommand("DELETE FROM [dbo].[aportaciones] WHERE [idHabitantes] = @id", con, tx))
                            {
                                cmdAportaciones.Parameters.AddWithValue("@id", idSeleccionado);
                                cmdAportaciones.ExecuteNonQuery();
                            }

                            using (SqlCommand cmdHabitante = new SqlCommand("DELETE FROM [dbo].[habitantes] WHERE [idHabitantes] = @id", con, tx))
                            {
                                cmdHabitante.Parameters.AddWithValue("@id", idSeleccionado);
                                cmdHabitante.ExecuteNonQuery();
                            }

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }

                    MessageBox.Show("Registro eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Buscador
        private void txtBuscarHabitantes_TextChanged(object sender, EventArgs e)
        {
            CargarDatos(txtBuscarHabitantes.Text.Trim());
        }

        // Manejador vacío que el diseñador (Designer.cs) espera encontrar
        private void grdHabitantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtNombreHabitante.Clear();
            txtCodigoHabitante.Clear();
            txtDireccionHabitante.Clear();
            txtTelefonoHabitante.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}