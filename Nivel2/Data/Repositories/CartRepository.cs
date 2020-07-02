using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Nivel2.Data.Repositories.Interfaces;
using Nivel2.Data.UnitOfWork.Interfaces;
using Nivel2.Domain.Models;

namespace Nivel2.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Cart cart)
        {
            StringBuilder sql = new StringBuilder(@"
                INSERT INTO cart(ComicId, UserId, Quantity)
                VALUES(@ComicId, @UserId, @Quantity)
            ");

            foreach (var item in cart.Detail)
            {
                await _unitOfWork.Connection.ExecuteAsync(
                       sql.ToString(),
                       new
                       {
                           ComicId = item.Comic.ComicID,
                           UserId = cart.User.Id,
                           Quantity = item.Quantity
                       }
                   );
            }
        }

        public async Task<IList<Cart>> Get()
        {
            string sql = "SELECT * FROM Cart";
            return (IList<Cart>)await _unitOfWork.Connection.QueryAsync<Cart>(sql, null, _unitOfWork.Transaction);
        }

        public async Task RemoveItem(int ComicId, int UserId)
        {
            string sql = "delete Cart where ComicId = @ComicId and UserId = @UserID";
            await _unitOfWork.Connection.ExecuteAsync(
                sql,
                new
                {
                    ComicId,
                    UserId
                },
                _unitOfWork.Transaction
            );
        }
    }
}