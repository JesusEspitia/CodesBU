using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ShutdownMonitoring
{
    public class ConnectWarehouse
    {
        public static string strAccessConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\mxtswtjnts\Groups\GRp Tijuana Departments\Plastics\2015 Plastics DB\Almacen\InventoryControl.accdb";
        private OleDbConnection conn;
        private DataSet myds;
        private OleDbCommand cmd;
        private OleDbDataReader reader;
        OleDbDataAdapter adp;
        public ConnectWarehouse()
        {
            try
            {
                conn = new OleDbConnection(strAccessConn);
                conn.Open();
                //MessageBox.Show("Conectado");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void fillList(List<string> lst,string query)
        {
            try
            {
                cmd = new OleDbCommand(query, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lst.Add(reader[0].ToString());
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw;
            }
        }

        public string getValue(string query)
        {
            try
            {
                cmd = new OleDbCommand(query, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                string value = "";
                while (reader.Read())
                {
                    value = reader[0].ToString();
                }
                reader.Close();
                conn.Close();
                return value;
            }
            catch (Exception ex)
            {
                conn.Close();
                return "";
            }
        }

        public bool getValueBool(string query)
        {
            try
            {
                cmd = new OleDbCommand(query, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                bool value = false;
                while (reader.Read())
                {
                    value = true;
                }
                reader.Close();
                conn.Close();
                return value;
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }
    }
}
