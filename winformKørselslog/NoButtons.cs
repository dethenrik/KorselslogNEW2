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
    internal class NoButtons
    {
        public void dataGridViewCall(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=192.168.23.104;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                UpdateDto data = new UpdateDto();

                data.TaskID = data.datagridview.SelectedRows[0].Cells[0].Value.ToString();
                data.DriverID = data.datagridview.SelectedRows[0].Cells[1].Value.ToString();
                data.NumberPlate = data.datagridview.SelectedRows[0].Cells[2].Value.ToString();
                data.RouteID = data.datagridview.SelectedRows[0].Cells[3].Value.ToString();
                data.TimeStart = data.datagridview.SelectedRows[0].Cells[4].Value.ToString();

            }
        }
    }
}
