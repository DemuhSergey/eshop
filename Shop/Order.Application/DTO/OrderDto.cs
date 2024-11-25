using Order.Domain.Enums;

namespace Order.Application.DTO
{
    public record OrderDto(
        Guid Id,
        Guid CustomerId,
        string OrderName,
        AddressDto ShippingAddress,
        AddressDto BillingAddress,
        OrderStatus Status,
        List<OrderItemDto> OrderItems);

    public record OrderItemDto(Guid OrderId, Guid ProductId, int Quantity, decimal Price);

    public record AddressDto(string FirstName, string LastName, string EmailAddress, string AddressLine, string Country, string State, string ZipCode);
}

