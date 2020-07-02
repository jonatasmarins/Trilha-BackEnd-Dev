using System;
using System.Collections.Generic;
using NivelBasico.Domain.Models;
using NivelBasico.Domain.Services;
using NivelBasico.Domain.Services.Interfaces;
using NivelBasico.Domain.ValuesObject;

namespace NivelBasico
{
    static class Program
    {
        public const int SAIR = 9;

        static void Main()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Bem-Vindo a plataforma de cadastro de cliente - Trilha Dev");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("Pressione o número para realizar as operações desejas: ");
            Console.WriteLine("");
            Console.WriteLine("1 - Visualizar Todos");
            Console.WriteLine("2 - Visualizar Usuário Por CPF");
            Console.WriteLine("3 - Adicionar");
            Console.WriteLine("4 - Atualizar");
            Console.WriteLine("5 - Remover");
            Console.WriteLine("");

            var opcao = Console.ReadKey();
            Console.WriteLine("");

            switch (opcao.KeyChar)
            {
                case '1':
                    GetAllUser();
                    break;
                case '2':
                    GetAUserByDocument();
                    break;
                case '3':
                    AddUser();
                    break;
                case '4':
                    UpdateUser();
                    break;
                case '5':
                    DeleteUser();
                    break;
                default:
                    Environment.Exit(0);
                    break;

            }

            Console.WriteLine("");
            Main();
        }

        static void GetAllUser()
        {
            IUserService service = new UserService();
            IList<User> users = service.GetAll();

            Console.WriteLine($"Existem {users?.Count} usuário(s) cadastrado(s)");
            foreach (var item in users)
            {
                Console.WriteLine(
                    string.Concat(
                        $"Usuário: {item.GetName()}, document: {item.GetDocumentNumber()}, ",
                        $"Idade: {item.GetYearsOld()}, Contato: {item.GetPhone()}, ",
                        $"Email: {item.GetEmail()}, Endereço: {item.GetAddress()} "
                    )
                );
            }
        }

        static void GetAUserByDocument()
        {
            IUserService service = new UserService();
            Console.WriteLine("Entre com o númerdo do cpf: ");
            string document = Console.ReadLine();

            if (isDocumentNotNull(document))
                service.Get(document);
        }

        static void AddUser()
        {
            IUserService service = new UserService();
            IList<User> users = service.GetAll();

            User user = new User(
               new Name("Jonatas Marins"),
               new YearsOld("27"),
               new Cpf("41800055588"),
               new Email("jonatas@gmail.com"),
               new Phone("19996969696"),
               "Rua das orquideas, 121 - Indaiatuba/SP"
           );

            service.Add(user);

            User user2 = new User(
                new Name("Marcos Alonso"),
                new YearsOld("27"),
                new Cpf("41841841888"),
                new Email("marcos@gmail.com"),
                new Phone("19669696666"),
                "Rua da rosaria, 121 - São Paulo/SP"
            );

            service.Add(user2);

            User user3 = new User(
                new Name("Carlos Feitosa"),
                new YearsOld("35"),
                new Cpf("44184145888"),
                new Email("carlos@gmail.com"),
                new Phone("19669776666"),
                "Rua da rosaria, 121 - São Paulo/SP"
            );

            service.Add(user3);

            User user4 = new User(
                new Name("Felipe Artur"),
                new YearsOld("25"),
                new Cpf("41841841778"),
                new Email("felipe@gmail.com"),
                new Phone("19665896668"),
                "Rua da dinamarca, 121 - São Paulo/SP"
            );

            service.Add(user4);

            User user5 = new User(
                new Name("Marcos Luiz"),
                new YearsOld("17"),
                new Cpf("41841841887"),
                new Email("luiz@gmail.com"),
                new Phone("19669696655"),
                "Rua da jamaica, 121 - São Paulo/SP"
            );

            service.Add(user5);
        }

        static void UpdateUser()
        {
            IUserService service = new UserService();

            Console.WriteLine("Entre com o númerdo do cpf: ");
            string document = Console.ReadLine();

            if (isDocumentNotNull(document))
                service.Update(document);
        }

        static void DeleteUser()
        {
            IUserService service = new UserService();

            Console.WriteLine("Entre com o númerdo do cpf: ");
            string document = Console.ReadLine();

            if (isDocumentNotNull(document))
                service.Delete(document);
        }

        static bool isDocumentNotNull(string document)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(document))
            {
                Console.WriteLine("É necessário entrar com o número do documento");
                isValid = false;
            }

            return isValid;
        }
    }
}
