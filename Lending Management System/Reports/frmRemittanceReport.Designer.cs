namespace Lending_Management_System
{
    partial class frmRemittanceReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemittanceReport));
            this.BorrowerRemittancesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.remittanceRV = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowerRemittancesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BorrowerRemittancesBindingSource
            // 
            this.BorrowerRemittancesBindingSource.DataSource = typeof(Lending_Management_System.BorrowerRemittances);
            // 
            // remittanceRV
            // 
            this.remittanceRV.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BorrowerRemittancesBindingSource;
            this.remittanceRV.LocalReport.DataSources.Add(reportDataSource1);
            this.remittanceRV.LocalReport.ReportEmbeddedResource = "Lending_Management_System.Reports.BorrowerRemittanceReport.rdlc";
            this.remittanceRV.Location = new System.Drawing.Point(0, 0);
            this.remittanceRV.Name = "remittanceRV";
            this.remittanceRV.Size = new System.Drawing.Size(545, 510);
            this.remittanceRV.TabIndex = 0;
            // 
            // frmRemittanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(545, 510);
            this.Controls.Add(this.remittanceRV);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRemittanceReport";
            this.Text = "Print Remittances";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRemittanceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BorrowerRemittancesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer remittanceRV;
        private System.Windows.Forms.BindingSource BorrowerRemittancesBindingSource;
    }
}