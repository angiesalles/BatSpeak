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
            components = new System.ComponentModel.Container();
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
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            waveViewer1 = new NAudio.Gui.WaveViewer();
            comboBox4 = new ComboBox();
            pictureBox5 = new System.Windows.Forms.PictureBox();
            label8 = new Label();
            formsPlot1 = new ScottPlot.FormsPlot();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Image = Properties.Resources.icons8_record_85;
            button1.Location = new Point(863, 224);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(85, 85);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1102, 104);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(0, 0);
            button2.TabIndex = 1;
            button2.Text = "Stop recording";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.play;
            button3.Location = new Point(830, 467);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(35, 35);
            button3.TabIndex = 2;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Image = Properties.Resources.stop;
            button4.Location = new Point(986, 466);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(35, 35);
            button4.TabIndex = 3;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Image = Properties.Resources.video_on;
            button5.Location = new Point(2, 251);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(48, 48);
            button5.TabIndex = 4;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(389, 187);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(130, 31);
            button6.TabIndex = 5;
            button6.Text = "Take Snapshot";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // videoSourcePlayer1
            // 
            videoSourcePlayer1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            videoSourcePlayer1.BackColor = Color.FromArgb(0, 0, 0);
            videoSourcePlayer1.Location = new Point(2, 10);
            videoSourcePlayer1.Name = "videoSourcePlayer1";
            videoSourcePlayer1.Size = new Size(317, 229);
            videoSourcePlayer1.TabIndex = 5;
            videoSourcePlayer1.Text = "videoSourcePlayer1";
            videoSourcePlayer1.VideoSource = null;
            videoSourcePlayer1.NewFrame += videoSourcePlayer1_NewFrame_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(950, 71);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(64, 27);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(858, 427);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(177, 27);
            textBox2.TabIndex = 8;
            textBox2.Text = "filename for playback";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(359, 154);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(177, 27);
            textBox3.TabIndex = 9;
            textBox3.Text = "filename to save webcam";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(74, 326);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(163, 28);
            comboBox1.TabIndex = 10;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = null;
            pictureBox2.Location = new Point(375, 10);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(160, 106);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(864, 403);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
            label1.TabIndex = 12;
            label1.Text = "Filename for playback";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(906, 48);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(160, 20);
            label2.TabIndex = 13;
            label2.Text = "Filename for recording";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(363, 133);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(180, 20);
            label3.TabIndex = 14;
            label3.Text = "Filename to save webcam";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(95, 302);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(137, 20);
            label4.TabIndex = 15;
            label4.Text = "Select your Camera";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(964, 150);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(175, 20);
            label5.TabIndex = 16;
            label5.Text = "Select your Audio Device";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(964, 172);
            comboBox2.Margin = new Padding(2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(188, 28);
            comboBox2.TabIndex = 17;
            // 
            // button7
            // 
            button7.Image = Properties.Resources.video_off;
            button7.Location = new Point(280, 251);
            button7.Margin = new Padding(2);
            button7.Name = "button7";
            button7.Size = new Size(48, 48);
            button7.TabIndex = 18;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Image = Properties.Resources.selectfile;
            button8.Location = new Point(800, 423);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(35, 35);
            button8.TabIndex = 19;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(717, 172);
            comboBox3.Margin = new Padding(2);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(158, 28);
            comboBox3.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(719, 150);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(144, 20);
            label6.TabIndex = 21;
            label6.Text = "Select sampling rate";
            // 
            // button9
            // 
            button9.Image = Properties.Resources.pause;
            button9.Location = new Point(904, 467);
            button9.Margin = new Padding(3, 4, 3, 4);
            button9.Name = "button9";
            button9.Size = new Size(35, 35);
            button9.TabIndex = 22;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.DarkGray;
            trackBar1.LargeChange = 10;
            trackBar1.Location = new Point(839, 508);
            trackBar1.Margin = new Padding(2);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(263, 56);
            trackBar1.TabIndex = 24;
            trackBar1.TickStyle = TickStyle.None;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(858, 602);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 26;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.ButtonHighlight;
            textBox4.Location = new Point(839, 573);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(96, 27);
            textBox4.TabIndex = 27;
            textBox4.Text = "00:00:00";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.wave;
            pictureBox3.Location = new Point(677, 172);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(35, 35);
            pictureBox3.TabIndex = 28;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.mic_FILL0_wght400_GRAD0_opsz48;
            pictureBox4.Location = new Point(924, 172);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(35, 35);
            pictureBox4.TabIndex = 29;
            pictureBox4.TabStop = false;
            // 
            // waveViewer1
            // 
            waveViewer1.Location = new Point(18, 412);
            waveViewer1.Name = "waveViewer1";
            waveViewer1.SamplesPerPixel = 128;
            waveViewer1.Size = new Size(501, 119);
            waveViewer1.StartPosition = 0L;
            waveViewer1.TabIndex = 30;
            waveViewer1.WaveStream = null;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(858, 358);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(244, 28);
            comboBox4.TabIndex = 31;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.speaker;
            pictureBox5.Location = new Point(800, 351);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(35, 35);
            pictureBox5.TabIndex = 32;
            pictureBox5.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(875, 335);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(139, 20);
            label8.TabIndex = 33;
            label8.Text = "Select your Speaker";
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(58, 403);
            formsPlot1.Margin = new Padding(5, 4, 5, 4);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(668, 208);
            formsPlot1.TabIndex = 34;
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1163, 735);
            Controls.Add(formsPlot1);
            Controls.Add(label8);
            Controls.Add(pictureBox5);
            Controls.Add(comboBox4);
            Controls.Add(waveViewer1);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
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
            Name = "Form1";
            Text = "BatSpeak";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
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
        private System.CodeDom.CodeTypeReference chart3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.CodeDom.CodeTypeReference chart4;
        private NAudio.Gui.WaveViewer waveViewer1;
        private System.CodeDom.CodeTypeReference chart1;
        private ComboBox comboBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Label label8;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Timer timer1;
    }
}