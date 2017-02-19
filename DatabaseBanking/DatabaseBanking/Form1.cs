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
namespace DatabaseBanking
{
    public partial class Form1 : Form
    {
        SqlDataReader r;
        SqlCommand cmd;
        SqlConnection con;
        string temp;
        char gender, accountType;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT CONCAT('" + accountType + "', '" + gender + "', FORMAT(COALESCE(MAX(SUBSTRING(accountID, 3, 3) + 1), '001'), '000'))AS numbers FROM accountsTable WHERE accountID like '" + accountType + "%'";
            r = cmd.ExecuteReader();
            if (r.Read())
            {
                temp = r["numbers"].ToString();
            }
            cmd.CommandText = "INSERT INTO accountsTable values('" + temp + "','" + textBox1.Text + "','" + textBox2.Text + "," + 0.00 + "')";
            r.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = 'M';
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = 'F';
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            accountType = 'C';
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            accountType = 'S';
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  con = new SqlConnection(Properties.Settings.Default.DatabaseAccountingConnectionString);
            con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\xxton\\Documents\\VSProjects\\DatabaseBanking\\DatabaseBanking\\DatabaseAccounting.mdf; Integrated Security = True");
            cmd = new SqlCommand();
            cmd.Connection = con;
            try {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not establish connection to database");
            }
        }
    }
}
