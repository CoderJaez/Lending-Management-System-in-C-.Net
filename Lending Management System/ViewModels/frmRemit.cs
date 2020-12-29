using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lending_Management_System
{
    public partial class frmRemit : Form
    {
        Modules.remittance remit = new Modules.remittance();
        Modules.user users = new Modules.user();

        public frmPosting post { get; set; }
         public string loanNo { get { return lblLoanNo.Text; } set { lblLoanNo.Text = value; } }
        public string ledgerID = "";
         public string dueDate { get { return lblDueDate.Text; } set { lblDueDate.Text = value; } }
         public string perRemit { get { return lbPerRemit.Text; } set { lbPerRemit.Text = value; } }
         public double loanBalace { get; set; } 
         public double amountRemit
        {
            get
            {
                try
                {
                    return (tbAmountRemit.Text != "" || tbAmountRemit.Text != ".") ? Convert.ToDouble(tbAmountRemit.Text.Replace(",", "")) : 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    tbAmountRemit.Text = "";
                    return 0;
                }
            }
            set {
                tbAmountRemit.Text = Convert.ToString(value);
            }
        }
       
        public string interestDue { get { return lblInterestDue.Text; } set { lblInterestDue.Text = value; } }
        public string returnDue { get { return lblReturnDue.Text; } set { lblReturnDue.Text = value; } }
        public string borrower { get { return lblBorrower.Text; } set { lblBorrower.Text = value; }  }
        

        public string area { get { return lblArea.Text; } set { lblArea.Text = value; } }
        public string maturityVal { get { return lblMatValue.Text; } set { lblMatValue.Text = value; } }
        private double interestRate = 0;
        private double balance = 0;
        private double returnAmount = 0;
        private double earnedInterest = 0;
        public void loadLastPayment()
        {
            double totalDue = 0;
            remit.loanNo = loanNo;
            if(remit.getLastPayment().Rows.Count <= 0)
            {
                lblAmountPaid.Text = "";
                lblReturn.Text ="";
                lblInterest.Text = "";
                lblBalance.Text = "";
            }
            foreach (DataRow row in remit.getLastPayment().Rows)
            {

                lblAmountPaid.Text = Convert.ToDouble(row["totalAmount"].ToString()).ToString("N");
                lblReturn.Text = Convert.ToDouble(row["amountRemit"].ToString()).ToString("N");
                lblInterest.Text = Convert.ToDouble(row["interest"].ToString()).ToString("N");
                lblBalance.Text = Convert.ToDouble(row["balance"].ToString()).ToString("N");
            }

            lblBalanceDue.Text = lblBalance.Text;
            if (lblBalance.Text !="")
            {
                totalDue = Convert.ToDouble(lblBalanceDue.Text) + Convert.ToDouble(returnDue) + Convert.ToDouble(interestDue);
            } else
            {
                totalDue = Convert.ToDouble(returnDue) + Convert.ToDouble(interestDue);
            }
            lblTotalDue.Text = totalDue.ToString("N");

        }

        public void loadCollector()
        {

            cbCollector.DisplayMember = "Text";
            cbCollector.ValueMember = "Value";
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");

            dt.Rows.Add("", "");
            foreach (DataRow row in users.loadCollectorList().Rows)
            {
                dt.Rows.Add(row["name"].ToString().ToUpper(), row["collectorID"]);
            }

            cbCollector.DataSource = dt;
        }
        public frmRemit()
        {
            InitializeComponent();
            loadCollector();
            tbAmountRemit.Focus();
            
        }

        public void loadInterestRate()
        {
            remit.getLoanInfo(loanNo);
            interestRate = remit.getInterestRate();
            loanBalace = remit.getLoanBalance();
            lblLoanBalance.Text = loanBalace.ToString("N");
        }
       



        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void remitPayments()
        {
            remit.loanNo = loanNo;
            remit.amountRemit = returnAmount;
            remit.interest = earnedInterest;
            remit.totalAmount = amountRemit;
            remit.balance = balance;
            remit.collector = cbCollector.SelectedValue.ToString();
            remit.area = lblArea.Text;
            remit.dateRemit = dtDateRemit.Value.ToString("yyyy-MM-dd");
            remit.prevBalance = (lblBalanceDue.Text != "") ? Convert.ToDouble(lblBalanceDue.Text.Replace(",", "")) : 0;
            remit.ledgerID = Convert.ToInt32(ledgerID);
            remit.LoanBalance = loanBalace;

            if (remit.isPaymentRemitted())
            {
                MessageBox.Show("The Payment is already remitted by other cashier.");
                return;
            }

            DialogResult result = MessageBox.Show($"Amount Remit: {amountRemit.ToString("N")} \nCollector: {cbCollector.Text} \nDate Remit: {dtDateRemit.Value.ToString("yyyy-MM-dd")} \n\nPLEASE CLICK OK TO PROCEED.", "JaezerTech Lending System", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            if (result == DialogResult.Cancel)
                return;

            if(remit.makeRemit())
            {
                MessageBox.Show("The payment is successfully remitted.", "JaezerTech Lending System");
                this.Close();
                post.loadCollectibles();
            }
            //if (loanBalace <= amountRemit)
            //{
            //    if (remit.makeRemit() && remit.updateLoanPaymentAndAccount() && remit.updateLedger())
            //    {
            //        MessageBox.Show("The payment is successfully remitted.\n The loan is now Paid. ", "JaezerTech Lending System");
            //        this.Close();
            //        post.loadCollectibles();
            //    }
            //}
            //else
            //{
            //    if (remit.makeRemit() && remit.updateLoanPayment() && remit.updateLedger())
            //    {
            //        MessageBox.Show("The payment is successfully remitted.", "JaezerTech Lending System");
            //        this.Close();
            //        post.loadCollectibles();
            //    }
            //}



        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbAmountRemit.Text != "" && cbCollector.Text != "" )
            {
                if (Convert.ToInt32(tbAmountRemit.Text) <= 0)
                {
                    MessageBox.Show("The the amount remit must be greater than or equal to Amount Due.");
                    return;
                }
                if (Convert.ToDateTime(lblDueDate.Text) <= Convert.ToDateTime(dtDateRemit.Value.ToShortDateString()))
                {
                    remitPayments();

                }
                else
                {
                    MessageBox.Show("The date remitted is lower than the due date.");
                }
            }
            else
            {
                MessageBox.Show("Amount and Collector field are required");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void lblAmountPaid_Click(object sender, EventArgs e)
        {

        }

        private void tbAmountRemit_TextChanged(object sender, EventArgs e)
        {
            if (tbAmountRemit.Text != "")
            {
                if (amountRemit <= double.Parse(lblTotalDue.Text.Replace(",", "")))
                {
                    earnedInterest = double.Parse(lblInterestDue.Text.Replace(",",""));
                    returnAmount = amountRemit - earnedInterest;
                    returnAmount = returnAmount < 0 ? 0 : returnAmount;
                    earnedInterest = amountRemit < earnedInterest ? amountRemit : earnedInterest;
                   
                } else if (amountRemit >= double.Parse(lblTotalDue.Text.Replace(",", "")) && amountRemit % (earnedInterest + double.Parse(returnDue)) == 0)
                {
                    earnedInterest = double.Parse(lblInterestDue.Text.Replace(",", ""));
                    returnAmount = double.Parse(returnDue);
                    double n = amountRemit / ( earnedInterest + double.Parse(returnDue));
                    returnAmount = 0;
                    earnedInterest = 0;
                    for (int i = 0; i < (int)n; i++)
                    {
                        returnAmount += double.Parse(returnDue);
                        earnedInterest += double.Parse(lblInterestDue.Text.Replace(",", ""));
                    }

                } else
                {
                    earnedInterest = double.Parse(lblInterestDue.Text.Replace(",",""));
                    returnAmount = double.Parse(returnDue);
                    double m = amountRemit / (earnedInterest + double.Parse(returnDue));
                    returnAmount = 0;
                    earnedInterest = 0;
                    for (int i = 0; i < (int)m; i++)
                    {
                        returnAmount += double.Parse(returnDue);
                        earnedInterest += double.Parse(lblInterestDue.Text.Replace(",", ""));
                    }


                    returnAmount += amountRemit - (earnedInterest + returnAmount);
                }
                balance = Convert.ToDouble(lblTotalDue.Text.Replace(",", "")) - (earnedInterest + returnAmount);
                balance = (balance < 0) ? 0 : balance;
                lblReturnPaid.Text = returnAmount.ToString("N");
                lblInterestPaid.Text = earnedInterest.ToString("N");
                lblBalancePayment.Text = balance.ToString("N");

            } else
            {
                clearPayment();
            }
            
        }

        private void tbAmountRemit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != (char)'.');
            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        public void clearPayment()
        {
            lblReturnPaid.Text = lblInterestPaid.Text = lblBalancePayment.Text = tbAmountRemit.Text =  "";

        }
    }
}
