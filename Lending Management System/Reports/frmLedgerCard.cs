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
    public partial class frmLedgerCard : Form
    {
        frmLoanApplication appLoan;
        private int days = 0;
        public frmLedgerCard(frmLoanApplication loan)
        {
            appLoan = loan;
            InitializeComponent();
        }

        private void frmLedgerCard_Load(object sender, EventArgs e)
        {
            BorrowerModel borrower = new BorrowerModel();
            List<Loans> l = new List<Loans>();
            List<Loans> l2 = new List<Loans>();
            days = Convert.ToInt32(appLoan.duration);
            var b = borrower.getBorrowerInfoViaLoan(appLoan.loanNo);
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
           {
                new Microsoft.Reporting.WinForms.ReportParameter("LoanNo",b.LoanNo),
                new Microsoft.Reporting.WinForms.ReportParameter("Borrower",b.Name),
                new Microsoft.Reporting.WinForms.ReportParameter("Address",b.Address),
                new Microsoft.Reporting.WinForms.ReportParameter("DateRelease",appLoan.effectiveDate),
                new Microsoft.Reporting.WinForms.ReportParameter("PrincipalAmount",appLoan.principalAmount.ToString("N")),
                new Microsoft.Reporting.WinForms.ReportParameter("Interest",appLoan.InterestAmount.ToString("N")),
                new Microsoft.Reporting.WinForms.ReportParameter("TotalAmount",appLoan.maturityValue.ToString("N")),
                new Microsoft.Reporting.WinForms.ReportParameter("Term",appLoan.Terms),
                new Microsoft.Reporting.WinForms.ReportParameter("Days",appLoan.duration),
                new Microsoft.Reporting.WinForms.ReportParameter("DailyPayment",appLoan.perRemit()),
           };
            this.reportViewer1.LocalReport.SetParameters(p);
            if (days <= 60)
            {
                for (int i = 1; i <= 60; i++)
                {
                    var loan = new Loans();
                    if (i <= 30)
                    {
                        loan.No = i;
                        l.Add(loan);
                    }
                    else
                    {
                        loan.No = i;
                        l2.Add(loan);
                    }
                }
            } else
            {
                for (int i = 1; i <= 120; i++)
                {
                    var loan = new Loans();
                    if (i <= 32)
                    {
                        loan.No = i;
                        l.Add(loan);
                    }
                    else if (i > 32 && i <= 64)
                    {
                        loan.No = i;
                        l2.Add(loan);
                    }
                    else if (i > 64 && i <= 92)
                    {
                        loan.No = i;
                        l.Add(loan);
                    } else
                    {
                        loan.No = i;
                        l2.Add(loan);
                    }
                }
            }
            pg.Margins.Top = 0;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;
            ledgerBindingSource.DataSource = l;
            LedgerBindingSource2.DataSource = l2;
            this.reportViewer1.SetPageSettings(pg);
            this.reportViewer1.RefreshReport();
        }
    }
}
