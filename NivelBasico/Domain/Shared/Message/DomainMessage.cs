using System;
using NivelBasico.Domain.Shared.Message.Interfaces;

namespace NivelBasico.Domain.Shared.Message
{
    public class DomainMessage : IDomainMessage
    {
        public DomainMessage(string value)
        {
            this.Value = value;
            this.Code = new Guid();
        }

        public string Value { get; set; }

        public Guid Code {get; private set;}

        public void GetMessages()
        {
            Console.WriteLine(new string('-', 2) + this.Value);
        }
    }
}