using System;
using System.Collections.Generic;
using System.Linq;
using NivelBasico.Domain.Enums;
using NivelBasico.Domain.Models;
using NivelBasico.Domain.Services.Interfaces;
using NivelBasico.Domain.ValuesObject;
using NivelBasico.Repositories;
using NivelBasico.Repositories.Interfaces;

namespace NivelBasico.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService()
        {
            _repository = new UserRepository();
        }

        public void Add(User user)
        {
            User userSearch = getUserBydocument(user.document.ToString());

            if (userSearch != null)
            {
                Console.WriteLine($"O usuário {user.GetName()} - {user.GetDocumentNumber()} já existe");
                return;
            }

            if (user.Validator.IsValid())
            {
                _repository.Add(user);
                Console.WriteLine($"O usuário {user.GetName() } adicionado com sucesso");
            }
            else
            {
                user.Validator.GetMessages();
            }
        }

        public void Update(string document)
        {
            int digit = 0;
            User user = getUserBydocument(document);

            if (user == null)
            {
                Console.WriteLine("Usuário não encontrado!");
                return;
            }

            var option = ShowMenuUpdate();
            if (int.TryParse(option.ToString(), out digit))
            {
                if (digit == Program.SAIR)
                {
                    return;
                }

                OptionSelected(digit, user);
                Update(document);
            }
            else
            {
                Console.WriteLine("Opção selecionada inválida");
                return;
            };
        }

        public void Delete(string document)
        {
            User user = getUserBydocument(document);

            if (user == null)
            {
                Console.WriteLine("Usuário não encontrado!");
            }
            else
            {
                _repository.Delete(document);
                Console.WriteLine("Usuário Removido com sucesso!");
            }
        }

        public User Get(string document)
        {
            User user = getUserBydocument(document);

            if (user != null)
            {
                Console.WriteLine(
                    string.Concat(
                        $"Usuário: {user.GetName()}, document: {user.GetDocumentNumber()}, ",
                        $"Idade: {user.GetYearsOld()}, Contato: {user.GetPhone()}, ",
                        $"Email: {user.GetEmail()}, Endereço: {user.GetAddress()} "
                    )
                );
            }
            else
            {
                Console.WriteLine("Usuário não encontrado!");
            }

            return user;
        }

        public IList<User> GetAll()
        {
            return _repository.GetAll();
        }

        private char ShowMenuUpdate()
        {
            Console.WriteLine("");
            Console.WriteLine("Deseja atualizar qual informação ?");
            Console.WriteLine("1 - Nome");
            Console.WriteLine("2 - Idade");
            Console.WriteLine("3 - Email");
            Console.WriteLine("4 - Telefone");
            Console.WriteLine("5 - Endereço");
            Console.WriteLine("9 - Voltar");
            Console.WriteLine("");

            var digit = Console.ReadKey().KeyChar;
            return digit;
        }

        private void OptionSelected(int digit, User user)
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o valor: ");
            Console.WriteLine("");
            var result = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine("Não houve nenhuma alteração, pois o valor digitado está nullo ou em branco");
                return;
            }

            switch (digit)
            {
                case (int)UserPropriety.Name:
                    user.SetName(new Name(result));
                    break;
                case (int)UserPropriety.YearsOld:
                    user.SetYearsOld(new YearsOld(result));
                    break;
                case (int)UserPropriety.Email:
                    user.SetEmail(new Email(result));
                    break;
                case (int)UserPropriety.Phone:
                    user.SetPhone(new Phone(result));
                    break;
                case (int)UserPropriety.Address:
                    user.SetAddress(result);
                    break;
                default:
                    break;
            }

            if (user.Validator != null && !user.Validator.IsValid())
            {
                user.Validator.GetMessages();
            }
            else
            {
                _repository.Update(user);
                Console.WriteLine("Usuário atualizado com sucesso"); ;
            }
        }

        private User getUserBydocument(string document)
        {
            User user = _repository.Get(document);

            return user;
        }
    }
}