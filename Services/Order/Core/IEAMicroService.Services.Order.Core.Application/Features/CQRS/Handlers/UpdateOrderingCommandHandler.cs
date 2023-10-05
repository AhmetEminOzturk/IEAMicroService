using AutoMapper;
using IEAMicroService.Services.Order.Core.Application.Dtos.OrderDtos;
using IEAMicroService.Services.Order.Core.Application.Features.CQRS.Commands;
using IEAMicroService.Services.Order.Core.Application.Interfaces;
using IEAMicroService.Services.Order.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEAMicroService.Services.Order.Core.Application.Features.CQRS.Handlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommandRequest, UpdateOrderingDto>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateOrderingDto> Handle(UpdateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            var values = new Ordering
            {
                OrderDate = request.OrderDate,
                OrderingId = request.OrderingId,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId
            };
            await _repository.UpdateAsync(values);
            return _mapper.Map<UpdateOrderingDto>(values);
        }
    }
}
