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
    public partial class frmLoading : Form
    {
        public ProgressBar loading { get; set; }
        public frmLoading()
        {
            InitializeComponent();
            loading = progressBar;
        }
    }
}
