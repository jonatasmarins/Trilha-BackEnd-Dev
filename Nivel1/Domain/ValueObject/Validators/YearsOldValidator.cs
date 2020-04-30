using FluentValidation;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class YearsOldValidator: AbstractValidator<YearsOld>
    {
        public YearsOldValidator()
        {
            RuleFor(x => x.Value)
                .NotEqual(0).WithMessage("Idade inválida")
                .LessThanOrEqualTo(150).WithMessage("Idade inválida, usuário está velho demais não acha ? :)");
        }
    }
}