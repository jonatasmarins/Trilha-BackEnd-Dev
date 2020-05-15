using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nivel1.Data.Context;
using Nivel1.Data.Repositories.Interfaces;
using Nivel1.Domain.ExternalServices.Models;

namespace Nivel1.Data.Repositories
{
    public class CreatorRepository : ICreatorRepository
    {
        private DataContext _dataContext;

        public CreatorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(Creator Creator)
        {
            if(!_dataContext.Creators.Any(x => x.Code == Creator.Code)) {
                await _dataContext.Creators.AddAsync(Creator);                
            }
        }

        public async Task<Creator> GetByCode(int Code)
        {
            return await _dataContext.Creators.Where(x => x.Code == Code).SingleOrDefaultAsync();
        }

        public async Task<int> GetIdByCode(int Code)
        {
            Creator creator = _dataContext.Creators.Where(x => x.Code == Code).SingleOrDefault();
            return await Task.FromResult(creator.CreatorID);
        }
    }
}