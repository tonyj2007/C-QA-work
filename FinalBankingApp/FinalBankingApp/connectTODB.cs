using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalBankingApp
{
    public partial class Form1
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader r;
        private SqlTransaction trans;

        public void connectToDb()
        {
            con = new SqlConnection(Properties.Settings.Default.AccountsDBConnectionString);
            cmd = new SqlCommand();
            //cmd.Transaction = trans;
            cmd.Connection = con;

            try
            {
                con.Open();
            } catch (Exception)
            {
                MessageBox.Show("Could not establish Database Connection");
            }
        }
    }
}