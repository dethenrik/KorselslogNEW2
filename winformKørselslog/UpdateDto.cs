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
    public class UpdateDto
    {
        public string TaskID { get; set; }
        public string DriverID { get; set; }
        public string NumberPlate { get; set; }
        public string RouteID { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public DataGridView datagridview { get; set; }
    

    }
}
