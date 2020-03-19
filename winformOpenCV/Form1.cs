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
using System.Runtime.CompilerServices;

namespace winformOpenCV
{
    public partial class Form1 : Form
    {
        VideoCapture capture = new VideoCapture();
        VideoWriter writer = new VideoWriter();
        private Thread cameraThread;
        Mat frame;
        int selectedCameraIndex = 0;
        int isCameraRunning = 0;
        int isRecRunning = 0;
        

        
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
        }
        private void Form1_FormClosing(object sender, EventArgs e)
        {
            stopCamera();
        }
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

            while (isCameraRunning == 1)
            {
                capture.Read(frame);
                if (!frame.Empty())
                {
                    image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                    pictureBox1.Image = image;
                }
                if(isRecRunning == 1)
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
                if (capture.IsOpened())
                {
                    capture.Dispose();
                }
                selectedCameraIndex = cameraList.SelectedIndex;
                CaptureCamera();
                button1.Text = "Stop";
                isCameraRunning = 1;
            }
            else
            {
                if (capture.IsOpened())
                {
                    capture.Release();
                }

                button1.Text = "Start";
                isCameraRunning = 0;
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
                isRecRunning = 1;
            }
            else
            {
                if (writer.IsOpened())
                {
                    writer.Release();
                }

                REC.Text = "REC start";
                isRecRunning = 0;
            }
        }
    }
}
