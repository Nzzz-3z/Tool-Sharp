﻿using Microsoft.Office.Interop.Word;
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
using Spire.Pdf.Graphics;
using Spire.Pdf;
using System.IO;
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

                //Create a PdfDocument object
                
            PdfDocument doc = new PdfDocument();
                


            //Set the margins
            doc.PageSettings.SetMargins(20);
                


            //Add a page
            PdfPageBase page = doc.Pages.Add();
                


            //Load an image
            Image image = Image.FromFile(openFileDialog1.FileName);
                


            //Get the image width and height
            float width = image.PhysicalDimension.Width;
            float height = image.PhysicalDimension.Height;


            //Declare a PdfImage variable
            PdfImage pdfImage;
                
             //If the image width is larger than page width

            if (width > page.Canvas.ClientSize.Width)
                    
            {
                    
                //Resize the image to make it to fit to the page width

                float widthFitRate = width / page.Canvas.ClientSize.Width;
                    
                Size size = new Size((int)(width / widthFitRate), (int)(height / widthFitRate));
                    
                Bitmap scaledImage = new Bitmap(image, size);
                    



                //Load the scaled image to the PdfImage object

                pdfImage = PdfImage.FromImage(scaledImage);
                    
            } else
                    
            {
                //Load the original image to the PdfImage objec
                pdfImage = PdfImage.FromImage(image);
            }


            //Draw image at (0, 0)
            page.Canvas.DrawImage(pdfImage, 0, 0, pdfImage.Width, pdfImage.Height);


            //Save to file

            doc.SaveToFile(saveFileDialog1.FileName);

                System.Diagnostics.Process.Start(saveFileDialog1.FileName);


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


                //Create a PdfDocument object

                PdfDocument doc = new PdfDocument();



                //Set the margins
                doc.PageSettings.SetMargins(20);



                //Add a page
                PdfPageBase page = doc.Pages.Add();



                //Load an image
                Image image = Image.FromFile(openFileDialog1.FileName);



                //Get the image width and height
                float width = image.PhysicalDimension.Width;
                float height = image.PhysicalDimension.Height;


                //Declare a PdfImage variable
                PdfImage pdfImage;

                //If the image width is larger than page width

                if (width > page.Canvas.ClientSize.Width)

                {

                    //Resize the image to make it to fit to the page width

                    float widthFitRate = width / page.Canvas.ClientSize.Width;

                    Size size = new Size((int)(width / widthFitRate), (int)(height / widthFitRate));

                    Bitmap scaledImage = new Bitmap(image, size);




                    //Load the scaled image to the PdfImage object

                    pdfImage = PdfImage.FromImage(scaledImage);

                }
                else

                {
                    //Load the original image to the PdfImage objec
                    pdfImage = PdfImage.FromImage(image);
                }


                //Draw image at (0, 0)
                page.Canvas.DrawImage(pdfImage, 0, 0, pdfImage.Width, pdfImage.Height);


                //Save to file

                doc.SaveToFile(saveFileDialog1.FileName);

                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            }
            }
        }
    }


