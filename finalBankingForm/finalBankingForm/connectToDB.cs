using System.Data.SqlClient;

namespace finalBankingForm
{
    public partial class Form1
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader r;

        public void connectToDb()
        {
            con = new SqlConnection(Properties.Settings.Default.AccountsConnectionString);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
    }
}