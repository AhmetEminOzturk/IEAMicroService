using IEAMicroService.BusinessLayer.Abstract;
using IEAMicroService.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IEAMicroService.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoStatesController : ControllerBase
    {
        private readonly ICargoStateService _cargoStateService;

        public CargoStatesController(ICargoStateService cargoStateService)
        {
            _cargoStateService = cargoStateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = await _cargoStateService.TGetAllAsync();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CargoState cargoState)
        {
            await _cargoStateService.TCreateAsync(cargoState);
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> Update(CargoState cargoState)
        {
            await _cargoStateService.TUpdateAsync(cargoState);
            return Ok("Güncelleme işlemi başarılı");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _cargoStateService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _cargoStateService.TGetByIdAsync(id);
            await _cargoStateService.TDeleteAsync(value);
            return Ok("Silme işlemi başarılı");
        }
    }
}
