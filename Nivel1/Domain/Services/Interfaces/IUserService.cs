using System.Collections.Generic;
using System.Threading.Tasks;
using Nivel1.Models;
using Nivel1.Models.Responses;
using Nivel1.Shared.Models.Interfaces;

namespace Nivel1.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<IResultResponse<IList<UserResponse>>> Get();
        Task<IResultResponse<UserResponse>> GetByDocument(string document);
        Task<IResultResponse> Create(UserCreateRequest request);
        Task<IResultResponse> Update(string document, UserUpdateRequest request);
        Task<IResultResponse> Delete(string document);
    }
}