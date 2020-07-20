using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lending_Management_System.Objects;

namespace Lending_Management_System
{
    public partial class frmLoanApplication : Form
    {
        Modules.Settings settings = new Modules.Settings();
        Modules.borrowerAcc account = new Modules.borrowerAcc();
        Modules.LoanModel loan = new Modules.LoanModel();
        Modules.remittance remit = new Modules.remittance();

        private string prevAccNo = null;
        public frmLoanApplist frmLoan { get; set; }
        public Boolean forUpate = false;
        public string address { get; set; }
        public string accNo { get { return lblAccno.Text; } set { lblAccno.Text = value; } }
        public string loanNo { get; set; }
        public string name { get { return lblName.Text; } set { lblName.Text = value; } }
       // public int term { get { return Convert.ToInt32(cbTerm.SelectedValue); } set { cbTerm.SelectedValue = value; } }
        public string Terms { get { return cbTerm.Text; } set { cbTerm.Text = value; } }
        public string duration { get { return lblDuration.Text; } set { lblDuration.Text = value; } }
        public string effectiveDate { get { return dpEffectiveDate.Value.ToString("yyyy/MM/dd"); } set { } }
        public double principalAmount { get { return Convert.ToDouble(tbPrincipalAmount.Text); } set { tbPrincipalAmount.Text = Convert.ToString(value); } }
        public double interest { get { return Convert.ToDouble(cbInterest.Text); } set { cbInterest.Text = Convert.ToString(value); } }
        public double maturityValue { get { return Convert.ToDouble(lblMatValue.Text); } set { lblMatValue.Text = Convert.ToString(value); } }
        public string maturityDate { get { return Convert.ToDateTime(lblMatDate.Text).ToString("yyyy/MM/dd"); } set { lblMatDate.Text = value; } }
        public double perRemittances { get { return Convert.ToDouble(lblPerRemittance.Text); } set { lblPerRemittance.Text = Convert.ToString(value); } }
        public double totalAmountRemittance { get { return Convert.ToDouble(lblTotalRem.Text); } set { lblTotalRem.Text = Convert.ToString(value); } }
        public double outstandingCapital { get { return Convert.ToDouble(lblOutstandingCap.Text); } set { lblOutstandingCap.Text = Convert.ToString(value); } }
        public double UnearnedInterest { get { return Convert.ToDouble(lblUnearnedInt.Text); } set { lblUnearnedInt.Text = Convert.ToString(value); } }
        public double InterestAmount { get { return Convert.ToDouble(lblInterestAmount.Text); } set { lblInterestAmount.Text = Convert.ToString(value); } }
        public int NoOfMonthsInterest { get { return Convert.ToInt32(NoOfMonths.Text); } set { NoOfMonths.Text = value.ToString(); } }
        double returnValue { get; set; }
        double returnInterest { get; set; }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        //private int start = 0;
        //private int limit = 100;
        //private string search = "";

        public string perRemit()
        {
            return lblPerRemittance.Text;
        }
        public string totalBal()
        {
            return lblTotalBal.Text;
        }
        public string totalRemit()
        {
            return lblTotalRem.Text;
        }
        public string pAmount()
        {
            return tbPrincipalAmount.Text;
        }

        public string intAmount()
        {
            return lblInterestAmount.Text;
        }
        public string matValue()
        {
            return lblMatValue.Text;
        }

        public void clearForm()
        {
            lblAccno.Text = "";
            lblName.Text = "";
            lblDuration.Text = "";
            lblInterestAmount.Text = "";
            lblMatDate.Text = "";
            lblMatValue.Text = "";
            lblOutstandingCap.Text = "";
            lblPerRemittance.Text = "";
            lblTotalBal.Text = "";
            lblTotalRem.Text = "";
            lblUnearnedInt.Text = "";
            lblInterestAmount.Text = "";
            tbPrincipalAmount.Text = "";
            try { dgLedger.Rows.Clear(); } catch {  } 
            
        }


