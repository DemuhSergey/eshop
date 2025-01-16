using Basket.Application.Commands.AddShoppingCart;
using Basket.Core.Entities;
using Carter;
using Mapster;
using MediatR;

namespace Basket.Api.Endpoints
{
    public record CreateBasketRequest(string UserName, List<ShoppingCartItem> Items);
    public record CreateBasketResponse(string UserName, decimal TotalPrice,List<ShoppingCartItem> Items);

    public class CreateBasket : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (CreateBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<AddShoppingCartCommand>();
                var basket = await sender.Send(command);
                var response = basket.Adapt<CreateBasketResponse>();
                return Results.Ok(response);
            })
            .WithName("CreateOrder")
            .Produces<CreateBasketResponse>(StatusCodes.Status201Created)
            .WithSummary("Create Basket")
            .WithDescription("Create Basket");
        }
    }
}
