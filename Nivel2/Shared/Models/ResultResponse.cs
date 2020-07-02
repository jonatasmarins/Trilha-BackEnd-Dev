using System.Collections.Generic;
using FluentValidation.Results;
using Nivel2.Shared.Models.Interfaces;

namespace Nivel2.Shared.Models
{
    public abstract class Result : IResult
    {
        public Result()
        {
            this.Messages = new List<string>();
        }

        public IReadOnlyList<string> Erros => Messages;
        private List<string> Messages { get; set;}
        public bool Success { get { return GetSucess(); } }

        public void AddMessage(IList<ValidationFailure> failures)
        {
            foreach (var item in failures)
            {
                this.Messages.Add(item.ErrorMessage);
            }
        }

        public void AddMessage(string failure)
        {
            this.Messages.Add(failure);
        }

        public IList<string> GetMessages()
        {
            return this.Messages;
        }

        private bool GetSucess()
        {
            if (this.Messages?.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class ResultResponse : Result, IResultResponse
    {
        public ResultResponse(string Message)
        {
            this.AddMessage(Message);
        }
        public ResultResponse()
        {

        }
    }

    public class ResultResponse<T> : Result, IResultResponse<T>
    {
        public ResultResponse() { }
        public ResultResponse(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
    }
}