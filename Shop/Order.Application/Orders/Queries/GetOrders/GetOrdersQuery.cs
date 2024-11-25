using Common.Core.CQRS;
using Common.Core.Pagination;
using Order.Application.DTO;

namespace Order.Application.Orders.Queries.GetOrders
{
    public record GetOrdersQuery(PaginationRequest PaginationRequest)
        : IQuery<GetOrdersResult>;

    public record GetOrdersResult(PaginatedResult<OrderDto> Orders);
}
