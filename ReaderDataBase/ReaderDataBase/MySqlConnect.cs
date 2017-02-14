using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ReaderDataBase
{
    public class MySqlConnect
    {
        private MySqlConnection conn;
        private MySqlCommand cmd = new MySqlCommand();
        private string connectionString = "server=localhost;uid=root;pwd=stringFoster9324;database=trackbatch";

        public MySqlConnect()
        {
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                conn.Close();
                //MessageBox.Show("Conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void InsertCatalog(List<Catalog> catalog)
        {
            try
            {
                foreach (var item in catalog)
                {
                    cmd.CommandText =string.Format("INSERT INTO Catalogs(CatalogNo,CatalogDescrip) VALUES ('{0}','{1}')",item.NoCatalog,item.NameCatalog);
                    //cmd.Parameters.AddWithValue("nocatalog", item.NoCatalog);
                    //cmd.Parameters.AddWithValue("namecatalog", item.NameCatalog);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void InsertValues(List<Orden> orden)
        {
            try
            {
                foreach (var o in orden)
                {
                    cmd.CommandText = "INSERT INTO work_ordens(CatalogId,BatchOrden,dateRegistry,quantityOrden) VALUES (@catalogo,@batch,@date,@qty)";
                    cmd.Parameters.AddWithValue("catalogo", o.references);
                    cmd.Parameters.AddWithValue("batch", o.batch);
                    cmd.Parameters.AddWithValue("date", o.date.ToString("yyyy-MM-dd H:mm_ss"));
                    cmd.Parameters.AddWithValue("qty", o.qty);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
