using FluentValidation;
using Nivel1.Domain.ValueObject.Validators;

namespace Nivel1.Domain.Models.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Document).SetValidator(new CpfValidator());
            RuleFor(x => x.Name).SetValidator(new NameValidator());
            RuleFor(x => x.Email).SetValidator(new EmailValidator());
            RuleFor(x => x.Phone).SetValidator(new PhoneValidator());
            RuleFor(x => x.YearsOld).SetValidator(new YearsOldValidator());
        }
    }
}