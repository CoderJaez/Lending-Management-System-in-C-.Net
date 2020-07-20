namespace Lending_Management_System
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnMin = new System.Windows.Forms.ToolStripButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.UserImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.HeaderPanel = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SidebarPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.UserName = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnBorrower = new System.Windows.Forms.Button();
            this.btnBAccounts = new System.Windows.Forms.Button();
            this.btnLoan = new System.Windows.Forms.Button();
            this.btnPosting = new System.Windows.Forms.Button();
            this.btnCollectibles = new System.Windows.Forms.Button();
            this.btnRemittance = new System.Windows.Forms.Button();
            this.btnPastdue = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnMyAccount = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.isClicked = new System.Windows.Forms.Panel();
            this.SidebarPanelBG = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            this.SidebarPanel.SuspendLayout();
            this.SidebarPanelBG.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnMin});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(1107, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Enabled = false;
            this.btnExit.Image = global::Lending_Management_System.Properties.Resources.Delete_24px;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(23, 22);
            this.btnExit.Text = "Close";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMin
            // 
            this.btnMin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMin.Image = global::Lending_Management_System.Properties.Resources.Subtract_24px;
            this.btnMin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(23, 22);
            this.btnMin.Text = "Minimize";
            this.btnMin.Visible = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 200;
            this.bunifuElipse1.TargetControl = this.UserImage;
            // 
            // UserImage
            // 
            this.UserImage.BackColor = System.Drawing.Color.Transparent;
            this.UserImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UserImage.BackgroundImage")));
            this.UserImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UserImage.Location = new System.Drawing.Point(40, 13);
            this.UserImage.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.UserImage.Name = "UserImage";
            this.UserImage.Size = new System.Drawing.Size(136, 137);
            this.UserImage.TabIndex = 2;
            this.UserImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MainPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(208, 102);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(899, 547);
            this.panel1.TabIndex = 4;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(119)))), ((int)(((byte)(116)))));
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(10, 10);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(3);
            this.MainPanel.Size = new System.Drawing.Size(879, 527);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 10;
            this.bunifuElipse2.TargetControl = this.MainPanel;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(89)))), ((int)(((byte)(102)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(146)))), ((int)(((byte)(128)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(119)))), ((int)(((byte)(116)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(127)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(208, 649);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(899, 70);
            this.bunifuGradientPanel1.TabIndex = 3;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HeaderPanel.BackgroundImage")));
            this.HeaderPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HeaderPanel.Controls.Add(this.label1);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(89)))), ((int)(((byte)(102)))));
            this.HeaderPanel.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(146)))), ((int)(((byte)(128)))));
            this.HeaderPanel.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(119)))), ((int)(((byte)(116)))));
            this.HeaderPanel.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(127)))), ((int)(((byte)(169)))));
            this.HeaderPanel.Location = new System.Drawing.Point(208, 25);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Quality = 10;
            this.HeaderPanel.Size = new System.Drawing.Size(899, 77);
            this.HeaderPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "BRAR LENDING INVESTOR";
            // 
            // SidebarPanel
            // 
            this.SidebarPanel.BackColor = System.Drawing.Color.Transparent;
            this.SidebarPanel.Controls.Add(this.UserImage);
            this.SidebarPanel.Controls.Add(this.UserName);
            this.SidebarPanel.Controls.Add(this.btnDashboard);
            this.SidebarPanel.Controls.Add(this.btnBorrower);
            this.SidebarPanel.Controls.Add(this.btnBAccounts);
            this.SidebarPanel.Controls.Add(this.btnLoan);
            this.SidebarPanel.Controls.Add(this.btnPosting);
            this.SidebarPanel.Controls.Add(this.btnCollectibles);
            this.SidebarPanel.Controls.Add(this.btnRemittance);
            this.SidebarPanel.Controls.Add(this.btnPastdue);
            this.SidebarPanel.Controls.Add(this.btnReports);
            this.SidebarPanel.Controls.Add(this.btnMyAccount);
            this.SidebarPanel.Controls.Add(this.btnSettings);
            this.SidebarPanel.Controls.Add(this.btnLogout);
            this.SidebarPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.SidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.SidebarPanel.Name = "SidebarPanel";
            this.SidebarPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.SidebarPanel.Size = new System.Drawing.Size(208, 694);
            this.SidebarPanel.TabIndex = 0;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.BackColor = System.Drawing.Color.Transparent;
            this.UserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.UserName.Location = new System.Drawing.Point(3, 153);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(202, 21);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "Admin admin";
            this.UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(146)))), ((int)(((byte)(128)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDashboard.Image = global::Lending_Management_System.Properties.Resources.icons8_Combo_Chart_32;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(3, 177);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(202, 30);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = " Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Visible = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnBorrower
            // 
            this.btnBorrower.BackColor = System.Drawing.Color.Transparent;
            this.btnBorrower.FlatAppearance.BorderSize = 0;
            this.btnBorrower.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnBorrower.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnBorrower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrower.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBorrower.Image = global::Lending_Management_System.Properties.Resources.icons8_Conference_32;
            this.btnBorrower.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrower.Location = new System.Drawing.Point(3, 213);
            this.btnBorrower.Name = "btnBorrower";
            this.btnBorrower.Size = new System.Drawing.Size(202, 30);
            this.btnBorrower.TabIndex = 2;
            this.btnBorrower.Text = " Borrowers";
            this.btnBorrower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrower.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrower.UseVisualStyleBackColor = false;
            this.btnBorrower.Visible = false;
            this.btnBorrower.Click += new System.EventHandler(this.btnBorrower_Click);
            // 
            // btnBAccounts
            // 
            this.btnBAccounts.BackColor = System.Drawing.Color.Transparent;
            this.btnBAccounts.FlatAppearance.BorderSize = 0;
            this.btnBAccounts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnBAccounts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnBAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBAccounts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBAccounts.Image = global::Lending_Management_System.Properties.Resources.icons8_General_Ledger_32;
            this.btnBAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBAccounts.Location = new System.Drawing.Point(3, 249);
            this.btnBAccounts.Name = "btnBAccounts";
            this.btnBAccounts.Size = new System.Drawing.Size(202, 30);
            this.btnBAccounts.TabIndex = 2;
            this.btnBAccounts.Text = " Borrower\'s accounts";
            this.btnBAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBAccounts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBAccounts.UseVisualStyleBackColor = false;
            this.btnBAccounts.Visible = false;
            this.btnBAccounts.Click += new System.EventHandler(this.btnBAccounts_Click);
            // 
            // btnLoan
            // 
            this.btnLoan.BackColor = System.Drawing.Color.Transparent;
            this.btnLoan.FlatAppearance.BorderSize = 0;
            this.btnLoan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnLoan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLoan.Image = global::Lending_Management_System.Properties.Resources.icons8_Budget_32;
            this.btnLoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoan.Location = new System.Drawing.Point(3, 285);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(202, 30);
            this.btnLoan.TabIndex = 2;
            this.btnLoan.Text = "Loan application";
            this.btnLoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoan.UseVisualStyleBackColor = false;
            this.btnLoan.Visible = false;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // btnPosting
            // 
            this.btnPosting.BackColor = System.Drawing.Color.Transparent;
            this.btnPosting.FlatAppearance.BorderSize = 0;
            this.btnPosting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnPosting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnPosting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosting.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPosting.Image = global::Lending_Management_System.Properties.Resources.icons8_Cash_Register_32;
            this.btnPosting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPosting.Location = new System.Drawing.Point(3, 321);
            this.btnPosting.Name = "btnPosting";
            this.btnPosting.Size = new System.Drawing.Size(202, 30);
            this.btnPosting.TabIndex = 2;
            this.btnPosting.Text = "Posting";
            this.btnPosting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPosting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPosting.UseVisualStyleBackColor = false;
            this.btnPosting.Visible = false;
            this.btnPosting.Click += new System.EventHandler(this.btnPosting_Click);
            // 
            // btnCollectibles
            // 
            this.btnCollectibles.BackColor = System.Drawing.Color.Transparent;
            this.btnCollectibles.FlatAppearance.BorderSize = 0;
            this.btnCollectibles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnCollectibles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnCollectibles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollectibles.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCollectibles.Image = global::Lending_Management_System.Properties.Resources.icons8_Collectibles_32;
            this.btnCollectibles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCollectibles.Location = new System.Drawing.Point(3, 357);
            this.btnCollectibles.Name = "btnCollectibles";
            this.btnCollectibles.Size = new System.Drawing.Size(202, 30);
            this.btnCollectibles.TabIndex = 2;
            this.btnCollectibles.Text = " Collectibles";
            this.btnCollectibles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCollectibles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCollectibles.UseVisualStyleBackColor = false;
            this.btnCollectibles.Visible = false;
            this.btnCollectibles.Click += new System.EventHandler(this.btnCollectibles_Click);
            // 
            // btnRemittance
            // 
            this.btnRemittance.BackColor = System.Drawing.Color.Transparent;
            this.btnRemittance.FlatAppearance.BorderSize = 0;
            this.btnRemittance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnRemittance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnRemittance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemittance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemittance.Image = global::Lending_Management_System.Properties.Resources.icons8_Cash_in_Hand_32;
            this.btnRemittance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemittance.Location = new System.Drawing.Point(3, 393);
            this.btnRemittance.Name = "btnRemittance";
            this.btnRemittance.Size = new System.Drawing.Size(202, 30);
            this.btnRemittance.TabIndex = 2;
            this.btnRemittance.Text = "Remittances";
            this.btnRemittance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemittance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemittance.UseVisualStyleBackColor = false;
            this.btnRemittance.Visible = false;
            this.btnRemittance.Click += new System.EventHandler(this.btnRemittance_Click);
            // 
            // btnPastdue
            // 
            this.btnPastdue.BackColor = System.Drawing.Color.Transparent;
            this.btnPastdue.FlatAppearance.BorderSize = 0;
            this.btnPastdue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnPastdue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnPastdue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPastdue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPastdue.Image = global::Lending_Management_System.Properties.Resources.icons8_Schedule_32;
            this.btnPastdue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPastdue.Location = new System.Drawing.Point(3, 429);
            this.btnPastdue.Name = "btnPastdue";
            this.btnPastdue.Size = new System.Drawing.Size(202, 30);
            this.btnPastdue.TabIndex = 2;
            this.btnPastdue.Text = "Past due";
            this.btnPastdue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPastdue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPastdue.UseVisualStyleBackColor = false;
            this.btnPastdue.Visible = false;
            this.btnPastdue.Click += new System.EventHandler(this.btnPastdue_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.Transparent;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReports.Image = global::Lending_Management_System.Properties.Resources.icons8_Graph_Report_32;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(3, 465);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(202, 30);
            this.btnReports.TabIndex = 2;
            this.btnReports.Text = "Summary";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnMyAccount
            // 
            this.btnMyAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnMyAccount.FlatAppearance.BorderSize = 0;
            this.btnMyAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnMyAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnMyAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyAccount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMyAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnMyAccount.Image")));
            this.btnMyAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyAccount.Location = new System.Drawing.Point(3, 501);
            this.btnMyAccount.Name = "btnMyAccount";
            this.btnMyAccount.Size = new System.Drawing.Size(202, 30);
            this.btnMyAccount.TabIndex = 4;
            this.btnMyAccount.Text = "My account";
            this.btnMyAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMyAccount.UseVisualStyleBackColor = false;
            this.btnMyAccount.Click += new System.EventHandler(this.btnMyAccount_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSettings.Image = global::Lending_Management_System.Properties.Resources.icons8_Services_32;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(3, 537);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(202, 30);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Visible = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(122)))), ((int)(((byte)(120)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(3, 573);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(202, 34);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // isClicked
            // 
            this.isClicked.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.isClicked.Location = new System.Drawing.Point(3, 172);
            this.isClicked.Name = "isClicked";
            this.isClicked.Size = new System.Drawing.Size(10, 32);
            this.isClicked.TabIndex = 2;
            // 
            // SidebarPanelBG
            // 
            this.SidebarPanelBG.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SidebarPanelBG.BackgroundImage")));
            this.SidebarPanelBG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SidebarPanelBG.Controls.Add(this.SidebarPanel);
            this.SidebarPanelBG.Controls.Add(this.isClicked);
            this.SidebarPanelBG.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidebarPanelBG.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(89)))), ((int)(((byte)(102)))));
            this.SidebarPanelBG.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(146)))), ((int)(((byte)(128)))));
            this.SidebarPanelBG.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(119)))), ((int)(((byte)(116)))));
            this.SidebarPanelBG.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(127)))), ((int)(((byte)(169)))));
            this.SidebarPanelBG.Location = new System.Drawing.Point(0, 25);
            this.SidebarPanelBG.Name = "SidebarPanelBG";
            this.SidebarPanelBG.Quality = 10;
            this.SidebarPanelBG.Size = new System.Drawing.Size(208, 694);
            this.SidebarPanelBG.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1107, 719);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.SidebarPanelBG);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.SidebarPanel.ResumeLayout(false);
            this.SidebarPanel.PerformLayout();
            this.SidebarPanelBG.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnMin;
        private System.Windows.Forms.Panel isClicked;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnPastdue;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnBAccounts;
        private System.Windows.Forms.Button btnBorrower;
        private System.Windows.Forms.Button btnRemittance;
        private System.Windows.Forms.Button btnCollectibles;
        private System.Windows.Forms.Button btnPosting;
        private System.Windows.Forms.Button btnLoan;
        private Bunifu.Framework.UI.BunifuGradientPanel HeaderPanel;
        private System.Windows.Forms.FlowLayoutPanel SidebarPanel;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel MainPanel;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox UserImage;
        private System.Windows.Forms.Button btnMyAccount;
        private System.Windows.Forms.Button btnLogout;
        private Bunifu.Framework.UI.BunifuGradientPanel SidebarPanelBG;
    }
}

