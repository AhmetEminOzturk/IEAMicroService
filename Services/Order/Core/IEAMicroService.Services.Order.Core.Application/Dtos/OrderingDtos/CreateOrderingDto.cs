using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEAMicroService.Services.Order.Core.Application.Dtos.OrderDtos
{
    public class CreateOrderingDto
    {
        
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        
    }
}
