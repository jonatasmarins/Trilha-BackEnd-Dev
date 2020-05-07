using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Nivel1.Data.UnitOfWork.Interfaces;
using Nivel1.Domain.Models;
using Nivel1.Domain.Services;
using Nivel1.Models;
using Nivel1.Models.Responses;
using Nivel1_Test.FakeRepository;
using Xunit;
using Xunit.Abstractions;

namespace Nivel1_Test
{
    public class UserTest
    {
        private ITestOutputHelper output;
        private UserFakeRepository fakeRepository;
        private UserService service;
        private Mock<IUnitOfWork> unitofWork;
        private Mock<IMapper> mapper;
        public UserTest(ITestOutputHelper outputHelper)
        {
            output = outputHelper;
            fakeRepository = new UserFakeRepository();
            unitofWork = new Mock<IUnitOfWork>();
            mapper = new Mock<IMapper>();
            service = new UserService(unitofWork.Object, mapper.Object);
        }

        [Fact]
        [Trait("GetByDocument", "Value Empty")]
        public async Task GetByDocument_Value_Empty_ERROR()
        {
            string document = string.Empty;
            User userFake = fakeRepository.GetByDocument(document);
            mapper.Setup(x => x.Map<UserResponse>(userFake));
            unitofWork.Setup(x => x.UserRepository.GetByDocument(document)).Returns(Task.FromResult(userFake));

            var result = await service.GetByDocument(document);

            Assert.NotNull(result.Erros);
            Assert.False(result.Success);
            Assert.Contains("Cpf é obrigatório", result.Erros);

            PrintErrorMessages(result.Erros);
            output.WriteLine("Teste executado com sucesso");
        }

        [Theory]
        [InlineData("418888")]
        [InlineData("418418418418")]
        [InlineData("418.418.418-418")]
        [InlineData("418.418.418-4")]
        [InlineData("418abc")]
        [InlineData("aaaaaaaaaaa")]
        [Trait("GetByDocument", "Value Invalid")]
        public async Task GetByDocument_Value_Invalid_ERROR(string document)
        {
            User userFake = fakeRepository.GetByDocument(document);
            mapper.Setup(x => x.Map<UserResponse>(userFake));
            unitofWork.Setup(x => x.UserRepository.GetByDocument(document)).Returns(Task.FromResult(userFake));

            var result = await service.GetByDocument(document);

            Assert.NotNull(result.Erros);
            Assert.False(result.Success);
            Assert.DoesNotContain("Cpf é obrigatório", result.Erros);

            PrintErrorMessages(result.Erros);
            output.WriteLine($"Valor Testado: {document}");
            output.WriteLine("Teste executado com sucesso");
        }

        [Theory]
        [InlineData("41841841800")]
        [InlineData("418.418.418-88")]
        [Trait("GetByDocument", "User not found")]
        public async Task GetByDocument_Value_Valid_Not_Found_ERROR(string document)
        {
            User userFake = fakeRepository.GetByDocumentNotFound(document);
            mapper.Setup(x => x.Map<UserResponse>(userFake));
            unitofWork.Setup(x => x.UserRepository.GetByDocument(document)).Returns(Task.FromResult(userFake));

            var result = await service.GetByDocument(document);

            Assert.NotNull(result.Erros);
            Assert.False(result.Success);

            PrintErrorMessages(result.Erros);
            output.WriteLine($"Valor Testado: {document}");
            output.WriteLine("Teste executado com sucesso");
        }

        [Theory]
        [InlineData("418.418.418-88")]
        [InlineData("41841841888")]
        [Trait("GetByDocument", "Success")]
        public async Task GetByDocument_Value_Valid_SUCCESS(string document)
        {
            User userFake = fakeRepository.GetByDocument(document);
            mapper.Setup(x => x.Map<UserResponse>(userFake));
            unitofWork.Setup(x => x.UserRepository.GetByDocument(document)).Returns(Task.FromResult(userFake));

            var result = await service.GetByDocument(document);

            Assert.True(result.Success);
            Assert.Equal(result.Erros?.Count, 0);

            output.WriteLine($"Valor Testado: {document}");
            output.WriteLine("Teste executado com sucesso");
        }

