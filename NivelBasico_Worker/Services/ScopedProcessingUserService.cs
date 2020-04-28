using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NivelBasico.Domain.Models;
using NivelBasico.Domain.Services.Interfaces;
using NivelBasico_Worker.Services.Interfaces;

namespace NivelBasico_Worker.Services
{
    public class ScopedProcessingUserService : IScopedProcessingUserService
    {
        private IUserService _service { get; set; }
        private ILogger<ScopedProcessingUserService> _logger{get;set;}
        private string PATH = string.Concat(Directory.GetCurrentDirectory(), "\\Relatorio\\");
        private const string FILE_NAME = "UserList.txt";

        public ScopedProcessingUserService(IUserService service, ILogger<ScopedProcessingUserService> logger)
        {
            _service = service;
            _logger = logger;
        }
        public async Task<IList<User>> DoWork(CancellationToken token)
        {
            _logger.LogInformation("Consultando os usuários cadastrados no banco de dados..");
            
            var users = await _service.GetAllAsync();

            _logger.LogInformation("Gerando arquivo de texto..");
            
            await CreateFile(users);
            
            _logger.LogInformation("Arquivo gerado com sucesso :)");
            return users;
        }

        public async Task CreateFile(IList<User> users)
        {
            StringBuilder builder = new StringBuilder();    
            CreateFile();    

            if(users != null && users?.Count > 0) {
                builder.Append($"Existe {users.Count} usuário(s) cadastrado(s)");
            } else 
                builder.AppendLine("Não existe nenhum usuário cadastrado");

            builder.AppendLine("");
            builder.AppendLine("");

            using (StreamWriter sw = File.CreateText(GetFileNameFull()))
            {
                foreach (var item in users)
                {
                    builder.AppendLine($@"Nome: {item.GetName()}");
                    builder.AppendLine($@"CPF: {item.GetDocumentNumber()}");
                    builder.AppendLine($@"Idade: {item.GetYearsOld()}");
                    builder.AppendLine($@"Email: {item.GetEmail()}");
                    builder.AppendLine($@"Contato: {item.GetPhone()}");
                    builder.AppendLine($@"Endereço: {item.GetAddress()}");
                    builder.AppendLine("");
                }

                await sw.WriteLineAsync(builder);
            }
        }

        private string GetFileNameFull()
        {
            return string.Concat(PATH, FILE_NAME);
        }

        private void CreateFile() {
            if (!Directory.Exists(PATH))
                Directory.CreateDirectory(PATH);

            if (File.Exists(GetFileNameFull()))
                File.Delete(GetFileNameFull());
        }
    }
}