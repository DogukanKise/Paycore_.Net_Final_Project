using FluentValidation;
using Paycore.Dto.Concrete;

namespace Paycore.Base.Util.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .MaximumLength(100);

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .MaximumLength(500);

            RuleFor(c => c.Color)
                .NotEmpty().WithMessage("Color cannot be empty");

            RuleFor(c => c.Brand)
                .NotEmpty().WithMessage("Brand cannot be empty");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Price cannot be empty");

            RuleFor(c => c.CategoryId)
                .NotEmpty().WithMessage("Category Id cannot be empty");

            RuleFor(c => c.OwnerId)
                .NotEmpty().WithMessage("OwnerId cannot be empty");
        }
    }
}
