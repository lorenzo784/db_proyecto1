using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1.Servicios
{
    class SalidaService
    {
        public static bool RegistrarSalidaProducto(int idProducto, int cantidad, int id_venta)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string checkQuery = "SELECT stock FROM productos WHERE id = @idProducto";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@idProducto", idProducto);

                object result = checkCmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Producto no encontrado en la base de datos.");
                    return false;
                }

                int stock = Convert.ToInt32(result);

                if (stock < cantidad)
                {
                    MessageBox.Show($"Stock insuficiente. Stock disponible: {stock}, cantidad solicitada: {cantidad}");
                    return false;
                }
            }

            using (SqlConnection conn = new Conexion().AbrirConexion())
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    string insertQuery = "INSERT INTO salida_productos (id_producto, cantidad, id_venta) VALUES (@idProducto, @cantidad, @id_venta)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction);
                    insertCmd.Parameters.AddWithValue("@idProducto", idProducto);
                    insertCmd.Parameters.AddWithValue("@cantidad", cantidad);
                    insertCmd.Parameters.AddWithValue("@id_venta", id_venta);
                    insertCmd.ExecuteNonQuery();

                    string updateQuery = "UPDATE productos SET stock = stock - @cantidad WHERE id = @idProducto";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@cantidad", cantidad);
                    updateCmd.Parameters.AddWithValue("@idProducto", idProducto);
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error al registrar salida: {ex.Message}");
                    return false;
                }
            }
        }

        public static int RegistrarVenta(string nit, int total)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string insertQuery = "INSERT INTO ventas (nit, total) OUTPUT INSERTED.id VALUES (@nit, @total)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@nit", nit);
                cmd.Parameters.AddWithValue("@total", total);

                try
                {
                    int idGenerado = (int)cmd.ExecuteScalar();
                    return idGenerado;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }


        public static DataTable ObtenerProductosIngresados(DateTime fechaInicio, DateTime fechaFin)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "SELECT * FROM productos WHERE fecha_ingreso BETWEEN @inicio AND @fin";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@inicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fin", fechaFin);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerProductosVendidos(DateTime fechaInicio, DateTime fechaFin)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "SELECT p.id, p.nombre, sp.cantidad, sp.fecha_salida " +
                               "FROM salida_productos sp " +
                               "INNER JOIN productos p ON sp.id_producto = p.id " +
                               "WHERE sp.fecha_salida BETWEEN @inicio AND @fin";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@inicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fin", fechaFin);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

    }
}
