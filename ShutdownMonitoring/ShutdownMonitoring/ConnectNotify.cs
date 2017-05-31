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
    public class ConnectNotify
    {
        private OleDbConnection con;
        private OleDbCommand cmd;
        private OleDbDataReader reader;
        private OleDbDataAdapter adapter;
        private DataTable table;

        private string strConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\mxtswtjnts\Groups\GRP Tijuana Public\Plastics\CAPA Tool\ACRS v Beta.mdb;";

        public ConnectNotify()
        {
            try
            {
                con = new OleDbConnection(strConnection);
                con.Open();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error al conectar. Mensaje:" + ex.Message, "Erro en la conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void executeQuery(string query)
        {
            try
            {
                cmd = new OleDbCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error al ejecutar la consulta. Mensaje:" + ex.Message, "Error en la ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string getValues(string query)
        {
            try
            {
                cmd = new OleDbCommand(query, con);
                con.Open();
                reader = cmd.ExecuteReader();
                string value = "";
                string bodytext = "";
                while (reader.Read())
                {
                    bodytext = bodytext + string.Format("<tr>" +
                                    "<td>{0}</td>" +
                                    "<td>{1}</td>" +
                                    "<td>{2}</td>" +
                                "</tr>", reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                }
                reader.Close();
                con.Close();
                return bodytext;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error al ejecutar la consulta. Mensaje:" + ex.Message, "Error en la ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public string getValue(string query)
        {
            try
            {
                cmd = new OleDbCommand(query, con);
                con.Open();
                reader = cmd.ExecuteReader();
                string value = "";
                while (reader.Read())
                {
                    value = reader[0].ToString();
                }
                reader.Close();
                con.Close();
                return value;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error al ejecutar la consulta. Mensaje:" + ex.Message, "Error en la ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public int getValueInt(string query)
        {
            try
            {
                cmd = new OleDbCommand(query, con);
                con.Open();
                reader = cmd.ExecuteReader();
                int value = 0;
                while (reader.Read())
                {
                    value = (int)reader[0];
                }
                reader.Close();
                con.Close();
                return value;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error al ejecutar la consulta. Mensaje:" + ex.Message, "Error en la ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public double getValueDbl(string query)
        {
            try
            {
                cmd = new OleDbCommand(query, con);
                con.Open();
                reader = cmd.ExecuteReader();
                double value = 0;
                while (reader.Read())
                {
                    value = (double)reader[0];
                }
                reader.Close();
                con.Close();
                return value;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error al ejecutar la consulta. Mensaje:" + ex.Message, "Error en la ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public bool getValueBool(string query)
        {
            try
            {
                cmd = new OleDbCommand(query, con);
                con.Open();
                reader = cmd.ExecuteReader();
                bool value = false;
                while (reader.Read())
                {
                    value = true;
                }
                reader.Close();
                con.Close();
                return value;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error al ejecutar la consulta. Mensaje:" + ex.Message, "Error en la ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void fillList(string query, List<string> lst)
        {
            try
            {
                cmd = new OleDbCommand(query, con);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lst.Add(reader[0].ToString());
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error al ejecutar la consulta. Mensaje:" + ex.Message, "Error en la ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string fillString(string query)
        {
            try
            {
                cmd = new OleDbCommand(query, con);
                con.Open();
                reader = cmd.ExecuteReader();
                string value = "";
                while (reader.Read())
                {
                    value += reader[0].ToString();
                }
                reader.Close();
                con.Close();
                return value;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Error al ejecutar la consulta. Mensaje:" + ex.Message, "Error en la ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

    }
}
