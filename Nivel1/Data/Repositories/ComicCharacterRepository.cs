using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nivel1.Data.Context;
using Nivel1.Data.Repositories.Interfaces;
using Nivel1.Domain.ExternalServices.Marvel.Models;

namespace Nivel1.Data.Repositories
{
    public class ComicCharacterRepository : IComicCharacterRepository
    {
        private DataContext _dataContext;

        public ComicCharacterRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(IList<ComicCharacter> comicCharacters)
        {
            await _dataContext.ComicCharacters.AddRangeAsync(comicCharacters);
        }
    }
}