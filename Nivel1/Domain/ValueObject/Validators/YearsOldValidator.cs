using FluentValidation;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class YearsOldValidator: AbstractValidator<YearsOld>
    {
        private string FieldName = "Idade";
        public YearsOldValidator()
        {
            
            RuleFor(x => x.Value)
                .NotEqual(0).WithMessage($"{FieldName} inválida")
                .LessThanOrEqualTo(150).WithMessage($"{FieldName} inválida, usuário está velho demais não acha ? :)");
        }
    }
}