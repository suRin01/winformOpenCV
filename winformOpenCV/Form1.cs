using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using OpenCvSharp;
using Accord.Video.DirectShow;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.IO;

namespace winformOpenCV
{
    public partial class Form1 : Form
    {
        //Variable for logger
        System.IO.StreamWriter file;
    
        //Variable for OpenCV
        VideoCapture capture = new VideoCapture();
        VideoWriter writer = new VideoWriter();
        private Thread cameraThread;
        Mat frame;
        int selectedCameraIndex = 0;

        //Variable for Serial IO
        SerialPort my_serial = new SerialPort();        // 시리얼 포트 변수 생성
        delegate void SetTextCallBack(string str);      // Callback 함수



        //Form construction, onLoad, destruction 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FilterInfoCollection FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in FilterInfoCollection)
                cameraList.Items.Add(filterInfo.Name);
            cameraList.SelectedIndex = 0;


            file = new System.IO.StreamWriter(initLogPath());
            my_serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
        }
        private void Form1_FormClosing(object sender, EventArgs e)
        {
            stopCamera();
        }

        //Dealing sercial IO Interupt 
        private string initLogPath()
        {
            string recSaveTargetDirectory = @"./Log/" + DateTime.Now.ToString("yyyy-MM-dd");
            if (!System.IO.File.Exists(recSaveTargetDirectory))
            {
                System.IO.Directory.CreateDirectory(recSaveTargetDirectory);
            }
            return recSaveTargetDirectory + "/" + DateTime.Now.ToString("HHmmss") + ".log";
        }

        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int i_recv_size = my_serial.BytesToRead;
            byte[] b_tmp_buf = new byte[i_recv_size];
            string recv_str = "";

            my_serial.Read(b_tmp_buf, 0, i_recv_size);
            recv_str = Encoding.Default.GetString(b_tmp_buf);
            this.BeginInvoke(new SetTextCallBack(display_data), new object[] { recv_str });
        }

        private void display_data(string str)
        {
            this.serialBox.AppendText(str);
            file.WriteLine(str);
        }

        //Dealing Camera Data
        public void startCamera(VideoCapture cam, int cameraIndex)
        {
            if (cam.IsDisposed)
            {
                cam.Release();
                cameraThread = new Thread(CaptureCameraCallback);
                cameraThread.Start();

            }
        }
        public void stopCamera()
        {
            if (capture.IsOpened())
            {
                capture.Release();
                if (cameraThread.IsAlive)
                {
                    cameraThread.Abort();
                    cameraThread.Join();
                }
                writer.Release();
            }
            if (writer.IsOpened())
            {
                writer.Release();
            }

        }

        private void CaptureCamera()
        {

            cameraThread = new Thread(new ThreadStart(CaptureCameraCallback));
            cameraThread.Start();
        }

        private void CaptureCameraCallback()
        {
            frame = new Mat();
            Bitmap image;
            capture.Open(selectedCameraIndex);

            while (capture.IsOpened())
            {
                capture.Read(frame);
                if (!frame.Empty())
                {
                    image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                    pictureBox1.Image = image;
                }
                if(writer.IsOpened())
                {
                    writer.Write(frame);
                }
                image = null;
            }

        }

        private void CaptureDeviceConnectButton_Click(object sender, EventArgs e)
        {

            if (button1.Text.Equals("Start"))
            {
                selectedCameraIndex = cameraList.SelectedIndex;
                CaptureCamera();
                button1.Text = "Stop";
            }
            else
            {
                if (capture.IsOpened())
                {
                    capture.Release();
                }

                button1.Text = "Start";
            }
        }

        private void RECstart_Click(object sender, EventArgs e)
        {
            if (REC.Text.Equals("REC start"))
            {
                string recSaveTargetDirectory = @"./REC/" + DateTime.Now.ToString("yyyy-MM-dd");
                if (!System.IO.File.Exists(recSaveTargetDirectory))
                {
                    System.IO.Directory.CreateDirectory(recSaveTargetDirectory);
                }
                string fileName = recSaveTargetDirectory + "/" + DateTime.Now.ToString("HHmmss") + "Rec.avi";
                int codec = VideoWriter.FourCC('M', 'J', 'P', 'G');
                double fps = 20.0;
                writer.Open(fileName, codec, fps, frame.Size(), true);
                REC.Text = "REC stop";
            }
            else
            {
                if (writer.IsOpened())
                {
                    writer.Release();
                }

                REC.Text = "REC start";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            display_data("hello world!");
        }
    }
}
