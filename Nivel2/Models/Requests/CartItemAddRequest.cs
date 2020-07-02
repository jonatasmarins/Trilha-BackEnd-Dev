namespace Nivel2.Models.Requests
{
    public class CartItemAddRequest
    {
        public int ComicID { get; set; }
        public int UserID { get; set; }
        public int Quantity { get; set; }
    }
}