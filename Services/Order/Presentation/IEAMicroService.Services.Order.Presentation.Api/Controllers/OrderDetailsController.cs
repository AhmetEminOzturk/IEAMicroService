using IEAMicroService.Services.Order.Core.Application.Features.CQRS.Commands;
using IEAMicroService.Services.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IEAMicroService.Services.Order.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }
         
        [HttpGet]
        public async Task<IActionResult> GetOrderDetailList()
        {
            var value = await _mediator.Send(new GetAllOrderDetailQueryRequest());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommandRequest createOrderDetailCommandRequest)
        {
            await _mediator.Send(createOrderDetailCommandRequest);
            return Ok("Sipariş Detayları Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _mediator.Send(new RemoveOrderDetailCommandRequest(id));
            return Ok("Sipariş Detayları Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var value = await _mediator.Send(new GetOrderDetailQueryRequest(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommandRequest updateOrderDetailCommandRequest)
        {
            await _mediator.Send(updateOrderDetailCommandRequest);
            return Ok("Güncelleme Başarılı");
        }
    }
}
