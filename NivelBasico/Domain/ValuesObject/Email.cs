using System;
using NivelBasico.Domain.Shared.Message;
using NivelBasico.Domain.Shared.Message.Interfaces;

namespace NivelBasico.Domain.ValuesObject
{
    public class Email : IValidatorMessage
    {
        public string Address { get; private set; }

        public IMessage Validator { get; private set; }

        public Email(string adress)
        {
            Validator = new Message(string.Empty);

            Validate(adress);
            if (Validator.IsValid())
            {
                this.Address = adress;
            }
        }

        public override string ToString()
        {
            return this.Address;
        }

        #region Methods

        private void AddValidator(IDomainMessage message)
        {
            if (Validator.IsValid())
                Validator = new Message("Email inválido");

            Validator.AddSubMessage(message);
        }

        #endregion

        #region Validate

        private void Validate(string address)
        {
            if (address != null && !address.Contains("@"))
            {
                AddValidator(new DomainMessage($"Endereço '{address}' de email está invalido"));
            }
        }

        #endregion
    }
}