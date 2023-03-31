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
    public class UpdateData
    {
        public void UpdateDataMethod(UpdateDto data)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=192.168.23.104;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = con;

                        command.CommandText = "Update LogBook set driverID = @driverID, NumberPlate = @NumberPlate, routeID = @RouteID, TimeStart = @Timestart, TimeEnd = @TimeEnd Where taskID = @TaskID";
                        command.CommandType = CommandType.Text;

                        command.Parameters.AddWithValue("@TaskID", data.TaskID);
                        command.Parameters.AddWithValue("@driverID", data.DriverID);
                        command.Parameters.AddWithValue("@NumberPlate", data.NumberPlate);
                        command.Parameters.AddWithValue("@routeID", data.RouteID);
                        command.Parameters.AddWithValue("@TimeStart", data.TimeStart);
                        command.Parameters.AddWithValue("@TimeEnd", data.TimeEnd);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}
