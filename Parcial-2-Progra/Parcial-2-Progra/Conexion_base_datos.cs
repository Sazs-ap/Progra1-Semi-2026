using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class Conexion_base_datos
{
    public SqlConnection conexionDb = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=Parcial2;Integrated Security=True");
    public DataSet ds = new DataSet();

    public void crearDs()
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM usuarios_usss013726", conexionDb);
            if (ds.Tables["usuarios"] != null)
            {
                ds.Tables["usuarios"].Clear();
            }
            da.Fill(ds, "usuarios");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al crear DataSet: " + ex.Message);
        }
    }

    public Boolean mantenimiento_usuarios_usss013726(int idUsuario, string usuario, string clave, string nombre, string direccion, string telefono, int accion)
    {
        string sentencia = "";

        if (accion == 1) // Agregar
        {
            sentencia = $"INSERT INTO usuarios_usss013726 (usuario, clave, nombre, dirección, teléfono) VALUES ('{usuario}', '{clave}', '{nombre}', '{direccion}', '{telefono}')";
        }
        else if (accion == 2) // Modificar
        {
            sentencia = $"UPDATE usuarios_usss013726 SET usuario='{usuario}', clave='{clave}', nombre='{nombre}', dirección='{direccion}', teléfono='{telefono}' WHERE idUsuario={idUsuario}";
        }
        else if (accion == 3) // Eliminar
        {
            sentencia = $"DELETE FROM usuarios_usss013726 WHERE idUsuario={idUsuario}";
        }

        return procesar(sentencia);
    }

    public bool procesar(string query)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query, conexionDb);
            conexionDb.Open();
            cmd.ExecuteNonQuery();
            conexionDb.Close();
            return true;
        }
        catch (Exception)
        {
            if (conexionDb.State == ConnectionState.Open) conexionDb.Close();
            return false;
        }
    }
}