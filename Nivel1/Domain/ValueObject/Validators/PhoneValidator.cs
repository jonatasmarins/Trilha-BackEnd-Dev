using System;
using FluentValidation;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class PhoneValidator: AbstractValidator<Phone>
    {
        public PhoneValidator()
        {
            RuleFor(x => x.Value)
                .MaximumLength(11).WithMessage("Quantidade de caracteres inválido")
                .MinimumLength(10).WithMessage("Quantidade de caracteres inválido")
                .Must(x => x.IsNumber()).WithMessage("Contato inválido")
                .Must(x => !x.StartsWith("0")).WithMessage("Formato inválido - (99) 9999-9999 ou (99) 9 9999-9999");
        }

        
    }
}