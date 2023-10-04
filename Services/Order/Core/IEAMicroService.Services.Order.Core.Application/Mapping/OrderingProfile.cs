using AutoMapper;
using IEAMicroService.Services.Order.Core.Application.Dtos.OrderDetailDtos;
using IEAMicroService.Services.Order.Core.Application.Dtos.OrderDtos;
using IEAMicroService.Services.Order.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEAMicroService.Services.Order.Core.Application.Mapping
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<ResultOrderingDto, Ordering>().ReverseMap();
            CreateMap<CreateOrderingDto, Ordering>().ReverseMap();
            CreateMap<UpdateOrderingDto, Ordering>().ReverseMap();
        }
    }
}
