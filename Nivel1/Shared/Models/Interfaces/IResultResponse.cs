using System.Collections.Generic;
using FluentValidation.Results;

namespace Nivel1.Shared.Models.Interfaces
{
    public interface IResult
    {
        bool Success { get; }
        IReadOnlyList<string> Erros { get; }
        void AddMessage(IList<ValidationFailure> failures);
        void AddMessage(string failure);
        IList<string> GetMessages();
    }

    public interface IResultResponse : IResult
    {

    }

    public interface IResultResponse<T> : IResult
    {
        T Value { get; set; }
    }
}