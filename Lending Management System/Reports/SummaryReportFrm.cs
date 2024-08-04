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
using Lending_Management_System.Objects;
namespace Lending_Management_System
{
    public partial class SummaryReportFrm : Form
    {
        private string search = "";
        private string where = "";
        public SummaryReportFrm(string _search, string _where)
        {
            search = _search;
            where = _where;
            InitializeComponent();
        }


        private void SummaryReportFrm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            LoanModel loan = new LoanModel();
            LoansBindingSource.DataSource = loan.getSummaryLoans(search,where);
            //System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            //pg.Margins.Top = 0;
            //pg.Margins.Bottom = 0;
            //pg.Margins.Left = 0;
            //pg.Margins.Right = 0;
            //pg.Landscape = true;
            //this.reportViewer1.SetPageSettings(pg);
            this.reportViewer1.RefreshReport();
        }

      
    }
}
