﻿using Common.Core.CQRS;
using Order.Application.DbContext;
using Order.Application.DTO;
using Order.Domain.ValueObjects;

namespace Order.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = CreateNewOrder(request.Order);

            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateOrderResult(order.Id.Value);
        }

        private Domain.Models.Order CreateNewOrder(OrderDto orderDto)
        {
            var shippingAddress = Address.Of(orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName, orderDto.ShippingAddress.EmailAddress, orderDto.ShippingAddress.AddressLine, orderDto.ShippingAddress.Country, orderDto.ShippingAddress.State, orderDto.ShippingAddress.ZipCode);
            var billingAddress = Address.Of(orderDto.BillingAddress.FirstName, orderDto.BillingAddress.LastName, orderDto.BillingAddress.EmailAddress, orderDto.BillingAddress.AddressLine, orderDto.BillingAddress.Country, orderDto.BillingAddress.State, orderDto.BillingAddress.ZipCode);

            var newOrder = Domain.Models.Order.Create(
                    id: OrderId.Of(Guid.NewGuid()),
                    customerId: CustomerId.Of(orderDto.CustomerId),
                    orderName: orderDto.OrderName,
                    shippingAddress: shippingAddress,
                    billingAddress: billingAddress);

            foreach (var orderItemDto in orderDto.OrderItems)
            {
                newOrder.Add(ProductId.Of(orderItemDto.ProductId), orderItemDto.Quantity, orderItemDto.Price);
            }
            return newOrder!;
        }
    }
}
