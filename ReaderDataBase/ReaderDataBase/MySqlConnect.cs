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
        private string connectionString = "server=localhost;uid=root;pwd=Baxter09.;database=trackbatch";

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
        public void InsertValues(List<Orden> orden)
        {
            try
            {
                foreach (var o in orden)
                {
                    cmd.CommandText = "INSERT INTO work_orden(id_catalog,batch_orden,date_registry,quentity_orden) VALUES (@catalogo,@batch,@date,@qty)";
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
