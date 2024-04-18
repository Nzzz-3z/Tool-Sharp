using Spire.Barcode;
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
    public partial class Barcode : Form
    {
        public Barcode()
        {
            InitializeComponent();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarcodeSettings bs = new BarcodeSettings();

            bs.Type = BarCodeType.Code128;
            bs.Data = (richTextBox1.Text);

            BarCodeGenerator bg = new BarCodeGenerator(bs);

            pictureBox1.Image = bg.GenerateImage();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Image |*" + "." + comboBox1.Text);
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
            linkLabel1.Text = saveFileDialog1.FileName;
            MessageBox.Show("Barcode is saved to image | CLick on purple text to open image", "Image saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        private void exportBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Image |*" + "." + comboBox1.Text);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
            linkLabel1.Text = saveFileDialog1.FileName;
            MessageBox.Show("Barcode is saved to image | CLick on purple text to open image", "Image saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