        private void computeLoan()
        {
            DateTime effDate = Convert.ToDateTime(effectiveDate);
            DateTime dueDate;
            double duration_ = Convert.ToDouble(lblDuration.Text);
            double ItemLoan =(string.IsNullOrEmpty(ItemAmountTxt.Text))? 0 : Convert.ToDouble(ItemAmountTxt.Text);
            int n = 1;

          
            //Interest Monthly
            InterestAmount = principalAmount * (interest / 100);
            //MessageBox.Show(Convert.ToDouble(duration_ / 30).ToString());
            InterestAmount = InterestAmount * NoOfMonthsInterest;
            lblInterestAmount.Text = InterestAmount.ToString("N");
            //Maturity Value
            maturityValue = ItemLoan + principalAmount + InterestAmount;
            lblMatValue.Text = maturityValue.ToString("N");
            //Maturity Date
            maturityDate = effDate.AddDays(n * duration_).ToString("MM/dd/yyyy");
            //Per remittances
            perRemittances = maturityValue / duration_;
            lblPerRemittance.Text = perRemittances.ToString("N");
            lblOutstandingCap.Text = principalAmount.ToString("N");
            lblUnearnedInt.Text = InterestAmount.ToString("N");
            lblTotalBal.Text = maturityValue.ToString("N");

            returnValue = perRemittances - (InterestAmount / duration_);
            returnInterest = (InterestAmount / duration_);
            //ledger
            try
            {
                dgLedger.Rows.Clear();
            }
            catch (Exception)
            {
                dgLedger.Columns.Clear();
                dgLedger.DataSource = null;
                DataGridViewTextBoxColumn DueDate = new DataGridViewTextBoxColumn();
                DueDate.HeaderText = "DueDate";
                DataGridViewTextBoxColumn Total = new DataGridViewTextBoxColumn();
                Total.HeaderText = "Total";
                DataGridViewTextBoxColumn AmountReceive = new DataGridViewTextBoxColumn();
                AmountReceive.HeaderText = "Return";
                DataGridViewTextBoxColumn DateRemit = new DataGridViewTextBoxColumn();
                DateRemit.HeaderText = "Interest";
                DataGridViewTextBoxColumn Balance = new DataGridViewTextBoxColumn();
                Balance.HeaderText = "Daily";
                DataGridViewTextBoxColumn Collector = new DataGridViewTextBoxColumn();
                Collector.HeaderText = "Collector";
                dgLedger.Columns.Add(DueDate);
                dgLedger.Columns.Add(Total);
                dgLedger.Columns.Add(AmountReceive);
                dgLedger.Columns.Add(DateRemit);
                dgLedger.Columns.Add(Balance);
                dgLedger.Columns.Add(Collector);

            }
            for (int i = 0; i < duration_; i++)
            {
                dueDate = effDate.AddDays(i + n);
                dgLedger.Rows.Add(dueDate.ToString("MM/dd/yyyy"), maturityValue.ToString("N"), returnValue.ToString("N"), returnInterest.ToString("N"), perRemittances.ToString("N"));
            }



        }

