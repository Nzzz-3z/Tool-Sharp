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
            MessageBox.Show("Image is save | Click on purple tetx to open saved image", "Image saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

           
        private void button2_Click(object sender, EventArgs e)
        {
            BarcodeSettings settings = new BarcodeSettings();
            
            settings.Type = BarCodeType.QRCode;

            settings.Data = (richTextBox1.Text);
            
            settings.Data2D = (richTextBox1.Text);

            settings.QRCodeDataMode = QRCodeDataMode.AlphaNumber;
            
            settings.X = 1.0f;
            
            settings.QRCodeECL = QRCodeECL.H;

            BarCodeGenerator generator = new BarCodeGenerator(settings);

            pictureBox1.Image = generator.GenerateImage();
            

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void exportQRCoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Image |*" + "." + comboBox1.Text);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
            linkLabel1.Text = saveFileDialog1.FileName;
            MessageBox.Show("Image is save | Click on purple tetx to open saved image", "Image saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
