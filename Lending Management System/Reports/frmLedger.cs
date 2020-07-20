using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Lending_Management_System
{
    public partial class frmLedger : Form
    {
        Collectibles_m col = new Collectibles_m();
        private int area = 0;
        private List<string> provCode;
        private List<string> citymunCode;
        private List<string> brgyCode;
        private string date;
        public frmLedger(int _area, List<string> _provCode, List<string> _citymunCode, List<string> _brgyCode,string _date)
        {
            date = _date;
            area = _area;
            provCode = _provCode;
            citymunCode = _citymunCode;
            brgyCode = _brgyCode;
            InitializeComponent();
        }

        private void frmLedger_Load(object sender, EventArgs e)
        {
            LoansBindingSource.DataSource = col.getMasterAreaList(area,provCode,citymunCode,brgyCode);

            this.reportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
          
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 0;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;
            this.reportViewer.SetPageSettings(pg);
            this.reportViewer.RefreshReport();
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {

            var mainSource = ((LocalReport)sender).DataSources["AreaMaster"];
            var areaCode = (e.Parameters["Area"].Values.First()).ToString();
            var subSource = col.getPostingList(area,areaCode,date);
            e.DataSources.Add(new ReportDataSource("LoanDetails", subSource));
        }
    }
}
