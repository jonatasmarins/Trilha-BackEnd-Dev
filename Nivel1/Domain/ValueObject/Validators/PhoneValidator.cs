using System;
using FluentValidation;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class PhoneValidator: AbstractValidator<Phone>
    {
        private string FieldName = "Contato";
        public PhoneValidator()
        {
            RuleFor(x => x.Value)
                .MaximumLength(11).WithMessage($"{FieldName}, quantidade de caracter inválido")
                .MinimumLength(10).WithMessage($"{FieldName}, quantidade de caracter inválido")
                .Must(x => x.IsNumber()).WithMessage($"{FieldName} inválido")
                .Must(x => !x.StartsWith("0")).WithMessage($"{FieldName}, formato inválido - (99) 9999-9999 ou (99) 9 9999-9999");
        }

        
    }
}