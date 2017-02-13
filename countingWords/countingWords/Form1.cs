using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace countingWords
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int wordNumber = CountWord(text);
            textBox2.Text = wordNumber.ToString();
        }
        public int CountWord(string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    if ((i + 1) == text.Length)
                    {
                        count++;
                    }
                    else
                    {
                        if (text[i + 1] == ' ')
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
