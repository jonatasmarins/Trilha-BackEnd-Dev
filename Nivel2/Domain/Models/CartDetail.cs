using Nivel1.Domain.ExternalServices.Models;

namespace Nivel2.Domain.Models
{
    public class CartDetail
    {
        public CartDetail(Comic comic, int quantity)
        {
            Comic = comic;
            Quantity = quantity;
        }

        public Comic Comic { get; private set; }
        public int Quantity { get; private set; }

        public void SetQuantity(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}