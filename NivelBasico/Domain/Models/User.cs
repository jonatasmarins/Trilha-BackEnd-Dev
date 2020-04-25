using NivelBasico.Domain.Shared.Message;
using NivelBasico.Domain.Shared.Message.Interfaces;
using NivelBasico.Domain.ValuesObject;

namespace NivelBasico.Domain.Models
{
    public class User : IValidatorMessage
    {
        public User(Name name, YearsOld yearold, Cpf document, Email email, Phone phone, string address)
        {
            this.name = name;
            this.yearsOld = yearold;
            this.document = document;
            this.email = email;
            this.phone = phone;
            this.address = address;

            this.Validate();
        }

        #region Proprieties
        public Name name { get; private set; }
        public YearsOld yearsOld { get; private set; }
        public Cpf document { get; private set; }
        public Email email { get; private set; }
        public Phone phone { get; private set; }
        public string address { get; private set; }
        public IMessage Validator { get; private set; }

        #endregion

        #region Getters And Setters

        #region Endereco
        public string GetAddress()
        {
            return address;
        }

        public void SetAddress(string value)
        {
            address = value;
        }
        #endregion

        #region phone

        public Phone GetPhone()
        {
            return phone;
        }

        public void SetPhone(Phone value)
        {            
            this.phone = value;
            Validate();
        }
        #endregion

        #region Email
        public Email GetEmail()
        {
            return email;
        }

        public void SetEmail(Email value)
        {
            this.email = value;
            Validate();
        }
        #endregion

        #region CPF
        public Cpf GetDocumentNumber()
        {
            return document;
        }

        private void SetDocumentNumber(Cpf value)
        {
            this.document = value;
            Validate();
        }
        #endregion

        #region Idade
        public YearsOld GetYearsOld()
        {
            return yearsOld;
        }

        public void SetYearsOld(YearsOld value)
        {
            this.yearsOld = value;
            Validate();
        }

        #endregion

        #region Nome
        public Name GetName()
        {
            return name;
        }
        public void SetName(Name value)
        {
            this.name = value;
            Validate();
        }
        #endregion

        #endregion

        #region Validator      

        private void SetValidator() {
            if (Validator == null)
                Validator = new Message("Cliente Inválido");
        }

        private void AddValidator(IMessage message)
        {
            SetValidator();
            Validator.AddMessage(message);
        }

        private void AddValidator(IDomainMessage message)
        {
            SetValidator();
            Validator.AddSubMessage(message);
        }

        private void Validate()
        {
            if (!this.document.Validator.IsValid())
            {
                AddValidator(this.document.Validator);
            }

            if(!this.email.Validator.IsValid()) {
                AddValidator(this.email.Validator);
            }

            if(!this.phone.Validator.IsValid()) {
                AddValidator(this.phone.Validator);
            }

            if(!this.name.Validator.IsValid()) {
                AddValidator(this.name.Validator);
            }

            if(!this.yearsOld.Validator.IsValid()) {
                AddValidator(this.yearsOld.Validator);
            }
        }
        #endregion
    }
}