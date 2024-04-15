using GemBox.Pdf.Content;
using GemBox.Pdf;
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
    public partial class Form7 : Form
    {
        public Form7()
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
            openFileDialog1.Filter = ("Pdf file |*.pdf");
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            button2.Hide();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void impoetPdfFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Pdf file |*.pdf");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = openFileDialog1.FileName;
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Image file |*." + comboBox1.Text);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel2.Text = saveFileDialog1.FileName;
            }
            // If using the Professional version, put your serial key below.
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            using (var document = PdfDocument.Load(linkLabel1.Text))
            {
                // Iterate through PDF pages.
                foreach (var page in document.Pages)
                {
                    // Get all image content elements on the page.
                    var imageElements = page.Content.Elements.All().OfType<PdfImageContent>().ToList();

                    // Export the first image element to an image file.
                    if (imageElements.Count > 0)
                    {
                        imageElements[0].Save(saveFileDialog1.FileName + "." + comboBox1.Text);
                        break;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel2.Text);
        }
    }
}
