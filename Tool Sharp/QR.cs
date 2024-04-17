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
    public partial class QR : Form
    {
        public QR()
        {
            InitializeComponent();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Image |*" + "." + comboBox1.Text);
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
            linkLabel1.Text = saveFileDialog1.FileName;
        }

           
        private void button2_Click(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw QR = new Zen.Barcode.CodeQrBarcodeDraw();
            pictureBox1.Image = QR.Draw(richTextBox1.Text , 100);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
