using FluentValidation;
using Paycore.Dto.Concrete;

namespace Paycore.Base.Util.Validators
{
    public class OfferValidator : AbstractValidator<OfferDto>
    {
        public OfferValidator()
        {
            RuleFor(c => c.ProductId)
                .NotEmpty().WithMessage("Product Id cannot be empty");
            RuleFor(c => c.Bid)
                .NotEmpty().WithMessage("Bid cannot be empty");
        }


    }
}
