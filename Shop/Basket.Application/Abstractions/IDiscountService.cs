using Basket.Application.Protos;

namespace Basket.Application.Abstractions
{
    public interface IDiscountService
    {
        Task<CouponResponse> GetDiscount(string productName);
    }
}