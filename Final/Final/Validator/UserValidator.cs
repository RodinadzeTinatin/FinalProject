using Data.Migrations;
using Domain.Final;
using FluentValidation;
using System.Xml.Linq;

namespace Final.Validator
{
    public class UserValidator : AbstractValidator <User>

    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull()
                .WithMessage("Your User Name should not be empty.")
                .Length(2, 25).WithMessage("User Name should be between 2 and 25 characters.");

            RuleFor(x => x.FirstName).NotEmpty().NotNull()
                .WithMessage("Your First Name should not be empty.")
                .Length(2, 25).WithMessage("First Name should be between 2 and 25 characters");

            RuleFor(x => x.LastName).NotEmpty().NotNull()
                .WithMessage("Your Last Name should not be empty.")
                .Length(2, 25).WithMessage("Last Name should be between 2 and 25 characters.");

            RuleFor(x => x.Age).NotEmpty().NotNull()
                .WithMessage("Your age can not be empty.")
                .GreaterThanOrEqualTo(20).WithMessage("Your should be above 20 to get loan");

            RuleFor(x => x.Email).NotNull().WithMessage("Your Email can not be empty.")
                .EmailAddress().WithMessage("Double-check your email. It's wrong.");

            RuleFor(x => x.Monthlyincome).NotEmpty().NotNull().WithMessage("Your Salary can not be empty.");
        }
    }
}
