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
    public partial class frmPosition : Form
    {
        Modules.Settings settings = new Modules.Settings();
        public DataTable modules;
        public string position { get { return tbPosition.Text; } set { tbPosition.Text = value; } }
        public string posID { get { return lbPosID.Text; } set { lbPosID.Text = value; } }
        public frmPosition(frmSettings setting)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(position == "")
            {
                MessageBox.Show("Position field is empty.", "Field required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                if(posID != "")
                {
                    updatePosition();
                }
                else
                {
                    savePosition();
                }
            }
            getUpdate();
            loadModules();
        }

        private void frmPosition_Load(object sender, EventArgs e)
        {

        }

        public void loadModules(DataTable modules = null)
        {
            DataTable dt = settings.loadModules();
            dgPosition.Rows.Clear();
            if (modules == null)
            {
                position = "";
                posID = "";
                foreach (DataRow row in dt.Rows)
                {
                    dgPosition.Rows.Add(row["modules"]);
                }
            } else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgPosition.Rows.Add(dt.Rows[i]["modules"],modules.Rows[i]["permission"]);
                }
            }
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    if (Convert.ToBoolean(dgPosition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                    {
                        dgPosition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }
                    else
                    {
                        dgPosition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    }
                    break;
                default:
                    break;
            }
        }

        public void savePosition()
        {
            modules = new DataTable();
            modules.Columns.Add("modules", typeof(string));
            modules.Columns.Add("permission", typeof(Boolean));
            for (int i = 0; i < dgPosition.Rows.Count; i++)
            {
                modules.Rows.Add(dgPosition.Rows[i].Cells[0].Value.ToString().ToLower(), Convert.ToBoolean(dgPosition.Rows[i].Cells[1].Value));
            }
            if(settings.addPosition(position, modules) == true)
            {
                MessageBox.Show("Successfully added");
            }
        }

        public void updatePosition()
        {
            string query = "UPDATE tbl_position SET position = '" + position + "' ";
            for (int i = 0; i < dgPosition.Rows.Count; i++)
            {
                query += ", " + dgPosition.Rows[i].Cells[0].Value.ToString().ToLower() + " = " + Convert.ToBoolean(dgPosition.Rows[i].Cells[1].Value);
            }
            query += " WHERE posID = "+posID+" ";
            if(settings.updatePosition(query))
            {
                MessageBox.Show("Successfully updated.");
                this.Close();
            }

        }
    }
}
