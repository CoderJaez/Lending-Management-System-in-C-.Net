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
    public partial class frmPastDue : UserControl
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

        Settings settings = new Settings();
        user user = new user();
        private int totalRows = 0;
        private int filteredRow = 0;
        private int start = 0;
        private int limit = 100;
        private int page = 1;
        private string where = "";
        public frmPastDue()
        {
            InitializeComponent();
            loadMonth();
            loadArea();
            //loadCollector();
            loadYear();
        }

        public void loadMonth()
        {
            DateTime month = new DateTime();
            cbMonth.Items.Add("");
            for (int i = 0; i < 12; i++)
            {
                cbMonth.Items.Add(month.AddMonths(i).ToString("MMMM"));
            }
        }
        public void loadArea()
        {
            cbArea.DisplayMember = "Text";
            cbArea.ValueMember = "Value";

            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            dt.Rows.Add("", "");
            cbArea.Items.Add("");
            foreach (DataRow row in settings.loadArea().Rows)
            {
                dt.Rows.Add(row["citymunDesc"],row["citymunCode"]);  
            }

            cbArea.DataSource = dt;
        }

        public void loadYear()
        {
            remittance remit = new remittance();
            cbYear.DataSource = remit.getYear();
        }

      
        public void loadPastDueList()
        {
            where = _where();
            Collectibles_m pastDue = new Collectibles_m();
            dgPastDue.Columns.Clear();
            dgPastDue.DataSource = pastDue.ListOfPastDue(start+1,start,limit,where);
            lblTotalCollectibles.Text = pastDue.getTotalPastDueCollectibles().ToString("N");
            totalRows = pastDue.totalRows(false);
            dgPastDue.Columns["ContactNo"].Visible = false;
            dgPastDue.Columns["DateFullyPaid"].Visible = false;
            dgPastDue.Columns["Status"].Visible = false;
            dgPastDue.Columns["AccountNo"].Visible = false;
            DataGridViewImageColumn view = new DataGridViewImageColumn();
            view.Image = Properties.Resources.icons8_view_16;
            view.Name = "ViewAccount";
            view.HeaderText = "";
            view.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgPastDue.Columns.Add(view);


            if (where == "")
            {
                lblPage.Text = $"{page}/{Math.Ceiling((double)totalRows / (double)100)}";
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
                filteredRow = pastDue.filtered_rows(false);
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

        private string _where()
        {
            string _where = "";
            //Month,Year, Area
            if (cbMonth.Text != "" && cbYear.Text != "" && cbArea.Text != "")
            {
                _where = $" AND DATE_FORMAT(loan.matDate ,'%M %Y') = '{cbMonth.Text} {cbYear.Text}' AND mem.citymunCode = '{cbArea.SelectedValue.ToString()}' ";
            }
            //Year & Area
            else if (cbYear.Text != "" && cbArea.Text != "")
            {
                _where = $" AND DATE_FORMAT(loan.matDate ,'%Y') = '{cbYear.Text}' AND mem.citymunCode = '{cbArea.SelectedValue.ToString()}'";
            }
            //Month & Year
            else if (cbMonth.Text != "" && cbYear.Text != "")
            {
                _where = $" AND DATE_FORMAT(loan.matDate ,'%M %Y') = '{cbMonth.Text} {cbYear.Text}'";
            }
            //Month & Area
            else if (cbMonth.Text != "" && cbArea.Text != "")
            {
                _where = $" AND DATE_FORMAT(loan.matDate ,'%M') = '{cbMonth.Text}' AND mem.citymunCode = '{cbArea.SelectedValue.ToString()}'";
            }
            //Month
            else if (cbMonth.Text != "")
            {
                _where = $" AND DATE_FORMAT(loan.matDate ,'%M') = '{cbMonth.Text}' ";
            }
            else if (cbYear.Text != "")
            {
                _where = $" AND DATE_FORMAT(loan.matDate ,'%Y') = '{cbYear.Text}' ";
            }
            else if (cbArea.Text != "")
            {
                _where = $" AND mem.citymunCode = '{cbArea.SelectedValue.ToString()}'";
            }
            return _where;
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMonth.Text != "")
                loadPastDueList();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbYear.Text != "")
                loadPastDueList();

        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbArea.Text != "")
                loadPastDueList();
        }

       
        private void btnApplyLoan_Click(object sender, EventArgs e)
        {
            frmPastDueRprt rpt = new frmPastDueRprt(_where());
            rpt.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            start += limit;
            page += 1;
            btnPrev.Enabled = true;
            if (where == "")
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
            loadPastDueList();
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
            loadPastDueList();
        }

        private void dgPastDue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                    //MessageBox.Show(e.ColumnIndex.ToString());
                if(dgPastDue.Columns[e.ColumnIndex].Name == "ViewAccount")
                {

                    frmLoanApplication apply = new frmLoanApplication();
                    apply.loanNo = dgPastDue.Rows[e.RowIndex].Cells[1].Value.ToString();
                    apply.name = dgPastDue.Rows[e.RowIndex].Cells[3].Value.ToString();
                    apply.loadInterest();
                    apply.borrrowerLoanInfo();
                    apply.forUpate = true;
                    apply.enableLedger();
                    apply.ShowDialog();
                }
            }
        }

        private void frmPastDue_Load(object sender, EventArgs e)
        {
            loadPastDueList();
        }
    }
}
