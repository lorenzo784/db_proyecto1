using Proyecto1.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Servicios
{
    class ProductoService
    {

        public static bool InsertarProducto(string nombre, string descripcion, decimal precio, int stock, string ruta_imagen)
        {

            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string checkQuery = "SELECT COUNT(*) FROM productos WHERE nombre = @nombre";
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
                string query = "INSERT INTO productos (nombre, descripcion, precio, stock, ruta_imagen) VALUES (@nombre, @descripcion, @precio, @stock, @ruta_imagen)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@ruta_imagen", string.IsNullOrEmpty(ruta_imagen) ? (object)DBNull.Value : ruta_imagen);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public static DataTable ObtenerProductos()
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "SELECT * FROM productos";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static bool EditarProducto(int id, string nombre, string descripcion, decimal precio, int stock, string ruta_imagen)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string checkQuery = "SELECT COUNT(*) FROM productos WHERE nombre = @nombre AND id != @id";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@nombre", nombre);
                checkCmd.Parameters.AddWithValue("@id", id);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    return false;
                }

                string updateQuery = "UPDATE productos SET nombre = @nombre, descripcion = @descripcion, ruta_imagen = @ruta_imagen, precio = @precio, stock = @stock WHERE id = @id";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@nombre", nombre);
                updateCmd.Parameters.AddWithValue("@descripcion", descripcion);
                updateCmd.Parameters.AddWithValue("@precio", precio);
                updateCmd.Parameters.AddWithValue("@stock", stock);
                updateCmd.Parameters.AddWithValue("@ruta_imagen", string.IsNullOrEmpty(ruta_imagen) ? (object)DBNull.Value : ruta_imagen);
                updateCmd.Parameters.AddWithValue("@id", id);
                updateCmd.ExecuteNonQuery();

                return true;
            }
        }

        public static void EliminarProducto(int id)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "DELETE FROM productos WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static Producto ObtenerProducto(int id)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "Select * FROM productos WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Producto
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.GetString(2),
                            Precio = reader.GetDecimal(3),
                            Stock = reader.GetInt32(4),
                            Ruta_imagen = reader.IsDBNull(6) ? null : reader.GetString(6)
                        };
                    }
                }
            }
            return null;
        }

        public static Dictionary<int, string> ObtenerProductosDictionary()
        {
            Dictionary<int, string> productos = new Dictionary<int, string>();

            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "SELECT id, nombre FROM productos ORDER BY nombre";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nombre = reader.GetString(1);
                            productos.Add(id, nombre);
                        }
                    }
                }
            }

            return productos;
        }


        public static List<Producto> ObtenerProductosParaCombo()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "SELECT id, nombre, precio, stock FROM productos ORDER BY nombre";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetDecimal(2),
                                Stock = reader.GetInt32(3)
                            };
                            productos.Add(producto);
                        }
                    }
                }
            }

            return productos;
        }




    }
}
