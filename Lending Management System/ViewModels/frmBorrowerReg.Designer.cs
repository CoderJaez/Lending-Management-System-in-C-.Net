namespace Lending_Management_System
{
    partial class frmBorrowerReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBorrowerReg));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblBorrowerNo = new System.Windows.Forms.Label();
            this.lblBrgy = new System.Windows.Forms.Label();
            this.lblCityMun = new System.Windows.Forms.Label();
            this.tbLname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbContact = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbOccupation = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.dpDob = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBrowsePic = new System.Windows.Forms.Button();
            this.bntOpenCam = new System.Windows.Forms.Button();
            this.BorrowerImg = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.lblProv = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnBrgy = new System.Windows.Forms.Button();
            this.btnCityMun = new System.Windows.Forms.Button();
            this.btnProv = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowerImg)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(5, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(576, 25);
            this.toolStrip1.TabIndex = 10;
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
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(146)))), ((int)(((byte)(128)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = global::Lending_Management_System.Properties.Resources.Registration_Skin_Type_7_96px;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(576, 107);
            this.label1.TabIndex = 13;
            this.label1.Text = "Borrower registration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Last name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 17);
            this.label11.TabIndex = 14;
            this.label11.Text = "Borrower no:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBorrowerNo
            // 
            this.lblBorrowerNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBorrowerNo.Location = new System.Drawing.Point(130, 130);
            this.lblBorrowerNo.Name = "lblBorrowerNo";
            this.lblBorrowerNo.Size = new System.Drawing.Size(210, 25);
            this.lblBorrowerNo.TabIndex = 14;
            this.lblBorrowerNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBrgy
            // 
            this.lblBrgy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBrgy.Location = new System.Drawing.Point(131, 449);
            this.lblBrgy.Name = "lblBrgy";
            this.lblBrgy.Size = new System.Drawing.Size(210, 25);
            this.lblBrgy.TabIndex = 14;
            this.lblBrgy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCityMun
            // 
            this.lblCityMun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCityMun.Location = new System.Drawing.Point(131, 477);
            this.lblCityMun.Name = "lblCityMun";
            this.lblCityMun.Size = new System.Drawing.Size(210, 25);
            this.lblCityMun.TabIndex = 14;
            this.lblCityMun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbLname
            // 
            this.tbLname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbLname.Location = new System.Drawing.Point(131, 167);
            this.tbLname.Name = "tbLname";
            this.tbLname.Size = new System.Drawing.Size(209, 25);
            this.tbLname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "First name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFname
            // 
            this.tbFname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbFname.Location = new System.Drawing.Point(131, 198);
            this.tbFname.Name = "tbFname";
            this.tbFname.Size = new System.Drawing.Size(209, 25);
            this.tbFname.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Middle Initial:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbMI
            // 
            this.tbMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbMI.Location = new System.Drawing.Point(131, 229);
            this.tbMI.Name = "tbMI";
            this.tbMI.Size = new System.Drawing.Size(209, 25);
            this.tbMI.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Contact no.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbContact
            // 
            this.tbContact.Location = new System.Drawing.Point(131, 260);
            this.tbContact.Name = "tbContact";
            this.tbContact.Size = new System.Drawing.Size(209, 25);
            this.tbContact.TabIndex = 4;
            this.tbContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbContact_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Occupation:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Date of birth:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Address:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(58, 453);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Barangay:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 481);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 17);
            this.label14.TabIndex = 22;
            this.label14.Text = "City/Municipality:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbOccupation
            // 
            this.tbOccupation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbOccupation.Location = new System.Drawing.Point(130, 352);
            this.tbOccupation.Name = "tbOccupation";
            this.tbOccupation.Size = new System.Drawing.Size(209, 25);
            this.tbOccupation.TabIndex = 7;
            // 
            // tbAddress
            // 
            this.tbAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbAddress.Location = new System.Drawing.Point(130, 383);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(209, 63);
            this.tbAddress.TabIndex = 8;
            // 
            // dpDob
            // 
            this.dpDob.Location = new System.Drawing.Point(130, 321);
            this.dpDob.Name = "dpDob";
            this.dpDob.Size = new System.Drawing.Size(209, 25);
            this.dpDob.TabIndex = 6;
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
            this.btnSave.Location = new System.Drawing.Point(425, 535);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 25);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(494, 535);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 25);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnBrowsePic
            // 
            this.btnBrowsePic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnBrowsePic.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.btnBrowsePic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.btnBrowsePic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnBrowsePic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowsePic.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowsePic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnBrowsePic.Image = global::Lending_Management_System.Properties.Resources.icons8_Pictures_Folder_16;
            this.btnBrowsePic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowsePic.Location = new System.Drawing.Point(478, 289);
            this.btnBrowsePic.Name = "btnBrowsePic";
            this.btnBrowsePic.Size = new System.Drawing.Size(74, 25);
            this.btnBrowsePic.TabIndex = 29;
            this.btnBrowsePic.Text = "Browse";
            this.btnBrowsePic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowsePic.UseVisualStyleBackColor = false;
            this.btnBrowsePic.Click += new System.EventHandler(this.btnBrowsePic_Click);
            // 
            // bntOpenCam
            // 
            this.bntOpenCam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.bntOpenCam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.bntOpenCam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.bntOpenCam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.bntOpenCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntOpenCam.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntOpenCam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.bntOpenCam.Image = global::Lending_Management_System.Properties.Resources.icons8_Web_Camera_16;
            this.bntOpenCam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntOpenCam.Location = new System.Drawing.Point(361, 289);
            this.bntOpenCam.Name = "bntOpenCam";
            this.bntOpenCam.Size = new System.Drawing.Size(111, 25);
            this.bntOpenCam.TabIndex = 30;
            this.bntOpenCam.Text = "Open camera";
            this.bntOpenCam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntOpenCam.UseVisualStyleBackColor = false;
            this.bntOpenCam.Click += new System.EventHandler(this.bntOpenCam_Click);
            // 
            // BorrowerImg
            // 
            this.BorrowerImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorrowerImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BorrowerImg.Image = global::Lending_Management_System.Properties.Resources.Manager_96px;
            this.BorrowerImg.Location = new System.Drawing.Point(361, 130);
            this.BorrowerImg.Name = "BorrowerImg";
            this.BorrowerImg.Size = new System.Drawing.Size(191, 150);
            this.BorrowerImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BorrowerImg.TabIndex = 34;
            this.BorrowerImg.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 17);
            this.label12.TabIndex = 35;
            this.label12.Text = "Gender:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbGender
            // 
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "MALE",
            "FEMALE\t"});
            this.cbGender.Location = new System.Drawing.Point(130, 290);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(209, 25);
            this.cbGender.TabIndex = 5;
            // 
            // lblProv
            // 
            this.lblProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProv.Location = new System.Drawing.Point(131, 508);
            this.lblProv.Name = "lblProv";
            this.lblProv.Size = new System.Drawing.Size(210, 25);
            this.lblProv.TabIndex = 36;
            this.lblProv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(58, 512);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 17);
            this.label15.TabIndex = 37;
            this.label15.Text = "Province:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrgy
            // 
            this.btnBrgy.Image = global::Lending_Management_System.Properties.Resources.icons8_more_161;
            this.btnBrgy.Location = new System.Drawing.Point(326, 464);
            this.btnBrgy.Name = "btnBrgy";
            this.btnBrgy.Size = new System.Drawing.Size(31, 10);
            this.btnBrgy.TabIndex = 38;
            this.btnBrgy.UseVisualStyleBackColor = true;
            this.btnBrgy.Click += new System.EventHandler(this.btnBrgy_Click);
            // 
            // btnCityMun
            // 
            this.btnCityMun.Image = global::Lending_Management_System.Properties.Resources.icons8_more_161;
            this.btnCityMun.Location = new System.Drawing.Point(326, 492);
            this.btnCityMun.Name = "btnCityMun";
            this.btnCityMun.Size = new System.Drawing.Size(31, 10);
            this.btnCityMun.TabIndex = 39;
            this.btnCityMun.UseVisualStyleBackColor = true;
            this.btnCityMun.Click += new System.EventHandler(this.btnCityMun_Click);
            // 
            // btnProv
            // 
            this.btnProv.Image = global::Lending_Management_System.Properties.Resources.icons8_more_161;
            this.btnProv.Location = new System.Drawing.Point(326, 523);
            this.btnProv.Name = "btnProv";
            this.btnProv.Size = new System.Drawing.Size(31, 10);
            this.btnProv.TabIndex = 40;
            this.btnProv.UseVisualStyleBackColor = true;
            this.btnProv.Click += new System.EventHandler(this.btnProv_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.btnProv);
            this.mainPanel.Controls.Add(this.btnCityMun);
            this.mainPanel.Controls.Add(this.btnBrgy);
            this.mainPanel.Controls.Add(this.label15);
            this.mainPanel.Controls.Add(this.lblProv);
            this.mainPanel.Controls.Add(this.cbGender);
            this.mainPanel.Controls.Add(this.label12);
            this.mainPanel.Controls.Add(this.BorrowerImg);
            this.mainPanel.Controls.Add(this.bntOpenCam);
            this.mainPanel.Controls.Add(this.btnBrowsePic);
            this.mainPanel.Controls.Add(this.btnCancel);
            this.mainPanel.Controls.Add(this.btnSave);
            this.mainPanel.Controls.Add(this.dpDob);
            this.mainPanel.Controls.Add(this.tbAddress);
            this.mainPanel.Controls.Add(this.tbOccupation);
            this.mainPanel.Controls.Add(this.label14);
            this.mainPanel.Controls.Add(this.label10);
            this.mainPanel.Controls.Add(this.label8);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.tbContact);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.tbMI);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.tbFname);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.tbLname);
            this.mainPanel.Controls.Add(this.lblCityMun);
            this.mainPanel.Controls.Add(this.lblBrgy);
            this.mainPanel.Controls.Add(this.lblBorrowerNo);
            this.mainPanel.Controls.Add(this.label11);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(5, 25);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(576, 576);
            this.mainPanel.TabIndex = 0;
            // 
            // frmBorrowerReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(119)))), ((int)(((byte)(116)))));
            this.ClientSize = new System.Drawing.Size(586, 606);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBorrowerReg";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBorrowerReg";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowerImg)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBorrowerNo;
        private System.Windows.Forms.Label lblBrgy;
        private System.Windows.Forms.Label lblCityMun;
        private System.Windows.Forms.TextBox tbLname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbContact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbOccupation;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.DateTimePicker dpDob;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBrowsePic;
        private System.Windows.Forms.Button bntOpenCam;
        private System.Windows.Forms.PictureBox BorrowerImg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label lblProv;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnBrgy;
        private System.Windows.Forms.Button btnCityMun;
        private System.Windows.Forms.Button btnProv;
        private System.Windows.Forms.Panel mainPanel;
    }
}