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
    public partial class frmRemittances : UserControl
    {
        user user = new user();
        Settings settings = new Settings();
        public frmRemittances()
        {
            InitializeComponent();
            loadMonth();
            loadArea();
            loadCollector();
            loadYear();
        }

        private int totalRows = 0;
        private int filteredRow = 0;
        private int start = 0;
        private int limit = 50;
        private int page = 1;
        private string where = "";

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
            cbArea.Items.Add("");
            foreach (DataRow row in settings.loadArea().Rows)
            {
                cbArea.Items.Add(row["citymunDesc"]);
            }

        }

        public void loadYear()
        {
            remittance remit = new remittance();
            cbYear.DataSource = remit.getYear();
        }

        public void loadCollector()
        {
            cbCollector.DisplayMember = "Text";
            cbCollector.ValueMember = "Value";
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");

            dt.Rows.Add("", "");
            foreach (DataRow row in user.loadCollectorList().Rows)
            {
                dt.Rows.Add(row["name"].ToString(), row["collectorID"].ToString());
            }

            cbCollector.DataSource = dt;
        }

        public void loadRemittanceList()
        {
            remittance remit = new remittance();
            where = _where();
            dgRemittance.DataSource = remit.remittanceList(start+1,start,limit,where);
            //lblTotalRemittances.Text = remit.getTotalRemittances().ToString("N");
            totalRows = remit.totalRows();
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
                filteredRow = remit.filtered_rows();
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



        private string _where()
        {
            string _where = "";
            //Month,Year, Area, & Collector
            if (cbMonth.Text != "" && cbYear.Text != "" && cbArea.Text != "" && cbCollector.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%M %Y') = '{cbMonth.Text} {cbYear.Text}' AND r.area = '{cbArea.Text}' AND r.colID = {cbCollector.SelectedValue}";
            }
            //Month, Year && Area
            else if (cbMonth.Text != "" && cbYear.Text != "" && cbArea.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%M %Y') = '{cbMonth.Text} {cbYear.Text}' AND r.area = '{cbArea.Text}'";
            }
            //Month, Year && Collector
            else if (cbMonth.Text != "" && cbYear.Text != "" && cbCollector.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%M %Y') = '{cbMonth.Text} {cbYear.Text}' AND  r.colID = {cbCollector.SelectedValue}";
            }
            //Month, Area & Collector
            else if (cbMonth.Text != "" && cbArea.Text != "" && cbCollector.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%M') = '{cbMonth.Text}' AND r.area = '{cbArea.Text}' AND  r.colID = {cbCollector.SelectedValue}";

            }
            //Year, Area & Collector
            else if (cbYear.Text != "" && cbArea.Text != "" && cbCollector.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%Y') = '{cbYear.Text}' AND r.area = '{cbArea.Text}' AND r.colID = {cbCollector.SelectedValue}";
            }
            //Month & Year
            else if (cbMonth.Text != "" && cbYear.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%M %Y') = '{cbMonth.Text} {cbYear.Text}'";
            }
            //Month & Area
            else if (cbMonth.Text != "" && cbArea.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%M') = '{cbMonth.Text}' AND r.area = '{cbArea.Text}'";            }
            //Month & Collector
            else if (cbMonth.Text != "" && cbCollector.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%M') = '{cbMonth.Text}'  AND r.colID = {cbCollector.SelectedValue}";
            }
            //Year & Collector
            else if (cbYear.Text != "" && cbCollector.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%Y') = '{cbYear.Text}' ANDr.colID = {cbCollector.SelectedValue}";
            }
            //Year & Area
            else if (cbYear.Text != "" && cbArea.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%Y') = '{cbYear.Text}' AND r.area = '{cbArea.Text}' ";
            }
            //Area & Collector
            else if (cbArea.Text != "" && cbCollector.Text != "")
            {
                _where = $"WHERE  r.area = '{cbArea.Text}' AND r.colID = {cbCollector.SelectedValue} ";
            }
            //Month
            else if (cbMonth.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%M') = '{cbMonth.Text}' ";
            }
            else if (cbYear.Text != "")
            {
                _where = $"WHERE DATE_FORMAT(r.`dateRemitted` ,'%Y') = '{cbYear.Text}' ";
            }
            else if (cbArea.Text != "")
            {
                _where = $"WHERE r.area = '{cbArea.Text}' ";
            }
            else if (cbCollector.Text != "")
            {
                _where = $"WHERE  r.colID = {cbCollector.SelectedValue}";
            }

            return _where;
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMonth.Text != "")
                loadRemittanceList();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbYear.Text != "")
                loadRemittanceList();
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbArea.Text != "")
                loadRemittanceList();
        }

        private void cbCollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCollector.SelectedValue.ToString() != "")
                loadRemittanceList();
        }

        private void CheckDate_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckDate.CheckState == CheckState.Checked)
            {
                dtDate.Enabled = true;
            } else
            {
                dtDate.Enabled = false;
            }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            where = $"WHERE r.`dateRemitted` = '{dtDate.Value.ToString("yyyy-MM-dd")}'";
            loadRemittanceList();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmRemittanceSummary report = new frmRemittanceSummary(_where());
            report.Show();
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
            loadRemittanceList();
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
            loadRemittanceList();
        }

        private void frmRemittances_Load(object sender, EventArgs e)
        {
            loadRemittanceList();
        }
    }
}
