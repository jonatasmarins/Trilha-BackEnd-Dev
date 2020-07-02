using System.Linq;
using System.Threading.Tasks;
using Nivel1.Data.Context;
using Nivel1.Data.Repositories.Interfaces;
using Nivel1.Domain.ExternalServices.Models;

namespace Nivel1.Data.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        protected readonly DataContext _dataContext;
        public CharacterRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(Character character)
        {
            if(!_dataContext.Characters.Any(x => x.Code == character.Code)) {
                await _dataContext.Characters.AddAsync(character);
            }
        }

        public async Task<Character> GetByCode(int Code)
        {
            return await Task.FromResult(_dataContext.Characters.Where(x => x.Code == Code).FirstOrDefault());
        }

        public async Task<int> GetIdByCode(int Code)
        {
            Character character = _dataContext.Characters.Where(x => x.Code == Code).SingleOrDefault();
            return await Task.FromResult(character.CharacterID);
        }
    }
}