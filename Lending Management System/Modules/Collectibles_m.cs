using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lending_Management_System.Modules;
using Lending_Management_System.Objects;
namespace Lending_Management_System
{
    class Collectibles_m:db_connect
    {
        private double TotalCollectibles = 0;
        private double TotalCollectiblesPastDue = 0;
        private string where = null;
        private int start = 0;
        private int limit = 100;

        public int totalRows(bool collectibles)
        {
            string qry = null;
            try
            {
                connect();
                if (collectibles)
                    qry = "SELECT COUNT(*) AS total FROM tbl_ledger  WHERE isRemitted = false";
                else
                    qry = $"SELECT COUNT(*) AS total FROM tbl_loan AS loan WHERE loan.`balance` > 0 AND loan.`matDate` <= DATE_FORMAT(NOW(),'%Y-%m-%d')";
                cmd.CommandText = qry;
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

        public int filtered_rows(bool collectibles)
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string qry = null;
            try
            {
                connect();
                if (collectibles)
                    qry = $"SELECT COUNT(*) AS total FROM tbl_ledger AS l INNER JOIN tbl_loan AS lo ON lo.loanNo = l.loanNo INNER JOIN tbl_borrower_acc AS acc ON acc.accID = lo.accID INNER JOIN tbl_borrower AS b  ON b.borrowerID = acc.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID inner join refcitymun on refcitymun.citymunCode = m.citymunCode  WHERE isRemitted = false  {where} "; 
                else 
                    qry = $"SELECT COUNT(*) AS total FROM tbl_loan AS loan INNER JOIN tbl_borrower_acc AS acc ON acc.`accID` = loan.`accID`  INNER JOIN tbl_borrower AS b ON b.`borrowerID` = acc.`borrowerID` INNER JOIN tbl_member AS mem ON mem.`memID` = b.`memID` WHERE loan.`balance` > 0 AND loan.`paid` = false AND loan.`matDate` <  '{currentDate}' {where} LIMIT {start},{limit}";
                cmd.CommandText = qry;
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

        public IList<Loans> ListOfPastDue(int _n,int _start,int _limit,string _where = null)
        {
            List<Loans> collectibles = new List<Loans>();
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            start = _start;
            limit = _limit;
            where = _where;
            int n = _n;
            try
            {
                connect();
                 cmd.CommandText = $"select loan.`matValue`,refcitymun.citymunDesc AS area, loan.`loanNO`,loan.`accID`,CONCAT(mem.`lname`, ', ', mem.`fname`,' ', mem.`mi`) AS bname,  loan.`effectiveDate`, loan.`principalAmount`, loan.`outstandingCapital`, loan.`balance`, loan.`unearnedInterest`, loan.`earnedInterest`, loan.`matDate` FROM tbl_loan AS loan INNER JOIN tbl_borrower_acc AS acc ON acc.`accID` = loan.`accID`  INNER JOIN tbl_borrower AS b ON b.`borrowerID` = acc.`borrowerID` INNER JOIN tbl_member AS mem ON mem.`memID` = b.`memID` INNER JOIN refcitymun ON refcitymun.citymunCode = mem.citymunCode WHERE  loan.`paid` = false  AND loan.matDate < '{currentDate}' {where} LIMIT {start},{limit}";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var c = new Loans();
                    c.No = n;
                    c.LoanNo = reader.GetString("loanNo");
                    c.AccountNo = reader.GetString("accID");
                    c.Borrower = reader.GetString("bname");
                    c.DateRelease = reader.GetDateTime("effectiveDate").ToShortDateString();
                    c.PrincipalAmount = reader.GetDecimal("principalAmount");
                    c.OutstandingCapital = reader.GetDecimal("outstandingCapital");
                    c.Balance = reader.GetDecimal("balance");
                    c.AccruedInterest = reader.GetDecimal("unearnedInterest");
                    c.EarnedInterest = reader.GetDecimal("earnedInterest");
                    c.DueDate = reader.GetDateTime("matDate").ToShortDateString();
                    c.TotalAmount = reader.GetString("matValue");
                    c.Area = reader.GetString("area");
                    DateTime d2 =  DateTime.Today;
                    c.DaysElapse = d2.Subtract(reader.GetDateTime("matDate")).TotalDays.ToString();
                    collectibles.Add(c);
                    n++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
                disconnect_db();
            }
            return collectibles;
        }
        public IList<Collectibles> ListOfCollectibles(int no,int _start, int _limit, string _where = null)
        {
            List<Collectibles> collectibles = new List<Collectibles>();
            start = _start;
            limit = _limit;
            where = _where;
            int n = no;
            try
            {
                connect();
                cmd.CommandText = $"SELECT  DATE_FORMAT(l.`dueDate`,'%m/%d/%Y') AS duedate,CONCAT(m.lname,', ', m.fname,' ', m.mi) AS borrower, refcitymun.citymunDesc, l.matValue, l.totalAmount  FROM tbl_ledger AS l INNER JOIN tbl_loan AS lo ON lo.loanNo = l.loanNo INNER JOIN tbl_borrower_acc AS acc ON acc.accID = lo.accID INNER JOIN tbl_borrower AS b  ON b.borrowerID = acc.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID inner join refcitymun on refcitymun.citymunCode = m.citymunCode WHERE isRemitted = false  {where} LIMIT {start}, {limit} ";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Collectibles c = new Collectibles();
                    c.No = n;
                    c.Duedate = reader.GetString("duedate");
                    c.Borrower = reader.GetString("borrower");
                    c.Area = reader.GetString("citymunDesc");
                    c.Matvalue = reader.GetDouble("matValue").ToString("N");
                    c.Remittance = reader.GetDouble("totalAmount").ToString("N");
                    TotalCollectibles += reader.GetDouble("totalAmount");
                    collectibles.Add(c);
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
            return collectibles;
        }

        public IList<String> getYear()
        {
            List<String> year = new List<string>();

            try
            {
                connect();
                cmd.CommandText = "SELECT DISTINCT DATE_FORMAT(dueDate,'%Y') AS yearList FROM tbl_ledger";
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
            }finally
            {
                cmd.Dispose();
                reader.Close();
                reader.Dispose();disconnect_db();
            }
            return year; 
        }

        public double getTotalCollectibles()
        {
            try
            {
                connect();
                cmd.CommandText = $"SELECT sum(l.totalAmount) AS total FROM tbl_ledger AS l INNER JOIN tbl_loan AS lo ON lo.loanNo = l.loanNo INNER JOIN tbl_borrower_acc AS acc ON acc.accID = lo.accID INNER JOIN tbl_borrower AS b  ON b.borrowerID = acc.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID inner join refcitymun on refcitymun.citymunCode = m.citymunCode   {where}";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? reader.GetDouble("total"):0;

            }
            catch (Exception)
            {
                return 0;
            } finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }

        public double getTotalPastDueCollectibles()
        {
            return TotalCollectiblesPastDue;
        }

        public IList<Loans> getMasterAreaList(int area,List<string> provCode, List<string> citymunCode, List<string> brgyCode)
        {
            var loan = new List<Loans>();
            string qry = "";
            if(area == 1)
            {
                qry = $"SELECT refprovince.provDesc AS area, m.provCode AS areaCode FROM tbl_loan AS l INNER JOIN tbl_borrower_acc AS a ON a.accID = l.accID INNER JOIN tbl_borrower AS b ON b.borrowerID = a.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID INNER JOIN refcitymun ON refcitymun.citymunCode = m.citymunCode INNER JOIN refprovince ON refprovince.provCode = m.provCode WHERE l.paid = FALSE AND m.provCode IN ({string.Join(",", provCode)})  GROUP BY refprovince.`provDesc` ORDER BY l.loanNo ASC";
            } else if(area == 2)
            {
                qry = $"SELECT CONCAT(refcitymun.citymunDesc,', ',refprovince.provDesc) AS area, m.citymunCode AS areaCode FROM tbl_loan AS l INNER JOIN tbl_borrower_acc AS a ON a.accID = l.accID INNER JOIN tbl_borrower AS b ON b.borrowerID = a.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID INNER JOIN refcitymun ON refcitymun.citymunCode = m.citymunCode INNER JOIN refprovince ON refprovince.provCode = m.provCode WHERE l.paid = FALSE AND m.citymunCode IN ({string.Join(",",citymunCode)})  GROUP BY refcitymun.`citymunDesc` ORDER BY l.loanNo ASC";
            }
            else if (area == 3)
            {
                qry = $"SELECT CONCAT(refbrgy.brgyDesc,', ',refcitymun.citymunDesc) AS area, m.brgyCode AS areaCode FROM tbl_loan AS l INNER JOIN tbl_borrower_acc AS a ON a.accID = l.accID INNER JOIN tbl_borrower AS b ON b.borrowerID = a.borrowerID INNER JOIN tbl_member AS m ON m.memID = b.memID INNER JOIN refcitymun ON refcitymun.citymunCode = m.citymunCode INNER JOIN refbrgy ON refbrgy.brgyCode = m.brgyCode WHERE l.paid = FALSE AND m.brgyCode IN ({string.Join(",", brgyCode)})  GROUP BY refbrgy.`brgyDesc` ORDER BY l.loanNo ASC";
            }

            try
            {
                connect();
                cmd.CommandText = qry;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var l = new Loans();
                    l.Area = reader.GetString("areaCode");
                    l.Status = reader.GetString("area");
                    loan.Add(l);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + $"\n {cmd.CommandText}");
            }
            finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return loan;
        }
        public IList<PostingGuideDetails> getPostingList(int area, string areaCode, string date)
        {
            var loan = new List<PostingGuideDetails>();
            string where = "";

            int n = 1;
            if(area == 1)
            {
                where = $"provCode = '{areaCode}'";
            } else if(area == 2)
            {
                where = $"citymunCode = '{areaCode}'";
            } else
            {
                where = $"brgyCode = '{areaCode}'";
            }
            try
            {
                connect();
                cmd.CommandText = $"SELECT bname,contact,principalAmount, effectiveDate,perRemittance,matDate,balance, '{date}' AS day1,DATE_ADD('{date}',INTERVAL 1 DAY) AS day2,DATE_ADD('{date}',INTERVAL 2 DAY) AS day3,DATE_ADD('{date}',INTERVAL 3 DAY) AS day4,DATE_ADD('{date}',INTERVAL 4 DAY) AS day5,DATE_ADD('{date}',INTERVAL 5 DAY) AS day6,DATE_ADD('{date}',INTERVAL 6 DAY) AS day7 from loan where paid = FALSE AND {where} ORDER BY loanNo ASC ";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var l = new PostingGuideDetails();
                    l.No = n;
                    l.Borrower = reader.GetString("bname");
                    l.ContactNo = reader.GetString("contact");
                    l.TotalAmount = reader.GetDecimal("principalAmount");
                    l.DateRelease = reader.GetDateTime("effectiveDate").ToShortDateString();
                    l.Daily = reader.GetDecimal("perRemittance");
                    l.DueDate = reader.GetDateTime("matDate").ToShortDateString();
                    l.Balance = reader.GetDecimal("balance");
                    l.Day1 = reader.GetDateTime("day1").ToString("MMM-dd-yy");
                    l.Day2 = reader.GetDateTime("day2").ToString("MMM-dd-yy");
                    l.Day3 = reader.GetDateTime("day3").ToString("MMM-dd-yy");
                    l.Day4 = reader.GetDateTime("day4").ToString("MMM-dd-yy");
                    l.Day5 = reader.GetDateTime("day5").ToString("MMM-dd-yy");
                    l.Day6 = reader.GetDateTime("day6").ToString("MMM-dd-yy");
                    l.Day7 = reader.GetDateTime("day7").ToString("MMM-dd-yy");
                    loan.Add(l);
                    n++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n {cmd.CommandText}","GetPostingList");
            } finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return loan;
        }
    }

    //Objects
    public class Collectibles
    {
        public int No { get; set; }
        public string Borrower { get; set; }
        public string Duedate { get; set; }
        public string Area { get; set; }
        public string Matvalue { get; set; }
        public string Remittance { get; set; }
        public string Collector { get; set; }
    }
}
