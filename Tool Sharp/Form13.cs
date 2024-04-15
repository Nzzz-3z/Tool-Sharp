using GemBox.Document;
using GemBox.Spreadsheet;
using Spire.Doc;
using Spire.Xls;
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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            label1.Hide();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Word and text file |*.txt;*.docx;*.doc;*.odt");
            if(openFileDialog1.ShowDialog () == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Pdf file |*.pdf");
            label1.Show(); 
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Workbook file = new Workbook();
                file.LoadFromFile(linkLabel1.Text);
                file.SaveToFile(saveFileDialog1.FileName , Spire.Xls.FileFormat.PDF);
            }
            label1.Text = ("File is converted !");
            linkLabel2.Text = saveFileDialog1.FileName;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel2.Text);
        }

        private void importWordAndTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Word and text file |*.txt;*.docx;*.doc;*.odt");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
        }

        private void exportToPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Pdf file |*.pdf");
            label1.Show();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Workbook file = new Workbook();
                file.LoadFromFile(linkLabel1.Text);
                file.SaveToFile(saveFileDialog1.FileName, Spire.Xls.FileFormat.PDF);
            }
            label1.Text = ("File is convented !");
            linkLabel2.Text = saveFileDialog1.FileName;
        }
    }
}
