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
    public partial class frmCollectiblesReport : Form
    {
        string where = "";
        public frmCollectiblesReport(string _where)
        {
            where = _where;
            InitializeComponent();
        }

        private void frmCollectiblesReport_Load(object sender, EventArgs e)
        {
            Collectibles_m col = new Collectibles_m();
            int limit = col.totalRows(true);
            this.CollectiblesBindingSource.DataSource = col.ListOfCollectibles(1, 0, limit, where);
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 0;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;
            this.reportViewer1.SetPageSettings(pg);
            this.reportViewer1.RefreshReport();
        }

        
    }
}
