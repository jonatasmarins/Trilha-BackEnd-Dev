using System;
using System.Collections.Generic;

namespace NivelBasico.Domain.Shared.Message.Interfaces
{
    public interface IMessage
    {
        string Title { get; }
        IList<IMessage> Messages{get;}
        IList<IDomainMessage> SubMessages{get;}
        IEnumerable<IMessage> GetAll();
        void RemoveMessage(IMessage subMessage);
        void AddMessage(IMessage subMessage);
        void AddSubMessage(IDomainMessage subMessage);
        bool IsValid();
        void GetMessages();
    }
}