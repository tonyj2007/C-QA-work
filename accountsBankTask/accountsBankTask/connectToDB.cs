using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace accountsBankTask
{
    public partial class Form1
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader r;
        
        
        public void connectToDb()
        {
            con = new SqlConnection(Properties.Settings.Default.accountsConnectionString);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
    }
}
