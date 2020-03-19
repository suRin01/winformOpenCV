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
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        int isCameraRunning = 0;
        int isRecRunning = 0;
        OpenCvSharp.VideoWriter writer = new OpenCvSharp.VideoWriter();
        int codec = OpenCvSharp.VideoWriter.FourCC('M', 'J', 'P', 'G');
        double fps = 20.0;
        string filename = "./live.avi";
        

        
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
        public string GetDateTime()//시간 데이터 저장함수

        {
            DateTime NowDate = DateTime.Now;
            return NowDate.ToString("yyyy-MM-dd HH:mm:ss") + ":" + NowDate.Millisecond.ToString("000");
        }
        public void stopCamera(VideoCapture cam, VideoWriter videoWriter)
        {
            if (cam.IsOpened())
            {
                cam.Release();
                if (camera.IsAlive)
                {
                    camera.Abort();
                    camera.Join();
                }
                videoWriter.Release();
            }

        }
        public void startCamera(VideoCapture cam, int cameraIndex)
        {
            if (cam.IsDisposed)
            {
                cam.Release();


            }
        }

        private void CaptureCamera()
        {

            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }
        private void Form1_FormClosing(object sender, EventArgs e)
        {
            stopCamera(capture, writer);
        }

        private void CaptureCameraCallback()
        {
            frame = new Mat();
            capture = new VideoCapture();
            capture.Open(0);

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Start"))
            {
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
                string fileName = recSaveTargetDirectory + "/" + "rec.avi";
                REC.Text = "REC stop";
                isRecRunning = 1;
                writer.Open(fileName, codec, fps, frame.Size(), true);
            }
            else
            {
                if (capture.IsOpened())
                {
                    capture.Release();
                    writer.Release();
                }

                REC.Text = "REC start";
                isRecRunning = 0;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
