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
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using AForge.Video;
using System.Diagnostics;
using AForge.Video.DirectShow;
//using AForge.Video.FFMPEG;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Globalization;
using System.Net;
using AForge.Controls;
using VisioForge.Libs.NAudio.Wave;
using VisioForge.Types;
using Microsoft.VisualBasic.Devices;
using VisioForge.Libs.WindowsMediaLib;
using System.Media;

namespace BatSpeak
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        //private FilterInfoCollection audioDevices;

        private VideoCaptureDevice videoDevice;

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
        //private VideoFileWriter videoWriter;
        private WaveFileWriter audioWriter;
        private bool recording = false;
        private BufferedWaveProvider bufferedWaveProvider;
        private string mediafolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BatSpeak", "BatSpeak", "Media");
        private WaveOutEvent waveOut;
        private SoundPlayer player;

        public Form1()
        {
            InitializeComponent();
            getListCameraUSB();
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
        }

        //private void getListAudioUSB()
        //{

        //}


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
            //string mediafolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BatSpeak-master", "BatSpeak", "Media");
            string audio_Path = Path.Combine(mediafolderPath, "Audio");
            string video_Path = Path.Combine(mediafolderPath, "Video");
            // string audiofolderPath= Path.Combine(Application.StartupPath, "Media", "Audio");
            if (!Directory.Exists(mediafolderPath))
            {
                Directory.CreateDirectory(mediafolderPath);
            }

            if (audioDevice != null)
            {
                audioDevice.StopRecording();
                audioDevice.Dispose();
            }


            audioDevice = new WaveInEvent();
            audioDevice.DeviceNumber = comboBox2.SelectedIndex;
            audioDevice.WaveFormat = new WaveFormat(44100, 1);
            audioDevice.BufferMilliseconds = (int)((double)bufferSize / (double)audioDevice.WaveFormat.AverageBytesPerSecond * 1000.0);
            bufferedWaveProvider = new BufferedWaveProvider(audioDevice.WaveFormat);
            audioDevice.DataAvailable += new EventHandler<WaveInEventArgs>(WaveIn_DataAvailable);
            //string textbox1 = textBox1.Text;
            string audioFileName = Path.Combine(audio_Path, DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") + ".wav");
            audioWriter = new WaveFileWriter(audioFileName, audioDevice.WaveFormat);
            audioDevice.StartRecording();

            //// string videofolderPath= Path.Combine(video_Path, "Video");
            //  videoDevice = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
            //  videoDevice.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            //  videoDevice.Start();
            //  string video= Path.Combine(video_Path, DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".avi");
            // // video = Path.Combine(Application.StartupPath, "Videos", "video.avi");
            //  videoWriter = new VideoFileWriter();
            //  videoWriter.Open(video, pictureBox1.Width, pictureBox1.Height, 25, VideoCodec.MPEG4);

        }


        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (audioWriter != null)
            {
                audioWriter.Write(e.Buffer, 0, e.BytesRecorded);
                audioWriter.Flush();
            }
        }


        //private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        //{
        //    Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
        //    pictureBox1.Image = bitmap;
        //    if (videoWriter != null && videoWriter.IsOpen)
        //    {
        //        videoWriter.WriteVideoFrame(bitmap);
        //    }
        //}


        private void stopRecording()
        {

            audioDevice.StopRecording();

            //audioDevice = null;

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

            //audioDevice.DeviceNumber = comboBox2.SelectedIndex;
            //audioDevice.WaveFormat = new WaveFormat(44100, 1);
            //audioDevice.BufferMilliseconds = (int)((double)bufferSize / (double)audioDevice.WaveFormat.AverageBytesPerSecond * 1000.0);
            //bufferedWaveProvider = new BufferedWaveProvider(audioDevice.WaveFormat);
            //audioDevice.DataAvailable += new EventHandler<WaveInEventArgs>(WaveIn_DataAvailable);


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
                textBox2.Text = openFileDialog.FileName;
            }
        }
        private void startplayback()
        {
            if (textBox2.Text != "")
            {
                if (player == null)
                {
                    player = new SoundPlayer();
                }
                player.SoundLocation = textBox2.Text;
                player.Play();
            }
        }


        private void stopplayback()
        {
            player.Stop();
        }


    }



}

