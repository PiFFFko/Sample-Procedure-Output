using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sample_Procedure_Output
{
    class DAO
    {
        private DatabaseConnector dbconnector = new DatabaseConnector();
        private string SQL_SP_REDUCECOST = "УменьшитьЦенуВсехТравНа20";
        private string SQL_SP_ADD_WORKER = "ДобавитьНовогоСборщика ";
        private string SQL_SP_COLLECTED_VOL = "СданныйОбъем";
        private string SQL_SP_DELETE_INFO_ABT_COLLECT = "УдалитьИнфуОСдачу";
        private string SQL_SP_DELETE_WORKER = "УдалитьСборщика";

        private SqlConnection getConnection()
        {
            return dbconnector.GetConnection();
        }
        public void ReduceHerbsCost()
        {
            SqlConnection connection = getConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = SQL_SP_REDUCECOST;
            command.ExecuteNonQuery();
        }

        public void addWorker(int number, string surname,string adress,string phoneNumber)
        {
            SqlConnection connection = getConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = SQL_SP_ADD_WORKER;
            command.Parameters.AddWithValue("@Номер", number);
            command.Parameters.AddWithValue("@Фамилия", surname);
            command.Parameters.AddWithValue("@Адрес", adress);
            command.Parameters.AddWithValue("@Телефон", phoneNumber);
            command.ExecuteNonQuery();
        }

        public int VolumeCollected(int number)
        {
            SqlConnection connection = getConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = SQL_SP_COLLECTED_VOL;
            command.Parameters.AddWithValue("@Номер", number);
            command.Parameters.Add("@Объем", System.Data.SqlDbType.Int);
            command.Parameters["@Объем"].Direction = System.Data.ParameterDirection.ReturnValue;
            return int.Parse(command.Parameters["@Объем"].Value.ToString());
        }
    
    
        public int deleteInfoAboutCollect(string surname, string herbName)
        {
            SqlConnection connection = getConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = SQL_SP_DELETE_INFO_ABT_COLLECT;
            command.Parameters.AddWithValue("@Фамилия", surname);
            command.Parameters.AddWithValue("@НазваниеТравы", herbName);
            return command.ExecuteNonQuery();
        }
    
        public int deleteWorker(int number)
        {
            SqlConnection connection = getConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = SQL_SP_DELETE_WORKER;
            command.Parameters.AddWithValue("@Номер", number);
            command.Parameters.Add("@Код", System.Data.SqlDbType.Int);
            command.Parameters["@Код"].Direction = System.Data.ParameterDirection.ReturnValue;
            command.ExecuteNonQuery();
            return int.Parse(command.Parameters["@Код"].Value.ToString());
        }
    
    }
}
