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
    public partial class frmBorrowerAcc : UserControl
    {
        Modules.borrowerAcc acc = new Modules.borrowerAcc();

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
        private string BorrowerID = null;
        public frmBorrowerAcc()
        {
            InitializeComponent();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgAccList.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgAccList.Rows[i].Cells[5].Value))
                    dgAccList.Rows[i].Cells[5].Value = false;
                else
                    dgAccList.Rows[i].Cells[5].Value = true;
            }
        }

        private void btnAddBorrower_Click(object sender, EventArgs e)
        {
            frmAccReg bAcc = new frmAccReg();
            bAcc.frmAcc = this;
            //bAcc.accNo = acc.getAccID();
            bAcc.ShowDialog();
        }

        private void btnDeleteBorrower_Click(object sender, EventArgs e)
        {
            int n = 0;
            List<string> AccountIDs = new List<string>();
            for (int i = 0; i < dgAccList.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgAccList.Rows[i].Cells[5].Value))
                    n += 1;    
            }

           if(n > 0)
            {
                DialogResult result = MessageBox.Show("Delete Selected Rows?", "Zeustech Lending System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    for (int i = 0; i < dgAccList.Rows.Count; i++)
                        if (Convert.ToBoolean(dgAccList.Rows[i].Cells[5].Value))
                            AccountIDs.Add(dgAccList.Rows[i].Cells[1].Value.ToString());
                    if (acc.delete_batch(AccountIDs))
                        MessageBox.Show("Selected Rows deleted.");
                    loadAccounts();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void loadBorrowersAcc()
        {
            dgBAccList.Rows.Clear();
            int _no = 1;
            foreach (DataRow row in acc.loadBorrowersAccounts(BorrowerID).Rows)
            {
                dgBAccList.Rows.Add(_no, row["accID"].ToString(), row["name"].ToString(), row["date_reg"].ToString());
                _no++;
            }
        }
        public void loadAccounts()
        {
            dgAccList.Rows.Clear();
            int _no = 1;
            foreach (DataRow row in acc.loadAccounts(tbSearch.Text,start,limit).Rows)
            {
                dgAccList.Rows.Add(_no + start, row["borrowerID"].ToString(), row["name"].ToString(), row["address"].ToString(),row["accounts"].ToString());
                _no++;
            }

            totalRows = acc.totalRows();


            if (tbSearch.Text == "")
            {
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
                filteredRow = acc.filtered_rows();
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

        private void dgAccList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                switch (dgAccList.Columns[e.ColumnIndex].Name)
                {
                    case "checkbox":
                        if (Convert.ToBoolean(dgAccList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                            dgAccList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        else
                            dgAccList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        break;
                    case "delete":
                        string AccountID = dgAccList.Rows[e.RowIndex].Cells[1].Value.ToString();
                        DialogResult result = MessageBox.Show("Delete selected row? \n This will delete all the selected Borrower's Account", "Zeustech Lending System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                            if (acc.deleteBorrowerAccList(AccountID))
                            {
                                MessageBox.Show("Selected row deleted.", "Zeustech Lending System");
                                loadAccounts();
                            }
                        break;
                    case "view":
                         BorrowerID = dgAccList.Rows[e.RowIndex].Cells[1].Value.ToString();
                        loadBorrowersAcc();
                        break;
                }
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                loadAccounts();
            else if (e.KeyCode == Keys.Escape)
            {
                tbSearch.Text = null;
                loadAccounts();
            }
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
            loadAccounts();
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
            loadAccounts();
        }

        private void dgAccList_MouseHover(object sender, EventArgs e)
        {
        }

        private void dgAccList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (e.ColumnIndex >= 5)
                    dgAccList.Cursor = Cursors.Hand;
                else
                    dgAccList.Cursor = Cursors.Default;

        }

        private void dgBAccList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgBAccList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgBAccList.Columns[e.ColumnIndex].Name == "DeleteAcc")
                {
                    string AccountID = dgBAccList.Rows[e.RowIndex].Cells[1].Value.ToString();
                    DialogResult result = MessageBox.Show("Delete selected row? ", "Zeustech Lending System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        if (acc.deleteBorrowerAcc(AccountID))
                        {
                            MessageBox.Show("Selected row deleted.", "Zeustech Lending System");
                            dgBAccList.Rows.RemoveAt(e.RowIndex);
                            loadAccounts();
                            loadBorrowersAcc();
                        }
                }
            }
        }
    }
}
