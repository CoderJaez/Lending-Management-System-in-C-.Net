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
    public partial class frmCollectibles : UserControl
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

        Collectibles_m colList = new Collectibles_m();
        user user = new user();
        Settings settings = new Settings();
        private string where = "";
        private int totalRows = 0;
        private int filteredRow = 0;
        private int start = 0;
        private int limit = 50;
        private int page = 1;
        public frmCollectibles()
        {
            InitializeComponent();
            loadMonth();
            loadArea();
            //loadCollector();
            loadYear();
            btnPrev.Enabled = false;
        }

        public void loadCollectibles()
        {
            where = _where();
            dgCollectibles.ClearSelection();
            dgCollectibles.DataSource = colList.ListOfCollectibles(start+1,start, limit, where);
            totalRows = colList.totalRows(true);
            dgCollectibles.Columns["No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgCollectibles.Columns["Duedate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgCollectibles.Columns["Borrower"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgCollectibles.Columns["Area"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgCollectibles.Columns["Matvalue"].HeaderText = "Loan Amount";
            dgCollectibles.Columns["Remittance"].HeaderText = "Daily";
            dgCollectibles.Columns["Collector"].Visible = false;


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
            } else
            {
            //lblTotalRemit.Text = colList.getTotalCollectibles().ToString("N");
                filteredRow = colList.filtered_rows(true);
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
            //lblTotalRemittances.Text = colList.getTotalCollectibles().ToString("N");

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
            cbArea.Items.Add(" ");
            foreach (DataRow row in settings.loadArea().Rows)
            {
                cbArea.Items.Add(row["citymunDesc"]);
            }

        }

        public void loadYear()
        {
            Collectibles_m colList = new Collectibles_m();
            cbYear.DataSource = colList.getYear();
        }

        //public void loadCollector()
        //{
        //    cbCollector.DisplayMember = "Text";
        //    cbCollector.ValueMember = "Value";
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Text");
        //    dt.Columns.Add("Value");

        //    dt.Rows.Add("", "");
        //    foreach (DataRow row in user.loadCollectorList().Rows)
        //    {
        //        dt.Rows.Add(row["name"].ToString(), row["collectorID"].ToString());
        //    }

        //    cbCollector.DataSource = dt;
        //}

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMonth.Text != "")
                 loadCollectibles();
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbArea.Text != "")
                loadCollectibles();
        }

      

        private string _where()
        {
          
            string _where = "";
            //Month,Year, Area
            if (cbMonth.Text !="" && cbYear.Text != "" && cbArea.Text != ""  )
            {
                _where = $" AND DATE_FORMAT(l.dueDate ,'%M %Y') = '{cbMonth.Text} {cbYear.Text}' AND refcitymun.citymunDesc = '{cbArea.Text}' ";
            }
            //Year & Area
            else if ( cbYear.Text != "" && cbArea.Text != "" )
            {
                _where = $" AND DATE_FORMAT(l.dueDate ,'%Y') = '{cbYear.Text}' AND refcitymun.citymunDesc = '{cbArea.Text}'";
            }
            //Month & Year
            else if (cbMonth.Text != "" && cbYear.Text != "" )
            {
                _where = $" AND DATE_FORMAT(l.dueDate ,'%M %Y') = '{cbMonth.Text} {cbYear.Text}'";
            }
            //Month & Area
            else if (cbMonth.Text != "" && cbArea.Text != "")
            {
                _where = $" AND DATE_FORMAT(l.dueDate ,'%M') = '{cbMonth.Text}' AND refcitymun.citymunDesc = '{cbArea.Text}' ";
            }
            //Month
            else if (cbMonth.Text != "" )
            {
                _where = $" AND DATE_FORMAT(l.dueDate ,'%M') = '{cbMonth.Text}' ";
            }
            else if (cbYear.Text != "")
            {
                _where = $" AND DATE_FORMAT(l.dueDate ,'%Y') = '{cbYear.Text}' ";
            }
            else if (cbArea.Text != "")
            {
                _where = $" AND refcitymun.citymunDesc = '{cbArea.Text}'";
            }
            return _where;
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            where = $" WHERE l.dueDate = '{dtDate.Value.ToString("yyyy-MM-dd")}'";
            loadCollectibles();
        }

        private void DateChecked_CheckedChanged(object sender, EventArgs e)
        {

            if (DateChecked.CheckState == CheckState.Checked)
            {
                dtDate.Enabled = true;
            } else
            {
                dtDate.Enabled = false;
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(cbYear.Text != "")
                loadCollectibles();
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
            if(where == "")
            {
                if ((totalRows - start) <= limit)
                {
                    btnNext.Enabled = false;
                }
            } else
            {
                if ((totalRows - start) <= limit)
                {
                    btnNext.Enabled = false;
                }
            }

            lblPage.Text = page.ToString();
            loadCollectibles();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmCollectiblesReport report = new frmCollectiblesReport(where);
            report.ShowDialog();
        }

        private void frmCollectibles_Load(object sender, EventArgs e)
        {
            loadCollectibles();

        }
    }
}
