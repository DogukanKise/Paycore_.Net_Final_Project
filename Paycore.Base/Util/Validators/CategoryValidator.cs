using FluentValidation;
using Paycore.Dto.Concrete;

namespace Paycore.Base.Util.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty");

        }

    }
}
