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
    public partial class ledgerReportFrm : Form
    {
        LoanModel loan = new LoanModel();
        BorrowerModel borrower = new BorrowerModel();
        //List<ledger> ledger;
        public frmLoanApplication appLoan { get; set; }
        public ledgerReportFrm() 
        { 
            InitializeComponent();
        }

        private void ledgerReportFrm_Load(object sender, EventArgs e)
        {
            ledgerBindingSource.DataSource = loan.getLedgerList(appLoan.loanNo);
            var b = borrower.getBorrowerInfoViaLoan(appLoan.loanNo);
                Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
             {
                new Microsoft.Reporting.WinForms.ReportParameter("LoanNo",b.LoanNo),
                new Microsoft.Reporting.WinForms.ReportParameter("borrower",b.Name),
                new Microsoft.Reporting.WinForms.ReportParameter("address",b.Address),
                new Microsoft.Reporting.WinForms.ReportParameter("DueDate",appLoan.maturityDate),
                new Microsoft.Reporting.WinForms.ReportParameter("currentDate",appLoan.effectiveDate),
                new Microsoft.Reporting.WinForms.ReportParameter("pAmount",appLoan.principalAmount.ToString("N")),
                new Microsoft.Reporting.WinForms.ReportParameter("interest",appLoan.InterestAmount.ToString("N")),
                new Microsoft.Reporting.WinForms.ReportParameter("totalAmount",appLoan.maturityValue.ToString("N")),
                new Microsoft.Reporting.WinForms.ReportParameter("cpno",b.ContactNo),
                new Microsoft.Reporting.WinForms.ReportParameter("term",appLoan.Terms),
                new Microsoft.Reporting.WinForms.ReportParameter("duration",appLoan.duration),
                new Microsoft.Reporting.WinForms.ReportParameter("Balance",appLoan.totalBal())
             };
            this.LegderRV.LocalReport.SetParameters(p);
            
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 1;
            pg.Margins.Bottom = 1;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;
           
            this.LegderRV.SetPageSettings(pg);
            this.LegderRV.RefreshReport();
        }

    }
}
