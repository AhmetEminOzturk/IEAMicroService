﻿using AutoMapper;
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
    public class GetAllOrderingQueryHandler : IRequestHandler<GetAllOrderingQueryRequest, List<ResultOrderingDto>>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public GetAllOrderingQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultOrderingDto>> Handle(GetAllOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultOrderingDto>>(values);
        }
    }
}
