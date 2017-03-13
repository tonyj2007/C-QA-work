using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capitalLetters
{
    /**
    windows form application that is used to change user input and display it in another text box as they are typing it.
        capital letters become lower case and lower case become capital letters. numbers are doubled. 
        Button was original used to convert but has been changed to do it after every character meaning the button is there but dose not do anything at the moment.
        Needs some error checking implemented.
        */
    public partial class Form1 : Form
    {
        string message1, message2 = "";
        int x, L = 0;
        char c;
        char[] messageArray;
        public Form1()
        {
            InitializeComponent();
        }

        /**
        auto conversion being used instead of when the button is clicked
            */
        private void button1_Click(object sender, EventArgs e)
        {
            message1 = richTextBox1.Text;
            messageArray = message1.ToCharArray();
            convertString(message1);
            if (richTextBox2.Text != richTextBox1.Text)
                richTextBox2.Text = message2;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            /**
            using Char class methods to see if the char is a letter or a number before converting it to the opposite or doubling it for numbers
            */
            if (richTextBox1.Text.Length != 0)
                c = richTextBox1.Text[richTextBox1.Text.Length - 1];
            if (Char.IsDigit(c))
            {
                message2 += (Convert.ToInt32(c.ToString()) * 2).ToString();
                L++;
            }
            else if (Char.IsLetter(c))
            {
                if (Char.IsUpper(c))
                {
                    message2 += Char.ToLower(c);
                    L++;
                }
                else {
                    message2 += Char.ToUpper(c);
                    L++;
                }
            }
            else
            {
                message2 += c;
                L++;
            }
            if (richTextBox1.Text.Length != L)
            {
                richTextBox2.Text = richTextBox2.Text.Substring(0, richTextBox2.Text.Length - 1);
                L = richTextBox1.Text.Length;
            }
            else
                richTextBox2.Text += message2;
            message2 = "";
        }
       
        public string convertString(string msg)
        { /**
        only needed for the button click conversion not needed for auto conversion
        */
            //for (int i = 0; i < msg.Length; i++)
            //{
            //    char c = messageArray[i];
            //    if (Char.IsDigit(c))
            //    {
            //        message2 += (Convert.ToInt32(c.ToString()) * 2).ToString();
            //    }
            //    else if (Char.IsLetter(c))
            //    {
            //        if (Char.IsUpper(c))
            //            message2 += Char.ToLower(c);
            //        else
            //            message2 += Char.ToUpper(c);
            //    }
            //    else
            //    {
            //        message2 += c;
            //    }
            //}
            return message2;
        }
    }
}