        [Theory]
        [InlineData("")]
        [InlineData("4184184188")]
        [InlineData("418418418888")]
        [InlineData("aaaaaaaaaaa")]
        [InlineData("418888888aa")]
        [Trait("Create", "Invalid Document")]
        public async Task Create_Value_Invalid_CPF_ERROR(string document)
        {            
            User userFake = fakeRepository.GetByDocument(document);
            UserCreateRequest userFakeRequest = fakeRepository.UserCreateRequest(document);
            mapper.Setup(x => x.Map<User>(userFakeRequest)).Returns(userFake);
            unitofWork.Setup(x => x.UserRepository.GetByDocument(userFake.Document.Value)).Returns(Task.FromResult(userFake));
            unitofWork.Setup(x => x.UserRepository.Create(userFake));

            var result = await service.Create(userFakeRequest);

            Assert.False(result.Success);
            Assert.NotEqual(result.Erros?.Count, 0);

            PrintErrorMessages(result.Erros);
            output.WriteLine($"Valor Testado: {document}");
            output.WriteLine("Teste executado com sucesso");
        }

        [Fact]
        [Trait("Create", "Invalid Name")]
        public async Task Create_Value_Invalid_Name_ERROR()
        {     
            User userFake = fakeRepository.GetByDocument(name: string.Empty);
            UserCreateRequest userFakeRequest = fakeRepository.UserCreateRequest(name: string.Empty);
            mapper.Setup(x => x.Map<User>(userFakeRequest)).Returns(userFake);
            unitofWork.Setup(x => x.UserRepository.GetByDocument(userFake.Document.Value)).Returns(Task.FromResult(userFake));
            unitofWork.Setup(x => x.UserRepository.Create(userFake));

            var result = await service.Create(userFakeRequest);

            Assert.False(result.Success);
            Assert.NotEqual(result.Erros?.Count, 0);

            PrintErrorMessages(result.Erros);
            output.WriteLine($"Valor Testado: {userFakeRequest.Document}");
            output.WriteLine("Teste executado com sucesso");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(150)]
        [InlineData(151)]
        [InlineData(null)]
        [Trait("Create", "Invalid YearsOld")]
        public async Task Create_Value_Invalid_YearsOld_ERROR(int yearsOld)
        {            
            User userFake = fakeRepository.GetByDocument(yearsOld: yearsOld);
            UserCreateRequest userFakeRequest = fakeRepository.UserCreateRequest(yearsOld: yearsOld);
            mapper.Setup(x => x.Map<User>(userFakeRequest)).Returns(userFake);
            unitofWork.Setup(x => x.UserRepository.GetByDocument(userFake.Document.Value)).Returns(Task.FromResult(userFake));
            unitofWork.Setup(x => x.UserRepository.Create(userFake));

            var result = await service.Create(userFakeRequest);

            Assert.False(result.Success);
            Assert.NotEqual(result.Erros?.Count, 0);

            PrintErrorMessages(result.Erros);
            output.WriteLine($"Valor Testado: {yearsOld}");
            output.WriteLine("Teste executado com sucesso");
        }

        [Theory]
        [InlineData("jonatas")]
        [InlineData("jonatas@")]
        [Trait("Create", "Invalid Email")]
        public async Task Create_Value_Invalid_Email_ERROR(string email)
        {            
            User userFake = fakeRepository.GetByDocument(email: email);
            UserCreateRequest userFakeRequest = fakeRepository.UserCreateRequest(email: email);
            mapper.Setup(x => x.Map<User>(userFakeRequest)).Returns(userFake);
            unitofWork.Setup(x => x.UserRepository.GetByDocument(userFake.Document.Value)).Returns(Task.FromResult(userFake));
            unitofWork.Setup(x => x.UserRepository.Create(userFake));

            var result = await service.Create(userFakeRequest);

            Assert.False(result.Success);
            Assert.NotEqual(result.Erros?.Count, 0);

            PrintErrorMessages(result.Erros);

            output.WriteLine($"Valor Testado: {email}");
            output.WriteLine("Teste executado com sucesso");
        }

        [Theory]
        [InlineData("199969696969")]
        [InlineData("(19) 9 9696-96969")]
        [InlineData("(19) 9696-969")]
        [InlineData("(019) 9 9696-969")]
        [InlineData("(019) 9696-9696")]
        [InlineData("aaa")]        
        [InlineData("1999696969o")]
        [Trait("Create", "Invalid Phone")]
        public async Task Create_Value_Invalid_Phone_ERROR(string phone)
        {            
            User userFake = fakeRepository.GetByDocument(phone: phone);
            UserCreateRequest userFakeRequest = fakeRepository.UserCreateRequest(phone: phone);
            mapper.Setup(x => x.Map<User>(userFakeRequest)).Returns(userFake);
            unitofWork.Setup(x => x.UserRepository.GetByDocument(userFake.Document.Value)).Returns(Task.FromResult(userFake));
            unitofWork.Setup(x => x.UserRepository.Create(userFake));

            var result = await service.Create(userFakeRequest);

            Assert.False(result.Success);
            Assert.NotEqual(result.Erros?.Count, 0);

            PrintErrorMessages(result.Erros);

            output.WriteLine($"Valor Testado: {phone}");
            output.WriteLine("Teste executado com sucesso");
        }


