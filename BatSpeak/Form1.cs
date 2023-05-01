using System.Collections;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using AForge.Video;
using AForge.Video.FFMPEG;
using AForge.Video.DirectShow;
using System.IO;
using System.IO.Ports;
using System.Globalization;
using System.Net;
using AForge.Controls;
//using VisioForge.Libs.NAudio.Wave;
using NAudio.Wave;

//using Microsoft.VisualBasic.Devices;

using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using PlaybackState = NAudio.Wave.PlaybackState;

using File = System.IO.File;
using NAudio.Gui;
using PictureBox = System.Windows.Forms.PictureBox;

using WaveInEvent = NAudio.Wave.WaveInEvent;
using WaveFormat = NAudio.Wave.WaveFormat;
using BufferedWaveProvider = NAudio.Wave.BufferedWaveProvider;
using WaveInEventArgs = NAudio.Wave.WaveInEventArgs;
using WaveFileWriter = NAudio.Wave.WaveFileWriter;
using WaveIn = NAudio.Wave.WaveIn;
using WaveInCapabilities = NAudio.Wave.WaveInCapabilities;
using WaveOut = NAudio.Wave.WaveOut;
using WaveFileReader = NAudio.Wave.WaveFileReader;
using WaveStream = NAudio.Wave.WaveStream;
using System.Windows.Forms.DataVisualization;
//Microsoft.Windows.SDK.Contracts

