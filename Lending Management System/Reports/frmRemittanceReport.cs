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
    public partial class frmRemittanceReport : Form
    {
        public frmLoanApplication appLoan { get; set; }
        remittance remit = new remittance();
        borrowerAcc borrower = new borrowerAcc();
        public frmRemittanceReport()
        {
            InitializeComponent();
        }

        private void frmRemittanceReport_Load(object sender, EventArgs e)
        {
            BorrowerRemittancesBindingSource.DataSource = remit.BorrowerRemittances(appLoan.loanNo);
            foreach (DataRow row in borrower.loadAccounts(appLoan.loanNo,0,1).Rows)
            {
                Microsoft.Reporting.WinForms.ReportParameter[] p1 = new Microsoft.Reporting.WinForms.ReportParameter[]
             {
                new Microsoft.Reporting.WinForms.ReportParameter("borrower",row["name"].ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("address",row["address"].ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("dueDate",appLoan.maturityDate),
                new Microsoft.Reporting.WinForms.ReportParameter("effectiveDate",appLoan.effectiveDate),
                new Microsoft.Reporting.WinForms.ReportParameter("pAmount",appLoan.pAmount()),
                new Microsoft.Reporting.WinForms.ReportParameter("interest",appLoan.intAmount()),
                new Microsoft.Reporting.WinForms.ReportParameter("matValue",appLoan.matValue()),
                new Microsoft.Reporting.WinForms.ReportParameter("cpno",row["contact"].ToString()),
               new Microsoft.Reporting.WinForms.ReportParameter("term",appLoan.Terms),
                new Microsoft.Reporting.WinForms.ReportParameter("duration",appLoan.duration),
                new Microsoft.Reporting.WinForms.ReportParameter("perRemit",appLoan.perRemit()),
                new Microsoft.Reporting.WinForms.ReportParameter("totalRemit",appLoan.totalRemit()),
                new Microsoft.Reporting.WinForms.ReportParameter("balance",appLoan.totalBal())
              
             };
                this.remittanceRV.LocalReport.SetParameters(p1);
            }
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 1;
            pg.Margins.Bottom = 1;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;
            this.remittanceRV.SetPageSettings(pg);
            this.remittanceRV.RefreshReport();
        }
    }

   
}
