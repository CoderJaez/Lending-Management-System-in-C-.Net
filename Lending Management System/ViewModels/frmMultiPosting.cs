using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentValidation;
using Lending_Management_System.Modules;
using System.Threading;

namespace Lending_Management_System
{
    public partial class frmMultiPosting : Form
    {
        public frmPosting post { get; set; }
        remittance remit = new remittance();
        Modules.user users = new Modules.user();
        public string msg = "";
        private double prevBal = 0;
        private double totalDue = 0;
        private string Collector = string.Empty;
        frmLoading frmload = new frmLoading();
        public frmMultiPosting()
        {
            InitializeComponent();
        }


        struct DataParams
        {
            public int Process;
            public int Delay;
        }
        private DataParams InputParams;

        public void LoadPaymentList(List<string> LedgerIDs)
        {
            
            foreach(DataRow row in remit.GetDuePayments(LedgerIDs).Rows)
            {
                try { prevBal = (double)row["prevBal"]; } catch { }
                try { totalDue = (double)row["prevBal"] + (double)row["totalAmount"]; } catch { totalDue = (double)row["totalAmount"]; }
                PaymentDuesDV.Rows.Add(PaymentDuesDV.Rows.Count + 1, row["loanNo"],row["bname"], Convert.ToDouble(row["matValue"]).ToString("N"), Convert.ToDouble(row["balance"]).ToString("N"),DateTime.Parse(row["dueDate"].ToString()).ToString("MM-dd-yyyy"), Convert.ToDouble(row["totalAmount"]).ToString("N"), prevBal.ToString("N"), totalDue.ToString("N"),row["interestRate"],row["ledgerNo"],"",row["citymunDesc"], row["interest"], row["returnAmount"]);
            }
            loadCollector();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaymentDuesDV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(AmountRecieve_KeyPress);

            if (PaymentDuesDV.CurrentCell.OwningColumn.Name == "AmountRecieve")
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(AmountRecieve_KeyPress);
                }
            }

        }

        private void AmountRecieve_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

       

        public void loadCollector()
        {

            CollectorCB.DisplayMember = "Text";
            CollectorCB.ValueMember = "Value";
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");

            dt.Rows.Add("", "");
            foreach (DataRow row in users.loadCollectorList().Rows)
            {
                dt.Rows.Add(row["name"].ToString().ToUpper(), row["collectorID"]);
            }

            CollectorCB.DataSource = dt;
        }

       


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var amntlist = new AmountRemit();

            if (PaymentDuesDV.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in PaymentDuesDV.Rows)
                {
                    amntlist.list.Add(new AmountRemit()
                    {
                        Amount = item.Cells["AmountRecieve"].Value.ToString() != "" ? double.Parse(item.Cells["AmountRecieve"].Value.ToString()) : 0,
                        Collector = CollectorCB.Text.ToString(),
                        Borrower = item.Cells["Borrower"].Value.ToString(),
                        DueDate = Convert.ToDateTime(item.Cells["DueDate"].Value.ToString()),
                        DateRemit = dt.Value
                    });

                }
            }
            else
                return;

            var rules = new RemitValidator();
            var result = rules.Validate(amntlist);
            if (!result.IsValid )
            {
                string ErrorMsg = string.Empty;
                foreach (var item in result.Errors)
                {
                    ErrorMsg += $"{item.ErrorMessage}\n";
                }
                MessageBox.Show(ErrorMsg);
                return;
            }

            var DResult = MessageBox.Show("You're about to save amount remitted to the SERVER. \n Please click the (YES) button to continue.","",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (DResult == DialogResult.No)
                return;
            if(!backgroundWorker.IsBusy)
            {
                InputParams.Delay = 200;
                InputParams.Process = PaymentDuesDV.Rows.Count;
                backgroundWorker.RunWorkerAsync(InputParams);
                frmload.ShowDialog();
            }


        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int process = ((DataParams)e.Argument).Process;
            int delay = ((DataParams)e.Argument).Delay;
            int index = 1;

            try
            {
                foreach (DataGridViewRow item in PaymentDuesDV.Rows)
                {
                    remit.interest = 0;
                    remit.amountRemit = 0;
                    remit.totalAmount = 0;
                    if (double.Parse(item.Cells["AmountRecieve"].Value.ToString()) <= double.Parse(item.Cells["TotalAmountDue"].Value.ToString()))
                    {
                        remit.interest = double.Parse(item.Cells["intDue"].Value.ToString());
                        remit.amountRemit = double.Parse(item.Cells["AmountRecieve"].Value.ToString()) - remit.interest;
                        remit.amountRemit = remit.amountRemit < 0 ? 0 : remit.amountRemit;
                        remit.interest = remit.interest < double.Parse(item.Cells["intDue"].Value.ToString()) ? double.Parse(item.Cells["AmountRecieve"].Value.ToString()) : remit.interest;
                    } else if (double.Parse(item.Cells["AmountRecieve"].Value.ToString()) >= double.Parse(item.Cells["TotalAmountDue"].Value.ToString()) && double.Parse(item.Cells["AmountRecieve"].Value.ToString()) % double.Parse(item.Cells["PerRemit"].Value.ToString()) == 0)
                    {
                        double n = double.Parse(item.Cells["AmountRecieve"].Value.ToString()) / double.Parse(item.Cells["PerRemit"].Value.ToString());

                        for (int i = 0; i < (int)n; i++)
                        {
                            remit.interest += double.Parse(item.Cells["intDue"].Value.ToString());
                            remit.amountRemit += double.Parse(item.Cells["retDue"].Value.ToString());

                        }
                    } else
                    {
                        double n = double.Parse(item.Cells["AmountRecieve"].Value.ToString()) / double.Parse(item.Cells["PerRemit"].Value.ToString());

                        for (int i = 0; i < (int)n; i++)
                        {
                            remit.interest += double.Parse(item.Cells["intDue"].Value.ToString());
                            remit.amountRemit += double.Parse(item.Cells["retDue"].Value.ToString());
                        }
                        remit.amountRemit += double.Parse(item.Cells["AmountRecieve"].Value.ToString()) - (remit.interest + remit.amountRemit);
                    }
                    remit.Borrower = item.Cells["Borrower"].Value.ToString();
                    remit.loanNo = item.Cells["LoanNo"].Value.ToString();
                   
                    remit.totalAmount = double.Parse(item.Cells["AmountRecieve"].Value.ToString());
                    remit.balance = double.Parse(item.Cells["TotalAmountDue"].Value.ToString()) - remit.totalAmount;
                    remit.balance = remit.balance < 0 ? 0 : remit.balance;
                    remit.prevBalance = item.Cells["PrevBalance"].Value.ToString() != "" ? double.Parse(item.Cells["PrevBalance"].Value.ToString()) : 0;
                    remit.LoanBalance = double.Parse(item.Cells["LoanBalance"].Value.ToString());
                    remit.ledgerID = (int)item.Cells["LedgerID"].Value;
                    remit.dateRemit = dt.Value.ToString("yyyy-MM-dd");
                    remit.collector = Collector;
                    remit.area = item.Cells["Area"].Value.ToString();
                    if(remit.MultiRemit(this))
                    {
                        backgroundWorker.ReportProgress(index++ * 100 / process);
                    }
                    Thread.Sleep(delay);

                }
            }
            catch (Exception ex)
            {
                backgroundWorker.CancelAsync();
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            frmload.loading.Value = e.ProgressPercentage;
            frmload.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(msg, "Remit Success");
            frmload.Close();
            post.loadCollectibles();
            this.Close();
        }

        private void PaymentDuesDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (PaymentDuesDV.Columns[e.ColumnIndex].Name)
            {
                
                case "delete":
                    var result = MessageBox.Show("Remove selected row?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        PaymentDuesDV.Rows.Remove(PaymentDuesDV.CurrentRow);
                    break;
            }
        }

        private void dt_ValueChanged(object sender, EventArgs e)
        {
            //dt.Visible = false;
        }

        private void CollectorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Collector = CollectorCB.SelectedValue.ToString();
        }
    }

    public class AmountRemit
    {
        public double Amount { get; set; }
        public string Collector { get; set; }
        public string Borrower { get; set; }
        public DateTime DateRemit { get; set; }
        public DateTime DueDate { get; set; }

        public List<AmountRemit> list = new List<AmountRemit>();
    }

    public class RemitValidator : AbstractValidator<AmountRemit>
    {
        public RemitValidator()
        {
            RuleForEach(amntList => amntList.list)
                .ChildRules(list => {
                    list.RuleFor(amnt => amnt.Amount).NotEmpty().WithName(b => b.Borrower).WithMessage("{PropertyName}'s 'Amount' must not be empty");
                    list.RuleFor(col => col.Collector).NotEmpty().WithName(b => b.Borrower).WithMessage("{PropertyName}'s 'Collector' is not selected");
                    list.RuleFor(dRemit => dRemit.DateRemit).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithName(b => b.Borrower).WithMessage("{PropertyName}'s 'DateRemit' must not be empty").GreaterThanOrEqualTo(dDue => dDue.DueDate).WithMessage("{PropertyName}'s 'DateRemit' must not be lower than the Due Date");


                });
        }
    }

}
   



