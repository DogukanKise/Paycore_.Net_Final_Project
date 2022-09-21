using FluentValidation;
using Paycore.Dto.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Paycore.Base.Util.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(c => c.Surname)
                .NotEmpty().WithMessage("Surname cannot be empty");
            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("Invalid e-mail adress (Example: dogukan.kisecuklu@paycore.com)");
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .Length(8, 20).WithMessage("Password must be between 8-20 characters");
            RuleFor(c => c.LastActivity)
                .NotEmpty().WithMessage("Last Activity cannot be empty");
        }
    }
}
