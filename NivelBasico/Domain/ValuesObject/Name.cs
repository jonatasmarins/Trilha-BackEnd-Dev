using NivelBasico.Domain.Shared.Message;
using NivelBasico.Domain.Shared.Message.Interfaces;

namespace NivelBasico.Domain.ValuesObject
{
    public class Name: IValidatorMessage
    {
        public string NameOV { get; private set; }

        public IMessage Validator { get; private set; }

        public Name(string name)
        {
            Validator = new Message(string.Empty);

            Validate(name);
            if (Validator.IsValid())
            {
                this.NameOV = name;
            }
        }

        public override string ToString()
        {
            return this.NameOV;
        }

        #region Methods

        private void AddValidator(IDomainMessage message)
        {
            if (Validator.IsValid())
                Validator = new Message("Nome inválido");

            Validator.AddSubMessage(message);
        }

        #endregion

        #region Validate

        private void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                AddValidator(new DomainMessage($"Nome está nullo ou vazio"));
            }
        }

        #endregion
    }
}