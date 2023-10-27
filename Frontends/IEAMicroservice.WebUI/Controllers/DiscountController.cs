using IEAMicroservice.WebUI.Services.Abstract;
using IEAMicroService.Shared.Dtos;
using IEAMicroService.WebUI.DiscountDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace IEAMicroservice.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDiscountCouponService _discountCouponService;

        public DiscountController(IHttpClientFactory httpClientFactory, IDiscountCouponService discountCouponService)
        {
            _httpClientFactory = httpClientFactory;
            _discountCouponService = discountCouponService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _discountCouponService.GetAllCategories();
            return View(values.data.ToList());
        }

        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCouponDtos createDiscountCouponDtos)
        {
            await _discountCouponService.CreateDiscountCoupons(createDiscountCouponDtos);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _discountCouponService.DeleteDiscountCoupons(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var values = await _discountCouponService.GetDiscountCouponsById(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountCouponDtos.Data updateDiscountCouponDtos)
        {
           await _discountCouponService.UpdateDiscountCoupons(updateDiscountCouponDtos);
            return RedirectToAction("Index");
        }

    }
}
