using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using GemBox.Pdf.Content;
using GemBox.Pdf;
using Tool_Sharp.Properties;


namespace Tool_Sharp
{
    public partial class Form6 : Form
    {
        public Form6()
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
            openFileDialog1.Filter = ("Image |*.jpg;*.png;*.gif;*.tiff;*.jpeg;*.bmp");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
        }



        private void Form6_Load(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {
            button6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Pdf file |*.pdf");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // If using the Professional version, put your serial key below.
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");

                using (var document = new PdfDocument())
                {
                    // Add a page.
                    var page = document.Pages.Add();

                    // Load the image from a file.
                    var image = PdfImage.Load(linkLabel1.Text);

                    // Set the location of the bottom-left corner of the image.
                    // We want the top-left corner of the image to be at location (50, 50)
                    // from the top-left corner of the page.
                    // NOTE: In PDF, location (0, 0) is at the bottom-left corner of the page
                    // and the positive y axis extends vertically upward.
                    double x = 0.2, y = page.CropBox.Top - 0.2 - image.Size.Height;

                    // Draw the image to the page.
                    page.Content.DrawImage(image, new PdfPoint(x, y));

                    document.Save(saveFileDialog1.FileName);
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }
            }
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void importImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Image |*.jpg;*.png;*.gif;*.tiff;*.jpeg;*.bmp");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
        }

        private void exportPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // If using the Professional version, put your serial key below.
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");

                using (var document = new PdfDocument())
                {
                    // Add a page.
                    var page = document.Pages.Add();

                    // Load the image from a file.
                    var image = PdfImage.Load(linkLabel1.Text);

                    // Set the location of the bottom-left corner of the image.
                    // We want the top-left corner of the image to be at location (50, 50)
                    // from the top-left corner of the page.
                    // NOTE: In PDF, location (0, 0) is at the bottom-left corner of the page
                    // and the positive y axis extends vertically upward.
                    double x = 50, y = page.CropBox.Top - 50 - image.Size.Height;

                    // Draw the image to the page.
                    page.Content.DrawImage(image, new PdfPoint(x, y));

                    document.Save(saveFileDialog1.FileName);
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }
            }
        }
    }
}

