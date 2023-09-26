using IEAMicroService.Discount.Dtos;
using IEAMicroService.Shared.Dtos;

namespace IEAMicroService.Discount.Services
{
    public interface IDiscountCouponService
    {
        Task<Response<List<ResultDiscountCouponDtos>>> GetListAll();
        Task<Response<NoContent>> CreateDiscountCoupon(CreateDiscountCouponDtos createDiscountCouponDtos);
        Task<Response<NoContent>> UpdateDiscountCoupon(UpdateDiscountCouponDtos updateDiscountCouponDtos);
        Task<Response<NoContent>> DeleteDiscountCoupon(int id);
    }
}
