using Spire.Doc;
using Spire.Presentation;
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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Powerpoint file |*.pptx;*.ppt;*.odp;*.rtf");
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            label2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Pdf file |*.pdf");
            label2.Show();
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Presentation file = new Presentation();
                file.LoadFromFile(linkLabel1.Text);
                file.SaveToFile(saveFileDialog1.FileName , Spire.Presentation.FileFormat.PDF);
            }
            label2.Text = ("File is convented !");
            linkLabel2.Text = (saveFileDialog1.FileName);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel2.Text);
        }

        private void importPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Powerpoint file |*.pptx;*.ppt;*.odp;*.rtf");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
        }

        private void exportPowerpointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Pdf file |*.pdf");
            label2.Show();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Presentation file = new Presentation();
                file.LoadFromFile(linkLabel1.Text);
                file.SaveToFile(saveFileDialog1.FileName, Spire.Presentation.FileFormat.PDF);
            }
            label2.Text = ("File is convented !");
            linkLabel2.Text = (saveFileDialog1.FileName);
        }   
    }
}
