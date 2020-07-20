using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lending_Management_System
{
    public partial class frmPastDueRprt : Form
    {
        private string where;
        public frmPastDueRprt(string _where)
        {
            InitializeComponent();
            where = _where;
        }

      

        private void frmPastDueRprt_Load(object sender, EventArgs e)
        {

            Collectibles_m pastDue = new Collectibles_m();
            int limit = pastDue.totalRows(false);
            LoansBindingSource.DataSource = pastDue.ListOfPastDue(1,0,limit,where);
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
