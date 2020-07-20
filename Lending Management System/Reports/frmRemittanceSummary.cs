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
namespace Lending_Management_System
{
    public partial class frmRemittanceSummary : Form
    {
        string _where;
        public frmRemittanceSummary(string where)
        {
            _where = where;
            InitializeComponent();
        }

        private void frmRemittanceSummary_Load(object sender, EventArgs e)
        {
            remittance remit = new remittance();
            remittancesBindingSource.DataSource = remit.remittanceList(1,0,remit.totalRows(),_where);
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
           {
                 new Microsoft.Reporting.WinForms.ReportParameter("TotalRemittance", remit.getTotalRemittances().ToString("N"))

           };
            this.reportViewer1.LocalReport.SetParameters(p);
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 1;
            pg.Margins.Bottom = 1;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;
            pg.Landscape = true;
            this.reportViewer1.SetPageSettings(pg);
            this.reportViewer1.RefreshReport();
        }
    }
}
