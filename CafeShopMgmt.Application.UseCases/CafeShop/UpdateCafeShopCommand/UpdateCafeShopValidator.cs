using FluentValidation;

namespace CafeShopMgmt.Application.UseCases.CafeShop.UpdateCafeShopCommand
{
    public class  UpdateCafeShopValidator : AbstractValidator<UpdateCafeShopCommand>
    {
        public UpdateCafeShopValidator()
        {
            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Cafe Shop Id is required.");

            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required.")
           .Length(6, 10).WithMessage("Name must be between 6 and 10 characters.");
            
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("Description is required.")
               .MaximumLength(256).WithMessage("Description must be 256 characters.");

            RuleFor(x => x.Status)
               .NotEmpty().WithMessage("Cafe Shop Status is required.");
        }
    }
}
