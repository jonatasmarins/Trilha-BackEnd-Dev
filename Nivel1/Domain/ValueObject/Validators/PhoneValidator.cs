using System;
using FluentValidation;

namespace Nivel1.Domain.ValueObject.Validators
{
    public class PhoneValidator: AbstractValidator<Phone>
    {
        public PhoneValidator()
        {
            RuleFor(x => x.Value)
                .MaximumLength(12).WithMessage("Quantidade de caracteres inválido")
                .Must(x => x.IsNumber()).WithMessage("Telefone inválido");
        }

        
    }
}