using FluentValidation;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        private string FieldName = "Email";

        public EmailValidator()
        {
            RuleFor(x => x.Value)
            .EmailAddress().WithMessage($"{FieldName} inválido");
        }
    }
}