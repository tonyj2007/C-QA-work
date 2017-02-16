using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accountsBankTask
{
    public partial class Form1 : Form
    {
        char accountType;
        char gender;
        bool reader = false;
        string temp;
        public Form1()
        {
            InitializeComponent();
        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectToDb();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //(getting record by account type) cmd.CommandText = "SELECT accountID, SUBSTRING(accountID,3,5) AS numbers FROM Accounts WHERE accountID like '" + accountType + "%'";
            cmd.CommandText = "SELECT CONCAT('"+accountType+"', '"+gender+"', FORMAT(COALESCE(MAX(SUBSTRING(accountID, 3, 3) + 1), '001'), '000'))AS numbers FROM Accounts WHERE accountID like '"+accountType+"%'";
            r = cmd.ExecuteReader();
            
            if (r.Read())
            {
                 temp = r["numbers"].ToString();                
            }
            r.Close();
            cmd.CommandText = "INSERT INTO Accounts values('" + temp + "','" + textBox1.Text + "','" + textBox2.Text + "')";
            cmd.ExecuteNonQuery();
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
        public void dataReader()
        {
            
            if (reader == false)
            {
                
                reader = true;
            }
        }

        private void accountViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT * FROM Accounts";
            r = cmd.ExecuteReader();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (r.Read())
            {
                textBox1.Text = r["accountID"].ToString();
                textBox2.Text = r["name"].ToString();
            }
            else
            {
                MessageBox.Show("No more records");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //con.Close();
        }
    }
}