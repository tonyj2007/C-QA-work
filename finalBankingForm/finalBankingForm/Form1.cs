using System;
using System.Windows.Forms;

namespace finalBankingForm
{
    public partial class Form1 : Form
    {
        char accountType,gender;
        string temp;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            connectToDb();
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            cmd.CommandText = "SELECT CONCAT('" + accountType + "', '" + gender + "', FORMAT(COALESCE(MAX(SUBSTRING(accountID, 3, 3) + 1), '001'), '000'))AS numbers FROM Accounts WHERE accountID like '" + accountType + "%'";
            r = cmd.ExecuteReader();

            if (r.Read())
            {
                temp = r["numbers"].ToString();
            }
            r.Close();
            cmd.CommandText = "INSERT INTO Accounts values('" + temp + "','" + textBox1.Text + "','" + textBox2.Text + "')";
            cmd.ExecuteNonQuery();
        }
    }
}