        public void loadInterest()
        {
            foreach (DataRow row in settings.loadInterest().Rows)
            {
                cbInterest.Items.Add(row["interest"]);
            }
        }

        
        private void accountList()
        {
            int no = 0;
            dgBList.Rows.Clear();
            foreach (DataRow row in account.loadAccountsForLoan(tbSearch.Text).Rows)
            {
                dgBList.Rows.Add(no + 1, row["accID"].ToString(), row["name"].ToString());
                no++;
            }
        }
        public void enableLedger()
        {
            btnRemittance.Enabled = true;
            btnPrint.Enabled = true;
        }
        public void disableLedger()
        {
            btnRemittance.Enabled = false;
            btnPrint.Enabled = false;
        }
        public void saveLoan()
        {
            loanNo = (forUpate) ? loanNo : loan.getLoaNo(); //Check wether loan is upadate or new
            loan.loanNo = loanNo;
            loan.terms = cbTerm.Text;
            loan.duration = Convert.ToInt32(duration);
            loan.effDate = effectiveDate;
            loan.principalAmount = principalAmount;
            loan.interestRate = interest;
            loan.perRemittance = perRemittances;
            loan.matDate = maturityDate;
            loan.outstandinCapital = outstandingCapital;
            loan.unearnedInterest = UnearnedInterest;
            loan.earnedInterest = 0;
            loan.balance = maturityValue;
            loan.interestAmount = InterestAmount;
            loan.matValue = maturityValue;
            loan.accID = accNo;
            loan.NoOfMonthsInterest = NoOfMonthsInterest;
            loan.Item = Convert.ToDouble(ItemAmountTxt.Text);

            List<string> queryString = new List<string>();
            for (int i = 0; i < dgLedger.Rows.Count; i++)
            {
                queryString.Add(string.Format("( '{0}', '{1}', '{2}','{3}','{4}','{5}' )", DateTime.Parse(dgLedger.Rows[i].Cells[0].Value.ToString()).ToString("yyyy/MM/dd"), dgLedger.Rows[i].Cells[1].Value.ToString().Replace(",", ""), dgLedger.Rows[i].Cells[2].Value.ToString().Replace(",", ""), dgLedger.Rows[i].Cells[3].Value.ToString().Replace(",", ""), dgLedger.Rows[i].Cells[4].Value.ToString().Replace(",", ""), loan.loanNo));
            }
            loan.ledger = queryString;
            if(forUpate == true)
            {
                updateLoan();
            }
            else
            {
                if (!loan.checkPendingLoans())
                {
                    if (loan.addLoan() && loan.saveLedger())
                    {
                        MessageBox.Show("Success!", "Zeustech Lending System");

                        frmLoan.LoadLoanList();
                        btnSave.Enabled = false;
                        enableLedger();
                    }
                }
                else
                {
                    MessageBox.Show("This account has still pending loan to be paid.", "Zeustech Lending System");
                }
            }
           

        }

        private Boolean validate()
        {
            Boolean isValidate = true;
            if (tbPrincipalAmount.Text == "" || cbInterest.Text == "" || lblAccno.Text == "" || lblDuration.Text == "" || NoOfMonths.Text == "")
            {
                isValidate = false;
            }
            return isValidate;
        }

        public void borrrowerLoanInfo()
        {
            loan.loanNo = loanNo;
            foreach (DataRow row in loan.getBorrowerLoanInfo().Rows)
            {

                accNo = row["accID"].ToString();
                prevAccNo = accNo;
                cbInterest.Text = row["interestRate"].ToString();
                maturityDate = DateTime.Parse( row["matDate"].ToString()).ToShortDateString();
                dpEffectiveDate.Value = DateTime.Parse(row["effectiveDate"].ToString());
                tbPrincipalAmount.Text = double.Parse(row["principalAmount"].ToString()).ToString("N");
                lblInterestAmount.Text = double.Parse(row["interestAmount"].ToString()).ToString("N");
                lblMatValue.Text = double.Parse(row["matValue"].ToString()).ToString("N");
                ItemAmountTxt.Text = double.Parse(row["item"].ToString()).ToString("N");
                lblDuration.Text = row["duration"].ToString();
                NoOfMonths.Text = row["noOfMonths"].ToString();
                lblPerRemittance.Text = double.Parse(row["perRemittance"].ToString()).ToString("N");
                lblOutstandingCap.Text = double.Parse(row["outstandingCapital"].ToString()).ToString("N");
                lblUnearnedInt.Text = double.Parse(row["unearnedInterest"].ToString()).ToString("N");
                lblTotalBal.Text = double.Parse(row["balance"].ToString()).ToString("N");
                address = "Pagadian City";
            }
            if (Convert.ToDouble(lblTotalBal.Text) < Convert.ToDouble(lblMatValue.Text))
            {
                btnSearchAcc.Enabled = false;
                btnSave.Enabled = false;
                tbPrincipalAmount.Enabled = false; 
            } else
            {
                btnSearchAcc.Enabled = true;
                btnSave.Enabled = true;
                tbPrincipalAmount.Enabled = true;
            }
            lblTotalRem.Text = remit.getTotalRemit(loanNo).ToString("N");
            loadLedgerAsync();
        }

