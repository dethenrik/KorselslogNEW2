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
    public class AddNewUser
    {
        string sqlQuery;
        SqlDataReader sqlRd;

        public void AddNew(UpdateDto data)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=192.168.23.104;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                try
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, conn))
                    {
                        sqlCmd.CommandType = CommandType.Text;

                        sqlCmd.CommandText = "insert into LogBook (DriverID, NumberPlate, RouteID, [TimeStart], [TimeEnd]) " + "values('" + data.DriverID + "', '" + data.NumberPlate + "', '" + data.RouteID + "', '" + data.TimeStart + "', '" + data.TimeEnd + "')";
                        sqlCmd.Parameters.AddWithValue("@driverID", data.DriverID);
                        sqlCmd.Parameters.AddWithValue("@NumberPlate", data.NumberPlate);
                        sqlCmd.Parameters.AddWithValue("@routeID", data.RouteID);
                        sqlCmd.Parameters.AddWithValue("@TimeStart", data.TimeStart);
                        sqlCmd.Parameters.AddWithValue("@TimeEnd", data.TimeEnd);



                        sqlRd = sqlCmd.ExecuteReader();
                    }
                    sqlRd.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
        }
    }
}











// REMEBER TOO ADD THIS CODE IN YOUR MAIN PAGE(GUI) THAT WAY YOU CAN USE THE {GET SET} FROM ANOTHER CLASS CREATED HERE YOU GIVE "TaskID" THE VALUE OF WHAT "txtTaskID.Text" contains
//private void btnAddNew_Click(object sender, EventArgs e)
//{
//    AddNewUser add = new AddNewUser();

//    UpdateDto updateData = new UpdateDto
//    {
//        TaskID = txtTaskID.Text,
//        DriverID = txtdriverID.Text,
//        NumberPlate = txtNumberPlate.Text,
//        RouteID = txtrouteID.Text,
//        TimeStart = txtTimeStart.Text,
//        TimeEnd = txtTimeEnd.Text,
//    };
//    add.AddNew(updateData);

//    GetDataFromData();
//}








//public class UpdateDto
//{
//    public string TaskID { get; set; }
//    public string DriverID { get; set; }
//    public string NumberPlate { get; set; }
//    public string RouteID { get; set; }
//    public string TimeStart { get; set; }
//    public string TimeEnd { get; set; }
//}
