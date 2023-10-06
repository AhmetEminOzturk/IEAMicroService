using IEAMicroService.Services.Order.Core.Application.Features.CQRS.Commands;
using IEAMicroService.Services.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IEAMicroService.Services.Order.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderingList()
        {
            var value = await _mediator.Send(new GetAllOrderingQueryRequest());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommandRequest createOrderingCommandRequest)
        {
            await _mediator.Send(createOrderingCommandRequest);
            return Ok("Sipariş Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommandRequest(id));
            return Ok("Sipariş Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var value = await _mediator.Send(new GetOrderingQueryRequest(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommandRequest updateOrderingCommandRequest)
        {
            await _mediator.Send(updateOrderingCommandRequest);
            return Ok("Güncelleme Başarılı");
        }
    }
}
