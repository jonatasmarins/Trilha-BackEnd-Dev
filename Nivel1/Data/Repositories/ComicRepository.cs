using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nivel1.Data.Context;
using Nivel1.Data.Repositories.Interfaces;
using Nivel1.Domain.ExternalServices.Models;

namespace Nivel1.Data.Repositories
{
    public class ComicRepository : IComicRepository
    {
        protected readonly DataContext _dataContext;
        public ComicRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(Comic Comic)
        {
            if(!_dataContext.Comics.Any(x => x.Code == Comic.Code)) {
                await _dataContext.Comics.AddAsync(Comic);                
            }
        }

        public async Task<IList<Comic>> Get()
        {
            return await _dataContext.Comics.AsNoTracking().ToListAsync();
        }

        public async Task<Comic> GetByCode(int ComicID)
        {
            return await _dataContext.Comics.Where(x => x.Code == ComicID).FirstOrDefaultAsync();
        }
    }
}