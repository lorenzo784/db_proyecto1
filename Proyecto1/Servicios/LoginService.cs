using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Servicios
{
    class LoginService
    {

        public static string EncriptarSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder resultado = new StringBuilder();
                foreach (byte b in hash)
                {
                    resultado.Append(b.ToString("x2"));
                }
                return resultado.ToString();
            }
        }


        public static bool InsertarUsuario(string nombre, string correo, string contra)
        {
            string contraEncriptada = EncriptarSHA256(contra);

            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string checkQuery = "SELECT COUNT(*) FROM usuarios WHERE nombre = @nombre OR correo = @correo";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@nombre", nombre);
                    checkCmd.Parameters.AddWithValue("@correo", correo);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        return false;
                    }
                }

                string insertQuery = @"
                    INSERT INTO usuarios (nombre, correo, contra)
                    VALUES (@nombre, @correo, @contra)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@contra", contraEncriptada);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public static bool IniciarSesion(string nombreOCorreo, string contra)
        {
            string contraEncriptada = EncriptarSHA256(contra);

            using (SqlConnection conn = new Conexion().AbrirConexion())
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM usuarios 
                    WHERE (nombre = @input OR correo = @input) 
                      AND contra = @contra";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@input", nombreOCorreo);
                    cmd.Parameters.AddWithValue("@contra", contraEncriptada);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }
}
