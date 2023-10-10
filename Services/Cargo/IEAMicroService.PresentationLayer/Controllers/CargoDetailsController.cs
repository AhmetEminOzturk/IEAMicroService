using IEAMicroService.BusinessLayer.Abstract;
using IEAMicroService.DataAccessLayer.Abstract;
using IEAMicroService.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IEAMicroService.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var value = await _cargoDetailService.TGetAllAsync();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CargoDetail cargoDetail)
        {
            await _cargoDetailService.TCreateAsync(cargoDetail);
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> Update(CargoDetail cargoDetail)
        {
            await _cargoDetailService.TUpdateAsync(cargoDetail);
            return Ok("Güncelleme işlemi başarılı");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _cargoDetailService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _cargoDetailService.TGetByIdAsync(id);
            await _cargoDetailService.TDeleteAsync(value);
            return Ok("Silme işlemi başarılı");
        }
    }
}
