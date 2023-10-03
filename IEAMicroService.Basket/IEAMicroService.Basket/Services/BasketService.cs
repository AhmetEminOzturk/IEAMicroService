using IEAMicroService.Basket.Dtos;
using IEAMicroService.Shared.Dtos;
using System.Text.Json;

namespace IEAMicroService.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail(404, "Sepet bulunamadı");
        }

        public async Task<Response<ResultBasket>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existBasket)) 
            {
                return Response<ResultBasket>.Fail(404, "Sepet bulunamadı");
            }
            return Response<ResultBasket>.Success(JsonSerializer.Deserialize<ResultBasket>(existBasket),200);
        }

        public async Task<Response<bool>> SaveOrUpdate(ResultBasket resultBasket)
        {
            var status = await _redisService.GetDb().StringSetAsync(resultBasket.UserId, JsonSerializer.Serialize(resultBasket));
            return status ? Response<bool>.Success(204) : Response<bool>.Fail(500, "Sepette ekleme veya güncelleme yapıldı");
        }
    }
}

