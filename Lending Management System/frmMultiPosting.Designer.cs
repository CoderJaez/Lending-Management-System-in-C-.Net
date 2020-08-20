namespace Lending_Management_System
{
    partial class frmMultiPosting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PaymentDuesDV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Borrower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerRemit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrevBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountRecieve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Collector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentDuesDV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panel1.Size = new System.Drawing.Size(867, 26);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Lending_Management_System.Properties.Resources.Delete_24px;
            this.btnClose.Location = new System.Drawing.Point(834, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 20);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(146)))), ((int)(((byte)(128)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = global::Lending_Management_System.Properties.Resources.Cash_Register_96px;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(867, 68);
            this.label1.TabIndex = 16;
            this.label1.Text = "             Remit";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PaymentDuesDV
            // 
            this.PaymentDuesDV.AllowUserToAddRows = false;
            this.PaymentDuesDV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.PaymentDuesDV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PaymentDuesDV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PaymentDuesDV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(146)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PaymentDuesDV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.PaymentDuesDV.ColumnHeadersHeight = 30;
            this.PaymentDuesDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.PaymentDuesDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Borrower,
            this.Loan,
            this.LoanBalance,
            this.PerRemit,
            this.PrevBal,
            this.Total,
            this.AmountRecieve,
            this.Collector,
            this.Balance});
            this.PaymentDuesDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaymentDuesDV.EnableHeadersVisualStyles = false;
            this.PaymentDuesDV.Location = new System.Drawing.Point(0, 169);
            this.PaymentDuesDV.Name = "PaymentDuesDV";
            this.PaymentDuesDV.RowHeadersVisible = false;
            this.PaymentDuesDV.Size = new System.Drawing.Size(867, 344);
            this.PaymentDuesDV.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Date Remit: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(79, 44);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(191, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(867, 75);
            this.panel2.TabIndex = 17;
            // 
            // Borrower
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Borrower.DefaultCellStyle = dataGridViewCellStyle2;
            this.Borrower.HeaderText = "Borrower";
            this.Borrower.Name = "Borrower";
            this.Borrower.Width = 150;
            // 
            // Loan
            // 
            this.Loan.HeaderText = "Loan";
            this.Loan.Name = "Loan";
            // 
            // LoanBalance
            // 
            this.LoanBalance.HeaderText = "Balance";
            this.LoanBalance.Name = "LoanBalance";
            // 
            // PerRemit
            // 
            this.PerRemit.HeaderText = "Due Amnt";
            this.PerRemit.Name = "PerRemit";
            // 
            // PrevBal
            // 
            this.PrevBal.HeaderText = "Prev Bal";
            this.PrevBal.Name = "PrevBal";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.Width = 80;
            // 
            // AmountRecieve
            // 
            this.AmountRecieve.HeaderText = "Amnt Rcv";
            this.AmountRecieve.Name = "AmountRecieve";
            // 
            // Collector
            // 
            this.Collector.HeaderText = "Collector";
            this.Collector.Name = "Collector";
            // 
            // Balance
            // 
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.Visible = false;
            // 
            // frmMultiPosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 513);
            this.Controls.Add(this.PaymentDuesDV);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMultiPosting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentDuesDV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView PaymentDuesDV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Borrower;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loan;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerRemit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevBal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountRecieve;
        private System.Windows.Forms.DataGridViewTextBoxColumn Collector;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
    }
}