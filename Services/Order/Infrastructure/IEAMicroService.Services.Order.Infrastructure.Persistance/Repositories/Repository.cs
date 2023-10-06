using IEAMicroService.Services.Order.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEAMicroService.Services.Order.Infrastructure.Persistance.Repositories
{
    public class Repository <T> where T : class
    {
        private readonly OrderContext _context;

        public Repository(OrderContext context)
        {
            _context = context;
        }
    }
}
