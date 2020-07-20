using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lending_Management_System.Objects
{
    class PostingGuideDetails
    {
        public int No { get; set; }
        public string LoanNo { get; set; }
        public string Borrower { get; set; }
        public string ContactNo { get; set; }
        public decimal TotalAmount { get; set; }
        public string DateRelease { get; set; }
        public string Area { get; set; }
        public decimal Daily { get; set; }
        public decimal Balance { get; set; }
        public string DueDate { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public string Day3 { get; set; }
        public string Day4 { get; set; }
        public string Day5 { get; set; }
        public string Day6 { get; set; }
        public string Day7 { get; set; }
    }
}
