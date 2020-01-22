using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.DB
{
    class DBConnect
    {

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

       public  DBConnect() {

            server = "localhost";
            database = "student";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }



        //Initialize values
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                
                return false;
            }
        }
        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
              
                return false;
            }
        }
    }
}
