using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Proyecto1.Servicios
{
    class ConexionMySQL
    {
        private MySqlConnection conexion;

        public ConexionMySQL()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConexion"]?.ConnectionString;
            if (connectionString == null)
            {
                throw new InvalidOperationException("Cadena de conexión no encontrada.");
            }
            conexion = new MySqlConnection(connectionString);
        }

        public MySqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }

}
