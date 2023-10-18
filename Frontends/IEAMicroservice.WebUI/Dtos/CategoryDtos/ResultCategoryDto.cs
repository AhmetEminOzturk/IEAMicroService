using static IEAMicroService.WebUI.DiscountDtos.ResultDiscountCouponDtos;

namespace IEAMicroService.WebUI.Dtos.CategoryDto
{
    public class ResultCategoryDto
    {
        public Data[] data { get; set; }
        public class Data
        {
            public string CategoryId { get; set; }
            public string CategoryName { get; set; }
        }
    }
}