        [Fact]
        [Trait("Create", "Success")]
        public async Task Create_Value_Valid_SUCCESS()
        {            
            User userFake = fakeRepository.GetByDocument();
            UserCreateRequest userFakeRequest = fakeRepository.UserCreateRequest();
            mapper.Setup(x => x.Map<User>(userFakeRequest)).Returns(userFake);
            unitofWork.Setup(x => x.UserRepository.GetByDocument(userFake.Document.Value)).Returns(Task.FromResult(fakeRepository.GetByDocumentNotFound(userFake.Document.Value)));
            unitofWork.Setup(x => x.UserRepository.Create(userFake));

            var result = await service.Create(userFakeRequest);

            Assert.True(result.Success);
            Assert.Equal(result.Erros?.Count, 0);
            output.WriteLine("Teste executado com sucesso");
        }

        [Fact]
        [Trait("Update", "Not Found User")]
        public async Task Update_Value_Invalid_not_found_user()
        {            
            User userFake = fakeRepository.GetByDocument();
            UserUpdateRequest userFakeRequest = fakeRepository.UserUpdateRequest();
            mapper.Setup(x => x.Map<User>(userFakeRequest)).Returns(userFake);
            unitofWork.Setup(x => x.UserRepository.GetByDocument(userFake.Document.Value)).Returns(Task.FromResult(fakeRepository.GetByDocumentNotFound(userFake.Document.Value)));
            unitofWork.Setup(x => x.UserRepository.Update(userFake));

            var result = await service.Update(userFake.Document.Value, userFakeRequest);

            Assert.False(result.Success);
            Assert.NotEqual(result.Erros?.Count, 0);
            PrintErrorMessages(result.Erros);
            output.WriteLine("Teste executado com sucesso");
        }

        [Fact]
        [Trait("Update", "Success")]
        public async Task Update_Value_Valid_SUCCESS()
        {            
            User userFake = fakeRepository.GetByDocument();
            UserUpdateRequest userFakeRequest = fakeRepository.UserUpdateRequest();
            mapper.Setup(x => x.Map<User>(userFakeRequest)).Returns(userFake);
            unitofWork.Setup(x => x.UserRepository.GetByDocument(userFake.Document.Value)).Returns(Task.FromResult(userFake));
            unitofWork.Setup(x => x.UserRepository.Update(userFake));

            var result = await service.Update(userFake.Document.Value, userFakeRequest);

            Assert.True(result.Success);
            Assert.Equal(result.Erros?.Count, 0);
            output.WriteLine("Teste executado com sucesso");
        }

        [Fact]
        [Trait("Delete", "Not Found User")]
        public async Task Delete_Value_Invalid_not_found_user()
        {            
            User userFake = fakeRepository.GetByDocument();
            UserUpdateRequest userFakeRequest = fakeRepository.UserUpdateRequest();
            mapper.Setup(x => x.Map<User>(userFakeRequest)).Returns(userFake);
            unitofWork.Setup(x => x.UserRepository.GetByDocument(userFake.Document.Value)).Returns(Task.FromResult(fakeRepository.GetByDocumentNotFound(userFake.Document.Value)));
            unitofWork.Setup(x => x.UserRepository.Delete(userFake));

            var result = await service.Delete(userFake.Document.Value);

            Assert.False(result.Success);
            Assert.NotEqual(result.Erros?.Count, 0);
            PrintErrorMessages(result.Erros);
            output.WriteLine("Teste executado com sucesso");
        }

        [Fact]
        [Trait("Delete", "Success")]
        public async Task Delete_Value_Valid_SUCCESS()
        {            
            User userFake = fakeRepository.GetByDocument();
            UserUpdateRequest userFakeRequest = fakeRepository.UserUpdateRequest();
            mapper.Setup(x => x.Map<User>(userFakeRequest)).Returns(userFake);
            unitofWork.Setup(x => x.UserRepository.GetByDocument(userFake.Document.Value)).Returns(Task.FromResult(userFake));
            unitofWork.Setup(x => x.UserRepository.Delete(userFake));

            var result = await service.Delete(userFake.Document.Value);

            Assert.True(result.Success);
            Assert.Equal(result.Erros?.Count, 0);
            output.WriteLine("Teste executado com sucesso");
        }

        private void PrintErrorMessages(IReadOnlyList<string> erros)
        {
            output.WriteLine($"Mensagens de erro: ");
            foreach (var item in erros)
            {
                output.WriteLine(item);
            }
        }
    }
}
