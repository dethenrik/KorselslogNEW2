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
    public partial class Form1 : Form
    {
        //FIELD//
        Bitmap bitmap;

        SqlConnection sqlCon = new SqlConnection(@"Data Source=192.168.23.104;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        DataTable sqlDt = new DataTable();

        string sqlQuery;

        SqlDataAdapter Dta = new SqlDataAdapter();

        SqlDataReader sqlRd;

        DataSet ds = new DataSet();




        /// ////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            GetDataFromData();
        }

        public void GetDataFromData() //OLD UPDATEDATA() // læsning af database som bliver skrevet til datagridview og fremvist til bruger ved indkaldelse af classe.
        {
            UpdateDGV DGV = new UpdateDGV();
            DGV.UpdateDataGV(this);
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNewUser add = new AddNewUser();

            UpdateDto updateData = new UpdateDto
            {
                TaskID = txtTaskID.Text,
                DriverID = txtdriverID.Text,
                NumberPlate = txtNumberPlate.Text,
                RouteID = txtrouteID.Text,
                TimeStart = txtTimeStart.Text,
                TimeEnd = txtTimeEnd.Text,
            };
            add.AddNew(updateData);

            GetDataFromData();
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData update = new UpdateData();

            UpdateDto updateData = new UpdateDto
            {
                TaskID = txtTaskID.Text,
                DriverID = txtdriverID.Text,
                NumberPlate = txtNumberPlate.Text,
                RouteID = txtrouteID.Text,
                TimeStart = txtTimeStart.Text,
                TimeEnd = txtTimeEnd.Text,
            };
            update.UpdateDataMethod(updateData);
            
            GetDataFromData();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(@"Data Source=192.168.23.104;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    try
                    {
                        conn.Open();
                        sqlCmd.Connection = conn;


                        sqlCmd.CommandText = "DELETE FROM logbook WHERE TaskID = @TaskID";
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.Parameters.AddWithValue("@taskID", txtTaskID.Text);

                        sqlCmd.Parameters.AddWithValue("@driverID", txtdriverID.Text);
                        sqlCmd.Parameters.AddWithValue("@truckID", txtNumberPlate.Text);
                        sqlCmd.Parameters.AddWithValue("@routeID", txtrouteID.Text);
                        sqlCmd.Parameters.AddWithValue("@TimeStart", txtTimeStart.Text);
                        sqlCmd.Parameters.AddWithValue("@TimeEnd", txtTimeEnd.Text);



                        sqlCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        GetDataFromData();
                    }
                }
            }
        }

        #region peter

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in panel6.Controls)
                {
                    if (c is TextBox)
                        ((TextBox)c).Clear();
                }
                txtSearch.Text = "";
                txtdriverID.Text = "";
                txtrouteID.Text = "";
                txtTaskID.Text = "";
                txtTimeStart.Text = "";
                txtNumberPlate.Text = "";
                txtTimeEnd.Text = "";
                txtTimeStart.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                GetDataFromData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            try
            {
                iExit = MessageBox.Show("Confirm if you want to exit", "KørselsLog",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (iExit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////EVERYTHING ELSE BUT BUTTONS///////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=192.168.23.104;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                UpdateDto updateData = new UpdateDto
                {
                    TaskID = txtTaskID.Text,
                    DriverID = txtdriverID.Text,
                    NumberPlate = txtNumberPlate.Text,
                    RouteID = txtrouteID.Text,
                    TimeStart = txtTimeStart.Text,
                    TimeEnd = txtTimeEnd.Text,
                    datagridview = dataGridView1,
                };

            }
        }
        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=192.168.23.104;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                try
                {
                    txtTaskID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    txtdriverID.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    txtNumberPlate.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    txtrouteID.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    txtTimeStart.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))// har oprettet en connection string inde på app.config som gør at hvis jeg henter "using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))" så opretter jeg min forbindelse ind til serveren
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using (DataTable dt = new DataTable("Logbook"))
                    {
                        using (SqlCommand cmd = new SqlCommand("select *from LogBook where DriverID=@DriverID", cn))
                        {

                            cmd.Parameters.AddWithValue("DriverID", txtSearch.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
