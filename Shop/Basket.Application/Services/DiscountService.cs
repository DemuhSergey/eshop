using Basket.Application.Abstractions;
using Basket.Application.Protos;

namespace Basket.Application.Services
{
    public class DiscountService : IDiscountService
    {
        public Task<CouponResponse> GetDiscount(string productName)
        {
            // TODO: Add grpc service for getting discount
            return Task.FromResult(new CouponResponse 
            { 
                Id = 1, 
                Amount = 0, 
                Description = string.Empty, 
                ProductName = productName
            });
        }
    }
}
