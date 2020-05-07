using Nivel1.Domain.Models;
using Nivel1.Domain.ValueObject;
using Nivel1.Models;

namespace Nivel1_Test.FakeRepository
{
    public class UserFakeRepository
    {
        public UserFakeRepository()
        {
        }

        public User GetByDocument(
            string document = "41841841888",
            string name = "Jonatas Marins Leite",
            int yearsOld = 27,
            string email = "jonatas@gmail.com",
            string phone = "19996969696"
        )
        {
            User user = new User(
                new Name(name),
                new YearsOld(yearsOld),
                new Cpf(document),
                new Email(email),
                new Phone(phone),
                "Rua candelaria, 525"
            );

            return user;
        }

        public User GetByDocumentNotFound(string document)
        {
            User user = null;
            return user;
        }

        public User CreateUserInvalidName(string name)
        {
            User user = new User(
                new Name(name),
                new YearsOld(27),
                new Cpf("41841841888"),
                new Email("jonatas@gmail.com"),
                new Phone("19996969696"),
                "Rua candelaria, 525"
            );

            return user;
        }

        public UserCreateRequest UserCreateRequest(
            string document = "41841841888", 
            string name = "Jonatas Marins Leite",
            int yearsOld = 27,
            string email = "jonatas@gmail.com",
            string phone = "19996969696"
        )
        {
            UserCreateRequest user = new UserCreateRequest();
            user.Document = document;
            user.Name = name;
            user.YearsOld = yearsOld;
            user.Email = email;
            user.Phone = phone;
            return user;
        }

        public UserUpdateRequest UserUpdateRequest(            
            string name = "Jonatas Marins Leite",
            int yearsOld = 27,
            string email = "jonatas@gmail.com",
            string phone = "19996969696"
        )
        {
            UserUpdateRequest user = new UserUpdateRequest();
            user.Name = name;
            user.YearsOld = yearsOld;
            user.Email = email;
            user.Phone = phone;
            return user;
        }
    }
}