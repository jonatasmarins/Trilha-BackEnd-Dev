using NivelBasico.Domain.Shared.Message;
using NivelBasico.Domain.Shared.Message.Interfaces;

namespace NivelBasico.Domain.ValuesObject
{
    public class YearsOld: IValidatorMessage
    {
        public string YearsOldOV { get; private set; }

        public IMessage Validator { get; private set; }

        public YearsOld(string yearsOld)
        {
            Validator = new Message(string.Empty);

            Validate(yearsOld);
            if (Validator.IsValid())
            {
                this.YearsOldOV = yearsOld;
            }
        }

        public override string ToString()
        {
            return this.YearsOldOV;
        }

        #region Methods

        private void AddValidator(IDomainMessage message)
        {
            if (Validator.IsValid())
                Validator = new Message("Idade inválida");

            Validator.AddSubMessage(message);
        }

        #endregion

        #region Validate

        private void Validate(string yearsOld)
        {
            int years = 0;
            if (!string.IsNullOrWhiteSpace(yearsOld) && !int.TryParse(yearsOld, out years))
            {
                AddValidator(new DomainMessage($"Valor para a propriedade Idade está inválida"));
            }
        }

        #endregion
    }
}