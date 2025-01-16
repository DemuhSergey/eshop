using Basket.Core.Repositories;
using Common.Core.CQRS;

namespace Basket.Application.Commands.DeleteBasket
{
    public class DeleteBasketCommandHandler(IBasketRepository repository)
    : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteBasketAsync(request.UserName, cancellationToken);
            return new DeleteBasketResult(true);

        }
    }
}
