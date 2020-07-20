using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lending_Management_System
{
    public partial class frmAccReg : Form
    {

        Modules.BorrowerModel b = new Modules.BorrowerModel();
        Modules.borrowerAcc bAcc = new Modules.borrowerAcc();
        Modules.Settings settings = new Modules.Settings();
        public frmBorrowerAcc frmAcc { get; set; }

       public string accNo { get { return lblAccNo.Text; } set { lblAccNo.Text = value; } }
        string borrowerNo { get { return lblAccNo.Tag.ToString(); } set { lblAccNo.Tag = value; } }
        
        int AccLimits { get; set; }
        //int borrowerNoAcc;
        
        public frmAccReg()
        {
            InitializeComponent();
        }

        private void frmAccReg_Load(object sender, EventArgs e)
        {
            //AccLimits = settings.LimitAcct();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCloseSearch_Click(object sender, EventArgs e)
        {
            SearchBorrower.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //loadBlist();
            SearchBorrower.Visible = true;
            bAcc.borrowerID = b.getBorrowerID();
            SearchBorrower.BringToFront();
        }


        private void loadBlist()
        {
            int no = 0;
            dgBList.Rows.Clear();
            int limit = b.totalRows();
            foreach (DataRow row in b.loadBorrowerList(0,limit).Rows)
            {
                dgBList.Rows.Add(no + 1, row["borrowerID"].ToString(), row["bname"].ToString());
                no++;
            }
        }


        private void loadBorrowerInfo()
        {
            b.borID = borrowerNo;
            foreach (DataRow userInfo in b.loadBorrowerInfo().Rows)
            {
                lblName.Text = userInfo["lname"].ToString() +", "+ userInfo["fname"].ToString() + " " + userInfo["mi"].ToString();
                lblAddress.Text = userInfo["address"].ToString();
                byte[] userImage = (byte[])userInfo["image"];
                try
                {
                    MemoryStream ms = new MemoryStream(userImage);
                    BorrowerImg.Image = Image.FromStream(ms);
                }
                catch (Exception)
                {
                    BorrowerImg.Image = Properties.Resources.Manager_96px;
                }

            }
        }

        private void dgBList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                borrowerNo = dgBList.Rows[e.RowIndex].Cells[1].Value.ToString();
                string name = dgBList.Rows[e.RowIndex].Cells[2].Value.ToString();
                bAcc.borrowerID = borrowerNo;
                loadBorrowerInfo();
                SearchBorrower.Visible = false;
                btnSave.Enabled = true;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bAcc.accID = bAcc.getAccID();
            bAcc.borrowerID = borrowerNo;
            if (bAcc.addAccount())
            {
                 MessageBox.Show("Account successfully created", "Zeustech Lending Systemr");
                clearForm();
                frmAcc.loadAccounts();
                btnSave.Enabled = false;
            }
        }

        private void clearForm()
        {
            accNo = bAcc.getAccID();
            lblName.Text = "";
            lblAddress.Text = "";
            BorrowerImg.Image = Properties.Resources.Manager_96px;

        }

        private void dgBList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                int no = 0;
                dgBList.Rows.Clear();
                int limit = b.totalRows();
                foreach (DataRow row in b.loadBorrowerList(0, limit, tbSearch.Text).Rows)
                {
                    dgBList.Rows.Add(no + 1, row["borrowerID"].ToString(), row["bname"].ToString());
                    no++;
                }
            }
        }
    }
}
