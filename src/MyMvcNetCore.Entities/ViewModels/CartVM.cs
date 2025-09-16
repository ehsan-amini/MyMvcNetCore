namespace MyMvcNetCore.Entities.ViewModels
{
    public class CartVM
    {
        public IEnumerable<Cart> ShoppingCartList { get; set; }
        public Order OrderHeader { get; set; }
    }
}
