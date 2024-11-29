using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DentalTech.Database
{
    internal class Conexao
    {

        private static string host = "localhost";
        private static string port = "3306";
        private static string user = "root";
        private static string password = "root";
        private static string dbname = "bd_DentalTech";
        private static MySqlConnection connection;
        private static MySqlCommand command;

        public Conexao()
        {
            try
            {
                connection = new MySqlConnection($"server={host}; database={dbname}; port={port}; user={user}; password={password}");
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public MySqlCommand Query(string comando)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = comando;

                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            connection.Close();
        }

    }

    /* testando */
}
