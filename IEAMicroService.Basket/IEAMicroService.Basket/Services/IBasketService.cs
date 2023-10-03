using IEAMicroService.Basket.Dtos;
using IEAMicroService.Shared.Dtos;

namespace IEAMicroService.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<ResultBasket>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(ResultBasket resultBasket);
        Task<Response<bool>> Delete(string userId);
    }
}
