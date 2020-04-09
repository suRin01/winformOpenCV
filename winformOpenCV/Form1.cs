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
using Microsoft.WindowsAPICodePack.Dialogs;

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
            if (!capture.Open(0))
            {
                MessageBox.Show("No cpature device");
                this.Close();
            }
            else
            {
                selectedFolderText.Text = AppDomain.CurrentDomain.BaseDirectory;

                FilterInfoCollection FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo filterInfo in FilterInfoCollection)
                    cameraList.Items.Add(filterInfo.Name);
                cameraList.SelectedIndex = 0;



                my_serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);

            }
        }
        private void Form1_FormClosing(object sender, EventArgs e)
        {
            stopCamera();
            if (file != null)
            {
                file.Dispose();
            }
        }

        //Dealing sercial IO Interupt 
        private string initPath()
        {
            return selectedFolderText.Text + "/" + DateTime.Now.ToString("yyyy-MM-dd-HHmmss");
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
            this.serialBox.AppendText(str + "\r\n");
            if (file == null)
            {
                file = new System.IO.StreamWriter(initPath() + ".log");
            }
            file.WriteLine(str);
            serialBox.SelectionStart = serialBox.Text.Length;
            serialBox.ScrollToCaret();
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
                if (cameraThread != null && cameraThread.IsAlive)
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
                if (writer.IsOpened())
                {
                    writer.Write(frame);
                }
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
                    stopCamera();
                }

                button1.Text = "Start";
            }
        }

        private void RECstart_Click(object sender, EventArgs e)
        {
            if (REC.Text.Equals("REC start"))
            {
                //string recSaveTargetDirectory = @"./REC/" + DateTime.Now.ToString("yyyy-MM-dd");
                //if (!System.IO.File.Exists(recSaveTargetDirectory))
                //{
                //    System.IO.Directory.CreateDirectory(recSaveTargetDirectory);
                //}
                string fileName = initPath() + "Rec.avi";
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


        private void folderSelectorButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog folderSector = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            if (folderSector.ShowDialog() == CommonFileDialogResult.Ok)
            {
                selectedFolderText.Text = folderSector.FileName;
            }

        }

        private void connectSerial_Click(object sender, EventArgs e)
        {
            if (my_serial.IsOpen)
            {
                my_serial.Close();
            }
            file = new System.IO.StreamWriter(initPath() + ".log");
            byte[] serial_send_data = new byte[8];
            string comport_str = "";
            if (serialDeviceList.Text != "")
            {
                my_serial.PortName = serialDeviceList.Text;
                comport_str = serialDeviceList.Text;
                my_serial.BaudRate = 115200;

                try
                {
                    my_serial.Open();
                    comport_str += "  " + "is Open !!";
                    serialBox.Text += comport_str + "\r\n";
                }
                catch
                {
                    MessageBox.Show("SEIRAL PORT CONNECTION FAIL |!");
                }
            }
        }

        private void stopPrinterButton_Click(object sender, EventArgs e)
        {
            if (my_serial.IsOpen)
            {
                my_serial.Write("M1");
            }
        }
    }
}
