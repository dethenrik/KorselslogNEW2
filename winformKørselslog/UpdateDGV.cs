using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace winformKørselslog
{
    public class UpdateDGV
    {
        public void UpdateDataGV(Form1 form) //OLD UPDATEDATA() // læsning af database som bliver skrevet til datagridview og fremvist til bruger ved indkaldelse af classe.
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=192.168.23.104;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Logbook", conn))
                {
                    conn.Open();
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();

                    adpt.Fill(table);

                    form.dataGridView1.DataSource = table;
                    conn.Close();
                }
            }
        }
    }
}
