namespace CMPE1600_Lab5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UI_LoadButton = new System.Windows.Forms.Button();
            this.UI_TransformButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UI_ContrastRadio = new System.Windows.Forms.RadioButton();
            this.UI_BWRadio = new System.Windows.Forms.RadioButton();
            this.UI_TintRadio = new System.Windows.Forms.RadioButton();
            this.UI_NoiseRadio = new System.Windows.Forms.RadioButton();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(881, 418);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UI_LoadButton
            // 
            this.UI_LoadButton.Location = new System.Drawing.Point(12, 459);
            this.UI_LoadButton.Name = "UI_LoadButton";
            this.UI_LoadButton.Size = new System.Drawing.Size(75, 23);
            this.UI_LoadButton.TabIndex = 1;
            this.UI_LoadButton.Text = "Load Picture";
            this.UI_LoadButton.UseVisualStyleBackColor = true;
            this.UI_LoadButton.Click += new System.EventHandler(this.UI_LoadButton_Click);
            // 
            // UI_TransformButton
            // 
            this.UI_TransformButton.Location = new System.Drawing.Point(818, 459);
            this.UI_TransformButton.Name = "UI_TransformButton";
            this.UI_TransformButton.Size = new System.Drawing.Size(75, 23);
            this.UI_TransformButton.TabIndex = 2;
            this.UI_TransformButton.Text = "Transform";
            this.UI_TransformButton.UseVisualStyleBackColor = true;
            this.UI_TransformButton.Click += new System.EventHandler(this.UI_TransformButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UI_NoiseRadio);
            this.groupBox1.Controls.Add(this.UI_TintRadio);
            this.groupBox1.Controls.Add(this.UI_BWRadio);
            this.groupBox1.Controls.Add(this.UI_ContrastRadio);
            this.groupBox1.Location = new System.Drawing.Point(93, 459);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ModificationType";
            // 
            // UI_ContrastRadio
            // 
            this.UI_ContrastRadio.AutoSize = true;
            this.UI_ContrastRadio.Checked = true;
            this.UI_ContrastRadio.Location = new System.Drawing.Point(6, 32);
            this.UI_ContrastRadio.Name = "UI_ContrastRadio";
            this.UI_ContrastRadio.Size = new System.Drawing.Size(64, 17);
            this.UI_ContrastRadio.TabIndex = 0;
            this.UI_ContrastRadio.TabStop = true;
            this.UI_ContrastRadio.Text = "Contrast";
            this.UI_ContrastRadio.UseVisualStyleBackColor = true;
            this.UI_ContrastRadio.CheckedChanged += new System.EventHandler(this.UI_ContrastRadio_CheckedChanged);
            // 
            // UI_BWRadio
            // 
            this.UI_BWRadio.AutoSize = true;
            this.UI_BWRadio.Location = new System.Drawing.Point(6, 64);
            this.UI_BWRadio.Name = "UI_BWRadio";
            this.UI_BWRadio.Size = new System.Drawing.Size(104, 17);
            this.UI_BWRadio.TabIndex = 1;
            this.UI_BWRadio.Text = "Black and White";
            this.UI_BWRadio.UseVisualStyleBackColor = true;
            this.UI_BWRadio.CheckedChanged += new System.EventHandler(this.UI_BWRadio_CheckedChanged);
            // 
            // UI_TintRadio
            // 
            this.UI_TintRadio.AutoSize = true;
            this.UI_TintRadio.Location = new System.Drawing.Point(145, 32);
            this.UI_TintRadio.Name = "UI_TintRadio";
            this.UI_TintRadio.Size = new System.Drawing.Size(43, 17);
            this.UI_TintRadio.TabIndex = 2;
            this.UI_TintRadio.Text = "Tint";
            this.UI_TintRadio.UseVisualStyleBackColor = true;
            this.UI_TintRadio.CheckedChanged += new System.EventHandler(this.UI_TintRadio_CheckedChanged);
            // 
            // UI_NoiseRadio
            // 
            this.UI_NoiseRadio.AutoSize = true;
            this.UI_NoiseRadio.Location = new System.Drawing.Point(145, 64);
            this.UI_NoiseRadio.Name = "UI_NoiseRadio";
            this.UI_NoiseRadio.Size = new System.Drawing.Size(52, 17);
            this.UI_NoiseRadio.TabIndex = 3;
            this.UI_NoiseRadio.Text = "Noise";
            this.UI_NoiseRadio.UseVisualStyleBackColor = true;
            this.UI_NoiseRadio.CheckedChanged += new System.EventHandler(this.UI_NoiseRadio_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(374, 459);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(247, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(596, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "100";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "|\"jpeg\"|*.jpg|\"png\"|*.png|\"bmp\"|*.bmp|\"All Files\"|*.*|";
            this.openFileDialog1.ShowHelp = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(490, 507);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "50";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 562);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UI_TransformButton);
            this.Controls.Add(this.UI_LoadButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Lab5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button UI_LoadButton;
        private System.Windows.Forms.Button UI_TransformButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton UI_NoiseRadio;
        private System.Windows.Forms.RadioButton UI_TintRadio;
        private System.Windows.Forms.RadioButton UI_BWRadio;
        private System.Windows.Forms.RadioButton UI_ContrastRadio;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
    }
}

