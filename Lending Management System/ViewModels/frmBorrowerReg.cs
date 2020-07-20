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
using Lending_Management_System.ViewModels;
namespace Lending_Management_System
{
    public partial class frmBorrowerReg : Form
    {
        Modules.BorrowerModel borrower = new Modules.BorrowerModel();
        Modules.Settings setinggs = new Modules.Settings();
        Modules.user users = new Modules.user();
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public frmLoadBorrowerList blist { get; set; }

        public Boolean isUpdate { get; set; }
        public Boolean isCameraSelected { get; set; }
        public Boolean isUploadSelected { get; set; }
        private Boolean isImageCaptured = false;
        public string borrowerID { get { return lblBorrowerNo.Text; } set { lblBorrowerNo.Text = value; } }
        public string fname { get { return tbFname.Text; } set { tbFname.Text = value; } }
        public string mi { get { return tbMI.Text; } set { tbMI.Text = value; } }
        public string lname { get { return tbLname.Text; } set { tbLname.Text = value; } }
        public string dob { get { return dpDob.Value.ToString("yyyy/MM/dd"); } set { } }
        public string contact { get { return tbContact.Text; } set { tbContact.Text = value; } }
        public string address { get { return tbAddress.Text; } set { tbAddress.Text = value; } }
        public string gender { get { return cbGender.Text; } set { cbGender.Text = value; } }
        public string occupation { get { return tbOccupation.Text; } set { tbOccupation.Text = value; } }
        public string brgyCode { get { return lblBrgy.Tag.ToString(); } set { lblBrgy.Tag = value; } }
        public string brgyDesc { get { return lblBrgy.Text; } set { lblBrgy.Text = value; } }
        public string citymunCode { get { return lblCityMun.Tag.ToString(); } set { lblCityMun.Tag = value; } }
        public string citymunDesc { get { return lblCityMun.Text; } set { lblCityMun.Text = value; } }
        public string provCode { get { return lblProv.Tag.ToString(); } set { lblProv.Tag = value; } }
        public string provDesc { get { return lblProv.Text; } set { lblProv.Text = value; } }
        public byte[] userImage { get; set; }
        public string memID { get; set; }
        public Image userPicture { get { return BorrowerImg.Image; } set { BorrowerImg.Image = value; } }
       
        Modules.Settings settings = new Modules.Settings();



        public frmBorrowerReg()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntOpenCam_Click(object sender, EventArgs e)
        {
            frmCamera cam = new frmCamera();
            cam.borrower = this;
            cam.ShowDialog();
        }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *.png) | *.jpg; *.jpeg; *.bmp; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                userPicture = new Bitmap(openFileDialog.FileName);
                isUploadSelected = true;
                isCameraSelected = false;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUser())
            {
                borrower.fname = fname;
                borrower.lname = lname;
                borrower.mi = mi;
                borrower.dob = dob;
                borrower.contact = contact;
                borrower.address = address;
                borrower.gender = gender;
                borrower.occupation = occupation;
                borrower.brgyCode = brgyCode;
                borrower.citymunCode = citymunCode;
                borrower.provCode = provCode;
                if (isCameraSelected)
                {
                    MemoryStream mstream = new MemoryStream();
                    BorrowerImg.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    borrower.arrayImage = mstream.GetBuffer();
                    mstream.Close();
                    isImageCaptured = true;
                } else
                {
                    MemoryStream mstream = new MemoryStream();
                    BorrowerImg.Image.Save(mstream, BorrowerImg.Image.RawFormat);
                    borrower.arrayImage = mstream.GetBuffer();
                    mstream.Close();
                    isImageCaptured = true;
                }


                if (isUpdate == false)
                {
                    borrower.memID = users.getMemID();
                    borrower.borID = borrower.getBorrowerID();

                    if (borrower.addBorrower() )
                        {
                            MessageBox.Show("Successfully added.", "Zeustech Lending System");
                            clearForm();
                        }

                }
                else
                {
                    if (borrower.updateBorrowerInfo())
                    {

                        if (isImageCaptured)
                            users.updateUserImage();
                        MessageBox.Show("Successfully updated", "Zeustech Lending System");
                        clearForm();
                        this.Close();
                    }
                }
                blist.loadBorrowerList();
            }
        }//END btnSave_Click();

        //public void loadCollector()
        //{

        //    cbCollector.DisplayMember = "Text";
        //    cbCollector.ValueMember = "Value";
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Text");
        //    dt.Columns.Add("Value");

        //    foreach (DataRow row in users.loadCollectorList().Rows)
        //    {
        //        dt.Rows.Add(row["name"].ToString().ToUpper(), row["collectorID"]);
        //    }

        //    cbCollector.DataSource = dt;
        //}


        private void clearForm()
        {
            fname = "";
            mi = "";
            lname = "";
            contact = "";
            address = "";
            brgyDesc = "";
            citymunDesc = "";
            provDesc = "";
            BorrowerImg.Image = Properties.Resources.Manager_96px;
            borrowerID = borrower.getBorrowerID();
            tbLname.Focus();
        }

        private bool validateUser()
        {
            if (tbFname.Text != "" && tbLname.Text != "" && tbContact.Text != "" && tbAddress.Text != "" && tbOccupation.Text != "" && provDesc !="" && citymunDesc != "" && provDesc != "")
            {
                return true;

            }
            MessageBox.Show("Please fill up all the fields required", "Zeustech Lending System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

     

        private void tbContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        public void borrowerInfo()
        {
            borrower.borID = borrowerID;
            foreach (DataRow userInfo in borrower.loadBorrowerInfo().Rows)
            {
                fname = userInfo["fname"].ToString();
                mi = userInfo["mi"].ToString();
                lname = userInfo["lname"].ToString();
                gender = userInfo["gender"].ToString();
                dpDob.Value = Convert.ToDateTime(userInfo["dob"].ToString());
                occupation = userInfo["occupation"].ToString();
                address = userInfo["address"].ToString();
                contact = userInfo["contact"].ToString();
                provCode = userInfo["provCode"].ToString();
                provDesc = userInfo["provDesc"].ToString();
                citymunCode = userInfo["citymunCode"].ToString();
                citymunDesc = userInfo["citymunDesc"].ToString();
                brgyCode = userInfo["brgyCode"].ToString();
                brgyDesc = userInfo["brgyDesc"].ToString();
                userImage = (byte[])userInfo["image"];
                try
                {
                    MemoryStream ms = new MemoryStream(userImage);
                    userPicture = Image.FromStream(ms);
                }
                catch (Exception )
                {
                    userPicture = Properties.Resources.Manager_96px;
                }

            }
        }

        private void btnProv_Click(object sender, EventArgs e)
        {
            frmAddress add = new frmAddress(this);
            add.loadLocation("prov");
            add.ShowDialog();
        }

        private void btnBrgy_Click(object sender, EventArgs e)
        {
            if (citymunDesc != "")
            {
                frmAddress add = new frmAddress(this);
                add.loadLocation("brgy",citymunCode);
                add.ShowDialog();
            }
            else
            {
                MessageBox.Show("City/Municipality field required.");
            }
        }

        private void btnCityMun_Click(object sender, EventArgs e)
        {
            if(provDesc != "")
            {
                frmAddress add = new frmAddress(this);
                add.loadLocation("citymun",provCode);
                add.ShowDialog();
            } else
            {
                MessageBox.Show("Province field required.");
            }
        }
    }
}
