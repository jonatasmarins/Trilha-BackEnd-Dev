using System;
using System.Collections.Generic;
using NivelBasico.Domain.Shared.Message.Interfaces;

namespace NivelBasico.Domain.Shared.Message
{
    public class Message : IMessage
    {

        #region proprieties

        private readonly int COUNT_PRINCIPAL = 2;
        private readonly int COUNT_PRINCIPAL_SUB = 4;
        private readonly int COUNT_PRINCIPAL_FILHO = 6;
        private readonly int COUNT_PRINCIPAL_FILHO_SUB = 8;
        public string Title { get; set; }
        public IList<IMessage> Messages {get; private set;}
        public IList<IDomainMessage> SubMessages { get; private set;}
        public Guid Code { get; private set; }

        #endregion

        #region Constructor

        public Message(string title)
        {
            this.Title = title;
            this.Code = new Guid();
            SubMessages = new List<IDomainMessage>();
            Messages = new List<IMessage>();
        }

        #endregion

        public void AddMessage(IMessage message)
        {
            Messages.Add(message);
        }

        public void RemoveMessage(IMessage message)
        {
            Messages.Remove(message);
        }

        public void AddSubMessage(IDomainMessage subMessage)
        {
            SubMessages.Add(subMessage);
        }

        public void ResetMessages() {
            Messages.Clear();
            SubMessages.Clear();
            Title = string.Empty;
        }

        public IEnumerable<IMessage> GetAll()
        {
            return Messages;
        }

        public void GetMessages()
        {
            Console.WriteLine(new string('-', this.COUNT_PRINCIPAL) + this.Title);
            GetSubMessage(SubMessages, this.COUNT_PRINCIPAL_SUB);

            foreach (var item in Messages)
            {
                Console.WriteLine(new string('-', this.COUNT_PRINCIPAL_FILHO) + item.Title);
                GetSubMessage(item.SubMessages, this.COUNT_PRINCIPAL_FILHO_SUB);
            }

            ResetMessages();
        }

        private void GetSubMessage(IList<IDomainMessage> subMessage, int sub)
        {
            if (subMessage != null && subMessage.Count > 0)
            {
                foreach (var item in subMessage)
                {
                    Console.WriteLine(new string('-', sub) + item.Value);
                }
            }
        }

        public bool IsValid() {
            if(SubMessages != null && SubMessages?.Count > 0 && !string.IsNullOrWhiteSpace(Title)) {
                return false;
            } else {
                return true;
            }
        }
    }
}