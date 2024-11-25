using Common.Core.CQRS;
using Order.Application.DTO;

namespace Order.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(OrderDto Order)
    : ICommand<CreateOrderResult>;

    public record CreateOrderResult(Guid Id);
}
