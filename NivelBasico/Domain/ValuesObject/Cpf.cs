using System;
using System.Collections.Generic;
using NivelBasico.Domain.Shared.Message;
using NivelBasico.Domain.Shared.Message.Interfaces;

namespace NivelBasico.Domain.ValuesObject
{
    public class Cpf : IValidatorMessage
    {
        #region Constructor
        public Cpf(string cpfOV)
        {
            Validator = new Message(string.Empty);
            
            Validate(cpfOV);
            if (Validator.IsValid())
            {
                this.CpfOV = cpfOV;
            }
        }

        #endregion

        #region Proprieties

        public IMessage Validator { get; private set; }
        private string CpfOV { get; }

        public override string ToString()
        {
            return this.CpfOV;
        }

        #endregion

        #region Methods

        private void AddValidator(IDomainMessage message)
        {
            if (Validator.IsValid())
                Validator = new Message("CPF inválido");

            Validator.AddSubMessage(message);
        }

        #endregion

        #region Validate

        private void Validate(string cpfOV)
        {
            string document = cpfOV.Replace(".", "").Replace("-", "");

            if (document == string.Empty)
            {
                AddValidator(new DomainMessage("A propriedade está nula ou vazia"));
                return;
            }

            else if (document.Length != 11)
            {
                AddValidator(new DomainMessage($"Não contém a quantidade de caracteres necessário para esse tipo de documento, doc: {cpfOV}"));
            }
        }

        #endregion
    }
}