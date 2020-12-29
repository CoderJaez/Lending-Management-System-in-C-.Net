using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lending_Management_System.Objects;

namespace Lending_Management_System.Modules
{
    class LoanModel : db_connect
    {
        public string loanNo { get; set; }
        public string terms { get; set; }
        public int duration { get; set; }
        public string effDate { get; set; }
        public double principalAmount { get; set; }
        public double interestRate { get; set; }
        public double perRemittance { get; set; }
        public string matDate { get; set; }
        public double outstandinCapital { get; set; }
        public double unearnedInterest { get; set; }
        public double earnedInterest { get; set; }
        public double interestAmount { get; set; }
        public double balance { get; set; }
        public string accID { get; set; }
        public string prevAccID { get; set; }
        public double matValue { get; set; }
        public int NoOfMonthsInterest { get; set; }
        public double Item { get; set; }

        public List<string> ledger { get; set; }
        private decimal earnedInt = 0;
        private decimal accruedInt = 0;
        private decimal principal = 0;
        private decimal bal = 0;
        private decimal outStandingCap = 0;
        private int loanAcc = 0;
        private int start = 0;
        private int limit = 50;
        private string where = null;
        private string search = "";

        public String getLoaNo()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT loanNo FROM tbl_loan ORDER BY loanNO DESC LIMIT 1";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToString(Convert.ToInt32(reader["loanNO"].ToString()) + 1) : "1000201001";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "null";
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                disconnect_db();
            }
        }

        public Boolean withLoanRange()
        {
            Boolean withInRange = false;
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_amount_loanable WHERE minAmount <= @amount AND maxAmount >= @amount";
                cmd.Parameters.AddWithValue("@amount", principalAmount);
                reader = cmd.ExecuteReader();
                withInRange = (reader.HasRows) ? true : false;
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            } finally
            {
                cmd.Dispose();
                reader.Close();
                disconnect_db();
            }
            return withInRange;
        }

        public Boolean addLoan()
        {
            Boolean success = false;
            try
            {
                connect();
                transact = con.BeginTransaction();
                cmd.Transaction = transact;
                cmd.CommandText = "INSERT INTO tbl_loan(loanNO, term, duration,noOfMonths, effectiveDate, principalAmount, interestRate, perRemittance, matDate,matValue, outstandingCapital, unearnedInterest, earnedInterest, balance, interestAmount, accID,date_fullyPaid,item) VALUES (@loanNO,@term, @duration, @NoOfMonths, @effDate, @pAmount, @intRate, @perRemit, @matDate,@matValue, @outstandingCap, @unearnedInt,@earnedInt, @balance, @intAmount, @accID, @DateFullPaid, @Item)";
                cmd.Parameters.AddWithValue("@loanNO", loanNo);
                cmd.Parameters.AddWithValue("@term", terms);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@NoOfMonths", NoOfMonthsInterest);
                cmd.Parameters.AddWithValue("@effDate", effDate);
                cmd.Parameters.AddWithValue("@pAmount", principalAmount);
                cmd.Parameters.AddWithValue("@intRate", interestRate);
                cmd.Parameters.AddWithValue("@perRemit", perRemittance);
                cmd.Parameters.AddWithValue("@matDate", matDate);
                cmd.Parameters.AddWithValue("@matValue", matValue);
                cmd.Parameters.AddWithValue("@outstandingCap", outstandinCapital);
                cmd.Parameters.AddWithValue("@unearnedInt", unearnedInterest);
                cmd.Parameters.AddWithValue("@earnedInt", earnedInterest);
                cmd.Parameters.AddWithValue("@balance", balance);
                cmd.Parameters.AddWithValue("@intAmount", interestAmount);
                cmd.Parameters.AddWithValue("@accID", accID);
                cmd.Parameters.AddWithValue("@DateFullPaid", "0000-00-00");
                cmd.Parameters.AddWithValue("@Item", Item);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE tbl_borrower_acc SET isPendingLoan = true WHERE accID = @AccountID";
                cmd.Parameters.AddWithValue("@AccountID", accID);
                cmd.ExecuteNonQuery();
                transact.Commit();
                success = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public Boolean saveLedger()
        {
            Boolean success = false;
            try
            {
                connect();
                StringBuilder commandString = new StringBuilder("INSERT INTO tbl_ledger(dueDate, matValue, returnAmount, interest, totalAmount, loanNo) VALUES");
                commandString.Append(string.Join(",", ledger));
                commandString.Append(";");
                cmd.CommandText = commandString.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            } finally
            {
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }

        public Boolean checkPendingLoans()
        {
            Boolean pendingLoans = false;
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_loan WHERE paid = false AND accID = @accID ";
                cmd.Parameters.AddWithValue("@accID", accID);
                reader = cmd.ExecuteReader();
                pendingLoans = (reader.HasRows) ? true : false;
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            } finally
            {
                cmd.Dispose();
                disconnect_db();

            }
            return pendingLoans;
        }
        public int LoantotalRows()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT count(*) AS total FROM loan  WHERE paid = false";
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

        public int Loanfiltered_rows()
        {
            try
            {
                connect();
                cmd.CommandText = $"Select COUNT(*) as total from loan where paid = FALSE AND (loanNo LIKE @LoanNo OR bname LIKE @BName) {where}";
                cmd.Parameters.AddWithValue("@LoanNo", $"%{search}%");
                cmd.Parameters.AddWithValue("@BName", $"%{search}%");
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToInt32(reader["total"].ToString()) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n {cmd.CommandText}", "filtered");
                return 0;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }

        


        public DataTable loanApplicationList(string _search, int _start, int _limit, string _where)
        {
            where = _where;
            search = _search;
            start = _start;
            limit = _limit;
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandTimeout = 0;
                cmd.CommandText =$"SELECT * FROM loan where paid = false AND balance > 0 AND (loanNO LIKE @LoanNo OR bname LIKE @BorrowerName) {where}  LIMIT {start},{limit}";
                cmd.Parameters.AddWithValue("@LoanNo", $"%{search}%");
                cmd.Parameters.AddWithValue("@BorrowerName", $"%{search}%");
              
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Zeustech Lending System");
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return dt;
        }


        public int totalRows()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT  COUNT(*) AS total FROM  tbl_ledger AS ledger WHERE ledger.`isRemitted` = FALSE ";
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

        public int filtered_rows()
        {
            try
            {
                connect();
                cmd.CommandText = $"SELECT COUNT(*) AS total FROM  tbl_ledger AS ledger  INNER JOIN tbl_loan AS loan    ON loan.`loanNO` = ledger.`loanNo`   INNER JOIN tbl_borrower_acc AS a    ON a.`accID` = loan.`accID`   INNER JOIN tbl_borrower AS b    ON b.`borrowerID` = a.`borrowerID`   INNER JOIN tbl_member AS m    ON m.`memID` = b.`memID`   INNER JOIN refcitymun    ON refcitymun.citymunCode = m.citymunCode WHERE ledger.`isRemitted` = FALSE  AND {where}";
               
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToInt32(reader["total"].ToString()) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"filtered");
                return 0;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }
        public DataTable loadPostingList(int _start,int _limit, string _where)
        {
            start = _start;
            limit = _limit;
            where = _where;
         
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = $"SELECT ledger.`ledgerNo`, ledger.`dueDate`, ledger.`matValue`, loan.`loanNO`,CONCAT(m.`lname`,', ', m.`fname`,' ', m.mi) AS bname, ledger.`returnAmount`, ledger.`interest`, refcitymun.`citymunDesc` ,ledger.`totalAmount` FROM   tbl_ledger AS ledger INNER JOIN tbl_loan AS loan ON loan.`loanNO` = ledger.`loanNo` INNER JOIN tbl_borrower_acc AS a ON a.`accID` = loan.`accID` INNER JOIN tbl_borrower AS b ON b.`borrowerID` = a.`borrowerID` INNER JOIN tbl_member AS m ON m.`memID` = b.`memID` INNER JOIN refcitymun on refcitymun.citymunCode = m.citymunCode  WHERE ledger.`isRemitted` = FALSE AND loan.paid = false AND {where} ORDER BY ledger.`dueDate` ASC, m.`lname` ASC,m.`fname` LIMIT {start},{limit}";
                reader = cmd.ExecuteReader();
                dt.Load(reader);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
            return dt;
        }

        public DataTable getBorrowerLoanInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_loan WHERE loanNO = @loanNo";
                cmd.Parameters.AddWithValue("@loanNo", loanNo);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
            return dt;
        }

      

      

        public DataTable getLedger()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_ledger WHERE loanNO = @loanNo";
                cmd.Parameters.AddWithValue("@loanNo", loanNo);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
            return dt;

        }

        public IList<ledger> getLedgerList(string LoanNo)
        {
            var ledger = new List<ledger>();
            try
            {
                connect();
                cmd.CommandText = "SELECT DATE_FORMAT(dueDate,'%m/%d/%Y' ) AS dueDate, totalAmount,AmountRemit((SELECT  r.totalAmount FROM tbl_remit AS r WHERE r.ledgerID = l.ledgerNo) ) AS AmountRemit, AmountRemit((SELECT  DATE_FORMAT(r.dateRemitted,'%m/%d/%Y' ) FROM tbl_remit AS r WHERE r.ledgerID = l.ledgerNo) ) AS dateRemitted,AmountRemit((SELECT  r.balance FROM tbl_remit AS r WHERE r.ledgerID = l.ledgerNo) ) AS balance,Collector((SELECT   CONCAT(co.lname,', ', co.fname,' ', co.mi) FROM tbl_remit AS r INNER JOIN tbl_collector c ON c.collectorID = r.colID INNER JOIN tbl_member AS co ON co.memID = c.memID WHERE r.ledgerID = l.ledgerNo) ) AS Collector   FROM tbl_ledger AS l WHERE l.loanNO = @loanNo";
                cmd.Parameters.AddWithValue("@loanNo", LoanNo);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var l = new ledger();
                    l.dueDate = reader.GetString("dueDate");
                    l.totalAmount = reader.GetDouble("totalAmount").ToString("N");
                    l.AmountRecieve = reader.GetString("AmountRemit");
                    l.Balance = reader.GetString("balance");
                    l.DateRemit = reader.GetString("dateRemitted");
                    l.Collector = reader.GetString("collector");
                    ledger.Add(l);

                }

                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }

            return ledger;
        }


        public DataTable summaryLoans(string search,string where)
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = $"SELECT * from loan where (bname LIKE @BName OR loanNO LIKE @LoanNo) {where}";
                cmd.Parameters.AddWithValue("@BName", $"%{search}%");
                cmd.Parameters.AddWithValue("@LoanNo", $"%{search}%");
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return dt;
        }
      

        public IList<Loans> getSummaryLoans(string search, string where)
        {
            var LoanList = new List<Loans>();
            try
            {
                connect();
                cmd.CommandText = $"SELECT * from loan where (bname LIKE @BName OR loanNO LIKE @LoanNo) {where}";
                cmd.Parameters.AddWithValue("@BName", $"%{search}%");
                cmd.Parameters.AddWithValue("@LoanNo", $"%{search}%");
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    var l = new Loans();
                    l.LoanNo = reader.GetString("loanNO");
                    l.Borrower = reader.GetString("bname");
                    l.DateRelease = reader.GetDateTime("effectiveDate").ToShortDateString();
                    l.PrincipalAmount = reader.GetDecimal("principalAmount");
                    l.OutstandingCapital = reader.GetDecimal("outstandingCapital");
                    l.EarnedInterest = reader.GetDecimal("earnedInterest");
                    l.AccruedInterest = reader.GetDecimal("unearnedInterest");
                    l.DueDate = reader.GetDateTime("matDate").ToShortDateString();
                    l.Balance = reader.GetDecimal("balance");
                    l.DateFullyPaid = (reader.GetBoolean("paid")) ? reader.GetDateTime("date_fullyPaid").ToShortDateString() : "";
                    LoanList.Add(l);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System");
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return LoanList;

        }

        public decimal getTotalPrincipal()
        {
            return principal;
        }

        public decimal getTotalOutstandingCapital()
        {
            return outStandingCap;
        }

        public decimal getTotalAccruedInt()
        {
            return accruedInt;
        }

        public decimal getTotalEarnedInt()
        {
            return earnedInt;
        }

        public decimal getTotalBalance()
        {
            return bal;
        }

        public int getTotalLoans()
        {
            return loanAcc;
        }

     

        public Boolean updateLoan()
        {
            Boolean success = false;
            try
            {
                connect();
                transact = con.BeginTransaction();
                cmd.Transaction = transact;
                cmd.CommandText = "UPDATE tbl_loan SET accID = @AccID, term = @term, duration = @duration, effectiveDate= @effDate, principalAmount = @pAmount, interestRate = @intRate, perRemittance = @perRemittance, matDate = @matDate, matValue = @matValue, outstandingCapital = @outstandingCapital, unearnedInterest = @unearnedInt, earnedInterest = @earnedInt,balance = @balance, interestAmount = @intAmount WHERE loanNo = @loanNo";
                cmd.Parameters.AddWithValue("@term",terms);
                cmd.Parameters.AddWithValue("@duration",duration);
                cmd.Parameters.AddWithValue("@AccID",accID);
                cmd.Parameters.AddWithValue("@effDate",effDate);
                cmd.Parameters.AddWithValue("@pAmount", principalAmount);
                cmd.Parameters.AddWithValue("@intRate", interestRate);
                cmd.Parameters.AddWithValue("@perRemittance", perRemittance);
                cmd.Parameters.AddWithValue("@matDate", matDate);
                cmd.Parameters.AddWithValue("@matValue", matValue);
                cmd.Parameters.AddWithValue("@outstandingCapital", outstandinCapital);
                cmd.Parameters.AddWithValue("@unearnedInt", unearnedInterest);
                cmd.Parameters.AddWithValue("@earnedInt", earnedInterest);
                cmd.Parameters.AddWithValue("@balance", balance);
                cmd.Parameters.AddWithValue("@intAmount", interestAmount);
                cmd.Parameters.AddWithValue("@loanNo", loanNo);
                cmd.ExecuteNonQuery();

                if(prevAccID != accID)
                {
                    cmd.CommandText = "UPDATE tbl_borrower_acc SET isPendingLoan = false WHERE accID = @PrevAccID";
                    cmd.Parameters.AddWithValue("@PrevAccID",prevAccID);
                    cmd.ExecuteNonQuery();
                }
                transact.Commit();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Zeustech Lending System!");
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }


        public Boolean deleteLedger()
        {
            Boolean success = false;
            try
            {
                connect();
                cmd.CommandText = "DELETE FROM tbl_ledger WHERE loanNo = @loanNo";
                cmd.Parameters.AddWithValue("@loanNo",loanNo);
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Zeustech Lending System!!");
            }finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return success;
        }
    }
}
