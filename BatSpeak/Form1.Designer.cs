using AForge.Controls;

namespace BatSpeak
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            videoSourcePlayer1 = new VideoSourcePlayer();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            pictureBox2 = new AForge.Controls.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(528, 97);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(130, 31);
            button1.TabIndex = 0;
            button1.Text = "Start recording";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(529, 136);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(129, 31);
            button2.TabIndex = 1;
            button2.Text = "Stop recording";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(528, 200);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(130, 31);
            button3.TabIndex = 2;
            button3.Text = "Start playback";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(529, 239);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(129, 31);
            button4.TabIndex = 3;
            button4.Text = "Stop playback";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(529, 339);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(129, 31);
            button5.TabIndex = 4;
            button5.Text = "Start webcam";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(528, 377);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(130, 31);
            button6.TabIndex = 5;
            button6.Text = "Stop webcam";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // videoSourcePlayer1
            // 
            videoSourcePlayer1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            videoSourcePlayer1.BackColor = Color.FromArgb(0, 0, 0);
            videoSourcePlayer1.Location = new Point(12, 71);
            videoSourcePlayer1.Name = "videoSourcePlayer1";
            videoSourcePlayer1.Size = new Size(307, 229);
            videoSourcePlayer1.TabIndex = 5;
            videoSourcePlayer1.Text = "videoSourcePlayer1";
            videoSourcePlayer1.VideoSource = null;
            videoSourcePlayer1.NewFrame += videoSourcePlayer1_NewFrame_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(314, 97);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(177, 27);
            textBox1.TabIndex = 7;
            textBox1.Text = "filename for recording";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(314, 201);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(177, 27);
            textBox2.TabIndex = 8;
            textBox2.Text = "filename for playback";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(314, 339);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(177, 27);
            textBox3.TabIndex = 9;
            textBox3.Text = "filename to save webcam";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(331, 143);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(163, 28);
            comboBox1.TabIndex = 10;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = null;
            pictureBox2.Location = new Point(360, 258);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(89, 64);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 451);
            Controls.Add(pictureBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            this.Controls.Add(this.videoSourcePlayer1);
            Name = "Form1";
            Text = "BatSpeak";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private AForge.Controls.PictureBox pictureBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private AForge.Controls.PictureBox pictureBox2;
        private VideoSourcePlayer videoSourcePlayer1;
    }
}