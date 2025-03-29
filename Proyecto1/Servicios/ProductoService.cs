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

        public void InsertarProducto(string nombre, string descripcion, decimal precio, int stock)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "INSERT INTO productos (nombre, descripcion, precio, stock) VALUES (@nombre, @descripcion, @precio, @stock)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.ExecuteNonQuery();
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

        public void EditarProducto(int id, string nombre, string descripcion, decimal precio, int stock)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "UPDATE productos SET nombre = @nombre, descripcion = @descripcion, precio = @precio, stock = @stock WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarProducto(int id)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "DELETE FROM productos WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
