using FluentValidation;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class CpfValidator : AbstractValidator<Cpf>
    {
        public CpfValidator()
        {
            RuleFor(x => x.Value)
                .NotEmpty().NotEmpty().WithMessage("Cpf é obrigatório")
                .MaximumLength(11).WithMessage("Quantidade de caracteres inválido")
                .MinimumLength(11).WithMessage("Quantidade de caracteres inválido");
        }
    }
}