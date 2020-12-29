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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.PaymentDuesDV = new System.Windows.Forms.DataGridView();
            this.n = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Borrower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerRemit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrevBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmountDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LedgerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountRecieve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CollectorCB = new System.Windows.Forms.ComboBox();
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentDuesDV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panel1.Size = new System.Drawing.Size(929, 26);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Lending_Management_System.Properties.Resources.Delete_24px;
            this.btnClose.Location = new System.Drawing.Point(896, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 20);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PaymentDuesDV
            // 
            this.PaymentDuesDV.AllowUserToAddRows = false;
            this.PaymentDuesDV.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.White;
            this.PaymentDuesDV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.PaymentDuesDV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.PaymentDuesDV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PaymentDuesDV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PaymentDuesDV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(146)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PaymentDuesDV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.PaymentDuesDV.ColumnHeadersHeight = 30;
            this.PaymentDuesDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.PaymentDuesDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.n,
            this.LoanNo,
            this.Borrower,
            this.Loan,
            this.LoanBalance,
            this.DueDate,
            this.PerRemit,
            this.PrevBalance,
            this.TotalAmountDue,
            this.interest,
            this.LedgerID,
            this.AmountRecieve,
            this.Area,
            this.intDue,
            this.retDue,
            this.delete});
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PaymentDuesDV.DefaultCellStyle = dataGridViewCellStyle25;
            this.PaymentDuesDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaymentDuesDV.EnableHeadersVisualStyles = false;
            this.PaymentDuesDV.Location = new System.Drawing.Point(3, 201);
            this.PaymentDuesDV.Name = "PaymentDuesDV";
            this.PaymentDuesDV.RowHeadersVisible = false;
            this.PaymentDuesDV.Size = new System.Drawing.Size(929, 309);
            this.PaymentDuesDV.TabIndex = 18;
            this.PaymentDuesDV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PaymentDuesDV_CellClick);
            this.PaymentDuesDV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.PaymentDuesDV_EditingControlShowing);
            // 
            // n
            // 
            this.n.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.n.HeaderText = "";
            this.n.Name = "n";
            this.n.Width = 17;
            // 
            // LoanNo
            // 
            this.LoanNo.HeaderText = "LoanNo";
            this.LoanNo.Name = "LoanNo";
            this.LoanNo.ReadOnly = true;
            // 
            // Borrower
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Borrower.DefaultCellStyle = dataGridViewCellStyle23;
            this.Borrower.HeaderText = "Borrower";
            this.Borrower.Name = "Borrower";
            this.Borrower.ReadOnly = true;
            this.Borrower.Width = 150;
            // 
            // Loan
            // 
            this.Loan.HeaderText = "Loan";
            this.Loan.Name = "Loan";
            this.Loan.ReadOnly = true;
            // 
            // LoanBalance
            // 
            this.LoanBalance.HeaderText = "Balance";
            this.LoanBalance.Name = "LoanBalance";
            this.LoanBalance.ReadOnly = true;
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            this.DueDate.Width = 80;
            // 
            // PerRemit
            // 
            this.PerRemit.HeaderText = "Due Amount";
            this.PerRemit.Name = "PerRemit";
            this.PerRemit.ReadOnly = true;
            // 
            // PrevBalance
            // 
            this.PrevBalance.HeaderText = "Previous Bal";
            this.PrevBalance.Name = "PrevBalance";
            this.PrevBalance.ReadOnly = true;
            this.PrevBalance.Width = 80;
            // 
            // TotalAmountDue
            // 
            this.TotalAmountDue.HeaderText = "Total Due";
            this.TotalAmountDue.Name = "TotalAmountDue";
            this.TotalAmountDue.ReadOnly = true;
            // 
            // interest
            // 
            this.interest.HeaderText = "interest";
            this.interest.Name = "interest";
            this.interest.ReadOnly = true;
            this.interest.Visible = false;
            // 
            // LedgerID
            // 
            this.LedgerID.HeaderText = "LedgerID";
            this.LedgerID.Name = "LedgerID";
            this.LedgerID.ReadOnly = true;
            this.LedgerID.Visible = false;
            // 
            // AmountRecieve
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.AmountRecieve.DefaultCellStyle = dataGridViewCellStyle24;
            this.AmountRecieve.HeaderText = "Amount Recieve";
            this.AmountRecieve.Name = "AmountRecieve";
            this.AmountRecieve.Width = 80;
            // 
            // Area
            // 
            this.Area.HeaderText = "Area";
            this.Area.Name = "Area";
            this.Area.Visible = false;
            // 
            // intDue
            // 
            this.intDue.HeaderText = "InterestDue";
            this.intDue.Name = "intDue";
            this.intDue.ReadOnly = true;
            this.intDue.Visible = false;
            // 
            // retDue
            // 
            this.retDue.HeaderText = "ReturnDue";
            this.retDue.Name = "retDue";
            this.retDue.ReadOnly = true;
            this.retDue.Visible = false;
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.delete.HeaderText = "";
            this.delete.Image = global::Lending_Management_System.Properties.Resources.icons8_Trash_Can_16;
            this.delete.Name = "delete";
            this.delete.Width = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.CollectorCB);
            this.panel2.Controls.Add(this.dt);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSubmit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(929, 102);
            this.panel2.TabIndex = 17;
            // 
            // CollectorCB
            // 
            this.CollectorCB.FormattingEnabled = true;
            this.CollectorCB.Location = new System.Drawing.Point(95, 41);
            this.CollectorCB.Name = "CollectorCB";
            this.CollectorCB.Size = new System.Drawing.Size(190, 21);
            this.CollectorCB.TabIndex = 38;
            this.CollectorCB.SelectedIndexChanged += new System.EventHandler(this.CollectorCB_SelectedIndexChanged);
            // 
            // dt
            // 
            this.dt.CustomFormat = "";
            this.dt.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt.Location = new System.Drawing.Point(95, 11);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(190, 24);
            this.dt.TabIndex = 37;
            this.dt.ValueChanged += new System.EventHandler(this.dt_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Collector:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Date Remit:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(127)))), ((int)(((byte)(169)))));
            this.btnSubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(77)))), ((int)(((byte)(116)))));
            this.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(95, 68);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(190, 28);
            this.btnSubmit.TabIndex = 36;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
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
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(929, 68);
            this.label1.TabIndex = 16;
            this.label1.Text = "             Remit";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMultiPosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(935, 513);
            this.Controls.Add(this.PaymentDuesDV);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMultiPosting";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSubmit;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.DateTimePicker dt;
        private System.Windows.Forms.ComboBox CollectorCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn n;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Borrower;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loan;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerRemit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrevBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmountDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn interest;
        private System.Windows.Forms.DataGridViewTextBoxColumn LedgerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountRecieve;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn intDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn retDue;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}