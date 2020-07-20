using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
namespace Lending_Management_System
{
    public partial class frmCamera : Form
    {
        VideoCaptureDevice camera;
        VideoCaptureDeviceForm cameraDevice = new VideoCaptureDeviceForm();
        Bitmap bmp;
        public frmUserReg user {get;set;}
        public frmCollector collector { get; set; }
        public frmBorrowerReg borrower { get; set; }
        public ucAccountSettings acc { get; set; }
        public frmCamera()
        {
            InitializeComponent();
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCamera_Load(object sender, EventArgs e)
        {
            openCamera();
        }

        private void openCamera()
        {
            if (cameraDevice.ShowDialog() == DialogResult.OK)
            {
                camera = cameraDevice.VideoDevice;
                camera.NewFrame += new NewFrameEventHandler(captureImage);
                camera.Start();

            }
        }

        private void captureImage(object sender, NewFrameEventArgs args)
        {
            bmp = (Bitmap)args.Frame.Clone();
            pictureBox1.Image = (Bitmap)args.Frame.Clone();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
            try
            {
                camera.Stop();

            }
            catch (Exception)
            {
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (btnCapture.Text == "Capture")
            {
                btnCapture.Text = "Start";
                camera.Stop();
            } else
            {
                btnCapture.Text = "Capture";
                camera.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(btnCapture.Text == "Start")
            {
                if (user != null)
                {
                    user.userPicture = pictureBox1.Image;
                    user.isCameraSelected = true;
                    user.isUploadSelected = false;
                    this.Close();
                }

                if (acc != null)
                {
                    acc.userPicture = pictureBox1.Image;
                    acc.isCameraSelected = true;
                    acc.isUploadSelected = false;
                    this.Close();
                }

                if (collector != null)
                {
                    collector.userPicture = pictureBox1.Image;
                    collector.isCameraSelected = true;
                    collector.isUploadSelected = false;
                    this.Close();
                }

                if (borrower != null)
                {
                    borrower.userPicture = pictureBox1.Image;
                    borrower.isCameraSelected = true;
                    borrower.isUploadSelected = false;
                    this.Close();
                }



            }
            
        }
    }
}
