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

/******************************************************************
 * Name:        William Fichtner
 * Program:     CMPE1600 Lab 5
 * Description: A basic image editor using threading and bitmaps
 * Instructor:  JD Silver
 * Date:        April 11, 2017
 * ***************************************************************/


namespace CMPE1600_Lab5
{
    public delegate void delVoidInt(int i);
    public delegate void delVoidVoid();
    public partial class Form1 : Form
    {
        Bitmap bitMap;
        Thread thOne;
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
            UI_TransformButton.Enabled = false;
            if (UI_ContrastRadio.Checked)
            {
                thOne = new Thread(Contrast);
                thOne.Start(trackBar1.Value);

            }
            else if (UI_TintRadio.Checked)
            {
                thOne = new Thread(Tint);
                thOne.Start(trackBar1.Value);

            }
            else if (UI_NoiseRadio.Checked)
            {
                thOne = new Thread(Noise);
                thOne.Start(trackBar1.Value);
            }
            else if (UI_BWRadio.Checked)
            {
                thOne = new Thread(BlackWhite);
                thOne.Start(trackBar1.Value);
            }

            
        }

        //Updates progress bar live
        private void CBWorking(int i)
        {
            UI_pb.Value = i;
        }

        //Housekeeping for end of thread
        //i.e updates new image, etc.
        private void CBFinished()
        {
            pictureBox1.Image = bitMap;
            UI_pb.Value = 0;
            trackBar1.Value = 50;
            UI_TransformButton.Enabled = true;
            label3.Text = trackBar1.Value.ToString();
        }

        //Changes the contrast of the picture
        public void Contrast(object thing)
        {
            Color tempColor;
            int rValue = 0, gValue = 0, bValue = 0;
            int trackValue = (int)thing;

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
                        rValue = ((rValue - (trackValue / 5)) < 0) ? 0 : (rValue - (trackValue / 5));
                    }
                    else if (rValue > 128)
                    {
                        rValue = ((rValue + (trackValue / 5)) > 255) ? 255 : (rValue + (trackValue / 5));
                    }

                    if (gValue < 128)
                    {
                        gValue = ((gValue - (trackValue / 5)) < 0) ? 0 : (gValue - (trackValue / 5));
                    }
                    else if (rValue > 128)
                    {
                        rValue = ((gValue + (trackValue / 5)) > 255) ? 255 : (gValue + (trackValue / 5));
                    }

                    if (bValue < 128)
                    {
                        bValue = ((bValue - (trackValue / 5)) < 0) ? 0 : (bValue - (trackValue / 5));
                    }
                    else if (bValue > 128)
                    {
                        bValue = ((bValue + (trackValue / 5)) > 255) ? 255 : (bValue + (trackValue / 5));
                    }

                    Color newColor = Color.FromArgb(rValue, gValue, bValue);

