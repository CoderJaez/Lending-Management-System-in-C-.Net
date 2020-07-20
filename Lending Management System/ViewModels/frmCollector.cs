using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lending_Management_System
{
    public partial class frmCollector : Form
    {
        Modules.user users = new Modules.user();
        public Boolean isUpdate { get; set; }
        public Boolean isCameraSelected { get; set; }
        public Boolean isUploadSelected { get; set; }
        private Boolean isImageCaptured = false;
        public string memID { get { return lblCollectorID.Text; } set { lblCollectorID.Text = value; } }
        public string fname { get { return tbFname.Text; } set { tbFname.Text = value; } }
        public string mi { get { return tbMI.Text; } set { tbMI.Text = value; } }
        public string lname { get { return tbLname.Text; } set { tbLname.Text = value; } }
        public string dob { get { return dpDob.Value.ToString("yyyy/MM/dd"); } set { } }
        public string contact { get { return tbCpno.Text; } set { tbCpno.Text = value; } }
        public string address { get { return tbAddress.Text; } set { tbAddress.Text = value; } }
        public string gender { get { return cbGender.Text; } set { cbGender.Text = value; } }
        public byte[] userImage { get; set; }
        public Image userPicture { get { return img.Image; } set { img.Image = value; } }
      
        Modules.Settings settings = new Modules.Settings();

        public frmCollector(frmSettings setting)
        {
            InitializeComponent();
            fsetting = setting;
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEvenHandler;
        frmSettings fsetting;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        public void getUpdate()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEvenHandler?.Invoke(this, args);
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenCam_Click(object sender, EventArgs e)
        {
            frmCamera cam = new frmCamera();
            cam.collector = this;
            cam.ShowDialog();
        }

        private void btnBrowseImg_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *.png) | *.jpg; *.jpeg; *.bmp; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                img.Image = new Bitmap(openFileDialog.FileName);
                isUploadSelected = true;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            users.memID = memID;
            users.fname = fname;
            users.lname = lname;
            users.mi = mi;
            users.dob = dob;
            users.contact = contact;
            users.address = address;
            users.gender = gender;
            //users.areaID = areaID;


            if (validateUser())
            {
                if (isCameraSelected)
                {
                    MemoryStream mstream = new MemoryStream();
                    img.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    users.arrayImage = mstream.GetBuffer();
                    mstream.Close();
                    isImageCaptured = true;
                }
                else
                {
                    MemoryStream mstream = new MemoryStream();
                    img.Image.Save(mstream, img.Image.RawFormat);
                    users.arrayImage = mstream.GetBuffer();
                    mstream.Close();
                    isImageCaptured = true;
                }




                if (isUpdate == false)
                    {
                        if (isImageCaptured)
                        {
                            if (users.addCollector())
                            {
                                MessageBox.Show("Success");
                                clearForm();
                                getUpdate();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please upload a picture.", "No picture.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        if (users.updateCollector())
                        {
                            if (isImageCaptured)
                            {
                                users.updateUserImage();
                            }
                          
                            MessageBox.Show("Success","Vil Jame Lending Investor");
                            clearForm();
                            this.Close();
                        }
                        getUpdate();
                    }
                }
            }


        private void clearForm()
        {
            fname = "";
            mi = "";
            lname = "";
            contact = "";
            address = "";
            img.Image = Properties.Resources.Manager_96px;
            memID = users.getMemID();
            tbLname.Focus();
        }

        private Boolean validateUser()
        {
            if (tbFname.Text != "" || tbLname.Text != "" || tbCpno.Text != "" || tbAddress.Text != "")
            {
                return true;

            }
            MessageBox.Show("Please fill up all the fields required", "Some fields are empty.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        //public void loadArea()
        //{
            
        //    cbArea.DisplayMember = "Text";
        //    cbArea.ValueMember = "Value";
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Text");
        //    dt.Columns.Add("Value");

        //    foreach (DataRow row in settings.loadArea().Rows)
        //    {
        //        dt.Rows.Add(row["area"].ToString().ToUpper(), row["areaID"]);
        //    }

        //    cbArea.DataSource = dt;
        //}

        public void loadCollectorInfo()
        {
            users.memID = memID;
            DataTable dt = users.loadCollectorInfo();
            foreach (DataRow userInfo in dt.Rows)
            {
                fname = userInfo["fname"].ToString();
                mi = userInfo["mi"].ToString();
                lname = userInfo["lname"].ToString();
                gender = userInfo["gender"].ToString();
                dpDob.Value = Convert.ToDateTime(userInfo["dob"].ToString());
                address = userInfo["address"].ToString();
                contact = userInfo["contact"].ToString();
                //cbArea.SelectedValue = (int)userInfo["areaID"];
                userImage = (byte[])userInfo["image"];
                try
                {
                    MemoryStream ms = new MemoryStream(userImage);
                    userPicture = Image.FromStream(ms);
                }
                catch (Exception)
                {
                    userPicture = Properties.Resources.Manager_96px;
                }

            }
        }

        private void tbCpno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}