        private void loadLedgerAsync()
        {
            dgLedger.Columns.Clear();
            dgLedger.DataSource = loan.getLedgerList(loanNo);
        }

      

        


        private void updateLoan()
        {
            loan.prevAccID = prevAccNo;
            if (loan.deleteLedger() && loan.updateLoan() && loan.saveLedger())
            {
                MessageBox.Show("Update successfull!", "Zeustech Lending System");
                frmLoan.LoadLoanList();
                clearForm();
                this.Close();
            }
        }

       
        public frmLoanApplication()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                if(lblMatValue.Text != "")
                {
                    loan.principalAmount = principalAmount;
                    saveLoan();
                } else
                {
                    MessageBox.Show("Please Compute the loan by clicking the principal amount field and press ENTER.", "Zeustech Lending System");
                }
              
            } else
            {
                MessageBox.Show("PLease fill out the fields. \n Interest/Principal/Account no./ Duration is empty.", "Zeustech Lending System");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }

       
        private void tbPrincipalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (validate())
                {
                    tbPrincipalAmount.Text = principalAmount.ToString("N");
                    loan.principalAmount = principalAmount;
                    if (loan.withLoanRange())
                    {
                        computeLoan();
                    }
                    else
                    {
                        MessageBox.Show("The amount you have entered is not within range of loanable amount", "Zeustech Lending System");
                    }
                }
                else
                {
                    MessageBox.Show("PLease fill out the fields. \n Interest/Principal/Account no./ No of Months Interest /Duration is empty.", "Zeustech Lending System");
                }
                
            }
            else
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void dgBList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearchAcc_Click(object sender, EventArgs e)
        {
            //accountList();
            browseAcc.Visible = true;
            btnSave.Enabled = true;
            browseAcc.BringToFront();
            //loanNo = loan.getLoaNo();
            disableLedger();
        }

        private void dgBList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnPrint.Enabled = false;
                clearForm();
                name = dgBList.Rows[e.RowIndex].Cells[2].Value.ToString();
                accNo = dgBList.Rows[e.RowIndex].Cells[1].Value.ToString();
                browseAcc.Visible = false;
            }
        }

        private void btnCloseAcc_Click(object sender, EventArgs e)
        {
            browseAcc.Visible = false;
        }

     

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ledgerReportFrm legder = new ledgerReportFrm();
            legder.appLoan = this;
            legder.ShowDialog();

        }

        private void frmLoanApplication_Load(object sender, EventArgs e)
        {
           
            
        }

        private void btnRemittance_Click(object sender, EventArgs e)
        {
            frmLedgerCard card = new frmLedgerCard(this);
            card.ShowDialog();
        }

        private void lblDuration_Click(object sender, EventArgs e)
        {

        }

        private void lblDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dpEffectiveDate_ValueChanged(object sender, EventArgs e)
        {
            if (tbPrincipalAmount.Text != "" && lblDuration.Text != "" && NoOfMonths.Text != "")
                computeLoan();
        }

        private void cbInterest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbPrincipalAmount.Text != "" && NoOfMonths.Text != "" && lblDuration.Text != "")
                computeLoan();
        }

        private void lblDuration_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.Enter)
                if (tbPrincipalAmount.Text != "" && NoOfMonths.Text != "")
                    computeLoan();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                accountList();
        }

        private void NoOfMonths_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void NoOfMonths_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (NoOfMonths.Text != "" && tbPrincipalAmount.Text != "" && lblDuration.Text != "" )
                    computeLoan();
        }

        private void ItemAmountTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ItemAmountTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (NoOfMonths.Text != "" && tbPrincipalAmount.Text != "" && lblDuration.Text != "" && ItemAmountTxt.Text != "")
                    computeLoan();
        }

        private void ItemLoanCB_CheckedChanged(object sender, EventArgs e)
        {
            if (ItemLoanCB.CheckState == CheckState.Checked)
                ItemAmountTxt.Enabled = true;
            else
                ItemAmountTxt.Enabled = false;
        }
    }
}
