using IEAMicroService.DataAccessLayer.Abstract;
using IEAMicroService.DataAccessLayer.Context;
using IEAMicroService.DataAccessLayer.Repository;
using IEAMicroService.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEAMicroService.DataAccessLayer.EntityFramework
{
    public class EfCargoStateDal : GenericRepository<CargoState>, ICargoStateDal
    {
        private readonly CargoContext _context;
        public EfCargoStateDal(CargoContext context) : base(context)
        {
            _context = context;
        }
    }
}
