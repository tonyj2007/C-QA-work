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
    /**
    calculator created using windows forms needs a few exception handling events adding like divide by 0 ect.
        */
    public partial class Form1 : Form
    {
        int result;
        int i = 0;
        string first, second, symbole = "";
        public Form1()
        {/**
            stop form size from being changeable 
            */
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        //private void button17_Click(object sender, EventArgs e)
        //{

        //}

        private void button5_Click(object sender, EventArgs e)
        {
            /**
            get input from the user about which button they pressed and perform the intended action, if a number add to screen and store until a symbol is used.
            */
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
            /**
            performs the associated calculator function depending on what symbol is used on the calculator
            */
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
            /**
            extends the calculator form and makes scientific buttons visible (sci functions not implemented)
            */
            if (button20.Visible == false) {
                button20.Visible = true;
                button19.Visible = true;
                button18.Visible = true;
                this.Width = this.Width + 80;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            /**
            reduces the calculator form and makes scientific buttons invisible (sci functions not implemented)
            */
            if (button20.Visible == true)
            {
                button20.Visible = false;
                button19.Visible = false;
                button18.Visible = false;
                this.Width = this.Width - 80;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        { /**
            used for displaying help descriptions about what buttons on the calculator do when uyo uhover over the button
            */
            Button b = (Button)sender;
            label1.Text = b.AccessibleDescription;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        public void firstNumber(string b)
        {
            /**
            works out wether the numbers entered into the calculator where before or after the symbol to determine 
            which was the first and which was the second number entered
            */
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
            /**
            power function of the calculator
            */
            result = a;
            for (int i = b - 1; i != 0; i--)
            {
                result *= a;
            }
            return result;
        }
    }
}