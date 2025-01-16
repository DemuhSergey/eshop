using Basket.Core.Entities;
using Common.Core.CQRS;

namespace Basket.Application.Queries.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
}
