using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lending_Management_System
{
    public partial class frmInterest : Form
    {
        Modules.Settings settings = new Modules.Settings();
        public string intID { get { return lblIntID.Text; } set { lblIntID.Text = value; } }
        public string interest { get { return tbInterest.Text; } set { tbInterest.Text = value; } }
        public frmInterest(frmSettings settings)
        {
            InitializeComponent();
            fsettings = settings;
        }
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEvenHandler;
        frmSettings fsettings;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        public void getUpdate()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEvenHandler?.Invoke(this, args);
        }
        private void btnCloseAreaForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(interest != "")
            {
                if(intID != "")
                {
                    if(settings.updateInterest(Convert.ToInt32(intID),Convert.ToDouble(interest)))
                    {
                        MessageBox.Show("Successfully updated!", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    if (settings.addInterest(Convert.ToDouble(interest)))
                    {
                        MessageBox.Show("Successfully added!", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                getUpdate();
            } else
            {
                MessageBox.Show("Please fill out the field!", "Interest field is empty.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void tbInterest_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            intID = "";
            interest = "";
        }
    }
}
