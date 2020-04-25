using System.Collections.Generic;

namespace NivelBasico.Domain.Shared.Message.Interfaces
{
    public interface IValidatorMessage
    {
         IMessage Validator { get; }
    }
}