namespace BatSpeak
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        //private FilterInfoCollection audioDevices;
        private System.Windows.Forms.Timer timer;
        private VideoCaptureDevice videoDevice;
        private WaveStream audioStream;
        private int bufferSize = 65536;
        private VideoCapabilities[] snapshotCapabilities;
        private ArrayList listCamera = new ArrayList();
        private ArrayList listAudio = new ArrayList();
        private WaveInEvent audioDevice;
        public string pathFolder = Application.StartupPath + @"\ImageCapture\";
        //private string video=Application.StartupPath + @"\video\";
        //private string Audio= Application.StartupPath + @"\Audio\";
        private Stopwatch stopWatch = null;
        private static bool needSnapshot = false;
        private VideoFileWriter videoWriter;
        private WaveFileWriter audioWriter;
        private bool recording = false;
        private BufferedWaveProvider bufferedWaveProvider;
        //private string mediafolderPath = Application.StartupPath + @"\Media\";
        // private WaveOutEvent waveOut ;
        private WaveOut waveOut;
        private SoundPlayer player;
        private string audioFileName;
        private string mediafolderPath;
        private string audio_Path;
        private int samplingRate;
        private AudioFileReader audioFileReader;
        private WaveViewer waveViewer;

        //private WaveViewer waveViewer1;

        public Form1()
        {
            InitializeComponent();
            getListCameraUSB();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            trackBar1.MouseClick += trackBar1_MouseClick;
            trackBar1.Scroll += trackBar1_Scroll;


        }



        private static string _usbcamera;


        public string usbcamera
        {
            get { return _usbcamera; }
            set { _usbcamera = value; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(
           string lpstrCommand,
           string lpstrReturnString,
           int uReturnLength,
           int hwndCallback);
        private void button1_Click(object sender, EventArgs e)
        {
            mciSendString("open new type WAVEAudio alias recsound", "", 0, 0);
            mciSendString("record recsound", "", 0, 0);
            startRecording();

        }



        private void button2_Click(object sender, EventArgs e)
        {
            mciSendString("stop recsound", "", 0, 0);
            mciSendString("save recsound D://temp.wav", "", 0, 0);
            mciSendString("close recsound", "", 0, 0);
            stopRecording();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            startplayback();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            needSnapshot = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stopplayback();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenCamera();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CloseCurrentVideoSource();

        }


        private void button8_Click(object sender, EventArgs e)
        {
            selectfile();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pausePlayback();
        }

        private void OpenCamera()
        {
            try
            {
                usbcamera = comboBox1.SelectedIndex.ToString();
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count != 0)
                {
                    // add all devices to combo
                    foreach (FilterInfo device in videoDevices)
                    {
                        listCamera.Add(device.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Camera devices found");
                }



                videoDevice = new VideoCaptureDevice(videoDevices[Convert.ToInt32(usbcamera)].MonikerString);

                snapshotCapabilities = videoDevice.SnapshotCapabilities;
                if (snapshotCapabilities.Length == 0)
                {
                    //MessageBox.Show("Camera Capture Not supported");
                }
                OpenVideoSource(videoDevice);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //Delegate Untuk Capture, insert database, update ke grid 
        public delegate void CaptureSnapshotManifast(Bitmap image);
        public void UpdateCaptureSnapshotManifast(Bitmap image)
        {
            try
            {
                needSnapshot = false;
                pictureBox2.Image = image;
                pictureBox2.Update();

                string namaImage = "sampleImage";
                string nameCapture = namaImage + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bmp";
                if (Directory.Exists(pathFolder))
                {
                    pictureBox2.Image.Save(pathFolder + nameCapture, ImageFormat.Bmp);
                }
                else
                {
                    Directory.CreateDirectory(pathFolder);
                    pictureBox2.Image.Save(pathFolder + nameCapture, ImageFormat.Bmp);
                }
            }
            catch { }
        }
        public void OpenVideoSource(IVideoSource source)
        {
            try
            {
                // set busy cursor
                this.Cursor = Cursors.WaitCursor;
                // stop current video source
                CloseCurrentVideoSource();
                // start new video source
                videoSourcePlayer1.VideoSource = source;
                videoSourcePlayer1.Start();
                // reset stop watch
                stopWatch = null;
                this.Cursor = Cursors.Default;
            }
            catch { }
        }
        private void getListCameraUSB()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count != 0)
            {
                // add all devices to combo
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
            }
            else
            {
                comboBox1.Items.Add("No DirectShow devices found");
            }
            comboBox1.SelectedIndex = 0;

            //Adding all the available Audio devices to ComboBox2
            for (int deviceIndex = 0; deviceIndex < WaveIn.DeviceCount; deviceIndex++)
            {
                WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(deviceIndex);
                comboBox2.Items.Add(deviceInfo.ProductName);
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }

            comboBox3.Items.Add("44100");
            comboBox3.Items.Add("48000");
            comboBox3.Items.Add("96000");
            comboBox3.Items.Add("192000");
            comboBox3.Items.Add("256000");
            comboBox3.Items.Add("384000");

            comboBox3.SelectedIndex = 0;


        }




        public void CloseCurrentVideoSource()
        {
            try
            {
                if (videoSourcePlayer1.VideoSource != null)
                {
                    videoSourcePlayer1.SignalToStop();
                    // wait ~ 3 seconds
                    for (int i = 0; i < 30; i++)
                    {
                        if (!videoSourcePlayer1.IsRunning)
                            break;
                        System.Threading.Thread.Sleep(100);
                    }
                    if (videoSourcePlayer1.IsRunning)
                    {
                        videoSourcePlayer1.Stop();
                    }
                    videoSourcePlayer1.VideoSource = null;
                }
            }
            catch { }
        }

        private void videoSourcePlayer1_NewFrame_1(object sender, ref Bitmap image)
        {
            try
            {
                DateTime now = DateTime.Now;
                Graphics g = Graphics.FromImage(image);
                // paint current time
                SolidBrush brush = new SolidBrush(Color.Red);
                g.DrawString(now.ToString(), this.Font, brush, new PointF(5, 5));
                brush.Dispose();
                if (needSnapshot)
                {
                    this.Invoke(new CaptureSnapshotManifast(UpdateCaptureSnapshotManifast), image);
                }
                g.Dispose();
            }
            catch
            { }
        }

        private void startRecording()
        {
            //mediafolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BatSpeak-master", "BatSpeak", "Media");
            mediafolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "audiorecord");

            audio_Path = Path.Combine(mediafolderPath, "Audio");
            //string video_Path = Path.Combine(mediafolderPath, "Video");
            // string audiofolderPath = Path.Combine(Application.StartupPath, "Media", "Audio");
            string audiofolderPath = Path.Combine(Application.StartupPath, "audiorecord", "Audio");
            if (!Directory.Exists(mediafolderPath))
            {
                Directory.CreateDirectory(mediafolderPath);
            }
            if (!Directory.Exists(audio_Path))
            {
                Directory.CreateDirectory(audio_Path);
            }

            if (audioDevice != null)
            {
                audioDevice.StopRecording();
                audioDevice.Dispose();
            }

            samplingRate = int.Parse(comboBox3.SelectedItem.ToString());
            audioDevice = new WaveInEvent();
            audioDevice.DeviceNumber = comboBox2.SelectedIndex;
            audioDevice.WaveFormat = new WaveFormat(samplingRate, 1);
            audioDevice.BufferMilliseconds = (int)((double)bufferSize / (double)audioDevice.WaveFormat.AverageBytesPerSecond * 1000.0);
            bufferedWaveProvider = new BufferedWaveProvider(audioDevice.WaveFormat);

            audioDevice.DataAvailable += new EventHandler<WaveInEventArgs>(WaveIn_DataAvailable);
            //string textbox1 = textBox1.Text;
            audioFileName = Path.Combine(audio_Path, DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") + ".wav");
            audioWriter = new WaveFileWriter(audioFileName, audioDevice.WaveFormat);

            waveViewer = new WaveViewer();
            waveViewer.Dock = DockStyle.Fill;


            audioDevice.StartRecording();



            // string videofolderPath= Path.Combine(video_Path, "Video");
            //videoDevice = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
            //videoDevice.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            //videoDevice.Start();
            //string video = Path.Combine(video_Path, DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".avi");
            //// video = Path.Combine(Application.StartupPath, "Videos", "video.avi");
            //videoWriter = new VideoFileWriter();
            //videoWriter.Open(video, pictureBox1.Width, pictureBox1.Height, 25, VideoCodec.MPEG4);

        }


        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (audioWriter != null)
            {
                audioWriter.Write(e.Buffer, 0, e.BytesRecorded);
                audioWriter.Flush();
            }
        }


        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmap;
            if (videoWriter != null && videoWriter.IsOpen)
            {
                videoWriter.WriteVideoFrame(bitmap);
            }
        }


        private void stopRecording()
        {
            //audioDevice.StopRecording();

            if (audioDevice != null)
            {
                audioDevice.StopRecording();
                audioDevice.Dispose();
                audioDevice = null;
            }

            if (audioWriter != null)
            {
                audioWriter.Flush();
                audioWriter.Dispose();
                audioWriter = null;

            }




            //if (File.Exists(Audio))
            //{
            //    var audioFileName = Path.GetFileName(Audio);
            //    var destAudioFilePath = Path.Combine(Application.StartupPath, audioFileName);
            //    File.Move(Audio, destAudioFilePath);
            //}




            //if (videoDevice != null && videoDevice.IsRunning)
            //{
            //    videoDevice.SignalToStop();
            //    videoDevice.WaitForStop();

            //    videoWriter.Close();
            //    videoWriter.Dispose();
            //}


        }






        private void selectfile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "WAV files (*.wav)|*.wav";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                }
                if (audioStream != null)
                {
                    audioStream.Dispose();
                }
                textBox2.Text = openFileDialog.FileName;
                audioStream = new WaveFileReader(textBox2.Text);
                waveOut = new WaveOut();
                waveOut.Init(audioStream);



            }
        }
        private void playbackControl(string control)
        {

            switch (control)
            {
                case "play":
                    stopRecording();
                    Thread.Sleep(100);

                    if (audioStream != null)
                    {
                        if (waveOut == null)
                        {
                            waveOut = new WaveOut();
                            waveOut.Init(audioStream);
                        }
                        waveOut.Play();
                        timer.Start();
                    }
                    break;

                case "pause":
                    if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        waveOut.Pause();
                        timer.Stop();

                    }
                    break;

                case "stop":
                    if (audioStream != null)
                    {
                        audioStream.Position = 0;
                    }
                    if (player != null && player.IsLoadCompleted)
                    {
                        player.Stop();
                        player.Dispose();
                    }
                    if (waveOut != null)
                    {
                        if (waveOut.PlaybackState == PlaybackState.Playing || waveOut.PlaybackState == PlaybackState.Paused)
                        {
                            waveOut.Stop();
                        }
                        waveOut.Dispose();
                        waveOut = null;
                    }
                    timer.Stop();
                    trackBar1.Value = 0;
                    textBox4.Text = "00:00:00";
                    break;
            }
        }

        private void startplayback()
        {
            playbackControl("play");

        }

        private void stopplayback()
        {
            playbackControl("stop");


        }

        private void pausePlayback()
        {
            ;
            playbackControl("pause");

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (audioStream != null)
            {
                TimeSpan currentTime = TimeSpan.FromSeconds((double)audioStream.Position / audioStream.WaveFormat.AverageBytesPerSecond);
                TimeSpan totalTime = audioStream.TotalTime;
                textBox4.Text = string.Format("{0:mm\\:ss} / {1:mm\\:ss}", currentTime, totalTime);
                trackBar1.Maximum = (int)audioStream.Length;
                if (audioStream.Position < audioStream.Length)
                {
                    trackBar1.Value = (int)(audioStream.Position * trackBar1.Maximum / audioStream.Length);
                }
                else
                {
                    stopplayback();
                }
            }
        }

        private void trackBar1_MouseClick(object sender, MouseEventArgs e)
        {
            if (audioStream != null)
            {
                var pos = e.X * audioStream.Length / trackBar1.Width;
                audioStream.Position = pos;
                trackBar1.Value = (int)(pos * trackBar1.Maximum / audioStream.Length);
                startplayback();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (audioStream != null)
            {
                int pos = (int)(trackBar1.Value * audioStream.Length / trackBar1.Maximum);
                audioStream.Position = pos;
                startplayback();
            }
        }




    }



}







