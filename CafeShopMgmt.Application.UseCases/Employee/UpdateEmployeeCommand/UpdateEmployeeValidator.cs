using FluentValidation;

namespace CafeShopMgmt.Application.UseCases.Employee.UpdateEmployeeCommand
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Employee Id is required.");

            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required.")
           .Length(6, 10).WithMessage("Name must be between 6 and 10 characters.");

            RuleFor(x => x.EmailAddress)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^[89]\d{7}$").WithMessage("Invalid phone number. It should start with 8 or 9 and have 8 digits.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.");

            RuleFor(x => x.Status)
               .NotEmpty().WithMessage("Employee Status is required.");
        }
    }
}
