namespace Lending_Management_System
{
    partial class ledgerReportFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ledgerReportFrm));
            this.ledgerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LegderRV = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LegderRV
            // 
            this.LegderRV.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Ledger";
            reportDataSource1.Value = this.ledgerBindingSource;
            this.LegderRV.LocalReport.DataSources.Add(reportDataSource1);
            this.LegderRV.LocalReport.ReportEmbeddedResource = "Lending_Management_System.Reports.ledgerReport.rdlc";
            this.LegderRV.Location = new System.Drawing.Point(0, 0);
            this.LegderRV.Name = "LegderRV";
            this.LegderRV.Size = new System.Drawing.Size(451, 446);
            this.LegderRV.TabIndex = 0;
            // 
            // ledgerReportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 446);
            this.Controls.Add(this.LegderRV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ledgerReportFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Ledger";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ledgerReportFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ledgerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer LegderRV;
        private System.Windows.Forms.BindingSource ledgerBindingSource;
    }
}