using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nivel1.Data.Context;
using Nivel1.Data.Repositories.Interfaces;
using Nivel1.Domain.ExternalServices.Marvel.Models;

namespace Nivel1.Data.Repositories
{
    public class ComicCreatorRepository : IComicCreatorRepository
    {
        private DataContext _dataContext;

        public ComicCreatorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(IList<ComicCreator> ComicCreator)
        {
            await _dataContext.ComicCreators.AddRangeAsync(ComicCreator);
        }
    }
}