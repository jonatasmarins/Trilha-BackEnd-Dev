using System;
using NivelBasico.Domain.Shared.Message;
using NivelBasico.Domain.Shared.Message.Interfaces;

namespace NivelBasico.Domain.ValuesObject
{
    public class Phone : IValidatorMessage
    {
        public string PhoneNumber { get; private set; }

        public IMessage Validator { get; private set; }

        public Phone(string phoneNumber)
        {
            Validator = new Message(string.Empty);

            Validate(phoneNumber);
            if (Validator.IsValid())
            {
                this.PhoneNumber = phoneNumber;
            }
        }

        public override string ToString()
        {
            return this.PhoneNumber;
        }

        #region Methods

        private void AddValidator(IDomainMessage message)
        {
            if (Validator.IsValid())
                Validator = new Message("Contato inválido");

            Validator.AddSubMessage(message);
        }

        #endregion

        #region Validate

        private void Validate(string phoneNumber)
        {
            string phone = phoneNumber.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

            if (
                !string.IsNullOrWhiteSpace(phone) &&
                (!phone.IsNumber() ||
                (phone?.Length != 11 && phone?.Length != 10))
            )
            {
                AddValidator(new DomainMessage($"Número de contato {phoneNumber} está inválido"));
                return;
            }
        }

        #endregion
    }
}