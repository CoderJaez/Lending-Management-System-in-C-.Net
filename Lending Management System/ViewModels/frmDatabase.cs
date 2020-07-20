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
    public partial class frmDatabase : Form
    {
        public frmLogin login { get; set; }
        public frmDatabase()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validate_field())
            {
                Properties.Settings.Default.Server = ServerTxt.Text;
                Properties.Settings.Default.Username = UsernameTxt.Text;
                Properties.Settings.Default.Password = PasswordTxt.Text;
                Properties.Settings.Default.Database = DatabaseNameTxt.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Setup Database Configuration Success");
                this.Close();
                login.Show();
            }
        }

        private bool validate_field()
        {
            if (ServerTxt.Text != "" || UsernameTxt.Text != "" || DatabaseNameTxt.Text != "")
                return true;
            MessageBox.Show("Please fill up all the required fields.");
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            db_connect db = new db_connect();
            string conString = $"server= {ServerTxt.Text};user={UsernameTxt.Text};password={PasswordTxt.Text};database={DatabaseNameTxt.Text};";

            if (db.testConnectionDB(conString))
                MessageBox.Show("Database connected.");
            else
                MessageBox.Show("Database not connected.");

        }
    }
}
