using IEAMicroService.WebUI.DiscountDtos;

namespace IEAMicroservice.WebUI.Services.Abstract
{
    public interface IDiscountCouponService
    {
        Task<ResultDiscountCouponDtos> GetAllCategories();
        Task<UpdateDiscountCouponDtos.Data> GetDiscountCouponsById(int id);
        Task CreateDiscountCoupons(CreateDiscountCouponDtos createDiscountCouponsDto);
        Task UpdateDiscountCoupons(UpdateDiscountCouponDtos.Data updateDiscountCouponsDto);
        Task DeleteDiscountCoupons(int id);
    }
}
