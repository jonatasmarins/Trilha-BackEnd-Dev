using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NivelBasico.Domain.Models;

namespace NivelBasico_Worker.Services.Interfaces
{
    public interface IScopedProcessingUserService
    {
        Task<IList<User>> DoWork(CancellationToken token);
    }
}