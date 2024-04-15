using Spire.Pdf;
using Spire.Pdf.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Markup;

namespace Tool_Sharp
{
    public partial class Form8 : Form
    {
        public Form8()
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

        private void chToolStripMenuItem_Click(object sender, EventArgs e)
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
            openFileDialog1.Filter = ("PDF file |*.pdf");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Excel File |*.xlsx");
            label2.Show();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PdfDocument file = new PdfDocument();
                file.LoadFromFile(linkLabel1.Text);
                file.SaveToFile(saveFileDialog1.FileName, Spire.Pdf.FileFormat.XLSX);
            }
            label2.Text = ("File is Convented!");
            linkLabel2.Text = saveFileDialog1.FileName;
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel2.Text);
        }
        private void importPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("PDF file |*.pdf");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
        }

        private void exportExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Excel File |*.xlsx");
            label2.Show();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PdfDocument file = new PdfDocument();
                file.LoadFromFile(linkLabel1.Text);
                file.SaveToFile(saveFileDialog1.FileName, Spire.Pdf.FileFormat.XLSX);
            }
            label2.Text = ("File is Convented!");
            linkLabel2.Text = saveFileDialog1.FileName;
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            label2.Hide();
        }
    }
}
