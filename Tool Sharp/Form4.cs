using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool_Sharp
{
    public partial class Form4 : Form
    {
        public Form4()
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

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.Font = fontDialog1.Font;
                button1.Font = fontDialog1.Font;
                button3.Font = fontDialog1.Font;
            }
            else
            {
                MessageBox.Show("You're not Select font", "Font not select", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("Word Files|*.docx;*.doc");
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                object miss = System.Reflection.Missing.Value;
                object path = label1.Text;
                object readOnly = true;
                Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);//13 times ref miss
                string totaltext = "";
                foreach (Paragraph p in docs.Paragraphs)
                {
                    totaltext += p.Range.Text.ToString();
                }
                foreach (Table table in docs.Tables)
                {
                    for (int row = 1; row <= table.Rows.Count; row++)
                    {
                        for (int col = 1; col <= table.Columns.Count; col++)
                        {
                            string data = table.Cell(row, col).Range.Text;
                            textBox1.AppendText(data + "|");
                        }
                        textBox1.AppendText(Environment.NewLine);
                    }
                }
                richTextBox1.Text = totaltext;
                docs.Close();
                word.Quit();
            }
            else
            {
                MessageBox.Show("File is not Select", "File not select",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = ("Text file |*.txt");
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextWriter txt = new StreamWriter(saveFileDialog1.FileName);
                txt.Write(richTextBox1.Text);
                MessageBox.Show("File is convent to this path -- " + saveFileDialog1.FileName, "File is convent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt.Close();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
    }
}

