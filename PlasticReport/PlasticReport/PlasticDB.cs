using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PlasticReport
{
    public class PlasticDB
    {
        private MySqlConnection mycon;
        private MySqlCommand cmd = new MySqlCommand();
        public PlasticDB()
        {
            try
            {
                mycon = new MySqlConnection("SERVER=localhost;DATABASE=plasticreport;UID=root;PASSWORD=stringFoster9324;");
                mycon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al momento de conectar a la base de dato" + ex.Message, "Error al conectar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
