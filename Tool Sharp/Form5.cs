using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tool_Sharp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void changeBackgroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.AnyColor = true;
            colorDialog1.FullOpen = true;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.Color = panel1.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }
            else
            {
                MessageBox.Show("You're not Select colour for Background", "Background colour not select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void changeTextColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.AnyColor = true;
            colorDialog1.FullOpen = true;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.Color = panel1.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.ForeColor = colorDialog1.Color;
            }
            else
            {
                MessageBox.Show("You're not Select colour for text", "text colour not select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Font = fontDialog1.Font;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Text file |*.txt");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
                richTextBox1.Text = File.ReadAllText(linkLabel1.Text);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }


        private void inportTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText(linkLabel1.Text);
        }


        private void Form5_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Text file |*.txt");
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextWriter txt = new StreamWriter(saveFileDialog1.FileName);
                txt.Write(richTextBox1.Text);
                MessageBox.Show("File is convent to this path -- "  + saveFileDialog1.FileName, "File is convent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt.Close();
            }
        }

        private void exportTextFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextWriter txt = new StreamWriter(saveFileDialog1.FileName);
            txt.Write(richTextBox1.Text);
            MessageBox.Show("File is convent to this path -- " + saveFileDialog1.FileName, "File is convent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
       }
    }
}
