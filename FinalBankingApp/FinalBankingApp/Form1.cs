using System;
using System.Windows.Forms;

namespace FinalBankingApp
{
    public partial class Form1 : Form
    {
        private char gender, accountType, transferType;
        private string temp;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = 'F';
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            accountType = 'S';
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = 'M';
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            accountType = 'C';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectToDb();
            
        }

        private void viewAllAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeForm("view");
            clearText();
            cmd.CommandText = "SELECT * FROM accountTable";
            try { r.Close(); } catch (Exception) { }
            r = cmd.ExecuteReader();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT CONCAT('" + accountType + "', '" + gender + "', FORMAT(COALESCE(MAX(SUBSTRING(accountID, 3, 3) + 1), '001'), '000'))AS numbers FROM accountTable WHERE accountID like '" + accountType + "%'";
            r = cmd.ExecuteReader();
            if (r.Read())
            {
                temp = r["numbers"].ToString();
            }
            r.Close();
            trans = con.BeginTransaction();
            cmd.Transaction = trans;
            cmd.CommandText = "INSERT INTO accountTable values('" + temp + "','" + textBox1.Text + "','" + textBox2.Text + "','" + 0.00 + "')";
            cmd.ExecuteNonQuery();
            trans.Commit();
            clearText();
            MessageBox.Show("Record added");
        }

        private void viewSavingsAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearText();
            changeForm("view");
            try { r.Close(); } catch (Exception) { }
            cmd.CommandText = "SELECT * FROM accountTable WHERE accountID LIKE 'S%' ORDER BY SUBSTRING(accountID,3,3) ASC";
            r = cmd.ExecuteReader();
        }

        private void viewCurrentAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearText();
            changeForm("view");
            try { r.Close(); } catch (Exception) { }
            cmd.CommandText = "SELECT* FROM accountTable WHERE accountID LIKE 'C%' ORDER BY SUBSTRING(accountID, 3, 3) ASC";
            r = cmd.ExecuteReader();
        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearText();
            try { r.Close(); } catch (Exception) { }
            changeForm("add");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (r.Read())
            {
                textBox3.Text = r["accountID"].ToString();
                textBox4.Text = r["name"].ToString();
                textBox5.Text = r["address"].ToString();
            }
            else
            {
                MessageBox.Show("No more records");
            }
        }
        public void changeForm(string x)
        {
            if (x == "view" && tableLayoutPanel2.Visible == false)
            {
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel3.Visible = false;
                tableLayoutPanel2.Bounds = tableLayoutPanel1.Bounds;
                tableLayoutPanel2.Visible = true;
                tableLayoutPanel4.Visible = false;
                tableLayoutPanel5.Visible = false;

            }
            else if (x == "add" && tableLayoutPanel1.Visible == false)
            {
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel1.Visible = true;
                tableLayoutPanel3.Visible = false;
                tableLayoutPanel4.Visible = false;
                tableLayoutPanel5.Visible = false;
            }
            else if (x == "balance" && tableLayoutPanel3.Visible == false)
            {
                tableLayoutPanel3.Bounds = tableLayoutPanel1.Bounds;
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel3.Visible = true;
                tableLayoutPanel4.Visible = false;
                tableLayoutPanel5.Visible = false;
            }
            else if (x == "deposit" && tableLayoutPanel4.Visible == false)
            {
                tableLayoutPanel4.Bounds = tableLayoutPanel1.Bounds;
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel4.Visible = true;
                tableLayoutPanel3.Visible = false;
                tableLayoutPanel5.Visible = false;
            }
            else if (x == "withdraw" && tableLayoutPanel5.Visible == false)
            {
                tableLayoutPanel5.Bounds = tableLayoutPanel1.Bounds;
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel4.Visible = false;
                tableLayoutPanel3.Visible = false;
                tableLayoutPanel5.Visible = true;
            }
        }

        private void checkBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearText();
            try { r.Close(); } catch (Exception) { }
            changeForm("balance");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tempAccNum = textBox7.Text;
            cmd.CommandText = "SELECT accountID,name, (SELECT(COALESCE(sum(Transactions.depositAmount) - sum(Transactions.withdrawAmount),'0.00')) FROM Transactions WHERE Transactions.accountID = '"+tempAccNum+"') as balance FROM accountTable WHERE accountID = '"+ tempAccNum+"'";
            r = cmd.ExecuteReader();
            if (r.Read())
            {
                textBox7.Text = r["accountID"].ToString();
                textBox6.Text = r["name"].ToString();
                textBox8.Text = r["balance"].ToString();
            }
            r.Close();
        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearText();
            transferType = 'W';
            try { r.Close(); } catch (Exception) { }
            changeForm("withdraw");
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearText();
            transferType = 'D';
            try { r.Close(); } catch (Exception) { }
            changeForm("deposit");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string depositAmount = textBox9.Text;
            string ID = textBox10.Text;
            cmd.CommandText = "SELECT CONCAT('" + transferType + "', FORMAT(COALESCE(MAX(SUBSTRING(transactionID, 3, 3) + 1), '001'), '000'))AS numbers FROM Transactions WHERE transactionID like '" + transferType + "%'";
            r = cmd.ExecuteReader();
            if (r.Read())
            {

                temp = r["numbers"].ToString();
            }
            r.Close();
            trans =con.BeginTransaction();
            cmd.Transaction = trans;
            cmd.CommandText = "insert into Transactions values('"+temp+"','"+ID+"','"+0.00+"','"+depositAmount+"',NULL)";
            cmd.ExecuteNonQuery();
            trans.Commit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string depositAmount = textBox12.Text;
            string ID = textBox13.Text;
            cmd.CommandText = "SELECT CONCAT('" + transferType + "', FORMAT(COALESCE(MAX(SUBSTRING(transactionID, 3, 3) + 1), '001'), '000'))AS numbers FROM Transactions WHERE transactionID like '" + transferType + "%'";
            r = cmd.ExecuteReader();
            if (r.Read())
            {

                temp = r["numbers"].ToString();
            }
            r.Close();
            trans = con.BeginTransaction();
            cmd.Transaction = trans;
            cmd.CommandText = "INSERT INTO Transactions values('" + temp + "','" + ID + "','" + depositAmount+ "','" + 0.00 + "',NULL)";
            cmd.ExecuteNonQuery();
            trans.Commit();
        }

        public void clearText()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox12.Clear();
            textBox13.Clear();
        }
    }
}