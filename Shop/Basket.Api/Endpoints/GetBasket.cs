using Basket.Application.Queries.GetBasket;
using Basket.Core.Entities;
using Carter;
using Mapster;
using MediatR;

namespace Basket.Api.Endpoints
{
    public record GetBasketResponse(ShoppingCart Orders);

    public class GetBasket : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (string userName, ISender sender) => {
                var result = await sender.Send(new GetBasketQuery(userName));

                var response = result.Adapt<GetBasketResponse>();

                return Results.Ok(response);
            })
            .WithName("GetBasketByUserName")
            .Produces<GetBasketResponse>(StatusCodes.Status200OK)
            .WithSummary("Get Basket")
            .WithDescription("Get Basket");
        }
    }
}
