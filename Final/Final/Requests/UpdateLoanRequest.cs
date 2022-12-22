using Domain.Final;

namespace Final.Requests
{
    public class UpdateLoanRequest
    {
        public LoanType TypeOfLoan { get; set; }
        public LoanCurrency CurrencyOfLoan { get; set; }
        public int AmountOfLoan { get; set; }
        public int PeriodOfLoan { get; set; }
        public LoanStatus StatusOfLoan { get; set; }
    }
}
