using InventoryIDL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InventoryDL
{
    public class DAL : IDAL
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public DataTable GetInventoryList()
        {
            DataTable dt;
            IDbConnection dmsDbConn = new SqlConnection(_connectionString);        
            dmsDbConn.Open();
            string Cmd = "dbo.GetInventoryList";
            IDbCommand command = dmsDbConn.CreateCommand();
            dt = RunQuery(Cmd, command, dmsDbConn);
            dt.TableName = "InventList";

            return dt;
        }


        public DataTable GetInventoryById(int Id)
        {
            DataTable dt;
            IDbConnection dmsDbConn = new SqlConnection(_connectionString);
            dmsDbConn.Open();

            string strCmd = "dbo.GetInventoryById";
            IDbCommand command = dmsDbConn.CreateCommand();
            IDataParameter parameter1 = command.CreateParameter();

            parameter1.ParameterName = "@Id";
            parameter1.Value = Id;
            command.Parameters.Add(parameter1);

            dt = RunQuery(strCmd, command, dmsDbConn);
            dt.TableName = "Inventory";

            return dt;
        }

        public int SaveInventory(string Name, string Description, int Price, string Picture)
            {
            IDbConnection dmsDbConn = new SqlConnection(_connectionString);
            dmsDbConn.Open();

            string strCmd = "dbo.SaveInventory";
            IDbCommand command = dmsDbConn.CreateCommand();
            IDataParameter parameter1 = command.CreateParameter();
                               
            parameter1.ParameterName = "@Name";
            parameter1.Value = Name;
            command.Parameters.Add(parameter1);
          
            parameter1 = command.CreateParameter();
            parameter1.ParameterName = "@Description";
            parameter1.Value = Description;
            command.Parameters.Add(parameter1);
          
            parameter1 = command.CreateParameter();
            parameter1.ParameterName = "@Price";
            parameter1.Value = Price;
            command.Parameters.Add(parameter1);

            parameter1 = command.CreateParameter();
            parameter1.ParameterName = "@Picture";
            parameter1.Value = Picture;
            command.Parameters.Add(parameter1);

            command.CommandText = strCmd;
            command.CommandType = CommandType.StoredProcedure;                                   
            return Convert.ToInt16(command.ExecuteNonQuery());           
        }

        private DataTable RunQuery(string cmd, IDbCommand command, IDbConnection dmsDbConn)
        {
            DataTable dt = new DataTable();
            try
            {
                command.CommandText = cmd;
                command.CommandType = CommandType.StoredProcedure;
                IDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            finally
            {
                dmsDbConn.Close();
            }

            return dt;
        }

        public int DeleteInventoryById(int Id)
        {
            IDbConnection dmsDbConn = new SqlConnection(_connectionString);
            dmsDbConn.Open();

            string strCmd = "dbo.DeleteInventoryById";
            IDbCommand command = dmsDbConn.CreateCommand();
            IDataParameter parameter1 = command.CreateParameter();

            parameter1.ParameterName = "@Id";
            parameter1.Value = Id;
            command.Parameters.Add(parameter1);           

            command.CommandText = strCmd;
            command.CommandType = CommandType.StoredProcedure;
            return Convert.ToInt16(command.ExecuteNonQuery());
        }
    }
}
