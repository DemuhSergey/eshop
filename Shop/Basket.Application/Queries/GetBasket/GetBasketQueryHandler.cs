using Basket.Core.Repositories;
using Common.Core.CQRS;

namespace Basket.Application.Queries.GetBasket
{
    public class GetBasketQueryHandler(IBasketRepository repository)
        : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBasketAsync(query.UserName);

            return new GetBasketResult(basket);
        }
    }
}
