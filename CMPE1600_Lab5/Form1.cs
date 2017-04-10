using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace CMPE1600_Lab5
{
    public partial class Form1 : Form
    {
        Bitmap bitMap;
        Thread thOne;
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

        private void UI_ContrastRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_ContrastRadio.Checked)
            {
                label1.Text = "Less";
                label2.Text = "More";
                
            }
        }

        private void UI_TintRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_TintRadio.Checked)
            {
                label1.Text = "Red";
                label2.Text = "Green";
            }
        }

        private void UI_BWRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_BWRadio.Checked)
            {
                label1.Text = "Less";
                label2.Text = "More";
            }
        }

        private void UI_NoiseRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_NoiseRadio.Checked)
            {
                label1.Text = "Less";
                label2.Text = "More";
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }

        private void UI_TransformButton_Click(object sender, EventArgs e)
        {
            if (UI_ContrastRadio.Checked)
            {
                Contrast();
                trackBar1.Value = 50;
            }
            else if(UI_TintRadio.Checked)
            {
                Tint();
                trackBar1.Value = 50;
            }
        }

        public void Contrast()
        {
            Color tempColor;
            int rValue = 0, gValue = 0, bValue = 0;

            for (int x = 0; x < bitMap.Width; x++)
            {
                for (int y = 0; y < bitMap.Height; y++)
                {
                    tempColor = bitMap.GetPixel(x, y);
                    rValue = tempColor.R;
                    gValue = tempColor.G;
                    bValue = tempColor.B;

                    if (rValue < 128)
                    {
                        rValue = ((rValue - (trackBar1.Value / 5)) < 0) ? 0 : (rValue - (trackBar1.Value / 5));
                    }
                    else if (rValue > 128)
                    {
                        rValue = ((rValue + (trackBar1.Value / 5)) > 255) ? 255 : (rValue + (trackBar1.Value / 5));
                    }

                    if (gValue < 128)
                    {
                        gValue = ((gValue - (trackBar1.Value / 5)) < 0) ? 0 : (gValue - (trackBar1.Value / 5));
                    }
                    else if (rValue > 128)
                    {
                        rValue = ((gValue + (trackBar1.Value / 5)) > 255) ? 255 : (gValue + (trackBar1.Value / 5));
                    }

                    if (bValue < 128)
                    {
                        bValue = ((bValue - (trackBar1.Value / 5)) < 0) ? 0 : (bValue - (trackBar1.Value / 5));
                    }
                    else if (bValue > 128)
                    {
                        bValue = ((bValue + (trackBar1.Value / 5)) > 255) ? 255 : (bValue + (trackBar1.Value / 5));
                    }

                    Color newColor = Color.FromArgb(rValue, gValue, bValue);
                    bitMap.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = bitMap;
        }

        public void Tint()
        {
            Color tempColor;
            int rValue = 0, gValue = 0, bValue = 0;

            for (int x = 0; x < bitMap.Width; x++)
            {
                for (int y = 0; y < bitMap.Height; y++)
                {
                    tempColor = bitMap.GetPixel(x, y);
                    rValue = tempColor.R;
                    gValue = tempColor.G;
                    bValue = tempColor.B;

                   if (trackBar1.Value < 50)
                    {
                        rValue = ((rValue + (50 - trackBar1.Value)) > 255) ? 255: (rValue + (50 - trackBar1.Value));
                    }
                   else if (trackBar1.Value > 50)
                    {
                        gValue = ((gValue + (trackBar1.Value + 50)) > 255) ? 255: (gValue + (trackBar1.Value + 50));
                    }


                    Color newColor = Color.FromArgb(rValue, gValue, bValue);
                    bitMap.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = bitMap;
        }
    }

        
    }


