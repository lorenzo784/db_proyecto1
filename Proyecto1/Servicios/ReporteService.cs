using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Servicios
{
    class ReporteService
    {
        public static DataTable ObtenerProductosStockBajo(int stockLimite)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "SELECT nombre, stock FROM productos WHERE stock < @StockLimite";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@StockLimite", stockLimite);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static DataTable ObtenerProductosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = "SELECT nombre, fecha_ingreso FROM productos WHERE fecha_ingreso BETWEEN @FechaInicio AND @FechaFin";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                da.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaFin);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerProveedoresYProductos()
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = @"
                    SELECT p.nombre AS Proveedor, pr.nombre AS Producto, pp.cantidad
                    FROM proveedores p
                    INNER JOIN producto_proveedor pp ON p.id = pp.id_proveedor
                    INNER JOIN productos pr ON pp.id_producto = pr.id";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerProveedoresYProductosLeftJoin()
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = @"
                    SELECT p.nombre AS Proveedor, pr.nombre AS Producto, pp.cantidad
                    FROM proveedores p
                    LEFT JOIN producto_proveedor pp ON p.id = pp.id_proveedor
                    LEFT JOIN productos pr ON pp.id_producto = pr.id";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerProveedoresYProductosRightJoin()
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = @"
                    SELECT p.nombre AS Proveedor, pr.nombre AS Producto, pp.cantidad
                    FROM proveedores p
                    RIGHT JOIN producto_proveedor pp ON p.id = pp.id_proveedor
                    RIGHT JOIN productos pr ON pp.id_producto = pr.id";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static DataTable ObtenerCantidadProductosPorProveedor()
        {
            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = @"
                    SELECT p.nombre AS Proveedor, SUM(pp.cantidad) AS TotalProductos
                    FROM proveedores p
                    INNER JOIN producto_proveedor pp ON p.id = pp.id_proveedor
                    GROUP BY p.nombre";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


    }
}
