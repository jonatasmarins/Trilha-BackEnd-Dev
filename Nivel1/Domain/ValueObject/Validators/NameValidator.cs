using FluentValidation;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class NameValidator: AbstractValidator<Name>
    {
        public NameValidator()
        {
            RuleFor(x => x.Value.ToString()).NotEmpty().NotNull().WithMessage("Nome é obrigatório");
        }
    }
}