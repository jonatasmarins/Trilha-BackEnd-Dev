using FluentValidation;
using System;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class CpfValidator : AbstractValidator<Cpf>
    {
        public CpfValidator()
        {
            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("Cpf é obrigatório")
                .NotNull().WithMessage("Cpf é obrigatório")
                .MaximumLength(11).WithMessage("Quantidade de caracteres inválido")
                .MinimumLength(11).WithMessage("Quantidade de caracteres inválido")
                .Must(x => x.IsNumber()).WithMessage("Cpf so aceita valor numéricos");
        }
    }
}