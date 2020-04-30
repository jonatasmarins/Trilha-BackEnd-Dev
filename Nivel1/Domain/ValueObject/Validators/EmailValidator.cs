using FluentValidation;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(x => x.Value)
            .EmailAddress().WithMessage("Email inválido");
        }
    }
}