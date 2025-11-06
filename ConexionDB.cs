using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xabiOFICIAL
{
    public static class ConexionDB
    {
        private static string connectionString = "Server=localhost;Port=3308;Database=volkswagenapp;Uid=root;Pwd=root;";

        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(connectionString);
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar a la base de datos: " + ex.Message);
            }
            return conexion;
        }
    }
}