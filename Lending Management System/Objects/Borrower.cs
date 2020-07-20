using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lending_Management_System
{
    class Borrower
    {
        public byte[] Image { get; set; }
        public string BorrowerID { get; set; }
        public string AccountID { get; set; }
        public string LoanNo { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string brgyCode { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
    }
}
