using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lending_Management_System
{
    public partial class frmLoadBorrowerList : UserControl
    {
        Modules.BorrowerModel b = new Modules.BorrowerModel();
        Modules.Settings setinggs = new Modules.Settings();
        Modules.user u = new Modules.user();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }


        private int totalRows = 0;
        private int filteredRow = 0;
        private int start = 0;
        private int limit = 50;
        private int page = 1;

        public frmLoadBorrowerList()
        {
            InitializeComponent();
            //loadBorrowerList();
        }

        

        private void btnAddBorrower_Click(object sender, EventArgs e)
        {
            frmBorrowerReg frmReg = new frmBorrowerReg();
            frmReg.blist = this;
            //frmReg.memID = u.getMemID();
            //frmReg.borrowerID = b.getBorrowerID();
            //frmReg.loadCollector();
            frmReg.ShowDialog();
        }

        public void loadBorrowerList()
        {
            dgBList.Rows.Clear();
            int n = 0;
            foreach (DataRow row in b.loadBorrowerList(start,limit,tbSearch.Text).Rows)
            {
                dgBList.Rows.Add(n+start+1,row["borrowerID"].ToString(),row["bname"].ToString(),row["contact"].ToString(), row["dob"].ToString(),row["occupation"].ToString(), row["date_reg"].ToString());
                dgBList.Rows[n].Cells[1].Tag = row["memID"].ToString();
                n++;
            }


            if (tbSearch.Text == "")
            {
                totalRows = b.totalRows();
                lblPage.Text = $"{page}/{Math.Ceiling((double)totalRows / (double)limit)}";
                if (totalRows - start < limit)
                {
                    btnNext.Enabled = false;
                    lblEntries.Text = $"Showing {start + 1} to {totalRows} of {totalRows} entries";
                }
                else {
                    lblEntries.Text = $"Showing {start + 1} to {start + limit} of {totalRows} entries";
                    btnNext.Enabled = true;
                }
            }
            else
            {
                filteredRow = b.filtered_rows();
                lblPage.Text = $"{page}/{Math.Ceiling((double)filteredRow / (double)100)}";
                if (filteredRow - start < limit)
                {
                    btnNext.Enabled = false;
                    lblEntries.Text = $"Showing {start + 1} to {filteredRow} of {filteredRow} entries (Filtered from {totalRows} total entries)";
                }
                else
                {
                    btnNext.Enabled = true;
                    lblEntries.Text = $"Showing {start + 1} to {start + limit} of  {filteredRow} entries (Filtered from {totalRows} total entries)";
                }

            }

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.Tag.ToString() == "check")
            {
                btnSelectAll.Tag = "uncheck";
                for (int i = 0; i < dgBList.Rows.Count; i++)
                {
                    dgBList.Rows[i].Cells[9].Value = true;

                }
            }
            else
            {
                btnSelectAll.Tag = "check";
                for (int i = 0; i < dgBList.Rows.Count; i++)
                {
                    dgBList.Rows[i].Cells[9].Value = false;

                }
            }
        }

        private void dgBList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 7:
                        frmBorrowerReg bfrm = new frmBorrowerReg();
                        bfrm.borrowerID = dgBList.Rows[e.RowIndex].Cells[1].Value.ToString();
                        bfrm.memID = dgBList.Rows[e.RowIndex].Cells[1].Tag.ToString();
                        bfrm.isUpdate = true;
                        //bfrm.loadCollector();
                        bfrm.borrowerInfo();
                        bfrm.blist = this;
                        bfrm.ShowDialog();
                        break;
                    case 8://Delete
                        DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            b.borID = dgBList.Rows[e.RowIndex].Cells[1].Value.ToString();
                            if (b.deleteBorrower())
                            {
                                MessageBox.Show("Selected row(s) deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgBList.Rows.RemoveAt(e.RowIndex);
                            }

                        }
                        break;
                    case 9://Check
                        if (Convert.ToBoolean(dgBList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                        {
                            dgBList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        }
                        else
                        {
                            dgBList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnDeleteBorrower_Click(object sender, EventArgs e)
        {

            int toDelete = 0;
            for (int i = 0; i < dgBList.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgBList.Rows[i].Cells[10].Value) == true)
                {
                    toDelete++;
                }
            }
            if (toDelete <= 0)
            {
                MessageBox.Show("No row(s) selected!", "Vil Jims Lending Investor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dgBList.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgBList.Rows[i].Cells[10].Value) == true)
                        {
                            b.borID = dgBList.Rows[i].Cells[1].Value.ToString();
                            b.deleteBorrower();
                            dgBList.Rows.RemoveAt(i);
                        }
                    }
                    MessageBox.Show("Selected row(s) deleted.", "Vil Jims Lending Investor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            //dgBList.Rows.Clear();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            start -= limit;
            page -= 1;
            btnNext.Enabled = true;
            if (start <= 0)
            {
                start = 0;
                page = 1;
                btnPrev.Enabled = false;
            }
            lblPage.Text = page.ToString();
            loadBorrowerList();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            start += limit;
            page += 1;
            btnPrev.Enabled = true;
            if (tbSearch.Text == "")
            {
                if ((totalRows - start) <= limit)
                {
                    btnNext.Enabled = false;
                }
            }
            else
            {
                if ((totalRows - start) <= limit)
                {
                    btnNext.Enabled = false;
                }
            }

            lblPage.Text = page.ToString();
            loadBorrowerList();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode == Keys.Enter)
                loadBorrowerList();
            else if (e.KeyCode == Keys.Escape)
            {
                tbSearch.Text = null;
                loadBorrowerList();
            }

        }
    }
}
