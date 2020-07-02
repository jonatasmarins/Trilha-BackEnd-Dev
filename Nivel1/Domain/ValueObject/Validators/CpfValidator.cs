using FluentValidation;
using System;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class CpfValidator : AbstractValidator<Cpf>
    {
        private string FieldName = "CPF";
        public CpfValidator()
        {
            RuleFor(x => x.Value)
                .NotEmpty().WithMessage($"{FieldName} é obrigatório")
                .NotNull().WithMessage($"{FieldName} é obrigatório")
                .MaximumLength(11).WithMessage($"{FieldName}, quantidade de caracter inválido")
                .MinimumLength(11).WithMessage($"{FieldName}, quantidade de caracter inválido")
                .Must(x => x.IsNumber()).WithMessage($"{FieldName} inválido, só aceita valor numérico");
        }
    }
}