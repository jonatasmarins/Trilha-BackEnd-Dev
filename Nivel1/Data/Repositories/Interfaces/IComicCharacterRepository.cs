using System.Collections.Generic;
using System.Threading.Tasks;
using Nivel1.Domain.ExternalServices.Marvel.Models;

namespace Nivel1.Data.Repositories.Interfaces
{
    public interface IComicCharacterRepository
    {
        Task Add(IList<ComicCharacter> comicCharacters);
    }
}