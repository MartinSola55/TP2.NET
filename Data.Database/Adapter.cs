using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        //Clave por defecto a utilizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";

        public SqlConnection sqlConn
        {
           get;
           set;
        }

        protected void OpenConnection()
        {
            string connectionString =null;
            //connectionString  = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=tp2_net;Integrated Security=True";
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
