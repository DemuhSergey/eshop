using Basket.Application.Abstractions;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using Common.Core.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commands.AddShoppingCart
{
    public class AddShoppingCartCommandHandler(IBasketRepository basketRepository, IDiscountService discountService) 
        : ICommandHandler<AddShoppingCartCommand, ShoppingCartResponse>
    {
        public async Task<ShoppingCartResponse> Handle(AddShoppingCartCommand request, CancellationToken cancellationToken)
        {
            await this.SetDiscount(request.CartItems);

            var cart = await basketRepository.StoreBasketAsync(new ShoppingCart()
            {
                UserName = request.UserName,
                Items = request.CartItems.ToList()
            });

            return new ShoppingCartResponse(request.UserName, request.CartItems);
        }

        private async Task SetDiscount(IEnumerable<ShoppingCartItem> items)
        {
            foreach (var item in items)
            {
                var coupon = await discountService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }
        }
    }
}
