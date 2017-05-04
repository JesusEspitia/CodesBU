using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ShutdownMonitoring
{
    public class MysqlDatabase
    {
        private MySqlConnection conn;
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader reader;
        private string connectionString = "server=localhost;uid=root;pwd=stringFoster9324;database=trackbatch";

        public MysqlDatabase()
        {
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public void fillList(List<string> lst,string query)
        {
            try
            {
                cmd.CommandText = query;
                cmd.Connection = conn;
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lst.Add(reader[0].ToString());
                }
                reader.Close();
                conn.Close();
            }
            catch 
            {
                throw;
            }
        }

        public string getValue(string query)
        {
            try
            {
                string value = "";
                cmd.CommandText = query;
                cmd.Connection = conn;
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    value = reader[0].ToString();
                }
                reader.Close();
                conn.Close();
                return value;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public void executeQuery(string query)
        {
            try
            {
                cmd.CommandText = query;
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {

                throw;
            }
        }

    }
}
