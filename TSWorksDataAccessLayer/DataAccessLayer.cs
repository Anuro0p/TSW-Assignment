using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace TSWorksDataAccessLayer
{
    public class DataAccessLayer
    {
        string connectionString;
        MySqlConnection TSWConn;
        MySqlCommand TSWComm;
        MySqlDataAdapter TSWAdapter;

        public DataAccessLayer()
        {
            connectionString = "server=localhost;user id=root;database=tsw;pwd=root;";
            TSWConn = new MySqlConnection(connectionString);
            TSWComm = new MySqlCommand();
            TSWComm.Connection = TSWConn;
            TSWAdapter = new MySqlDataAdapter(TSWComm);
        }

        public void PostAppleData(string date, string open, string high, string low, string close, string adjclose, string volume)
        {
            TSWComm.CommandText = "INSERT INTO apple values(@date,@open,@high,@low,@close,@adjclose,@volume);";
            TSWComm.CommandType = CommandType.Text;
            TSWComm.Parameters.Clear();
            TSWComm.Parameters.AddWithValue("@date", date);
            TSWComm.Parameters.AddWithValue("@open", open);
            TSWComm.Parameters.AddWithValue("@high", high);
            TSWComm.Parameters.AddWithValue("@low", low);
            TSWComm.Parameters.AddWithValue("@close", close);
            TSWComm.Parameters.AddWithValue("@adjclose", adjclose);
            TSWComm.Parameters.AddWithValue("@volume", volume);
            Console.WriteLine(open);

            try
            {
                TSWConn.Open();
                TSWComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                TSWConn.Close();
            }
        }

        public DataTable GetAppleData(string date)
        {
            DataTable dataTable = new DataTable();
            TSWComm.CommandText = "SELECT * from apple where date = @date;";
            TSWComm.CommandType = CommandType.Text;
            TSWComm.Parameters.Clear();
            TSWComm.Parameters.AddWithValue("@date", date);
            try
            {
                TSWConn.Open();
                TSWAdapter.Fill(dataTable);
                Console.Write(dataTable);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
               dataTable = null;
            }
            finally
            {
 
                TSWConn.Close();
            }
            return dataTable;
        }


        public DataTable GetAllAppleData()
        {
            DataTable dataTable = new DataTable();
            TSWComm.CommandText = "SELECT * from apple;";
            TSWComm.CommandType = CommandType.Text;
            try
            {
                TSWConn.Open();
                TSWAdapter.Fill(dataTable);
                Console.Write(dataTable);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                dataTable = null;
            }
            finally
            {

                TSWConn.Close();
            }
            return dataTable;
        }
    }
}
