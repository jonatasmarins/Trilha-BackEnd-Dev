using System;
using System.Linq;
using NivelBasico.Domain.Enums;
using NivelBasico.Domain.Models;
using NivelBasico.Domain.Services.Interfaces;
using NivelBasico.Domain.ValuesObject;

namespace NivelBasico.Domain.Services
{
    public class UserService : IUserService
    {
        public void Add(User user)
        {
            if (user.Validator == null)
            {
                Program.users.Add(user);
                Console.WriteLine($"O Cliente {user.GetName() } adicionado com sucesso");
            }
            else
            {
                user.Validator.GetMessages();
            }
        }

        public void Update(string cpf)
        {
            int digit = 0;

            User user = getUserByCPF(cpf);

            if (user == null)
            {
                Console.WriteLine("Usuário não encontrado!");
                return;
            }

            var option = ShowMenuUpdate();
            if (int.TryParse(option.ToString(), out digit))
            {
                if (digit == 9)
                {
                    return;
                }

                OptionSelected(digit, user);
                Update(cpf);
            }
            else
            {
                Console.WriteLine("Opção selecionada inválida");
                return;
            };
        }

        public void Delete(string cpf)
        {
            User user = getUserByCPF(cpf);

            if (user == null)
            {
                Console.WriteLine("Usuário não encontrado!");
            }
            else
            {
                Program.users.Remove(user);
                Console.WriteLine("Usuário Removido com sucesso!");
            }
        }

        public void Get(string cpf)
        {
            var user = getUserByCPF(cpf);
            Console.WriteLine(
                string.Concat(
                    $"Usuário: {user.GetName()}, CPF: {user.GetDocumentNumber()}, ",
                    $"Idade: {user.GetYearsOld()}, Contato: {user.GetPhone()}, ",
                    $"Email: {user.GetEmail()}, Endereço: {user.GetAddress()} "
                )
            );
        }

        public void GetAll()
        {
            Console.WriteLine($"Existem {Program.users?.Count} usuário(s) cadastrado(s)");
            foreach (var item in Program.users)
            {
                Console.WriteLine(
                    string.Concat(
                        $"Usuário: {item.GetName()}, CPF: {item.GetDocumentNumber()}, ",
                        $"Idade: {item.GetYearsOld()}, Contato: {item.GetPhone()}, ",
                        $"Email: {item.GetEmail()}, Endereço: {item.GetAddress()} "
                    )
                );
            }
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
                    if(!SetName(result, user)) 
                        return;
                    break;
                case (int)UserPropriety.YearsOld:
                    if(!SetYearsOld(result, user))
                        return;
                    break;
                case (int)UserPropriety.Email:
                    if(!SetEmail(result, user))
                        return;
                    break;
                case (int)UserPropriety.Phone:
                    if(!SetPhone(result, user))
                        return;
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
                Console.WriteLine("Usuário atualizado com sucesso"); ;
            }
        }

        private User getUserByCPF(string cpf)
        {
            User user = Program.users.Where(
               x => x.document.ToString() == cpf
           ).FirstOrDefault();

            return user;
        }

        private bool SetPhone(string phoneNumber, User user)
        {
            bool result = true;
            Phone phone = new Phone(phoneNumber);
            if (phone.Validator.IsValid())
            {
                user.SetPhone(phone);
            }
            else
            {
                phone.Validator.GetMessages();
                result = false;
            }

            return result;
        }

        private bool SetEmail(string address, User user)
        {
            bool result = true;
            Email email = new Email(address);
            if (email.Validator.IsValid())
            {
                user.SetEmail(email);
            }
            else
            {
                email.Validator.GetMessages();
                result = false;
            }

            return result;
        }

        private bool SetYearsOld(string yearsOld, User user)
        {
            bool result = true;
            YearsOld years = new YearsOld(yearsOld);
            if (years.Validator.IsValid())
            {
                user.SetYearsOld(years);
            }
            else
            {
                years.Validator.GetMessages();
                result = false;
            }

            return result;
        }

        private bool SetName(string value, User user)
        {
            bool result = true;
            Name name = new Name(value);
            if (name.Validator.IsValid())
            {
                user.SetName(name);
            }
            else
            {
                name.Validator.GetMessages();
                result = false;
            }

            return result;
        }
    }
}