/*private void selectfile(object sender, WaveInEventArgs e)
{
    OpenFileDialog openFileDialog = new OpenFileDialog();
     openFileDialog.Filter = "WAV files (*.wav)|*.wav";
     if (openFileDialog.ShowDialog() == DialogResult.OK)
     {
         if (player != null)
         {
             player.Stop();
             player.Dispose();
         }
         textBox2.Text = openFileDialog.FileName;
         audioStream = new WaveFileReader(textBox2.Text);
         waveOut = new WaveOut();
         waveOut.Init(audioStream);


     }


}

private void startplayback(object sender, WaveInEventArgs e)
{
    if (textBox2.Text != "")
    {
        if (player != null)
        {
            player.Dispose();
        }

        player = new SoundPlayer();
        player.SoundLocation = textBox2.Text;

            player.Load();
            player.Play();
            timer.Start();


    }


}

private void stopplayback(object sender, WaveInEventArgs e)
{
    player.Stop();
    //audioStream.Position = 0;
    timer.Stop();
    trackBar1.Value = 0;
    textBox4.Text = "00:00:00";

    timer.Stop();

}

private void pausePlayback(object sender, WaveInEventArgs e)
{
    player.Stop();
}

private void Timer_Tick(object sender, EventArgs e)
{

    if (audioStream != null)
    {
        TimeSpan currentTime = TimeSpan.FromSeconds((double)audioStream.Position / audioStream.WaveFormat.AverageBytesPerSecond);
        TimeSpan totalTime = audioStream.TotalTime;
        textBox4.Text = string.Format("{0:mm\\:ss} / {1:mm\\:ss}", currentTime, totalTime);
        trackBar1.Maximum = (int)audioStream.Length;

        *//* if (audioStream.Position < audioStream.Length)
         {

             trackBar1.Value = (int)(audioStream.Position * trackBar1.Maximum / audioStream.Length);
             // textBox4.Text = TimeSpan.FromMilliseconds(audioStream.Position).ToString(@"hh\:mm\:ss");


         }
         else
         {
             stopplayback();
         }*//*
    }
}


private void trackBar1_MouseClick(object sender, MouseEventArgs e)
{
    if (audioStream != null)
    {
        var pos = e.X * audioStream.Length / trackBar1.Width;
        audioStream.Position = pos;
        trackBar1.Value = (int)(pos * trackBar1.Maximum / audioStream.Length);
    }
}

private void trackBar1_Scroll(object sender, EventArgs e)
{
    if (audioStream != null)
    {
        int pos = (int)(trackBar1.Value * audioStream.Length / trackBar1.Maximum);
        audioStream.Position = pos;
        if (player != null && player.IsLoadCompleted)
        {
            player.Play();
        }
    }
}*/
