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

namespace Lending_Management_System
{
    public partial class frmLogin : Form
    {
        private string uname;
        private string pass;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            user_auth();
        }

        private void user_auth()
        {
            if (checkFields())
                checkUser();
            else
                MessageBox.Show("Username/Password required.");

        }

        private bool checkFields()
        {
            uname = tbUname.Text;
            pass = tbPass.Text;
            if (uname != "" && pass != "")
                return true;
            return false;
        }

        private void checkUser()
        {
            user user = new user();
            if(user.CheckUser(uname,pass))
            {
                tbPass.Text = null;
                tbUname.Text = null;
                tbUname.Focus();
                MessageBox.Show("Login Successfull");
                frmMain main = new frmMain(user.getUserID());
                main.login = this;
                this.Visible = false;
                this.Hide();
                main.Show();
            }
            else
                MessageBox.Show("Incorrect Username/Password.");

        }

        private void tbUname_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.Enter)
                user_auth();
        }

        private void tbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                user_auth();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            db_connect db = new db_connect();
            if (!db.isConnected())
            {
                this.Visible = false;
                this.Hide();
                frmDatabase frmDB = new frmDatabase();
                frmDB.login = this;
                frmDB.ShowDialog();
            }
            tbUname.Focus();
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            frmDatabase frmDB = new frmDatabase();
            frmDB.login = this;
            frmDB.ShowDialog();
        }
    }
}
