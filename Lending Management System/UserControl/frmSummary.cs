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
using Lending_Management_System.Objects;

namespace Lending_Management_System
{
    public partial class frmSummary : UserControl
    {
        public frmSummary()
        {
            InitializeComponent();
        }
        private string where = "";
        private double PrincipalAmount = 0;
        private double OutstandingCapital = 0;
        private double Balance = 0;
        private double AcruedInterest = 0;
        private double EarnedInterest = 0;
        LoanModel _summary = new LoanModel();

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
        public void loadSummaryOfLoans()
        {
            where = _where();
             int n = 1;
            dgSummary.Rows.Clear();
            PrincipalAmount = 0;
            OutstandingCapital = 0;
            Balance = 0;
            AcruedInterest = 0;
            EarnedInterest = 0;
            foreach (DataRow row in _summary.summaryLoans(SearchTxt.Text,where).Rows)
            {
                dgSummary.Rows.Add(n, row["loanNo"].ToString(), row["bname"].ToString(), Convert.ToDateTime(row["effectiveDate"]).ToShortDateString(), Convert.ToDouble(row["principalAmount"]).ToString("N"), Convert.ToDateTime(row["matDate"]).ToShortDateString(),Convert.ToDouble(row["outstandingCapital"]).ToString("N"), Convert.ToDouble(row["unearnedInterest"]).ToString("N"), Convert.ToDouble(row["earnedInterest"]).ToString("N"), Convert.ToDouble(row["balance"]).ToString("N"),((bool)row["paid"]) ? Convert.ToDateTime(row["date_fullyPaid"]).ToShortDateString():"");
                PrincipalAmount += (double)row["principalAmount"];
                OutstandingCapital += (double)row["outstandingCapital"];
                Balance += (double)row["balance"];
                AcruedInterest += (double)row["unearnedInterest"];
                EarnedInterest += (double)row["earnedInterest"];
                n++;
            }

            lblPrinciapal.Text = PrincipalAmount.ToString("N");
            lblOutstandingCap.Text = OutstandingCapital.ToString("N");
            lblBalance.Text = Balance.ToString("N");
            lblAccruedInt.Text = AcruedInterest.ToString("N");
            lblEarnedInt.Text = EarnedInterest.ToString("N");
            lblLoanNo.Text = (n-1).ToString();
        }
        public string _where()
        {
            string _where = "";
            string dateFromTo = $"AND effectiveDate BETWEEN '{dpDateFrom.Value.ToString("yyyy-MM-dd")}' AND '{dpDateTo.Value.AddDays(1).ToString("yyyy-MM-dd")}' ";
            try
            {
                if (!string.IsNullOrEmpty(cbProvince.SelectedValue.ToString()) && !string.IsNullOrEmpty(cbCityMun.SelectedValue.ToString()) && !string.IsNullOrEmpty(cbBarangay.SelectedValue.ToString()))
                {
                    _where = $"AND provCode = '{cbProvince.SelectedValue.ToString()}' AND citymunCode = '{cbCityMun.SelectedValue.ToString()}' AND brgyCode = '{cbBarangay.SelectedValue.ToString()}' {dateFromTo}";
                }
                else if (cbProvince.SelectedValue.ToString() != "" && cbCityMun.SelectedValue.ToString() != "")
                {
                    _where = $"AND provCode = '{cbProvince.SelectedValue.ToString()}' AND citymunCode = '{cbCityMun.SelectedValue.ToString()}'  {dateFromTo}";
                }
                else if (cbProvince.SelectedValue.ToString() != "")
                {
                    _where = $"AND provCode = '{cbProvince.SelectedValue.ToString()}'  {dateFromTo}";
                }
                else
                {
                    _where = dateFromTo;
                }
            }
            catch (Exception)
            {
            }
            return _where;
        }

        private void btnApplyLoan_Click(object sender, EventArgs e)
        {
            SummaryReportFrm rprt = new SummaryReportFrm(SearchTxt.Text, where);
            rprt.ShowDialog();
        }

      

        private void btnFilter_Click(object sender, EventArgs e)
        {
            loadSummaryOfLoans();
        }

        private void SearchTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                loadSummaryOfLoans();
        }

        private void frmSummary_Load(object sender, EventArgs e)
        {
            LoadProvince();
        }

        private void cbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCityMunicipality(cbProvince.SelectedValue.ToString());
        }

        private void cbCityMun_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBarangay(cbCityMun.SelectedValue.ToString());
        }

        private void cbBarangay_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgSummary.Columns[e.ColumnIndex].Name == "VeiwLoanDetails")
                {

                    frmLoanApplication apply = new frmLoanApplication();
                    apply.loanNo = dgSummary.Rows[e.RowIndex].Cells[1].Value.ToString();
                    apply.name = dgSummary.Rows[e.RowIndex].Cells[3].Value.ToString();
                    apply.loadInterest();
                    apply.borrrowerLoanInfo();
                    apply.forUpate = true;
                    apply.enableLedger();
                    apply.ShowDialog();
                }
            }
        }
    }
}
