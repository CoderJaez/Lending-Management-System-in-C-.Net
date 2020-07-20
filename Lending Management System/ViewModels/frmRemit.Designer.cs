namespace Lending_Management_System
{
    partial class frmRemit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCollector = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblInterest = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblReturn = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblLoanNo = new System.Windows.Forms.Label();
            this.lbPerRemit = new System.Windows.Forms.Label();
            this.lblLoanBalance = new System.Windows.Forms.Label();
            this.lblMatValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBorrower = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtDateRemit = new System.Windows.Forms.DateTimePicker();
            this.tbAmountRemit = new System.Windows.Forms.TextBox();
            this.lblBalancePayment = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblInterestPaid = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblReturnPaid = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblBalanceDue = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblInterestDue = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lblReturnDue = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblTotalDue = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(606, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Image = global::Lending_Management_System.Properties.Resources.Delete_24px;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(23, 22);
            this.btnExit.Text = "Close";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.label1.Location = new System.Drawing.Point(0, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(606, 84);
            this.label1.TabIndex = 15;
            this.label1.Text = "             Remit";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 125);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(580, 212);
            this.panel1.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCollector);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblLoanNo);
            this.groupBox1.Controls.Add(this.lbPerRemit);
            this.groupBox1.Controls.Add(this.lblLoanBalance);
            this.groupBox1.Controls.Add(this.lblMatValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblArea);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblBorrower);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblDueDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loan info";
            // 
            // cbCollector
            // 
            this.cbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCollector.FormattingEnabled = true;
            this.cbCollector.Location = new System.Drawing.Point(72, 98);
            this.cbCollector.Name = "cbCollector";
            this.cbCollector.Size = new System.Drawing.Size(240, 23);
            this.cbCollector.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBalance);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.lblInterest);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.lblReturn);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblAmountPaid);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(319, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 133);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Previous Payment";
            // 
            // lblBalance
            // 
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalance.Location = new System.Drawing.Point(92, 99);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(131, 20);
            this.lblBalance.TabIndex = 4;
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(6, 99);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 20);
            this.label23.TabIndex = 3;
            this.label23.Text = "Balance:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInterest
            // 
            this.lblInterest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInterest.Location = new System.Drawing.Point(91, 74);
            this.lblInterest.Name = "lblInterest";
            this.lblInterest.Size = new System.Drawing.Size(131, 20);
            this.lblInterest.TabIndex = 2;
            this.lblInterest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(6, 74);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 20);
            this.label20.TabIndex = 1;
            this.label20.Text = "Interest:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReturn
            // 
            this.lblReturn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReturn.Location = new System.Drawing.Point(92, 49);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(131, 20);
            this.lblReturn.TabIndex = 2;
            this.lblReturn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(6, 54);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 20);
            this.label18.TabIndex = 1;
            this.label18.Text = "Return:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAmountPaid.Location = new System.Drawing.Point(92, 24);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(131, 20);
            this.lblAmountPaid.TabIndex = 2;
            this.lblAmountPaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAmountPaid.Click += new System.EventHandler(this.lblAmountPaid_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(6, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "Amount paid:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoanNo.Location = new System.Drawing.Point(217, 23);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(95, 20);
            this.lblLoanNo.TabIndex = 0;
            this.lblLoanNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPerRemit
            // 
            this.lbPerRemit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPerRemit.Location = new System.Drawing.Point(246, 124);
            this.lbPerRemit.Name = "lbPerRemit";
            this.lbPerRemit.Size = new System.Drawing.Size(66, 20);
            this.lbPerRemit.TabIndex = 0;
            this.lbPerRemit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoanBalance
            // 
            this.lblLoanBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoanBalance.Location = new System.Drawing.Point(90, 147);
            this.lblLoanBalance.Name = "lblLoanBalance";
            this.lblLoanBalance.Size = new System.Drawing.Size(92, 20);
            this.lblLoanBalance.TabIndex = 0;
            this.lblLoanBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMatValue
            // 
            this.lblMatValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMatValue.Location = new System.Drawing.Point(90, 124);
            this.lblMatValue.Name = "lblMatValue";
            this.lblMatValue.Size = new System.Drawing.Size(92, 20);
            this.lblMatValue.TabIndex = 0;
            this.lblMatValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Balance:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(176, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Per remit:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(7, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Total Amount:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblArea
            // 
            this.lblArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblArea.Location = new System.Drawing.Point(71, 74);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(241, 20);
            this.lblArea.TabIndex = 0;
            this.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Collector:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBorrower
            // 
            this.lblBorrower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBorrower.Location = new System.Drawing.Point(71, 49);
            this.lblBorrower.Name = "lblBorrower";
            this.lblBorrower.Size = new System.Drawing.Size(241, 20);
            this.lblBorrower.TabIndex = 0;
            this.lblBorrower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Area:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDueDate
            // 
            this.lblDueDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDueDate.Location = new System.Drawing.Point(71, 23);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(79, 20);
            this.lblDueDate.TabIndex = 0;
            this.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Borrower:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loan No:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Due Date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Location = new System.Drawing.Point(12, 343);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(580, 207);
            this.panel2.TabIndex = 16;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancel.Image = global::Lending_Management_System.Properties.Resources.icons8_Cancel_16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(476, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 25);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(127)))), ((int)(((byte)(169)))));
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(77)))), ((int)(((byte)(116)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::Lending_Management_System.Properties.Resources.icons8_Save_16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(407, 170);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 25);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox3.Controls.Add(this.dtDateRemit);
            this.groupBox3.Controls.Add(this.tbAmountRemit);
            this.groupBox3.Controls.Add(this.lblBalancePayment);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.lblInterestPaid);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.lblReturnPaid);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.label46);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Location = new System.Drawing.Point(302, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 149);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payment:";
            // 
            // dtDateRemit
            // 
            this.dtDateRemit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateRemit.Location = new System.Drawing.Point(110, 17);
            this.dtDateRemit.Name = "dtDateRemit";
            this.dtDateRemit.Size = new System.Drawing.Size(130, 23);
            this.dtDateRemit.TabIndex = 6;
            // 
            // tbAmountRemit
            // 
            this.tbAmountRemit.Location = new System.Drawing.Point(110, 42);
            this.tbAmountRemit.Name = "tbAmountRemit";
            this.tbAmountRemit.Size = new System.Drawing.Size(130, 23);
            this.tbAmountRemit.TabIndex = 5;
            this.tbAmountRemit.Text = "0.00";
            this.tbAmountRemit.TextChanged += new System.EventHandler(this.tbAmountRemit_TextChanged);
            this.tbAmountRemit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAmountRemit_KeyPress);
            // 
            // lblBalancePayment
            // 
            this.lblBalancePayment.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBalancePayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalancePayment.Location = new System.Drawing.Point(109, 120);
            this.lblBalancePayment.Name = "lblBalancePayment";
            this.lblBalancePayment.Size = new System.Drawing.Size(131, 20);
            this.lblBalancePayment.TabIndex = 4;
            this.lblBalancePayment.Text = "0.00";
            this.lblBalancePayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(20, 120);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(83, 20);
            this.label25.TabIndex = 3;
            this.label25.Text = "Balance:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInterestPaid
            // 
            this.lblInterestPaid.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblInterestPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInterestPaid.Location = new System.Drawing.Point(109, 95);
            this.lblInterestPaid.Name = "lblInterestPaid";
            this.lblInterestPaid.Size = new System.Drawing.Size(131, 20);
            this.lblInterestPaid.TabIndex = 2;
            this.lblInterestPaid.Text = "0.00";
            this.lblInterestPaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(20, 95);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(83, 20);
            this.label27.TabIndex = 1;
            this.label27.Text = "Interest:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReturnPaid
            // 
            this.lblReturnPaid.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblReturnPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReturnPaid.Location = new System.Drawing.Point(109, 70);
            this.lblReturnPaid.Name = "lblReturnPaid";
            this.lblReturnPaid.Size = new System.Drawing.Size(131, 20);
            this.lblReturnPaid.TabIndex = 2;
            this.lblReturnPaid.Text = "0.00";
            this.lblReturnPaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(20, 70);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 20);
            this.label29.TabIndex = 1;
            this.label29.Text = "Return:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(20, 17);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(83, 20);
            this.label46.TabIndex = 1;
            this.label46.Text = "Date:";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(20, 40);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(83, 20);
            this.label31.TabIndex = 1;
            this.label31.Text = "Amount paid:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblBalanceDue);
            this.groupBox4.Controls.Add(this.label39);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.lblInterestDue);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Controls.Add(this.lblReturnDue);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.lblTotalDue);
            this.groupBox4.Controls.Add(this.label38);
            this.groupBox4.Location = new System.Drawing.Point(17, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 149);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Amount Due:";
            // 
            // lblBalanceDue
            // 
            this.lblBalanceDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalanceDue.Location = new System.Drawing.Point(107, 69);
            this.lblBalanceDue.Name = "lblBalanceDue";
            this.lblBalanceDue.Size = new System.Drawing.Size(131, 20);
            this.lblBalanceDue.TabIndex = 12;
            this.lblBalanceDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(21, 72);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(83, 20);
            this.label39.TabIndex = 3;
            this.label39.Text = "Balance:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(21, 94);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(217, 20);
            this.label32.TabIndex = 11;
            this.label32.Text = "------------------------------------------";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInterestDue
            // 
            this.lblInterestDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInterestDue.Location = new System.Drawing.Point(107, 44);
            this.lblInterestDue.Name = "lblInterestDue";
            this.lblInterestDue.Size = new System.Drawing.Size(131, 20);
            this.lblInterestDue.TabIndex = 8;
            this.lblInterestDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(18, 44);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(83, 20);
            this.label34.TabIndex = 5;
            this.label34.Text = "Interest:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReturnDue
            // 
            this.lblReturnDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReturnDue.Location = new System.Drawing.Point(107, 19);
            this.lblReturnDue.Name = "lblReturnDue";
            this.lblReturnDue.Size = new System.Drawing.Size(131, 20);
            this.lblReturnDue.TabIndex = 9;
            this.lblReturnDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(18, 19);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(83, 20);
            this.label36.TabIndex = 6;
            this.label36.Text = "Return:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDue
            // 
            this.lblTotalDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDue.Location = new System.Drawing.Point(107, 114);
            this.lblTotalDue.Name = "lblTotalDue";
            this.lblTotalDue.Size = new System.Drawing.Size(131, 20);
            this.lblTotalDue.TabIndex = 10;
            this.lblTotalDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(18, 114);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(83, 20);
            this.label38.TabIndex = 7;
            this.label38.Text = "Total Amount:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmRemit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(119)))), ((int)(((byte)(116)))));
            this.ClientSize = new System.Drawing.Size(606, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRemit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRemit";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLoanNo;
        private System.Windows.Forms.Label lbPerRemit;
        private System.Windows.Forms.Label lblMatValue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblBorrower;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblInterest;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbAmountRemit;
        private System.Windows.Forms.Label lblBalancePayment;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblInterestPaid;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblReturnPaid;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblBalanceDue;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblInterestDue;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label lblReturnDue;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label lblTotalDue;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.DateTimePicker dtDateRemit;
        private System.Windows.Forms.ComboBox cbCollector;
        private System.Windows.Forms.Label lblLoanBalance;
        private System.Windows.Forms.Label label3;
    }
}