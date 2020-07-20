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

namespace Lending_Management_System.ViewModels
{
    public partial class frmAddress : Form
    {
        string locType;
        BorrowerModel borrower = new BorrowerModel();
        frmBorrowerReg frmBorrower;
        public frmAddress(frmBorrowerReg b)
        {
            frmBorrower = b;
            InitializeComponent();
        }

        public void loadLocation(string _locType, string code = null)
        {
            dgLocation.Columns.Clear();
            locType = _locType;
            switch (locType)
            {
                case "brgy":
                    lblDescription.Text = "Barangay";
                    dgLocation.DataSource = borrower.getBrgy(code);
                    break;
                case "citymun":
                    lblDescription.Text = "City/Municipality";
                    dgLocation.DataSource = borrower.getCityMun(code);
                    break;
                case "prov":
                    lblDescription.Text = "Province";
                    dgLocation.DataSource = borrower.getProvince();
                    break;
              
            }
           
                dgLocation.Columns["code"].Visible = false;
                dgLocation.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgLocation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (locType)
                {
                    case "brgy":
                        frmBorrower.brgyCode = dgLocation.Rows[e.RowIndex].Cells[0].Value.ToString();
                        frmBorrower.brgyDesc = dgLocation.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                    case "citymun":
                        frmBorrower.citymunCode = dgLocation.Rows[e.RowIndex].Cells[0].Value.ToString();
                        frmBorrower.citymunDesc = dgLocation.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                    case "prov":
                        frmBorrower.provCode = dgLocation.Rows[e.RowIndex].Cells[0].Value.ToString();
                        frmBorrower.provDesc = dgLocation.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                   
                }
                this.Close();
            }
        }

        private void dgLocation_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgLocation.Cursor = Cursors.Hand;
                dgLocation.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(184, 15, 10);
                dgLocation.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            }
        }

        private void dgLocation_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgLocation.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgLocation.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

       
    }
}
