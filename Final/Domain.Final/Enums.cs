
namespace Domain.Final
{
    public enum LoanType
    {
        FastLoan,
        AutoLoan,
        Installment
    }

    public enum LoanCurrency
    {
        GEL,
        USD,
        EUR,
        JPY,
        GBP
    }

    public enum LoanStatus
    {
        Processing,
        Confirmed,
        Declined
    }
}
