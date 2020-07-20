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
    public partial class frmArea : Form
    {
        string qry;
        Modules.Settings settings = new Modules.Settings();
        public string areaID { get { return lblareaID.Text; } set { lblareaID.Text = value; } }
        public string area { get { return tbArea.Text; } set { tbArea.Text = value; } }
        public string previousData { get; set; }

        public frmArea(frmSettings fsettings)
        {
            InitializeComponent();
            fsetting = fsettings;
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEvenHandler;
        frmSettings fsetting;

        public class UpdateEventArgs:EventArgs
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
                qry = "SELECT * FROM tbl_area WHERE isdelete = false AND area ='"+ area +"' ";
            if (area != "")
            {
                if (areaID == "")
                {
                    if ( settings.validate(qry) == true)
                    {
                        MessageBox.Show("The " + area + " is already registered.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else
                    {
                        if (settings.addArea(area) == true)
                        {
                            MessageBox.Show("Successfully added!", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        areaID = "";
                        area = "";
                        this.Close();
                    }

                }
                else
                {
                    if (area == previousData)
                    {
                        if (settings.updateArea(Convert.ToInt16(areaID), area) == true)
                        {
                            MessageBox.Show("Successfully updated!", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    } else
                    {
                        if (settings.validate(qry) == true)
                        {
                            MessageBox.Show("The " + area + " is already registered.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (settings.updateArea(Convert.ToInt16(areaID), area) == true)
                            {
                                MessageBox.Show("Successfully updated!", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            areaID = "";
                            area = "";
                        }


                    }
                    
                }
               
                getUpdate();

            } else
            {
                MessageBox.Show("Please fill out the field!", "Area field is empty.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            areaID = "";
            area = "";
        }
    }
}
