using FluentValidation;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class NameValidator: AbstractValidator<Name>
    {
        public NameValidator()
        {
            RuleFor(x => x.Value.ToString()).NotEmpty().WithMessage("Nome é obrigatório")
            .NotNull().WithMessage("Nome é obrigatório");
        }
    }
}