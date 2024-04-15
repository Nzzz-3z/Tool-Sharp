using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool_Sharp
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void chaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.Font = fontDialog1.Font;
            }
            else
            {
                MessageBox.Show("You're not Select font", "Font not select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Pdf file |*.pdf");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            label1.Hide();        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("World file |*.docx");
            label1.Show();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PdfDocument file = new PdfDocument();
                file.LoadFromFile(linkLabel1.Text);
                file.SaveToFile(saveFileDialog1.FileName, FileFormat.DOCX);
            }
            label1.Text = ("File is Convent !");
            linkLabel2.Text = saveFileDialog1.FileName;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel2.Text);
        }

        private void importPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Pdf file |*.pdf");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
        }

        private void exportDocxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("World file |*.docx");
            label1.Show();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PdfDocument file = new PdfDocument();
                file.LoadFromFile(linkLabel1.Text);
                file.SaveToFile(saveFileDialog1.FileName, FileFormat.DOCX);
            }
            label1.Text = ("File is Convent !");
            linkLabel2.Text = saveFileDialog1.FileName;
        }
    }
}