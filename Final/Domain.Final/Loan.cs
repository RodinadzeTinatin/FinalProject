using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Final
{
    public class Loan 
    {
        public int Id { get; set; }
        public LoanType TypeOfLoan { get; set; }
        public LoanCurrency CurrencyOfLoan { get; set; }
        public int AmountOfLoan { get; set; }
        public int PeriodOfLoan { get; set; }
        public LoanStatus StatusOfLoan { get; set; }
        public User User { get; set; }
        public int UserId { get; set; } 

    }
}
