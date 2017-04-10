using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE1600_Lab5
{
    public partial class Form1 : Form
    {
        Bitmap bitMap;
        public Form1()
        {
            InitializeComponent();
        }

        private void UI_LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.Text = openFileDialog1.SafeFileName;
                    pictureBox1.Load(openFileDialog1.SafeFileName);
                    bitMap = new Bitmap(pictureBox1.Image);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lab 5", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
