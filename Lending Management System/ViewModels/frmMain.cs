using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lending_Management_System.Modules;
using System.IO;

namespace Lending_Management_System
{
    public partial class frmMain : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        frmLoadBorrowerList f = new frmLoadBorrowerList();
        frmSettings settings = new frmSettings();
        public frmLogin login { get; set; }
        private string UserID = null;
        public frmMain(string _userID)
        {
            UserID = _userID;
            InitializeComponent();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            usersPermissions();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            IsbuttonClicked(btnDashboard);
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
        frmLoanApplist loanList = new frmLoanApplist();
            IsbuttonClicked(btnLoan);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(loanList);
            loanList.Dock = DockStyle.Fill;
            //loanList.LoadLoanList();

        }
        public void updateImage(Image img)
        {

            UserImage.BackgroundImage = img;
        }

        private void btnPosting_Click(object sender, EventArgs e)
        {
        frmPosting posting = new frmPosting();
            IsbuttonClicked(btnPosting);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(posting);
            posting.Dock = DockStyle.Fill;
            //posting.loadCollectibles();

        }

        private void btnCollectibles_Click(object sender, EventArgs e)
        {
        frmCollectibles collectibles = new frmCollectibles();
            IsbuttonClicked(btnCollectibles);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(collectibles);
            collectibles.Dock = DockStyle.Fill;
            //collectibles.loadCollectibles();
        }

        private void btnRemittance_Click(object sender, EventArgs e)
        {
        frmRemittances remit = new frmRemittances();
            IsbuttonClicked(btnRemittance);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(remit);
            remit.Dock = DockStyle.Fill;
            //remit.loadRemittanceList();

        }

        private void btnBorrower_Click(object sender, EventArgs e)
        {
            IsbuttonClicked(btnBorrower);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.loadBorrowerList();
        }

        private void btnBAccounts_Click(object sender, EventArgs e)
        {
        frmBorrowerAcc bAcc = new frmBorrowerAcc();
            IsbuttonClicked(btnBAccounts);
            bAcc.loadAccounts();
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(bAcc);
            bAcc.Dock = DockStyle.Fill;

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmSummary summary = new frmSummary();
            IsbuttonClicked(btnReports);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(summary);
            summary.Dock = DockStyle.Fill;
        }

        private void btnPastdue_Click(object sender, EventArgs e)
        {
            frmPastDue pastDue = new frmPastDue();
            IsbuttonClicked(btnPastdue);
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(pastDue);
            pastDue.Dock = DockStyle.Fill;
            //pastDue.loadPastDueList();
            
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            IsbuttonClicked(btnSettings);
            MainPanel.Controls.Clear();
            settings.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(settings);

        }

        private void usersPermissions()
        {
            // SidebarPanel.Controls.Remove(btnReports);
            user u = new user();
            var user = u.GetUserPermission(UserID);
            UserName.Text = user.Name;
            MemoryStream ms = new MemoryStream(user.UserImage);
            UserImage.BackgroundImage = Image.FromStream(ms);
            //if (user.Dashboard)
            //    btnDashboard.Visible = true;
            if (user.Borrower)
                btnBorrower.Visible = true;
            if (user.Accounts)
                btnBAccounts.Visible = true;
            if (user.Loans)
                btnLoan.Visible = true;
            if (user.Posting)
                btnPosting.Visible = true;
            if (user.Collectibles)
                btnCollectibles.Visible = true;
            if (user.Remittance)
                btnRemittance.Visible = true;
            if (user.Pastdue)
                btnPastdue.Visible = true;
            if (user.Settings)
                btnSettings.Visible = true;
        }

        private void IsbuttonClicked(object sender)
        {
            foreach (Control p in SidebarPanel.Controls)
            {
                if (p.GetType() == typeof(Button))
                {
                    if(p == sender)
                    {
                        p.BackColor = Color.FromArgb(70, 146, 128);
                    } else
                    {
                        p.BackColor = Color.Transparent;
                    }
                    
                }
            }

        }

        private void btnMatureAcc_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show(); 
        }

        private void btnMyAccount_Click(object sender, EventArgs e)
        {
            ucAccountSettings acc = new ucAccountSettings();
            acc.main = this;
            acc.userID = UserID;
            acc.loadUserInfo();
            IsbuttonClicked(btnMyAccount);
            MainPanel.Controls.Clear();
            acc.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(acc);
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }



    public class MainPanel: Panel
    {
        public MainPanel()
        {
           // this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
    }
}
