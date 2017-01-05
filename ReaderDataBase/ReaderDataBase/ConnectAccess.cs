using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.OleDb;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace ReaderDataBase
{
    public class ConnectAccess
    {
        private string strAccessConn = @"Provider=Microsoft.ACE.OLEDB.12.0;;Data Source=C:\Users\_espitl1\Documents\ReadarDB.accdb";
        private OleDbConnection conn;
        private DataSet myds;
        private OleDbCommand cmd;
        private OleDbDataReader reader;
        OleDbDataAdapter adp;
        private Orden orden;
        public ConnectAccess()
        {
            try
            {
                conn = new OleDbConnection(strAccessConn);
                conn.Open();
                MessageBox.Show("Conectado");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ReadDataBase(DataGridView dt)
        {
            adp = new OleDbDataAdapter("select * from Orden", conn);
            myds = new DataSet();
            conn.Open();
            adp.Fill(myds);

            dt.DataSource = myds.Tables[0];

            conn.Close();
        }
        public void ReadDataBase()
        {
            cmd = new OleDbCommand("select * from Orden", conn);
            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                orden = new Orden() { id = (int)reader[0], id_catalogo=(int)reader[1],cantidad=(int)reader[2]};
                Form1.orden.lstOrden.Add(orden);
            }
            reader.Close();
            conn.Close();
        }
    }
}
