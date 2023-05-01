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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBox2 = new ComboBox();
            button7 = new Button();
            button8 = new Button();
            comboBox3 = new ComboBox();
            label6 = new Label();
            button9 = new Button();
            trackBar1 = new TrackBar();
            label7 = new Label();
            textBox4 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1026, 130);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(62, 39);
            button1.TabIndex = 0;
            button1.Text = "Start recording";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1378, 130);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(63, 39);
            button2.TabIndex = 1;
            button2.Text = "Stop recording";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(1113, 271);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(58, 39);
            button3.TabIndex = 2;
            button3.Text = "Play";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1307, 270);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(62, 39);
            button4.TabIndex = 3;
            button4.Text = "Stop playback";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(12, 322);
            button5.Margin = new Padding(4, 5, 4, 5);
            button5.Name = "button5";
            button5.Size = new Size(161, 39);
            button5.TabIndex = 4;
            button5.Text = "Start webcam";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(486, 234);
            button6.Margin = new Padding(4, 5, 4, 5);
            button6.Name = "button6";
            button6.Size = new Size(162, 39);
            button6.TabIndex = 5;
            button6.Text = "Take Snapshot";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // videoSourcePlayer1
            // 
            videoSourcePlayer1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            videoSourcePlayer1.BackColor = Color.FromArgb(0, 0, 0);
            videoSourcePlayer1.Location = new Point(3, 13);
            videoSourcePlayer1.Margin = new Padding(4);
            videoSourcePlayer1.Name = "videoSourcePlayer1";
            videoSourcePlayer1.Size = new Size(396, 286);
            videoSourcePlayer1.TabIndex = 5;
            videoSourcePlayer1.Text = "videoSourcePlayer1";
            videoSourcePlayer1.VideoSource = null;
            videoSourcePlayer1.NewFrame += videoSourcePlayer1_NewFrame_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1188, 89);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(79, 31);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1133, 229);
            textBox2.Margin = new Padding(4, 5, 4, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(220, 31);
            textBox2.TabIndex = 8;
            textBox2.Text = "filename for playback";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(449, 193);
            textBox3.Margin = new Padding(4, 5, 4, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(220, 31);
            textBox3.TabIndex = 9;
            textBox3.Text = "filename to save webcam";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(92, 407);
            comboBox1.Margin = new Padding(4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(203, 33);
            comboBox1.TabIndex = 10;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = null;
            pictureBox2.Location = new Point(469, 13);
            pictureBox2.Margin = new Padding(4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(200, 132);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1157, 199);
            label1.Name = "label1";
            label1.Size = new Size(185, 25);
            label1.TabIndex = 12;
            label1.Text = "Filename for playback";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1133, 60);
            label2.Name = "label2";
            label2.Size = new Size(191, 25);
            label2.TabIndex = 13;
            label2.Text = "Filename for recording";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(454, 166);
            label3.Name = "label3";
            label3.Size = new Size(215, 25);
            label3.TabIndex = 14;
            label3.Text = "Filename to save webcam";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(119, 378);
            label4.Name = "label4";
            label4.Size = new Size(164, 25);
            label4.TabIndex = 15;
            label4.Text = "Select your Camera";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(92, 459);
            label5.Name = "label5";
            label5.Size = new Size(209, 25);
            label5.TabIndex = 16;
            label5.Text = "Select your Audio Device";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(92, 495);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(209, 33);
            comboBox2.TabIndex = 17;
            // 
            // button7
            // 
            button7.Location = new Point(233, 322);
            button7.Name = "button7";
            button7.Size = new Size(147, 39);
            button7.TabIndex = 18;
            button7.Text = "Stop webcam";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(1001, 229);
            button8.Name = "button8";
            button8.Size = new Size(116, 34);
            button8.TabIndex = 19;
            button8.Text = "choose file";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(321, 407);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(182, 33);
            comboBox3.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(321, 379);
            label6.Name = "label6";
            label6.Size = new Size(171, 25);
            label6.TabIndex = 21;
            label6.Text = "Select sampling rate";
            // 
            // button9
            // 
            button9.Location = new Point(1205, 271);
            button9.Margin = new Padding(4, 5, 4, 5);
            button9.Name = "button9";
            button9.Size = new Size(62, 39);
            button9.TabIndex = 22;
            button9.Text = "pause";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(1052, 318);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(329, 69);
            trackBar1.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1079, 362);
            label7.Name = "label7";
            label7.Size = new Size(0, 25);
            label7.TabIndex = 26;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1012, 362);
            textBox4.Margin = new Padding(4, 5, 4, 5);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(119, 31);
            textBox4.TabIndex = 27;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1454, 580);
            Controls.Add(textBox4);
            Controls.Add(label7);
            Controls.Add(trackBar1);
            Controls.Add(button9);
            Controls.Add(label6);
            Controls.Add(comboBox3);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(comboBox2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
            Controls.Add(videoSourcePlayer1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "BatSpeak";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox2;
        private Button button7;
        private Button button8;
        private ComboBox comboBox3;
        private Label label6;
        private Button button9;
        private TrackBar trackBar1;
        private Label label7;
        private TextBox textBox4;
        private System.CodeDom.CodeTypeReference chart2;
        private System.CodeDom.CodeTypeReference chart1;
        private System.CodeDom.CodeTypeReference chart3;
    }
}