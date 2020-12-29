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
    public partial class frmPosting : UserControl
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


        Modules.LoanModel loan = new Modules.LoanModel();
        Modules.Settings settings = new Modules.Settings();
        Modules.user user = new Modules.user();
        double Totcollectibles = 0;
        private int totalRows = 0;
        private int filteredRow = 0;
        private int start = 0;
        private int limit = 50;
        private int page = 1;
        private int entries = 0;
        private string where = "";
        private List<string> LedgerIDs = new List<string>();
        public frmPosting()
        {
            InitializeComponent();
            loadTerm();
            loadArea();
            //loadCollector();
        }



        public void loadTerm()
        {
            cbTerm.DisplayMember = "Text";
            cbTerm.ValueMember = "Value";
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            dt.Rows.Add("", "");
            foreach (DataRow row in settings.loadTerm().Rows)
            {
                dt.Rows.Add(row["terms"].ToString(), row["durations"].ToString());
            }

            cbTerm.DataSource = dt;
        }

        public void loadArea()
        {
            foreach (DataRow row in settings.loadArea().Rows)
            {
                cbArea.Items.Add(row["citymunDesc"]);
            }

        }
        private string _where()
        {
            string _where = "";
            if (cbTerm.Text != "" && cbArea.Text != "" && textBox1.Text != "")
            {
                _where = $"loan.`term` = '{cbTerm.Text}' AND ledger.`dueDate` = '{cgDate.Value.ToString("yyyy/MM/dd")}' AND refcitymun.citymunDesc = '{cbArea.Text}' AND (m.`lname` LIKE '%{textBox1.Text}%' OR m.`fname` LIKE '%{textBox1.Text}%' OR ledger.`loanNo` LIKE '%{textBox1.Text}%') ";
            }
            else if (cbArea.Text != "" && textBox1.Text != "")
            {
                _where = $"ledger.`dueDate` = '{cgDate.Value.ToString("yyyy/MM/dd")}' AND refcitymun.citymunDesc = '{cbArea.Text}'  AND (m.`lname` LIKE '%{textBox1.Text}%' OR m.`fname` LIKE '%{textBox1.Text}%' OR ledger.`loanNo` LIKE '%{textBox1.Text}%') ";
            }
            else if (cbTerm.Text != "" && cbArea.Text != "")
            {
                _where = $"loan.`term` = '{cbTerm.Text}' AND ledger.`dueDate` = '{cgDate.Value.ToString("yyyy/MM/dd")}' AND refcitymun.citymunDesc = '{cbArea.Text}' ";
            }
            else if (cbArea.Text != "")
            {
                _where = $"ledger.`dueDate` = '{cgDate.Value.ToString("yyyy/MM/dd")}' AND refcitymun.citymunDesc = '{cbArea.Text}' ";
            }
            else if(cbTerm.Text != "")
            {
                _where = $"loan.`term` = '{cbTerm.Text}' AND ledger.`dueDate` = '{cgDate.Value.ToString("yyyy/MM/dd")}' ";
            }
            else if(textBox1.Text != "")
            {
                _where = $"ledger.`dueDate` = '{cgDate.Value.ToString("yyyy/MM/dd")}'  AND (m.`lname` LIKE '%{textBox1.Text}%' OR m.`fname` LIKE '%{textBox1.Text}%' OR ledger.`loanNo` LIKE '%{textBox1.Text}%') ";
            } else
            {
                _where = $"ledger.`dueDate` = '{cgDate.Value.ToString("yyyy/MM/dd")}' ";
            }
            return _where;
        }


       
        public void loadCollectibles()
        {
            LedgerIDs.Clear();
            where = _where();
            dgPostingList.Rows.Clear();
            int no = 0;
            Totcollectibles = 0;
            foreach (DataRow row in loan.loadPostingList(start,limit,where).Rows)
            {
                dgPostingList.Rows.Add(false, no+1,DateTime.Parse(row["dueDate"].ToString()).ToShortDateString(),row["loanNo"].ToString(), double.Parse(row["matValue"].ToString()).ToString("N"), row["bname"].ToString(), row["citymunDesc"].ToString(), double.Parse(row["returnAmount"].ToString()).ToString("N"), double.Parse(row["interest"].ToString()).ToString("N"), double.Parse(row["totalAmount"].ToString()).ToString("N"));
                dgPostingList.Rows[no].Cells["checkbox"].Tag = row["ledgerNo"].ToString();
                no++;
                Totcollectibles += double.Parse(row["totalAmount"].ToString());
            }
            totalRows = loan.totalRows();
            filteredRow = loan.filtered_rows();
            entries = (filteredRow == dgPostingList.Rows.Count) ? filteredRow : dgPostingList.Rows.Count;
            lblPage.Text = $"{page}/{Math.Ceiling((double)filteredRow / (double)limit)}";
            if (filteredRow - start < limit)
            {
                btnNext.Enabled = false;
                lblEntries.Text = $"Showing {start + 1} to {entries} of {filteredRow} entries (Filtered from {totalRows} total entries)";
            }
            else
            {
                btnNext.Enabled = true;
                lblEntries.Text = $"Showing {start + 1} to {entries} of  {filteredRow} entries (Filtered from {totalRows} total entries)";
            }

            collectibles.Text = Totcollectibles.ToString("N");
        }

       
        private void dgPostingList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cbTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
          if(cbTerm.Text != "")
                loadCollectibles();
        }

        private void cgDate_ValueChanged(object sender, EventArgs e)
        {
            
            loadCollectibles();
        }

       

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {

           if(cbArea.Text != "")
                loadCollectibles();

        }

       

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRemit_Click(object sender, EventArgs e)
        {
            frmRemit remit = new frmRemit();
            remit.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadCollectibles();
            }
        }

        private void dgPostingList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
           if(e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 9)
                    dgPostingList.Cursor = Cursors.Hand;
            }
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
            loadCollectibles();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            start += limit;
            page += 1;
            btnPrev.Enabled = true;

            if ((totalRows - start) <= limit)
            {
                btnNext.Enabled = false;
            }

            lblPage.Text = page.ToString();
            loadCollectibles();
        }

        private void dgPostingList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (dgPostingList.Columns[e.ColumnIndex].Name)
                {
                    case "Remit":
                        frmRemit remit = new frmRemit();
                        remit.ledgerID = dgPostingList.Rows[e.RowIndex].Cells["checkbox"].Tag.ToString();
                        remit.dueDate = dgPostingList.Rows[e.RowIndex].Cells["DueDate"].Value.ToString();
                        remit.borrower = dgPostingList.Rows[e.RowIndex].Cells["Borrower"].Value.ToString();
                        remit.loanNo = dgPostingList.Rows[e.RowIndex].Cells["LoanNo"].Value.ToString();
                        remit.maturityVal = dgPostingList.Rows[e.RowIndex].Cells["MatValue"].Value.ToString();
                        remit.area = dgPostingList.Rows[e.RowIndex].Cells["Area"].Value.ToString();
                        remit.perRemit = dgPostingList.Rows[e.RowIndex].Cells["Daily"].Value.ToString();
                        remit.interestDue = dgPostingList.Rows[e.RowIndex].Cells["Interest"].Value.ToString();
                        remit.returnDue = dgPostingList.Rows[e.RowIndex].Cells["Return"].Value.ToString();
                        remit.loadLastPayment();
                        remit.loadInterestRate();
                        remit.clearPayment();
                        remit.post = this;
                        remit.ShowDialog();
                        break;
                    case "checkbox":
                        dgPostingList.CurrentCell.Value = (bool)dgPostingList.CurrentCell.Value ? false:true;
                        if ((bool)dgPostingList.CurrentCell.Value)
                            LedgerIDs.Add(dgPostingList.CurrentCell.Tag.ToString());
                        else
                            LedgerIDs.Remove(dgPostingList.CurrentCell.Tag.ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        private void dgPostingList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgPostingList.Cursor = Cursors.Default;
        }

        private void frmPosting_Load(object sender, EventArgs e)
        {
            loadCollectibles();
        }

        private void btnMakeRemit_Click(object sender, EventArgs e)
        {
            if(LedgerIDs.Count <= 0)
            {
                MessageBox.Show("No Payment checked. Please check the selected for payments");
                return;
            }
            frmMultiPosting post = new frmMultiPosting();
            post.post = this;
            post.LoadPaymentList(LedgerIDs);
            post.ShowDialog();
        }
    }
}
