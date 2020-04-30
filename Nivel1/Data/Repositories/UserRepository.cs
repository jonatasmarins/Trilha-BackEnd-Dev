using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nivel1.Data.Context;
using Nivel1.Data.Repositories.Interfaces;
using Nivel1.Domain.Models;
using Nivel1.Domain.ValueObject;

namespace Nivel1.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Create(User user)
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _dataContext.Users.Remove(user);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IList<User>> Get()
        {
            return await _dataContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByDocument(string document)
        {
            return await _dataContext.Users.AsNoTracking().Where(x => x.Document.Value == document).SingleOrDefaultAsync();
        }

        public async Task Update(User user)
        {
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
        }
    }
}