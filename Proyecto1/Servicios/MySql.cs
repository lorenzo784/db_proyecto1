using System;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Proyecto1.Servicios
{
    class ClientesService
    {
        public static Dictionary<string, string> BuscarClientePorNit(string nit)
        {
            using (MySqlConnection conn = new ConexionMySQL().AbrirConexion())
            {
                string query = "SELECT datos_cliente FROM Clientes WHERE JSON_UNQUOTE(JSON_EXTRACT(datos_cliente, '$.nit')) LIKE @nit";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nit", "%" + nit + "%");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string jsonData = reader.GetString(0);
                        var clienteDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
                        return clienteDict;
                    }
                }
            }
            return null;
        }
    }
}