                    bitMap.SetPixel(x, y, newColor);
                    if (InvokeRequired)
                    {
                        try
                        {
                            Invoke(new delVoidInt(CBWorking), (x * 100) / bitMap.Width);
                        }
                        catch (Exception error)
                        {

                        }
                    }
                }

            }
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new delVoidVoid(CBFinished)); // this one needs to be a delvoidvoid
                }
                catch (Exception e)
                {

                }
            }

        }
        //Pushes the picture to be either more red tinted or green tinted
        public void Tint(object thing)
        {
            Color tempColor;
            int rValue = 0, gValue = 0, bValue = 0;
            int trackValue = (int)thing;

            for (int x = 0; x < bitMap.Width; x++)
            {
                for (int y = 0; y < bitMap.Height; y++)
                {
                    tempColor = bitMap.GetPixel(x, y);
                    rValue = tempColor.R;
                    gValue = tempColor.G;
                    bValue = tempColor.B;

                    if (trackValue < 50)
                    {
                        rValue = ((rValue + (50 - trackValue)) > 255) ? 255 : (rValue + (50 - trackValue));
                    }
                    else if (trackValue > 50)
                    {
                        gValue = ((gValue + (trackValue + 50)) > 255) ? 255 : (gValue + (trackValue + 50));
                    }


                    Color newColor = Color.FromArgb(rValue, gValue, bValue);
                    bitMap.SetPixel(x, y, newColor);
                    if (InvokeRequired)
                    {
                        try
                        {
                            Invoke(new delVoidInt(CBWorking), (x * 100) / bitMap.Width);
                        }
                        catch (Exception error)
                        {

                        }
                    }
                }
            }
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new delVoidVoid(CBFinished)); // this one needs to be a delvoidvoid
                }
                catch (Exception e)
                {

                }
            }
        }


        //Creates noise by randomizing the colors of the picture
        public void Noise(object thing)
        {
            Color tempColor;
            Random rand = new Random();
            int rValue = 0, gValue = 0, bValue = 0;
            int trackValue = (int)thing;

            for (int x = 0; x < bitMap.Width; x++)
            {
                for (int y = 0; y < bitMap.Height; y++)
                {
                    tempColor = bitMap.GetPixel(x, y);
                    rValue = tempColor.R;
                    gValue = tempColor.G;
                    bValue = tempColor.B;
                    int mod = rand.Next(-trackValue, trackValue);

                    rValue = (((rValue + mod) < 0) || ((rValue + mod) > 255)) ? rValue : (rValue + mod);
                    gValue = (((gValue + mod) < 0) || ((gValue + mod) > 255)) ? gValue : (gValue + mod);
                    bValue = (((bValue + mod) < 0) || ((bValue + mod) > 255)) ? bValue : (bValue + mod);

                    Color newColor = Color.FromArgb(rValue, gValue, bValue);
                    bitMap.SetPixel(x, y, newColor);

                    if (InvokeRequired)
                    {
                        try
                        {
                            Invoke(new delVoidInt(CBWorking), (x * 100) / bitMap.Width);
                        }
                        catch (Exception error)
                        {

                        }
                    }
                }

               
            }
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new delVoidVoid(CBFinished)); // this one needs to be a delvoidvoid
                }
                catch (Exception e)
                {

                }
            }
        }
        //Makes the picture black and white
        public void BlackWhite(object thing)
        {
            Color tempColor;
            int rValue = 0, gValue = 0, bValue = 0;
            int average = 0;
            int trackValue = (int)thing;

            for (int x = 0; x < bitMap.Width; x++)
            {
                for (int y = 0; y < bitMap.Height; y++)
                {
                    tempColor = bitMap.GetPixel(x, y);
                    rValue = tempColor.R;
                    gValue = tempColor.G;
                    bValue = tempColor.B;
                    average = (rValue + gValue + bValue) / 3;

                    rValue = ((rValue + ((average - rValue) * (trackValue / 100)) < 0) || (rValue + ((average - rValue) * (trackValue / 100)) > 255)) ? rValue : rValue + ((average - rValue) * (trackValue / 100));
                    gValue = ((gValue + ((average - gValue) * (trackValue / 100)) < 0) || (gValue + ((average - gValue) * (trackValue / 100)) > 255)) ? gValue : gValue + ((average - gValue) * (trackValue / 100));
                    bValue = ((bValue + ((average - bValue) * (trackValue / 100)) < 0) || (bValue + ((average - bValue) * (trackValue / 100)) > 255)) ? bValue : bValue + ((average - bValue) * (trackValue / 100));

                    Color newColor = Color.FromArgb(rValue, gValue, bValue);
                    bitMap.SetPixel(x, y, newColor);

                    if (InvokeRequired)
                    {
                        try
                        {
                            Invoke(new delVoidInt(CBWorking), (x * 100) / bitMap.Width);
                        }
                        catch (Exception error)
                        {

                        }
                    }
                }
            }
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new delVoidVoid(CBFinished)); // this one needs to be a delvoidvoid
                }
                catch (Exception e)
                {

                }
            }
        }
        //Stops all threads while closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            thOne.Abort();
        }
    }

}


