using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sample_Procedure_Output
{
    class DatabaseConnector
    {
        public SqlConnection connection = new SqlConnection();


        public void initiateConnection()
        {
            if (connection.ConnectionString=="")

            {
                //connection = new SqlConnection();
                connection.ConnectionString = "Data Source=DESKTOP-9KCHNBI;Initial Catalog=travki;Integrated Security=True;Pooling=False";
            }
        }

        public SqlConnection GetConnection()
        { 
            if (!IsConnectionOpen())
            {
                OpenConnection();
            }
            return connection;
        }

        public void OpenConnection()
        {
            initiateConnection();
            connection.Open();
        }

        public void CloseConnection()
        {
            if (IsConnectionOpen())
                connection.Open();
        }
    
        public bool IsConnectionOpen()
        {
            bool flag=false;
            if (connection != null)
            {
                flag = connection.State == System.Data.ConnectionState.Open;
            }
            return flag;
        }
    
    } 
}
