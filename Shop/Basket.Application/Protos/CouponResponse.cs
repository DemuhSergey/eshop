namespace Basket.Application.Protos
{
    public class CouponResponse
    {
        public int Id { get; set; } = default!;
        public string ProductName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Amount { get; set; } = default!;
    }
}
