using FluentValidation;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class NameValidator: AbstractValidator<Name>
    {
        private string FieldName = "Nome";

        public NameValidator()
        {
            RuleFor(x => x.Value.ToString()).NotEmpty().WithMessage($"{FieldName} é obrigatório")
            .NotNull().WithMessage($"{FieldName} é obrigatório");
        }
    }
}