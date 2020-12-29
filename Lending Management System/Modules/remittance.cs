using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lending_Management_System.Objects;
using FluentValidation;
using MySql.Data.MySqlClient;

namespace Lending_Management_System.Modules
{
   public class remittance:db_connect
    {
        public string transactionNo { get; set; }
        public double amountRemit { get; set; }
        public double interest { get; set; }
        public double balance { get; set; }
        public double LoanBalance { get; set; }
        public string loanNo { get; set; }
        public double totalAmount { get; set; }
        public double prevBalance { get; set; }
        public int ledgerID { get; set; }
        public string dateRemit { get; set; }
        public string collector { get; set; }
        public string area { get; set; }
        public string Borrower { get; set; }


        private double outStandingCapital = 0;
        private double unEarnedInt = 0;
        private double earnedInt = 0;
        private double MatBalance = 0;
        private double interestRate = 0;
        private double totalRemittances = 0;
        private int start = 0;
        private int limit = 100;
        private string where = null;

        public DataTable GetDuePayments(List<string> ledgerID)
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = $"SELECT loan.`bname`,l.`ledgerNo`,lo.`interestRate`, l.`loanNo`,c.`citymunDesc`, l.`dueDate`, l.`matValue`,loan.`balance`, l.`totalAmount`,(SELECT r.balance FROM tbl_remit AS r WHERE r.loanNo = l.`loanNo` ORDER BY r.transactionNo DESC LIMIT 1) AS prevBal, l.returnAmount, l.interest FROM tbl_ledger AS l INNER JOIN  loan ON loan.`loanNO` = l.`loanNo` INNER JOIN tbl_loan AS lo ON l.`loanNo` = lo.`loanNO` INNER JOIN  refcitymun AS c ON c.`citymunCode` = loan.`citymunCode`  WHERE  l.`isRemitted` = FALSE  AND l.ledgerNo IN ({string.Join(",", ledgerID)}) ";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return dt;
        }
        private string getTransactionNo()
        {

            try
            {
                connect();
                cmd.CommandText = "SELECT transactionNo FROM tbl_remit ORDER BY transactionNo DESC LIMIT 1";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToString(Convert.ToInt32(reader["transactionNo"].ToString()) + 1) : "10000101";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
                disconnect_db();
            }
        }
        public DataTable getLastPayment()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_remit WHERE loanNo = @loanNo ORDER BY transactionNO DESC LIMIT 1";
                cmd.Parameters.AddWithValue("@loanNO", loanNo);
                reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                cmd.Dispose();
                reader.Close();
                disconnect_db();
            }
            return dt;
        }

        public bool MultiRemit(frmMultiPosting frm)
        {
            try
            {
                using (con = new MySqlConnection(ConnString))
                {
                  
                    using (cmd = new MySqlCommand("",con))
                    {
                        con.Open();
                        MySqlTransaction tr = con.BeginTransaction();

                        cmd.CommandText = "SELECT ledgerNo FROM tbl_ledger WHERE isRemitted = true AND ledgerNo = @LedgerNo";
                        cmd.Parameters.AddWithValue("@LedgerNo", ledgerID);
                        bool isAlreadyRemitted = false;
                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            if(rd.HasRows)
                            {
                                frm.msg += $"The {Borrower}'s Payment is already remitted by other cashier.\n";
                                isAlreadyRemitted = true;
                            }
                            cmd.Parameters.Clear();

                        }
                        if(isAlreadyRemitted)
                        {
                            tr.Commit();
                            return true;
                        }

                        //Get Transation No
                        cmd.CommandText = "SELECT transactionNo FROM tbl_remit ORDER BY transactionNo DESC LIMIT 1";
                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            transactionNo  = (rd.Read()) ? Convert.ToString(Convert.ToInt32(rd["transactionNo"].ToString()) + 1) : "10000101";
                        }
                        

                        //Insert Payment to tbl_remit
                        cmd.CommandText = "INSERT INTO tbl_remit (transactionNo, amountRemit, interest, totalAmount, balance, loanNo,dateRemitted, prevBalance, ledgerID,colID,area) VALUES (@transactionNo,@amountRemit, @interest, @totalAmount, @balance, @loanNo, @dateRemit, @prevBal, @ledgerID, @Collector,@Area)";
                        cmd.Parameters.AddWithValue("@transactionNo", transactionNo);
                        cmd.Parameters.AddWithValue("@amountRemit", amountRemit);
                        cmd.Parameters.AddWithValue("@interest", interest);
                        cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@balance", balance);
                        cmd.Parameters.AddWithValue("@loanNo", loanNo);
                        cmd.Parameters.AddWithValue("@dateRemit", dateRemit);
                        cmd.Parameters.AddWithValue("@prevBal", prevBalance);
                        cmd.Parameters.AddWithValue("@ledgerID", ledgerID);
                        cmd.Parameters.AddWithValue("@Collector", collector);
                        cmd.Parameters.AddWithValue("@Area", area);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        //This is will update ledger status
                        cmd.CommandText = "UPDATE tbl_ledger SET isRemitted = true WHERE ledgerNo = @ledgerID";
                        cmd.Parameters.AddWithValue("@ledgerID", ledgerID);
                        cmd.ExecuteNonQuery();


                       

                        if (LoanBalance <= amountRemit)
                        {
                            cmd.CommandText = "UPDATE tbl_loan AS loan INNER JOIN tbl_borrower_acc as a ON a.accID = loan.accID SET  outstandingCapital = 0, unearnedInterest = 0, earnedInterest = interestAmount, balance = 0 , date_fullyPaid = @DatePaid, paid = true, a.isPendingLoan = false WHERE loanNO = @loanNo";
                            frm.msg += $"The payment is successfully remitted. {Borrower}'s  loan is now Paid. \n";
                        } else
                        {
                            cmd.CommandText = "UPDATE tbl_loan SET  outstandingCapital = @outstandingCapital, unearnedInterest = unearnedInterest - @unearnedInterest, earnedInterest = earnedInterest + @earnedInterest, balance = balance - @balance WHERE loanNO = @loanNo";
                            frm.msg += $"The {Borrower}'s payment is successfully remitted. \n";
                        }


                        cmd.Parameters.AddWithValue("@outstandingCapital", amountRemit);
                        cmd.Parameters.AddWithValue("@earnedInterest", interest);
                        cmd.Parameters.AddWithValue("@unearnedInterest", interest);
                        cmd.Parameters.AddWithValue("@balance", totalAmount);
                        cmd.Parameters.AddWithValue("@loanNo", loanNo);
                        cmd.Parameters.AddWithValue("@DatePaid", dateRemit);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();


                        cmd.CommandText = $"UPDATE tbl_ledger SET isRemitted = true WHERE ledgerNo = {ledgerID}";
                        cmd.ExecuteNonQuery();
                        tr.Commit();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool isPaymentRemitted()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT ledgerNo FROM tbl_ledger WHERE isRemitted = true AND ledgerNo = @LedgerNo";
                cmd.Parameters.AddWithValue("@LedgerNo", ledgerID);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }else
                {
                    return  false;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "CheckPayment");
                return false;
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }
        public bool makeRemit()
        {
            transactionNo = getTransactionNo();
                try
                {
                using (con = new MySqlConnection(ConnString))
                {
                    using (cmd = new MySqlCommand("", con))
                    {
                        con.Open();
                        MySqlTransaction tr = con.BeginTransaction();
                        cmd.CommandText = "INSERT INTO tbl_remit (transactionNo, amountRemit, interest, totalAmount, balance, loanNo,dateRemitted, prevBalance, ledgerID,colID,area) VALUES (@transactionNo,@amountRemit, @interest, @totalAmount, @balance, @loanNo, @dateRemit, @prevBal, @ledgerID, @Collector,@Area)";
                        cmd.Parameters.AddWithValue("@transactionNo", transactionNo);
                        cmd.Parameters.AddWithValue("@amountRemit", amountRemit);
                        cmd.Parameters.AddWithValue("@interest", interest);
                        cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@balance", balance);
                        cmd.Parameters.AddWithValue("@loanNo", loanNo);
                        cmd.Parameters.AddWithValue("@dateRemit", dateRemit);
                        cmd.Parameters.AddWithValue("@prevBal", prevBalance);
                        cmd.Parameters.AddWithValue("@ledgerID", ledgerID);
                        cmd.Parameters.AddWithValue("@Collector", collector);
                        cmd.Parameters.AddWithValue("@Area", area);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();


                        //Update the loan Status
                        if(LoanBalance <= totalAmount)
                            cmd.CommandText = "UPDATE tbl_loan AS loan INNER JOIN tbl_borrower_acc as a ON a.accID = loan.accID SET  outstandingCapital = 0, unearnedInterest = 0 , earnedInterest = interestAmount, balance = 0, date_fullyPaid = @DatePaid, paid = true, a.isPendingLoan = false WHERE loanNO = @loanNo";
                        else
                            cmd.CommandText = "UPDATE tbl_loan SET  outstandingCapital = outstandingCapital - @outstandingCapital, unearnedInterest = unearnedInterest - @unearnedInterest, earnedInterest = earnedInterest + @earnedInterest, balance = balance - @balance WHERE loanNO = @loanNo";
                        cmd.Parameters.AddWithValue("@outstandingCapital", amountRemit);
                        cmd.Parameters.AddWithValue("@earnedInterest", interest);
                        cmd.Parameters.AddWithValue("@unearnedInterest", interest);
                        cmd.Parameters.AddWithValue("@balance", totalAmount);
                        cmd.Parameters.AddWithValue("@loanNo", loanNo);
                        cmd.Parameters.AddWithValue("@DatePaid", dateRemit);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        //update Ledger status to paid
                        cmd.CommandText = "UPDATE tbl_ledger SET isRemitted = true WHERE ledgerNo = @ledgerID";
                        cmd.Parameters.AddWithValue("@ledgerID", ledgerID);
                        cmd.ExecuteNonQuery();
                        tr.Commit();
                        return true;
                    }
                }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} !!!" );
                    return false;
                }
           
        }

        public bool updateLoanPaymentAndAccount()
        {
            bool success = false;
            getLoanInfo(loanNo);
            //getLoanInfo();
            outStandingCapital -= amountRemit;
            unEarnedInt -= interest;
            earnedInt += interest;
            MatBalance -= totalAmount;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_loan AS loan INNER JOIN tbl_borrower_acc as a ON a.accID = loan.accID SET  outstandingCapital = @outstandingCapital, unearnedInterest = @unearnedInterest, earnedInterest = @earnedInterest, balance = @balance, date_fullyPaid = @DatePaid, paid = true, a.isPendingLoan = false WHERE loanNO = @loanNo";
                cmd.Parameters.AddWithValue("@outstandingCapital", outStandingCapital);
                cmd.Parameters.AddWithValue("@earnedInterest", earnedInt);
                cmd.Parameters.AddWithValue("@unearnedInterest", unEarnedInt);
                cmd.Parameters.AddWithValue("@balance", MatBalance);
                cmd.Parameters.AddWithValue("@loanNo", loanNo);
                cmd.Parameters.AddWithValue("@DatePaid", dateRemit);

                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }
        public bool updateLoanPayment()
        {
            bool success = false;
            getLoanInfo(loanNo);
            //getLoanInfo();
            outStandingCapital -= amountRemit;
            unEarnedInt -= interest;
            earnedInt += interest;
            MatBalance -= totalAmount;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_loan SET  outstandingCapital = @outstandingCapital, unearnedInterest = @unearnedInterest, earnedInterest = @earnedInterest, balance = @balance WHERE loanNO = @loanNo";
                cmd.Parameters.AddWithValue("@outstandingCapital",outStandingCapital);
                cmd.Parameters.AddWithValue("@earnedInterest", earnedInt);
                cmd.Parameters.AddWithValue("@unearnedInterest",unEarnedInt);
                cmd.Parameters.AddWithValue("@balance",MatBalance);
                cmd.Parameters.AddWithValue("@loanNo",loanNo);
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;

        }

        public bool updateLedger()
        {
            bool success = false;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_ledger SET isRemitted = true WHERE ledgerNo = @ledgerID";
                cmd.Parameters.AddWithValue("@ledgerID",ledgerID);
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }
        public double getLoanBalance()
        {
            return MatBalance;
        }

        public  void getLoanInfo(string loanNO = null)
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT outstandingCapital,unearnedInterest,earnedInterest,balance,interestRate FROM tbl_loan WHERE loanNo = @loanNO";
                cmd.Parameters.AddWithValue("@loanNo",loanNO);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    outStandingCapital = reader.GetDouble("outstandingCapital");
                    unEarnedInt = reader.GetDouble("unearnedInterest");
                    earnedInt = reader.GetDouble("earnedInterest");
                    MatBalance = reader.GetDouble("balance");
                    interestRate = reader.GetDouble("interestRate");
                }
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} #");
            }finally
            {
                cmd.Dispose();
                reader.Close();
                disconnect_db();
            }
        }

        public string getRemittance(string ledgerID,string column)
        {
            try
            {
                connect();
                cmd.CommandText = $"SELECT {column}  FROM tbl_remit WHERE ledgerID = @ledgerID ";
                cmd.Parameters.AddWithValue("@ledgerID", ledgerID);
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? reader.GetString($"{column}") : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
        }

        public double getInterestRate()
        {
            return interestRate;
        }
        public int totalRows()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT COUNT(*) AS total FROM tbl_remit";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToInt32(reader["total"].ToString()) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"totalRows");
                return 0;
            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }

        public int filtered_rows()
        {
            try
            {
                connect();
                cmd.CommandText = $"SELECT COUNT(*) AS total FROM tbl_remit AS r INNER JOIN tbl_loan AS lo ON lo.loanNo = r.loanNo INNER JOIN tbl_ledger AS l ON l.ledgerNo = r.ledgerID INNER JOIN tbl_borrower_acc AS acc ON acc.accID = lo.accID INNER JOIN tbl_borrower AS b  ON b.borrowerID = acc.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID INNER JOIN tbl_collector AS c ON c.collectorID = r.colID INNER JOIN tbl_member AS co ON co.memID = c.memiD {where}";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToInt32(reader["total"].ToString()) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }
        public IList<remittances> remittanceList(int n,int _start, int _limit, string _where = null)
        {
            start = _start;
            limit = _limit;
            where = _where;
            var remitList = new List<remittances>();
          
            try
            {
                connect();
                cmd.CommandText = $"SELECT r.`transactionNo`,DATE_FORMAT(l.`dueDate`,'%m/%d/%Y') AS duedate, DATE_FORMAT(r.`dateRemitted`,'%m/%d/%Y') AS dateremit,CONCAT(m.lname,', ', m.fname,' ', m.mi) AS borrower, r.Area, r.`amountRemit`,r.`interest`,r.`totalAmount` AS totalRemit, l.totalAmount AS dueAmount,r.`prevBalance`, r.`balance`, CONCAT(co.lname,', ', co.fname,' ', co.mi) AS collector  FROM tbl_remit AS r INNER JOIN tbl_loan AS lo ON lo.loanNo = r.loanNo INNER JOIN tbl_ledger AS l ON l.ledgerNo = r.ledgerID INNER JOIN tbl_borrower_acc AS acc ON acc.accID = lo.accID INNER JOIN tbl_borrower AS b  ON b.borrowerID = acc.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID INNER JOIN tbl_collector AS c ON c.collectorID = r.colID INNER JOIN tbl_member AS co ON co.memID = c.memiD  {where} ORDER BY r.dateRemitted DESC,m.lname ASC LIMIT {start},{limit}";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    remittances remit = new remittances();
                    remit.No = n;
                    remit.TransactioNo = reader.GetString("transactionNo");
                    remit.DueDate = reader.GetString("duedate");
                    remit.DateRemitted = reader.GetString("dateremit");
                    remit.Borrower = reader.GetString("borrower");
                    remit.Area = reader.GetString("Area");
                    remit.AmountDue = (reader.GetDouble("prevBalance") + reader.GetDouble("dueAmount")).ToString("N");
                    remit.Return = reader.GetDouble("amountRemit").ToString("N");
                    remit.interest = reader.GetDouble("interest").ToString("N");
                    remit.AmountPaid = reader.GetDouble("totalRemit").ToString("N");
                    remit.Balance = reader.GetDouble("balance").ToString("N");
                    remit.Collector = reader.GetString("collector");
                    remitList.Add(remit);
                    totalRemittances += reader.GetDouble("totalRemit");
                    n++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
            return remitList;
        }

        public IList<BorrowerRemittances> BorrowerRemittances(string loanNo = null)
        {
            var borrowerRemit = new List<BorrowerRemittances>();
            int n = 1;
            try
            {
                connect();
                cmd.CommandText = "SELECT l.`dueDate`, l.`totalAmount`,r.`prevBalance`, r.`dateRemitted`,r.`balance`, r.`totalAmount` FROM tbl_remit	AS r INNER JOIN tbl_ledger AS l ON l.`ledgerNo` = r.`ledgerID` WHERE r.`loanNo` = @loanNo ";
                cmd.Parameters.AddWithValue("@loanNo", loanNo);
                reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                while (reader.Read())
                {
                    BorrowerRemittances b = new BorrowerRemittances();
                    b.No = n;
                    b.DueDate = reader.GetDateTime("dueDate").ToShortDateString();
                    b.DueAmount = (reader.GetDouble("totalAmount") + reader.GetDouble("prevBalance")).ToString("N");
                    b.PaidDate = reader.GetDateTime("dateRemitted").ToShortDateString();
                    b.Amount = reader.GetDouble("totalAmount").ToString("N");
                    b.Balance = reader.GetDouble("balance").ToString("N");
                    borrowerRemit.Add(b);
                    n++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
            return borrowerRemit;
        }


        public double getTotalRemit(string _loanNo)
        {
            try

            {
                connect();
                cmd.CommandText = $"SELECT SUM(totalAmount) AS totalAmount from tbl_remit where loanNo ='{_loanNo}'";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? reader.GetDouble("totalAmount") : 0;
            }
            catch (Exception)
            {
                //messagebox.show(e.message, "gettotalremit");
                return 0;
            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }
        public double getTotalRemittances()
        {

            try
            {
                connect();
                cmd.CommandText = $"SELECT SUM(r.`totalAmount`) AS totalAmount  FROM tbl_remit AS r INNER JOIN tbl_loan AS lo ON lo.loanNo = r.loanNo INNER JOIN tbl_ledger AS l ON l.ledgerNo = r.ledgerID INNER JOIN tbl_borrower_acc AS acc ON acc.accID = lo.accID INNER JOIN tbl_borrower AS b  ON b.borrowerID = acc.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID INNER JOIN tbl_collector AS c ON c.collectorID = r.colID INNER JOIN tbl_member AS co ON co.memID = c.memiD {where}";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? reader.GetDouble("totalAmount") : 0;
            }
            catch (Exception)
            {

                //MessageBox.Show(e.Message, "getTotalRemit");
                return 0;
            } finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }

        public IList<String> getYear()
        {
            List<String> year = new List<string>();

            try
            {
                connect();
                cmd.CommandText = "SELECT DISTINCT DATE_FORMAT(dateRemitted,'%Y') AS yearList FROM tbl_remit";
                reader = cmd.ExecuteReader();
                year.Add("");
                while (reader.Read())
                {
                    year.Add(reader.GetString("yearList"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                reader.Dispose(); disconnect_db();
            }
            return year;
        }
        //public bool makeRemit(List<remittance> remit,List<Loans> loan)
        //{
        //    try
        //    {
        //        connect();
        //        transact = con.BeginTransaction();
        //        cmd.Transaction = transact;
                

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }

    public class remittances
    {
        public int No { get; set; }
        //public string LedgerNo { get; set; }
        //public string LoanNo { get; set; }
        public string TransactioNo { get; set; }
        public string DueDate { get; set; }
        public string DateRemitted { get; set; }
        public string Borrower { get; set; }
        public string Area { get; set; }
        public string AmountDue { get; set; }
        public string Return { get; set; }
        public string interest { get; set; }
        public string AmountPaid { get; set; }
        public string Balance { get; set; }
        public string Collector { get; set; }
    }
}
