using Basket.Application.Commands.DeleteBasket;
using Carter;
using Mapster;
using MediatR;

namespace Basket.Api.Endpoints
{
    public record DeleteBasketResponse(bool IsSuccess);

    public class DeleteBasket : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(userName));
                var response = result.Adapt<DeleteBasketResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteBascetByUserName")
            .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
            .WithSummary("Delete Basket")
            .WithDescription("Delete Basket");
        }
    }
}
