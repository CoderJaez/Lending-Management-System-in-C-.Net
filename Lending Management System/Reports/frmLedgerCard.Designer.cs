namespace Lending_Management_System
{
    partial class frmLedgerCard
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLedgerCard));
            this.ledgerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LedgerBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ledgerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LedgerBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // ledgerBindingSource
            // 
            this.ledgerBindingSource.DataSource = typeof(Lending_Management_System.Objects.ledger);
            // 
            // LedgerBindingSource2
            // 
            this.LedgerBindingSource2.DataSource = typeof(Lending_Management_System.Objects.Loans);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "LedgerDetails";
            reportDataSource1.Value = this.ledgerBindingSource;
            reportDataSource2.Name = "LedgerDetails2";
            reportDataSource2.Value = this.LedgerBindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Lending_Management_System.Reports.LedgerCard.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 182);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmLedgerCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 182);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLedgerCard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLedgerCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ledgerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LedgerBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ledgerBindingSource;
        private System.Windows.Forms.BindingSource LedgerBindingSource2;
    }
}