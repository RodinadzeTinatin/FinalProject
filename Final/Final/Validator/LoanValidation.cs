using Data.Migrations;
using Domain.Final;
using FluentValidation;
using System.Xml.Linq;

namespace Final.Validator
{
    public class LoanValidator : AbstractValidator<Loan>

    {
        public LoanValidator()
        {


            RuleFor(x => x.TypeOfLoan).NotNull().WithMessage("Type Of Loan should not be empty.");

            RuleFor(x => x.CurrencyOfLoan).NotNull().WithMessage("Currency Of Loan should not be empty.");

            RuleFor(x => x.StatusOfLoan).NotNull().WithMessage("Status Of Loan should not be empty.");

            RuleFor(x => x.AmountOfLoan).NotNull().WithMessage("Amount should not be null.")
                .Must(x => (x >= 5000 && x <= 50000)).WithMessage("Amount should be between 5000 - 50 000");

            RuleFor(x => x.PeriodOfLoan).NotNull().WithMessage("Period can't be null.")
                .Must(x => (x >= 6 && x <= 144)).WithMessage("Period should be between 6 to 144 months.");






        }
    }
}
