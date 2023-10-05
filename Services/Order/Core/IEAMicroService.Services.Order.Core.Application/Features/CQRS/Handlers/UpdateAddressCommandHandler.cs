using AutoMapper;
using IEAMicroService.Services.Order.Core.Application.Dtos.AddressDtos;
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
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, UpdateAddressDto>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateAddressDto> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Address
            {
                AddressId = request.AddressId,
                City = request.City,
                Detail = request.Detail,
                District = request.District,
                UserId = request.UserId,
            };
            await _repository.UpdateAsync(value);
            return _mapper.Map<UpdateAddressDto>(value);
        }
    }
}
