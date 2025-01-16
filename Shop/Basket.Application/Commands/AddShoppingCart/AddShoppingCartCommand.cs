using Basket.Application.Responses;
using Basket.Core.Entities;
using Common.Core.CQRS;

namespace Basket.Application.Commands.AddShoppingCart
{
    public class AddShoppingCartCommand : ICommand<ShoppingCartResponse>
    {
        public AddShoppingCartCommand(string userName, IList<ShoppingCartItem> items) 
        {
            this.UserName = userName;
            this.CartItems = items;
        }

        public string UserName { get; }
        public IList<ShoppingCartItem> CartItems { get; }
    }
}
