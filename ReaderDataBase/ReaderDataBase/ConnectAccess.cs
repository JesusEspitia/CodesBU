using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace ReaderDataBase
{
    public class ConnectAccess
    {
        //private string strAccessConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\_espitl1\Documents\ReadarDB.accdb";
        private string strAccessConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\mxtswtjnts\Public\UDI\UDI Labeling Database\UDI Labeling Database.accdb";
        private OleDbConnection conn;
        private DataSet myds;
        private OleDbCommand cmd;
        private OleDbDataReader reader;
        OleDbDataAdapter adp;
        private Orden orden;
        private Catalog catalog;
        public ConnectAccess()
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
        public void getCatalog()
        {
            cmd= new OleDbCommand("select Reference,Product_Name from Product_Data", conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                catalog = new Catalog() { NoCatalog = reader[0].ToString(), NameCatalog = reader[1].ToString() };
                Form1.catalog.lstCatalog.Add(catalog);
            }
            reader.Close();
            conn.Close();
        }
        public void ReadDataBase(DataGridView dt)
        {
            adp = new OleDbDataAdapter("select Reference,Batch,Batch_qty,Production_Date from Batch_Data", conn);
            myds = new DataSet();
            conn.Open();
            adp.Fill(myds);

            dt.DataSource = myds.Tables[0];

            conn.Close();
        }
        public void ReadDataBase()
        {
            try
            {
                cmd = new OleDbCommand("select Reference,Batch,Batch_qty,Production_Date from Batch_Data", conn);
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    orden = new Orden() { references = reader[0].ToString(), batch = reader[1].ToString(), qty = (int)reader[2], date = (DateTime)reader[3] };
                    Form1.orden.lstOrden.Add(orden);
                }
                reader.Close();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
