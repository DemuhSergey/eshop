﻿using Common.Core.CQRS;
using Order.Application.DbContext;
using Order.Application.Exceptions;

namespace Order.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderHandler(IApplicationDbContext dbContext)
        : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await dbContext.Orders
                .FindAsync([request.OrderId], cancellationToken: cancellationToken);

            if (order is null)
            {
                throw new OrderNotFoundException(request.OrderId);
            }

            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new DeleteOrderResult(true);
        }
    }
}
