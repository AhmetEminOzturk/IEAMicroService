using AutoMapper;
using IEAMicroService.Discount.Dtos;
using IEAMicroService.Discount.Models;

namespace IEAMicroService.Discount.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<DiscountCoupon,ResultDiscountCouponDtos>().ReverseMap();
            CreateMap<DiscountCoupon,CreateDiscountCouponDtos>().ReverseMap();
            CreateMap<DiscountCoupon,UpdateDiscountCouponDtos>().ReverseMap();
        }
    }
}
