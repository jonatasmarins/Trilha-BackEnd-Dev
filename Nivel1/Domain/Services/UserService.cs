using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Nivel1.Data.UnitOfWork.Interfaces;
using Nivel1.Domain.Models;
using Nivel1.Domain.Models.Validators;
using Nivel1.Domain.Services.Interfaces;
using Nivel1.Domain.ValueObject;
using Nivel1.Domain.ValueObject.Validators;
using Nivel1.Models;
using Nivel1.Models.Responses;
using Nivel1.Shared.Models;
using Nivel1.Shared.Models.Interfaces;

namespace Nivel1.Domain.Services
{
    public class UserService : IUserService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResultResponse> Create(UserCreateRequest request)
        {
            IResultResponse response = new ResultResponse();

            User user = _mapper.Map<User>(request);

            UserValidator validator = new UserValidator();
            var result = await validator.ValidateAsync(user);

            if (result.IsValid)
            {
                await _unitOfWork.UserRepository.Create(user);
            }
            else
            {
                response.AddMessage(result.Errors);
            }

            return response;
        }

        public async Task<IResultResponse> Delete(string document)
        {
            IResultResponse response = new ResultResponse();
            CpfValidator validator = new CpfValidator();
            var result = await validator.ValidateAsync(new Cpf(document));

            if (result.IsValid)
            {
                User user = await _unitOfWork.UserRepository.GetByDocument(document);
                if (user != null)
                    await _unitOfWork.UserRepository.Delete(user);
                else
                    response.AddMessage($"Usuário com o Cpf {document} não encontrado");
            }
            else
            {
                response.AddMessage(result.Errors);
            }

            return response;
        }

        public async Task<IResultResponse<IList<UserResponse>>> Get()
        {
            IResultResponse<IList<UserResponse>> response = new ResultResponse<IList<UserResponse>>();
            IList<User> users = await _unitOfWork.UserRepository.Get();

            if (users == null || users?.Count == 0)                
                response.AddMessage("Não existe nenhum usuário cadastrado");
            else
                response.Value = _mapper.Map<IList<UserResponse>>(users);
                

            return response;
        }

        public async Task<IResultResponse<UserResponse>> GetByDocument(string document)
        {
            IResultResponse<UserResponse> response = new ResultResponse<UserResponse>();
            CpfValidator validator = new CpfValidator();
            var result = await validator.ValidateAsync(new Cpf(document));

            if (result.IsValid)
            {
                User user = await _unitOfWork.UserRepository.GetByDocument(document);
                if (user == null)
                    response.AddMessage($"Usuário com o Cpf {document} não encontrado");

                response.Value = _mapper.Map<UserResponse>(user);
            }
            else
            {
                response.AddMessage(result.Errors);
            }

            return response;
        }

        public async Task<IResultResponse> Update(string document, UserUpdateRequest request)
        {
            IResultResponse response = new ResultResponse();
            User user = await _unitOfWork.UserRepository.GetByDocument(document);

            if (user == null)
            {
                response.AddMessage("Usuário não encontrado");
                return response;
            }

            user.SetName(new Name(request.Name));
            user.SetYearsOld(new YearsOld(request.YearsOld));
            user.SetEmail(new Email(request.Email));
            user.SetPhone(new Phone(request.Phone));
            user.SetAddress(request.Address);

            UserValidator validator = new UserValidator();
            var result = await validator.ValidateAsync(user);

            if (result.IsValid)
            {
                await _unitOfWork.UserRepository.Update(user);
            }
            else
            {
                response.AddMessage(result.Errors);
            }

            return response;
        }
    }
}