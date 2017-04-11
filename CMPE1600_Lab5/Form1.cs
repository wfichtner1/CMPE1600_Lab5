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
    public delegate void delVoidInt(int i);
    public delegate void delVoidVoid();
    public partial class Form1 : Form
    {
        Bitmap bitMap;
        public Form1()
        {
            InitializeComponent();
        }
        //Loads a picture into the picture box when button is pressed
        private void UI_LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.Text = openFileDialog1.SafeFileName;
                    pictureBox1.Load(openFileDialog1.SafeFileName);
                    UI_TransformButton.Enabled = true;
                    bitMap = new Bitmap(pictureBox1.Image);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lab 5", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Checks if contrast radio is checked
        private void UI_ContrastRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_ContrastRadio.Checked)
            {
                label1.Text = "Less";
                label2.Text = "More";

            }
        }
        //Checks if Tint radio is checked
        private void UI_TintRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_TintRadio.Checked)
            {
                label1.Text = "Red";
                label2.Text = "Green";
            }
        }
        //Checked if black and white radio is checked
        private void UI_BWRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_BWRadio.Checked)
            {
                label1.Text = "Less";
                label2.Text = "More";
            }
        }
        //Checks if noise radio is checked
        private void UI_NoiseRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_NoiseRadio.Checked)
            {
                label1.Text = "Less";
                label2.Text = "More";
            }
        }

        //updates the trackbar value label
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }
        //Enacts the changes to the picture as specified by user
        private void UI_TransformButton_Click(object sender, EventArgs e)
        {
            if (UI_ContrastRadio.Checked)
            {
                Contrast();                
            }
            else if (UI_TintRadio.Checked)
            {
                Tint();
                
            }
            else if(UI_NoiseRadio.Checked)
            {
                Noise();                
            }
            else if(UI_BWRadio.Checked)
            {
                BlackWhite();
            }

            trackBar1.Value = 50;
        }
        //Changes the contrast of the picture
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
        //Pushes the picture to be either more red tinted or green tinted
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
                        rValue = ((rValue + (50 - trackBar1.Value)) > 255) ? 255 : (rValue + (50 - trackBar1.Value));
                    }
                    else if (trackBar1.Value > 50)
                    {
                        gValue = ((gValue + (trackBar1.Value + 50)) > 255) ? 255 : (gValue + (trackBar1.Value + 50));
                    }


                    Color newColor = Color.FromArgb(rValue, gValue, bValue);
                    bitMap.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = bitMap;
        }

        private void CBMethod(int i)
        {
            UI_pb.Value = i;
        }
        //Creates noise by randomizing the colors of the picture
        public void Noise()
        {
            Color tempColor;
            Random rand = new Random();
            int rValue = 0, gValue = 0, bValue = 0;

            for (int x = 0; x < bitMap.Width; x++)
            {
                for (int y = 0; y < bitMap.Height; y++)
                {
                    tempColor = bitMap.GetPixel(x, y);
                    rValue = tempColor.R;
                    gValue = tempColor.G;
                    bValue = tempColor.B;
                    int mod = rand.Next(-trackBar1.Value, trackBar1.Value);

                    rValue = (((rValue + mod) < 0) || ((rValue + mod) > 255)) ? rValue : (rValue + mod);
                    gValue = (((gValue + mod) < 0) || ((gValue + mod) > 255)) ? gValue : (gValue + mod);
                    bValue = (((bValue + mod) < 0) || ((bValue + mod) > 255)) ? bValue : (bValue + mod);

                    Color newColor = Color.FromArgb(rValue, gValue, bValue);
                    bitMap.SetPixel(x, y, newColor);
                }

                //if (InvokeRequired)
                //{
                //    try
                //    {
                //        Invoke(new delVoidInt(CBMethod), (x * 100) / bitMap.Width);
                //    }
                //    catch (Exception error)
                //    {

                //    }
                //}
            }
            pictureBox1.Image = bitMap;
            //if (InvokeRequired)
            //{
            //    try
            //    {
            //        Invoke(new delVoidInt(CBMethod), (x * 100) / bitMap.Width); // this one needs to be a delvoidvoid
            //    }
            //    catch (Exception error)
            //    {

            //    }
            //}
        }
        //Makes the picture black and white
        public void BlackWhite()
        {
            Color tempColor;
            int rValue = 0, gValue = 0, bValue = 0;
            int average = 0;
            for (int x = 0; x < bitMap.Width; x++)
            {
                for (int y = 0; y < bitMap.Height; y++)
                {
                    tempColor = bitMap.GetPixel(x, y);
                    rValue = tempColor.R;
                    gValue = tempColor.G;
                    bValue = tempColor.B;
                    average = (rValue + gValue + bValue) / 3;

                    rValue = ((rValue + ((average - rValue) * (trackBar1.Value / 100)) < 0) || (rValue + ((average - rValue) * (trackBar1.Value / 100)) > 255)) ? rValue : rValue + ((average - rValue) * (trackBar1.Value / 100));
                    gValue = ((gValue + ((average - gValue) * (trackBar1.Value / 100)) < 0) || (gValue + ((average - gValue) * (trackBar1.Value / 100)) > 255)) ? gValue : gValue + ((average - gValue) * (trackBar1.Value / 100));
                    bValue = ((bValue + ((average - bValue) * (trackBar1.Value / 100)) < 0) || (bValue + ((average - bValue) * (trackBar1.Value / 100)) > 255)) ? bValue : bValue + ((average - bValue) * (trackBar1.Value / 100));

                    Color newColor = Color.FromArgb(rValue, gValue, bValue);
                    bitMap.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = bitMap;
        }
    }

}


