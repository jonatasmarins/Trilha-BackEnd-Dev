using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nivel1.Domain.Models;

namespace Nivel2.Domain.Models
{
    public class Cart
    {
        public Cart(User user, IList<CartDetail> detail)
        {
            User = user;
            Detail = detail;
        }

        public int CartID { get; set; }
        public User User { get; private set; }
        public IList<CartDetail> Detail { get; private set; }
    }
}