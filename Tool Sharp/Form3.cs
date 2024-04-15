using ExcelDataReader;
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
    public partial class Form3 : Form
    {
        public Form3()
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

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.Font = fontDialog1.Font;
                button1.Font = fontDialog1.Font;
                button2.Font = fontDialog1.Font;
                button3.Font = fontDialog1.Font;
                button4.Font = fontDialog1.Font;

            }
            else
            {
                MessageBox.Show("You're not Select font", "Font not select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("common Excel Files |*.xlsx;*.xls;*.csv");
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("File is not select", "File not select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var stream = File.Open(label2.Text, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var data = reader.AsDataSet();
                    dataGridView1.DataSource = data.Tables[0];//this is for read xlsx nad xls files
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var stream = File.Open(label2.Text, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    var data = reader.AsDataSet();
                    dataGridView1.DataSource = data.Tables[0];//this is for read csv files
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
