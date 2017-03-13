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
        /**
        windows forms application that counts the amount of words you enter into a text box -
            once the button is pressed
        
            */
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**
            button press sends content of the text box to the function that works out the amount of words
            the user has typed in 
            */
            string text = textBox1.Text;
            int wordNumber = CountWord(text);
            textBox2.Text = wordNumber.ToString();
        }
        public int CountWord(string text)
        {/**
            works out the number of words by determining where the white spaces are and if the length of the text has been reached
            */
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
