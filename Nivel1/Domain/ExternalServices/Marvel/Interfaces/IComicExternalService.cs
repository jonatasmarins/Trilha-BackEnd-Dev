using System.Collections.Generic;
using System.Threading.Tasks;
using Nivel1.Domain.ExternalServices.Models;
using Nivel1.Shared.Models.Interfaces;

namespace Nivel1.Domain.ExternalServices.Marvel.Interfaces
{
    public interface IComicExternalService
    {
        IResultResponse<IList<Comic>> Get();
    }
}