using Proyecto1.Modelos;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto1.Servicios
{
    class ProveedorService
    {
        public static bool InsertarProveedor(string nombre, string telefono, string correo_electronico, string direccion)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string checkQuery = "SELECT COUNT(*) FROM proveedores WHERE nombre = @nombre";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@nombre", nombre);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    return false;
                }
            }

            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "INSERT INTO proveedores (nombre, telefono, correo_electronico, direccion) VALUES (@nombre, @telefono, @correo_electronico, @direccion)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@correo_electronico", correo_electronico);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public static DataTable ObtenerProveedores()
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "SELECT * FROM proveedores";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static bool EditarProveedor(int id, string nombre, string telefono, string correo_electronico, string direccion)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string checkQuery = "SELECT COUNT(*) FROM proveedores WHERE nombre = @nombre AND id != @id";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@nombre", nombre);
                checkCmd.Parameters.AddWithValue("@id", id);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    return false;
                }

                string updateQuery = "UPDATE proveedores SET nombre = @nombre, telefono = @telefono, correo_electronico = @correo_electronico, direccion = @direccion WHERE id = @id";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@nombre", nombre);
                updateCmd.Parameters.AddWithValue("@telefono", telefono);
                updateCmd.Parameters.AddWithValue("@correo_electronico", correo_electronico);
                updateCmd.Parameters.AddWithValue("@direccion", direccion);
                updateCmd.Parameters.AddWithValue("@id", id);
                updateCmd.ExecuteNonQuery();

                return true;
            }
        }

        public static void EliminarProveedor(int id)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "DELETE FROM proveedores WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static Proveedor ObtenerProveedor(int id)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "SELECT * FROM proveedores WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Proveedor
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Telefono = reader.IsDBNull(2) ? null : reader.GetString(2),
                            CorreoElectronico = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Direccion = reader.IsDBNull(4) ? null : reader.GetString(4)
                        };
                    }
                }
            }
            return null;
        }
    }
}
