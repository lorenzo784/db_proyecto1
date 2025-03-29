using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Servicios
{
    class DistribucionService
    {
        public static DataTable ObtenerProveedores()
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = @"
                    SELECT p.id, p.nombre AS NombreProveedor, COUNT(pp.id_producto) AS CantidadProductos
                    FROM proveedores p
                    LEFT JOIN producto_proveedor pp ON p.id = pp.id_proveedor
                    GROUP BY p.id, p.nombre";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerProductosDis(int idProveedor)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = @"
                    SELECT 
                        pr.nombre AS NombreProducto,
                        pp.cantidad AS CantidadProducto
                    FROM proveedores p
                    INNER JOIN producto_proveedor pp ON p.id = pp.id_proveedor
                    INNER JOIN productos pr ON pp.id_producto = pr.id
                    WHERE p.id = @idProveedor
                    ORDER BY pr.nombre";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void InsertarProductoProveedor(int idProducto, int idProveedor, int cantidad)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = @"
                    INSERT INTO producto_proveedor (id_producto, id_proveedor, cantidad) 
                    VALUES (@idProducto, @idProveedor, @cantidad)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);

                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
