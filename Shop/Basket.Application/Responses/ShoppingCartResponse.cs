using Basket.Core.Entities;

namespace Basket.Application.Responses
{
    public class ShoppingCartResponse
    {
        public ShoppingCartResponse(string userName, IList<ShoppingCartItem> items) 
        {
            this.UserName = userName;
            this.Items = items;
        }

        public string UserName { get; }

        public IList<ShoppingCartItem> Items { get; }

        public decimal TotalPrice 
        { 
            get => this.Items.Sum(x => x.Price * x.Quantity);
        }
    }
}
