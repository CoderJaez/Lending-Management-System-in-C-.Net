using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lending_Management_System.Modules;

namespace Lending_Management_System
{
    public partial class frmLoanApplist : UserControl
    {
        Modules.LoanModel loan = new Modules.LoanModel();
        public frmLoanApplist()
        {
            InitializeComponent();
        }
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
        private string where = "";
        public void LoadLoanList()
        {
            where = _where();
            dgLoan.Rows.Clear();
            int no = 0;
            //dgLoan.DataSource = loan.loanApplicationList(tbSearch.Text, start, limit, where);
            foreach (DataRow row in loan.loanApplicationList(tbSearch.Text, start, limit, where).Rows)
            {
                dgLoan.Rows.Add(no + start + 1, row["loanNo"].ToString(), row["bname"].ToString(), DateTime.Parse(row["effectiveDate"].ToString()).ToShortDateString(), double.Parse(row["principalAmount"].ToString()).ToString("N"), double.Parse(row["outstandingCapital"].ToString()).ToString("N"), double.Parse(row["balance"].ToString()).ToString("N"), double.Parse(row["unearnedInterest"].ToString()).ToString("N"), double.Parse(row["earnedInterest"].ToString()).ToString("N"), DateTime.Parse(row["matDate"].ToString()).ToShortDateString());
                no++;
            }

            totalRows = loan.LoantotalRows();


            if (where == "")
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
                filteredRow = loan.Loanfiltered_rows();
                lblPage.Text = $"{page}/{Math.Ceiling((double)filteredRow / (double)limit)}";
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

        private void btnApplyLoan_Click(object sender, EventArgs e)
        {
            frmLoanApplication apply = new frmLoanApplication();
            //apply.loanNo = loan.getLoaNo();
            apply.frmLoan = this;
            apply.loadInterest();
            //apply.loadTerm();
            apply.btnSave.Enabled = true;
            apply.tbPrincipalAmount.Enabled = true;
            apply.clearForm();
            apply.forUpate = false;
            apply.ShowDialog();
        }


        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadLoanList();
        }

        private void btnPosting_Click(object sender, EventArgs e)
        {
            //frmLedger ledger = new frmLedger();
            //ledger.ShowDialog();

            frmPostingGuide guide = new frmPostingGuide();
            guide.ShowDialog();
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
            LoadLoanList();
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
            LoadLoanList();
        }

       

        private void dgLoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgLoan.Columns[e.ColumnIndex].Name == "edit")
                {
                    frmLoanApplication apply = new frmLoanApplication();
                    apply.loanNo = dgLoan.Rows[e.RowIndex].Cells[1].Value.ToString();
                    apply.name = dgLoan.Rows[e.RowIndex].Cells[2].Value.ToString();
                    apply.loadInterest();
                    apply.borrrowerLoanInfo();
                    apply.forUpate = true;
                    apply.frmLoan = this;
                    apply.enableLedger();
                    apply.ShowDialog();
                }

            }
        }

        private void dgLoan_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgLoan.Columns[e.ColumnIndex].Name == "edit")
                {
                    dgLoan.Cursor = Cursors.Hand;
                }

            }
        }

        private void dgLoan_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgLoan.Cursor = Cursors.Default;

            }
        }

        private void frmLoanApplist_Load(object sender, EventArgs e)
        {
            LoadProvince();
            LoadLoanList();
        }

        private void LoadProvince()
        {
            BorrowerModel p = new BorrowerModel();
            cbProvince.DisplayMember = "Text";
            cbProvince.ValueMember = "Value";
           
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            dt.Rows.Add("", "");
            foreach (DataRow row in p.LoadProvince().Rows)
                dt.Rows.Add(row["provDesc"], row["provCode"].ToString());
            cbProvince.DataSource = dt;
        }

        private void LoadCityMunicipality(string provCode)
        {
            BorrowerModel p = new BorrowerModel();
            cbCityMun.DisplayMember = "Text";
            cbCityMun.ValueMember = "Value";
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            dt.Rows.Add("", "");
            foreach (DataRow row in p.LoadCityMunicipality(provCode).Rows)
                dt.Rows.Add(row["citymunDesc"], row["citymunCode"].ToString());
            cbCityMun.DataSource = dt;
        }

        private void LoadBarangay(string citymunCode)
        {
            BorrowerModel p = new BorrowerModel();
            cbBarangay.DisplayMember = "Text";
            cbBarangay.ValueMember = "Value";

            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            dt.Rows.Add("", "");
            foreach (DataRow row in p.LoadBarangay(citymunCode).Rows)
                dt.Rows.Add(row["brgyDesc"], row["brgyCode"].ToString());
            cbBarangay.DataSource = dt;
        }

        private void cbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbProvince.SelectedValue.ToString() != "")
            {
                LoadCityMunicipality(cbProvince.SelectedValue.ToString());
                LoadLoanList();
            }
        }

        private void cbCityMun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCityMun.SelectedValue.ToString() != "")
            {
                LoadBarangay(cbCityMun.SelectedValue.ToString());
                LoadLoanList();
            }
        }
        private void cbBarangay_SelectedIndexChanged(object sender, EventArgs e)
        {
          if(cbBarangay.SelectedValue.ToString() != "")
                LoadLoanList();
        }
        public string _where()
        {
            string _where = "";
            if(cbProvince.SelectedValue.ToString() != "" && cbCityMun.SelectedValue.ToString() != "" && cbBarangay.SelectedValue.ToString() != ""  )
            {
                _where = $"AND provCode = '{cbProvince.SelectedValue.ToString()}' AND citymunCode = '{cbCityMun.SelectedValue.ToString()}' AND brgyCode = '{cbBarangay.SelectedValue.ToString()}'";
            } else if(cbProvince.SelectedValue.ToString() != "" && cbCityMun.SelectedValue.ToString() != "")
            {
                _where = $"AND provCode = '{cbProvince.SelectedValue.ToString()}' AND citymunCode = '{cbCityMun.SelectedValue.ToString()}'";
            } else if(cbProvince.SelectedValue.ToString() != "")
            {
                _where = $"AND provCode = '{cbProvince.SelectedValue.ToString()}'";
            }
            return _where;
        }

     
    }
}
