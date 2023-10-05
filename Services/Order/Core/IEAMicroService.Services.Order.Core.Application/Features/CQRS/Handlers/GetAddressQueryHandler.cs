using AutoMapper;
using IEAMicroService.Services.Order.Core.Application.Dtos.AddressDtos;
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
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQueryRequest, ResultAddressDto>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultAddressDto> Handle(GetAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ResultAddressDto>(value);
        }
    }
}
