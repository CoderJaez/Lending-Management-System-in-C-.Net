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
    public partial class frmUserReg : Form
    {
        Modules.user users = new Modules.user();
        public Boolean isUpdate { get; set; }
        public Boolean isCameraSelected { get; set; }
        public Boolean isUploadSelected { get; set; }
        private Boolean isImageCaptured = false;
        public string userID { get { return lblUserID.Text; } set { lblUserID.Text = value; } }
        public string fname { get { return tbFname.Text; } set { tbFname.Text = value; } }
        public string mi { get { return tbMI.Text; } set { tbMI.Text = value; } }
        public string lname { get { return tbLname.Text; } set { tbLname.Text = value; } }
        public string dob { get { return dpDob.Value.ToString("yyyy/MM/dd"); } set { } }
        public string contact { get { return tbCpno.Text; } set { tbCpno.Text = value; } }
        public string address { get { return tbAddress.Text; } set { tbAddress.Text = value; } }
        public string uname { get { return tbUname.Text; } set { tbUname.Text = value; } }
        public string pass { get { return tbPass.Text; } set { tbConfirmPass.Text = value; } }
        public string Cpass { get { return tbConfirmPass.Text; } set { tbConfirmPass.Text = value; } }
        public string gender { get { return cbGender.Text; } set { cbGender.Text = value; } }
        public int posID { get { return Convert.ToInt32(cbPosition.SelectedValue); } set { cbPosition.SelectedValue = value; } }
        public byte[] userImage { get; set; }
        public Image userPicture { get { return img.Image; } set { img.Image = value; } }



        public frmUserReg(frmSettings setting)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *.png) | *.jpg; *.jpeg; *.bmp; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                img.Image = new Bitmap(openFileDialog.FileName);
                isUploadSelected = true;
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            img.Image = Properties.Resources.Manager_96px;
        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            frmCamera cam = new frmCamera();
            cam.user = this;
            cam.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            users.memID = userID;
            users.fname = fname;
            users.lname = lname;
            users.mi = mi;
            users.dob = dob;
            users.contact = contact;
            users.address = address;
            users.uname = uname;
            users.pass = pass;
            users.gender = gender;
            users.posID = posID;

            
            if(validateUser())
            {
                if (validatePass())
                {
                    if (isCameraSelected)
                    {
                        MemoryStream mstream = new MemoryStream();
                        img.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        users.arrayImage = mstream.GetBuffer();
                        mstream.Close();
                        isImageCaptured = true;
                    }

                    if(isUploadSelected)
                    {
                        MemoryStream mstream = new MemoryStream();
                        img.Image.Save(mstream, img.Image.RawFormat);
                        users.arrayImage = mstream.GetBuffer();
                        mstream.Close();
                        isImageCaptured = true;
                    }


                    if (isUpdate == false)
                    {
                       if(isImageCaptured)
                        {
                            if (users.isDuplicateUser())
                                return;
                            if (users.AddUser())
                            {
                                MessageBox.Show("Success");
                                clearForm();
                                getUpdate();
                            }
                        } else
                        {
                            MessageBox.Show("Please upload a picture.", "No picture.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        if (users.isDuplicateUser())
                            return;
                        if (users.updateUser())
                        {
                            if (isImageCaptured)
                            {
                                users.updateUserImage();
                            }
                            if(tbPass.Text != ""  && tbConfirmPass.Text != "")
                            {
                                if (validatePass())
                                {
                                    users.updateUserAcc();
                                }
                            }
                            MessageBox.Show("Success");
                            clearForm();
                            this.Close();
                        }
                        getUpdate();
                    }
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
            uname = "";
            pass = "";
            Cpass = "";
            img.Image = Properties.Resources.Manager_96px;
            userID = users.getMemID();
            tbLname.Focus();
        }

        private Boolean validateUser()
        {
            if(tbFname.Text != "" || tbLname.Text != "" || tbCpno.Text != "" || tbAddress.Text != "" || tbUname.Text !=""  || tbPass.Text != "" || tbConfirmPass.Text !="" )
            {
              return true;

            }
            MessageBox.Show("Please fill up all the fields required", "Some fields are empty.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private Boolean validatePass()
        {
            if(tbPass.Text != tbConfirmPass.Text)
            {
                MessageBox.Show("Password do not matched!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public void loadPosition()
        {
            cbPosition.DisplayMember = "Text";
            cbPosition.ValueMember = "Value";
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            

            foreach (DataRow row in users.loadPosition().Rows)
            {
                dt.Rows.Add(row["position"].ToString().ToUpper(), row["posID"]);
            }

            cbPosition.DataSource = dt;
        }

        private void frmUserReg_Load(object sender, EventArgs e)
        {
        }

        private void tbCpno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        public void loadUserInfo()
        {
            users.memID = userID;
            DataTable dt = users.loadUserInfo();
            foreach (DataRow userInfo in dt.Rows)
            {
                fname = userInfo["fname"].ToString();
                mi = userInfo["mi"].ToString();
                lname = userInfo["lname"].ToString();
                gender = userInfo["gender"].ToString();
                dpDob.Value = Convert.ToDateTime(userInfo["dob"].ToString());
                address = userInfo["address"].ToString();
                contact = userInfo["contact"].ToString();
                uname = userInfo["uname"].ToString();
                cbPosition.SelectedValue = (int)userInfo["posID"];
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

        //EventHandler for AREA
      
    }
}
