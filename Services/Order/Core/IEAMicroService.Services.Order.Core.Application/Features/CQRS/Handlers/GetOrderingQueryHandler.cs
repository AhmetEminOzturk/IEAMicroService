using AutoMapper;
using IEAMicroService.Services.Order.Core.Application.Dtos.OrderDtos;
using IEAMicroService.Services.Order.Core.Application.Features.CQRS.Queries;
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
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQueryRequest, ResultOrderingDto>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public GetOrderingQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultOrderingDto> Handle(GetOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ResultOrderingDto>(value);
        }
    }
}
