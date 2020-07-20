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
    public partial class frmTerm : Form
    {
        Modules.Settings settings = new Modules.Settings();
        public string term { get { return cbTerm.Text; } set { cbTerm.Text = value; } }
        public string durations { get { return tbDuration.Text; } set { tbDuration.Text = value; } }
        public string termID { get { return lblTermID.Text; } set { lblTermID.Text = value; } }
       
        public frmTerm(frmSettings frm)
        {
            InitializeComponent();
            fsettings = frm;
        }
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEvenHandler;
        frmSettings fsettings;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



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
            if(term != "" && durations != "")
            {
                if(termID != "")
                {
                    if (settings.updateTerm(Convert.ToInt16(termID), term, durations) == true)
                    {
                        MessageBox.Show("Successfully updated the data.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                } else
                {
                    if (settings.addTerm(term, durations))
                    {
                        MessageBox.Show("Successfully added to term list.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                getUpdate();
            } else
            {
                MessageBox.Show("Please fill up the fields required.", "Term/durations empty!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            term = "";
            durations = "";
            termID = "";
        }

        private void tbDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
