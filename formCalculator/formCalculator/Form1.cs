using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formCalculator
{
    public partial class Form1 : Form
    {
        int result;
        int i = 0;
        string first, second, symbole = "";
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        //private void button17_Click(object sender, EventArgs e)
        //{

        //}

        private void button5_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Text)
            {
                case "+":
                    symbole = "+";
                    textBox1.Text = b.Text;
                    i = 1;
                    second = "";
                    break;
                case "-":
                    symbole = "-";
                    textBox1.Text = b.Text;
                    i = 1;
                    second = "";
                    break;
                case "/":
                    symbole = "/";
                    textBox1.Text = b.Text;
                    i = 1;
                    second = "";
                    break;
                case "*":
                    symbole = "*";
                    textBox1.Text = b.Text;
                    i = 1;
                    second = "";
                    break;
                case "Power":
                    symbole = "p";
                    textBox1.Text = b.Text;
                    i = 1;
                    second = "";
                    break;
                case "c":
                    i = 0;
                    first = "";
                    second = "";
                    textBox1.Text = "";
                    break;
                case "=":
                    if (i != 0 && second != "")
                    {
                        i = 0;
                        calc(first, second, symbole);
                    }
                    break;
                default:
                    firstNumber(b.Text);
                    break;
            }
        }
        public void calc(string a, string b, string symbole)
        {
            switch (symbole)
            {
                case "+":
                    result = Convert.ToInt32(a) + Convert.ToInt32(b);
                    break;
                case "-":
                    result = Convert.ToInt32(a) - Convert.ToInt32(b);
                    break;
                case "/":
                    result = Convert.ToInt32(a) / Convert.ToInt32(b);
                    break;
                case "*":
                    result = Convert.ToInt32(a) * Convert.ToInt32(b);
                    break;
                case "p":
                    result = powerOf(Convert.ToInt32(a), Convert.ToInt32(b));
                    break;
            }
            first = result.ToString();
            second = "";
            textBox1.Text = result.ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (button20.Visible == false) {
                button20.Visible = true;
                button19.Visible = true;
                button18.Visible = true;
                this.Width = this.Width + 80;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (button20.Visible == true)
            {
                button20.Visible = false;
                button19.Visible = false;
                button18.Visible = false;
                this.Width = this.Width - 80;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            label1.Text = b.AccessibleDescription;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        public void firstNumber(string b)
        {
            if (i == 0)
            {
                first += b;
                textBox1.Text = first;
            }
            else
            {
                second += b;
                textBox1.Text = second;
            }
        }

        public int powerOf(int a, int b)
        {
            result = a;
            for (int i = b - 1; i != 0; i--)
            {
                result *= a;
            }
            return result;
        }
    }
}