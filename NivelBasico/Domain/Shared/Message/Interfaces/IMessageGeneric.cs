using System;

namespace NivelBasico.Domain.Shared.Message.Interfaces
{
    public interface IMessageGeneric
    {
        Guid Code { get; }
        string Value { get; set;}
    }
}