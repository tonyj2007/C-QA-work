using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichtextBoxForm
{
    /** 
    WordPad mock up using windows forms, includes opening, saving and creating new files. color and font formating included
        */
    public partial class Form1 : Form
    {
        DialogResult result;
        bool changed = false;
        string fileName = "";
        public Form1()
        {
            InitializeComponent();
            this.Text = "New file";
        }
        private void Form1_Resize(object sender, EventArgs e)
        {/**
            scale the text box with the form if it is resized
            */
            richTextBox1.Width = this.Width;
            richTextBox1.Height = this.Height-75;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Width = this.Width;
            richTextBox1.Height = this.Height - 75;
        }

        public void sFile()
        {/**
            save as file function used to save the text box content to a file using the built in save dialog box
            */
            if (richTextBox1.Visible == false)
            {
                MessageBox.Show("There is nothing to save");
            }
            else {
                saveFileDialog1.ShowDialog();
                fileName = saveFileDialog1.FileName;
                if (fileName != "")
                {
                    richTextBox1.SaveFile(fileName);
                    this.Text = fileName;
                    changed = false;
                }
            }
        }
        public void oFile()
        {/**
            open file function used to open text files and set the content to the text box using the built in open file dialog boxes
            */
            result = openFileDialog1.ShowDialog();
            fileName = openFileDialog1.FileName;
            if (fileName != "" && result != DialogResult.Cancel)
            {
                richTextBox1.LoadFile(fileName);
                this.Text = fileName;
                changed = false;
                richTextBox1.Visible = true;
                saveOptions();
            }
        }
        public void nFile()
        {
            /**
            creates a new empty file ready to be typed into and promotes the user to save there changes if there have been any from the last file
            */
            richTextBox1.Visible = true;
            saveOptions();
            if (changed == true)
            {
                result = MessageBox.Show("Do you want to save changes ?", " Save file", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (fileName == "")
                    {
                        sFile();
                        
                    }
                    else
                    {
                        richTextBox1.SaveFile(fileName);
                        richTextBox1.Clear();
                        this.Text = "New file";
                    }
                }
                else if (result == DialogResult.No)
                {
                    richTextBox1.Clear();
                    resetFileVer();
                }
            }
            else {
                richTextBox1.Clear();
                resetFileVer();
            }
            richTextBox1.Font = base.Font;
            richTextBox1.ForeColor = base.ForeColor;
        }
    
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {//tool strip option
            oFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {//tool strip option
            sFile();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {//tool strip option
            nFile();
        }

        public void resetFileVer()
        {/**
            used to reset the variables used to work out if there has been any changes to the file since it opened
            */
            fileName = "";
            changed = false;
            this.Text = "New File";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {/**
            basic save function dose not need a file name if it is an edited version of an already existent file
            */
            if (fileName != "")
            {
                richTextBox1.SaveFile(fileName);
                changed = false;
            }
            else if (richTextBox1.Visible == false)
            {
                MessageBox.Show("There is nothing to save");
            }
            else
                sFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {// tool strip option
            this.Close();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {/**
            uses built in font dialog boxes to change font of the text box
            */
            if(fontDialog1.ShowDialog() != DialogResult.Cancel)
                richTextBox1.Font = fontDialog1.Font;
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {/**
            uses built in color dialog boxes to change font of the text box
            */
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
                richTextBox1.ForeColor = colorDialog1.Color;

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {/**
            close file function. closes the file but not the program. disables save functionality while there is no file there, but promotes the save option before closing the current file.
            */
            if (changed == false)
            {
                richTextBox1.Visible = false;
                resetFileVer();
                saveOptions();
            }
            else
                result = MessageBox.Show("Do you want to save changes before closing the window", "save", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    sFile();
                }
                else if (result == DialogResult.No)
                {
                    resetFileVer();
                    richTextBox1.Clear();
                }
        }
        public void saveOptions()
        {/**
            used to disable the save function while there is no file loaded and re enables the save function when a file is present.
            */
            if (saveToolStripMenuItem.Enabled == true)
            {
                saveAsToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
            }
            else
            {
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
            }
        }
    }
}
