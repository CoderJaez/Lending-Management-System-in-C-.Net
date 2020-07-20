using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lending_Management_System
{
    public partial class frmSettings : UserControl
    {
        Modules.Settings settings = new Modules.Settings();
        Modules.user users = new Modules.user();
        int areaID;
        int termID;
        int intID;
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public frmSettings()
        {
            InitializeComponent();
            
        }




        private void btnAddArea_Click(object sender, EventArgs e)
        {
            frmArea area = new frmArea(this);
            area.areaID = "";
            area.area = "";
            area.UpdateEvenHandler += UpdateEventHandler;
            area.ShowDialog();
        }

        private void btnInterestFrm_Click(object sender, EventArgs e)
        {
            
            frmInterest interest = new frmInterest(this);
            interest.UpdateEvenHandler += UpdateEventHandlerInterest;
            interest.ShowDialog();
        }

        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            frmTerm term = new frmTerm(this);
            term.termID = "";
            term.term = "";
            term.durations = "";
            term.UpdateEvenHandler += UpdateEventHandlerTerm;
            term.ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            
            frmUserReg user = new frmUserReg(this);
            user.UpdateEvenHandler += UpdateEventHandlerUser;
            user.userID = users.getMemID();
            user.isUpdate = false;
            user.loadPosition();
            user.ShowDialog();
        }

        //LOAD INTEREST
        public void loadInterest()
        {
            DataTable dt;
            int no = 0;
            dt = settings.loadInterest();
            dgInterest.Rows.Clear();
            foreach (DataRow rows in dt.Rows)
            {

                dgInterest.Rows.Add(no + 1, rows["interest"].ToString().ToUpper());
                dgInterest.Rows[no].Cells[0].Tag = rows["intID"];
                no++;
            }
            dt.Dispose();
        }
        //END LOAD INTEREST

        //LOAD AREA
        public void loadArea()
        {
            DataTable dt;
            int no = 0;
            dt = settings.loadArea();
            dgArea.Rows.Clear();
            foreach (DataRow rows in dt.Rows)
            {

                dgArea.Rows.Add(no + 1, rows["area"].ToString().ToUpper());
                dgArea.Rows[no].Cells[0].Tag = rows["areaID"];
                no++;
            }
            dt.Dispose();
        }
        //END LOAD AREA
        
        //LOAD TERM
         public void loadTerm()
        {
            DataTable dt;
            int no = 0;
            dt = settings.loadTerm();
            dgTerms.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dgTerms.Rows.Add(no + 1, row["terms"].ToString().ToUpper(), row["durations"].ToString());
                dgTerms.Rows[no].Cells[0].Tag = row["termsID"];
                no++;
            }
            dt.Dispose();
        }
        //END LOAD TERM

        private void dgArea_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            frmArea area = new frmArea(this);
            switch (e.ColumnIndex)
            {
                case 2:
                   if (e.RowIndex >= 0)
                    {
                        area.areaID = dgArea.Rows[e.RowIndex].Cells[0].Tag.ToString();
                        area.area = dgArea.Rows[e.RowIndex].Cells[1].Value.ToString();
                        area.previousData = dgArea.Rows[e.RowIndex].Cells[1].Value.ToString();
                        area.UpdateEvenHandler += UpdateEventHandler;
                        area.ShowDialog();
                    }
                    break;
                case 3:
                    if (e.RowIndex >= 0)
                    {
                        DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            areaID = Convert.ToInt16(dgArea.Rows[e.RowIndex].Cells[0].Tag);
                            settings.deleteArea(areaID);
                            loadArea();
                        }
                    }
                    break;
                case 4:
                    if (e.RowIndex >= 0)
                    {
                        if (Convert.ToBoolean(dgArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                        {
                            dgArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        }
                        else
                        {
                            dgArea.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        }

                    }
                    break;
                default:
                    break;
            }
            
        }

        private void btnDeleteArea_Click(object sender, EventArgs e)
        {
            int toDelete = 0;
            for (int i = 0; i < dgArea.Rows.Count; i++)
            {
                if(Convert.ToBoolean(dgArea.Rows[i].Cells[4].Value) == true)
                {
                    toDelete++;
                }
            }
            if(toDelete <= 0)
            {
                MessageBox.Show("No row(s) selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                 DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if ( result == DialogResult.Yes)
                {
                    for (int i = 0; i < dgArea.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgArea.Rows[i].Cells[4].Value) == true)
                        {
                            areaID = Convert.ToInt16(dgArea.Rows[i].Cells[0].Tag);
                            settings.deleteArea(areaID);
                        }
                    }
                    loadArea();
                }
            }
        }

       //EventHandler for AREA
        private void UpdateEventHandler(object sender, frmArea.UpdateEventArgs args)
        {
            loadArea();
        }
        //END EvenHandler for AREA

        //EventHandler for Term
        private void UpdateEventHandlerTerm(object sender, frmTerm.UpdateEventArgs args)
        {
            loadTerm();
        }
        //END EventHandler for Term


        //EventHandler for Interest
        private void UpdateEventHandlerInterest(object sender, frmInterest.UpdateEventArgs args)
        {
            loadInterest();
        }
        //END EventHandler for Interest

        //EventHandler for User Registration
        private void UpdateEventHandlerUser(object sender, frmUserReg.UpdateEventArgs args)
        {
            loadUserList();
        }
        //END EventHandler for User Registration


        //EventHandler for User Collector
        private void UpdateEventHandlerCollector(object sender, frmInterest.UpdateEventArgs args)
        {
            loadInterest();
        }
        //END EventHandler for User Collector

        //EventHandler for User Postion
        private void UpdateEventHandlerPosition(object sender, frmPosition.UpdateEventArgs args)
        {
            loadPosition();
        }
        //END EventHandler for User Postion

        //EventHandler for Collector
        private void UpdateEventHandlerCollector(object sender, frmCollector.UpdateEventArgs args)
        {
            loadCollector();
        }
        //END EventHandler for Collector




        private void btnSelectArea_Click(object sender, EventArgs e)
        {
            if(btnSelectArea.Tag.ToString() == "false")
            {
                btnSelectArea.Tag = "true";
                for (int i = 0; i < dgArea.Rows.Count; i++)
                {
                    dgArea.Rows[i].Cells[4].Value = true;

                }
            } else
            {
                btnSelectArea.Tag = "false";
                for (int i = 0; i < dgArea.Rows.Count; i++)
                {
                    dgArea.Rows[i].Cells[4].Value = false;

                }
            }
        }

        //frmSettings load event
        #region frmSettings load event
        private void frmSettings_Load(object sender, EventArgs e)
        {
            //loadArea();
            loadTerm();
            loadLimitAcc();
            loadAmountsLoanable();
            loadInterest();
            loadPosition();
            loadUserList();
            loadCollector();
        }
        #endregion
        //frmSettings load event

        private void dgTerms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmTerm term = new frmTerm(this);

            switch(e.ColumnIndex)
            {
                case 3:
                    if (e.RowIndex >= 0)
                    {
                        term.termID = dgTerms.Rows[e.RowIndex].Cells[0].Tag.ToString();
                        term.term = dgTerms.Rows[e.RowIndex].Cells[1].Value.ToString();
                        term.durations = dgTerms.Rows[e.RowIndex].Cells[2].Value.ToString();
                        term.UpdateEvenHandler += UpdateEventHandlerTerm;
                        term.ShowDialog();
                    }
                    break;
                case 4:

                    if (e.RowIndex >= 0)
                    {
                         DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {

                            termID = Convert.ToInt16(dgTerms.Rows[e.RowIndex].Cells[0].Tag);
                            settings.deleteTerm(termID);
                            loadTerm();
                        }
                    }
                    break;
                case 5:
                    if (e.RowIndex >= 0)
                    {
                        if (Convert.ToBoolean(dgTerms.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                        {
                            dgTerms.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        }
                        else
                        {
                            dgTerms.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        }
                    }
                    break;

            }
        }

        private void btnSelectTerm_Click(object sender, EventArgs e)
        {
            if (btnSelectTerm.Tag.ToString() == "check")
            {
                btnSelectTerm.Tag = "uncheck";
                for (int i = 0; i < dgTerms.Rows.Count; i++)
                {
                    dgTerms.Rows[i].Cells[5].Value = true;

                }
            }
            else
            {
                btnSelectTerm.Tag = "check";
                for (int i = 0; i < dgTerms.Rows.Count; i++)
                {
                    dgTerms.Rows[i].Cells[5].Value = false;

                }
            }
        }

        private void btnDeleteTerm_Click(object sender, EventArgs e)
        {

            int toDelete = 0;
            for (int i = 0; i < dgTerms.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgTerms.Rows[i].Cells[5].Value) == true)
                {
                    toDelete++;
                }
            }
            if (toDelete <= 0)
            {
                MessageBox.Show("No row(s) selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dgTerms.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgTerms.Rows[i].Cells[5].Value) == true)
                        {
                            termID = Convert.ToInt16(dgTerms.Rows[i].Cells[0].Tag);
                            settings.deleteTerm(termID);
                        }
                    }
                    loadTerm();
                }
            }
        }

        private void btnSaveLimitAcc_Click(object sender, EventArgs e)
        {
           if ( tbLimitAccounts.Text != "")
            {
                int accs = Convert.ToInt16(tbLimitAccounts.Text);
                if (settings.updateLimits(accs))
                {
                    MessageBox.Show("Successfully updated!", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadLimitAcc();
                }
            } else
            {
                    MessageBox.Show("Please fill up the field!", "Limit account field is empty.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //START-LOAD ACCOUNTS TO BE CREATED
        public void loadLimitAcc()
        {
            tbLimitAccounts.Text = settings.LimitAcct().ToString();
            tbLimitAccounts.Enabled = false;
            btnSaveLimitAcc.Enabled = false;
        }
        //END-LOAD ACCOUNTS TO BE CREATED

        //START-LOAD AMOUNTS TO BE LOAN
        #region LOAD AMOUNTS TO BE LOAN
        public void loadAmountsLoanable()
        {
            tbMin.Text = settings.amountsLoanable()[0].ToString();
            tbMax.Text = settings.amountsLoanable()[1].ToString();
            tbMin.Enabled = false;
            tbMax.Enabled = false;
            btnSaveAmount.Enabled = false;
            btnModifyAmount.Enabled = true;
        }

        //END-LOAD AMOUNTS TO BE LOAN
        #endregion

        //START-LOAD POSITION 
        #region LOAD POSITION
          public void loadPosition()
        {
            DataTable dt = settings.loadPosition();
            int no = 0;
            dgPosition.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dgPosition.Rows.Add(no + 1, row["position"], row["accounts"], row["borrowers"], row["collectibles"], row["dashboard"], row["loans"],row["pastdue"], row["posting"], row["remittances"], row["reports"], row["settings"]);
                dgPosition.Rows[no].Cells[0].Tag = row["posID"];
                no++;
            }
            dt.Dispose();
        }
        #endregion
        //END-LOAD POSITION 
        #region LOAD USERLIST
        public void loadUserList()
        {
            int no = 0;
            dgUser.Rows.Clear();

            foreach (DataRow row in users.loadUserList().Rows) 
            {
                    dgUser.Rows.Add(no + 1,row["memID"].ToString(), row["name"].ToString().ToUpper(), row["contact"], row["uname"], row["position"]);
                    no++;
            }
        }
        #endregion


        private void btnModifyLimitAcc_Click(object sender, EventArgs e)
        {
            tbLimitAccounts.Enabled = true;
            btnModifyLimitAcc.Enabled = false;
            btnSaveLimitAcc.Enabled = true;
        }

        private void btnCancelLimit_Click(object sender, EventArgs e)
        {
            loadLimitAcc();

        }

        private void tbLimitAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnModifyAmount_Click(object sender, EventArgs e)
        {
            tbMin.Enabled = true;
            tbMax.Enabled = true;
            btnSaveAmount.Enabled = true;
            tbMin.Focus();
            btnModifyAmount.Enabled = false; 
        }

        private void tbMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void tbMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnCancelAmount_Click(object sender, EventArgs e)
        {
            loadAmountsLoanable();
            btnModifyAmount.Enabled = true;
        }

        private void btnSaveAmount_Click(object sender, EventArgs e)
        {
           if(tbMin.Text != "" && tbMax.Text != "")
            {
                if (settings.saveLoanAmounts(Convert.ToDouble(tbMin.Text), Convert.ToDouble(tbMax.Text)))
                {
                    MessageBox.Show("Successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                loadAmountsLoanable();
            } else
            {
                MessageBox.Show("Pleased fill out all the fields", "Min/Max amount empty.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void dgInterest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            frmInterest interest = new frmInterest(this);
            switch (e.ColumnIndex)
            {
                case 2:
                    if (e.RowIndex >= 0)
                    {
                        interest.intID = dgInterest.Rows[e.RowIndex].Cells[0].Tag.ToString();
                        interest.interest = dgInterest.Rows[e.RowIndex].Cells[1].Value.ToString();
                        interest.UpdateEvenHandler += UpdateEventHandlerInterest;
                        interest.ShowDialog();
                    }
                    break;
                case 3:
                    if (e.RowIndex >= 0)
                    {
                        DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {

                            intID = Convert.ToInt16(dgInterest.Rows[e.RowIndex].Cells[0].Tag);
                            settings.deleteInterest(intID);
                            loadInterest();
                        }
                    }
                    break;
                case 4:
                    if (Convert.ToBoolean(dgInterest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                    {
                        dgInterest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }
                    else
                    {
                        dgInterest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    }

                    break;
                default:
                    break;
            }
        }

        private void btnSelectInterest_Click(object sender, EventArgs e)
        {
            if (btnSelectInterest.Tag.ToString() == "check")
            {
                btnSelectInterest.Tag = "uncheck";
                for (int i = 0; i < dgInterest.Rows.Count; i++)
                {
                    dgInterest.Rows[i].Cells[4].Value = true;

                }
            }
            else
            {
                btnSelectInterest.Tag = "check";
                for (int i = 0; i < dgInterest.Rows.Count; i++)
                {
                    dgInterest.Rows[i].Cells[4].Value = false;

                }
            }
        }

        private void btnDeleteInterest_Click(object sender, EventArgs e)
        {

            int toDelete = 0;
            for (int i = 0; i < dgInterest.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgInterest.Rows[i].Cells[4].Value) == true)
                {
                    toDelete++;
                }
            }
            if (toDelete <= 0)
            {
                MessageBox.Show("No row(s) selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dgInterest.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgInterest.Rows[i].Cells[4].Value) == true)
                        {
                            intID = Convert.ToInt16(dgInterest.Rows[i].Cells[0].Tag);
                            settings.deleteInterest(intID);
                        }
                    }
                    loadInterest();
                }
            }
        }

        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            frmPosition pos = new frmPosition(this);
            pos.UpdateEvenHandler += UpdateEventHandlerPosition;
            pos.loadModules();
            pos.ShowDialog();
        }

        private void dgPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmPosition pos = new frmPosition(this);
            DataTable modules = new DataTable();
            switch (e.ColumnIndex)
            {
                case 12:
                   if(e.RowIndex >= 0)
                    {
                        modules.Columns.Add("permission", typeof(Boolean));
                        for (int i = 0; i < 10; i++)
                        {
                            modules.Rows.Add(Convert.ToBoolean(dgPosition.Rows[e.RowIndex].Cells[i + 2].Value));

                        }
                        pos.posID = dgPosition.Rows[e.RowIndex].Cells[0].Tag.ToString();
                        pos.position = dgPosition.Rows[e.RowIndex].Cells[1].Value.ToString();
                        pos.loadModules(modules);
                        pos.UpdateEvenHandler += UpdateEventHandlerPosition;
                        pos.ShowDialog();
                    }
                    break;
                case 13:
                    if (e.RowIndex >= 0)
                    {
                        DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {

                            intID = Convert.ToInt16(dgInterest.Rows[e.RowIndex].Cells[0].Tag);
                            settings.deletePosition(intID);
                            loadPosition();
                        }
                    }
                    break;
                case 14:
                    if (Convert.ToBoolean(dgPosition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                    {
                        dgPosition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }
                    else
                    {
                        dgPosition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnDeletePosition_Click(object sender, EventArgs e)
        {

            int toDelete = 0;
            for (int i = 0; i < dgPosition.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgPosition.Rows[i].Cells[14].Value) == true)
                {
                    toDelete++;
                }
            }
            if (toDelete <= 0)
            {
                MessageBox.Show("No row(s) selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dgPosition.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgPosition.Rows[i].Cells[14].Value) == true)
                        {
                            intID = Convert.ToInt16(dgPosition.Rows[i].Cells[0].Tag);
                            settings.deletePosition(intID);
                        }
                    }
                    loadPosition();
                }
            }
        }

        private void btnSelectPosition_Click(object sender, EventArgs e)
        {
            if (btnSelectPosition.Tag.ToString() == "check")
            {
                btnSelectPosition.Tag = "uncheck";
                for (int i = 0; i < dgPosition.Rows.Count; i++)
                {
                    dgPosition.Rows[i].Cells[14].Value = true;

                }
            }
            else
            {
                btnSelectPosition.Tag = "check";
                for (int i = 0; i < dgPosition.Rows.Count; i++)
                {
                    dgPosition.Rows[i].Cells[14].Value = false;

                }
            }
        }

        private void dgUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUserReg user = new frmUserReg(this);
            switch (e.ColumnIndex)
            {
                case 6:
                    if (e.RowIndex >= 0)
                    {
                        user.userID = dgUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                        user.isUpdate = true;
                        user.loadPosition();
                        user.loadUserInfo();
                        user.UpdateEvenHandler += UpdateEventHandlerUser;
                        user.ShowDialog();
                    }
                     
                    break;
                case 7://Delete user
                    if (e.RowIndex >= 0)
                    {
                        DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            users.memID = dgUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                            if (users.DeleteUser())
                            {
                                MessageBox.Show("Selected row(s) deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgUser.Rows.RemoveAt(e.RowIndex);
                            }

                        }
                    }
                    break;
                case 8://Check user

                    if (e.RowIndex >= 0)
                    {
                        if (Convert.ToBoolean(dgUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                        {
                            dgUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        }
                        else
                        {
                            dgUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        }

                    }
                    break;
                default:
                    break;
            }

        }

        private void btnSelectUserAll_Click(object sender, EventArgs e)
        {
            if (btnSelectUserAll.Tag.ToString() == "check")
            {
                btnSelectUserAll.Tag = "uncheck";
                for (int i = 0; i < dgUser.Rows.Count; i++)
                {
                    dgUser.Rows[i].Cells[8].Value = true;

                }
            }
            else
            {
                btnSelectUserAll.Tag = "check";
                for (int i = 0; i < dgUser.Rows.Count; i++)
                {
                    dgUser.Rows[i].Cells[8].Value = false;

                }
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {

            int toDelete = 0;
            for (int i = 0; i < dgUser.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgUser.Rows[i].Cells[8].Value) == true)
                {
                    toDelete++;
                }
            }
            if (toDelete <= 0)
            {
                MessageBox.Show("No row(s) selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dgUser.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgUser.Rows[i].Cells[8].Value) == true)
                        {
                            users.memID = dgUser.Rows[i].Cells[1].Value.ToString();
                            users.DeleteUser();
                            dgUser.Rows.RemoveAt(i); 
                        }
                    }
                    MessageBox.Show("Selected row(s) deleted.", "Vil Jims Lending Investor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tbSearchUser_TextChanged(object sender, EventArgs e)
        {
            int no = 0;
            dgUser.Rows.Clear();

            foreach (DataRow row in users.loadUserList(tbSearchUser.Text).Rows)
            {
                dgUser.Rows.Add(no + 1, row["memID"].ToString(), row["name"].ToString().ToUpper(), row["contact"], row["uname"], row["position"]);
                no++;
            }
        }

        private void btnAddCollector_Click(object sender, EventArgs e)
        {
            frmCollector collector = new frmCollector(this);
            collector.UpdateEvenHandler += UpdateEventHandlerCollector;
            collector.isUpdate = false;
            collector.memID = users.getMemID();
            //collector.loadArea();
            collector.ShowDialog();
            
        }
        //END-LOAD ACCOUNTS TO BE CREATED



        #region Collector

        public void loadCollector()
        {
            int no = 0;
            dgCollector.Rows.Clear();
            foreach (DataRow row in users.loadCollectorList().Rows)
            {
                dgCollector.Rows.Add(no + 1,row["memID"].ToString() ,row["name"].ToString(),row["contact"].ToString());
                no++;
            }
        }


        private void btnSelectAllCollector_Click(object sender, EventArgs e)
        {
            if (btnSelectAllCollector.Tag.ToString() == "check")
            {
                btnSelectAllCollector.Tag = "uncheck";
                for (int i = 0; i < dgCollector.Rows.Count; i++)
                {
                    dgCollector.Rows[i].Cells[6].Value = true;

                }
            }
            else
            {
                btnSelectAllCollector.Tag = "check";
                for (int i = 0; i < dgCollector.Rows.Count; i++)
                {
                    dgCollector.Rows[i].Cells[6].Value = false;

                }
            }
        }

        private void btnDeleteCollector_Click(object sender, EventArgs e)
        {

            int toDelete = 0;
            for (int i = 0; i < dgCollector.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgCollector.Rows[i].Cells[6].Value) == true)
                {
                    toDelete++;
                }
            }
            if (toDelete <= 0)
            {
                MessageBox.Show("No row(s) selected!", "Vil James Lending Investor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Vil James Lending Investor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dgCollector.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgCollector.Rows[i].Cells[7].Value) == true)
                        {
                            users.memID = dgCollector.Rows[i].Cells[1].Value.ToString();
                            users.deleteCollector();
                            dgCollector.Rows.RemoveAt(i);
                        }
                    }
                    MessageBox.Show("Selected row(s) deleted.", "Vil James Lending Investor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //loadCollector();
                }
            }
        }

        private void tbSearchCollector_TextChanged(object sender, EventArgs e)
        {
            int no = 0;
            dgCollector.Rows.Clear();
            foreach (DataRow row in users.loadCollectorList(tbSearchCollector.Text).Rows)
            {
                dgCollector.Rows.Add(no + 1, row["memID"].ToString(), row["name"].ToString(), row["contact"].ToString(), row["area"].ToString());
                no++;
            }
        }

        private void dgCollector_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 4:
                        frmCollector col = new frmCollector(this);
                        col.memID = dgCollector.Rows[e.RowIndex].Cells[1].Value.ToString();
                        col.isUpdate = true;
                        //col.loadArea();
                        col.loadCollectorInfo();
                        col.UpdateEvenHandler += UpdateEventHandlerCollector;
                        col.ShowDialog();
                        break;

                    case 5://Delete user
                        DialogResult result = MessageBox.Show("Do you want to delete selected row(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            users.memID = dgCollector.Rows[e.RowIndex].Cells[1].Value.ToString();
                            if (users.deleteCollector())
                            {
                                MessageBox.Show("Selected row(s) deleted.", "Vil James Lending Investor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //loadCollector();
                                dgCollector.Rows.RemoveAt(e.RowIndex);
                            }
                        }

                        break;
                    case 6://Check user


                        if (Convert.ToBoolean(dgCollector.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                        {
                            dgCollector.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        }
                        else
                        {
                            dgCollector.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        }


                        break;
                    default:
                        break;
                }

            }
        }
        #endregion




    }
}
