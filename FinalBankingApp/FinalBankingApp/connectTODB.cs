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

        /**
        partial class used for setting up a database connection and creation of connection object, sql command object, sql data reader object and sql transaction reader

            */
        public void connectToDb()
        {
            /**
            tries to connect to a database using dataset connection string stored in Properties.Settings.Default.AccountsDBConnectionString
            */
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