using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lending_Management_System.Objects
{
    class Loans
    {
        public int No { get; set; }
        public string LoanNo { get; set; }
        public string AccountNo { get; set; }
        public string Borrower{ get; set;}
        public string ContactNo { get; set; }
        public string TotalAmount { get; set; }
        public string DateRelease { get; set; }
        public string Area { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal OutstandingCapital { get; set; }
        public decimal AccruedInterest { get; set; }
        public decimal EarnedInterest { get; set; }
        public decimal Balance { get; set; }
        public string DateFullyPaid { get;set; }
        public string DueDate { get; set; }
        public string DaysElapse { get; set; }
        public string Status { get; internal set; }
        public int NoOfMonthsInterest { get; set; }
    }
}
