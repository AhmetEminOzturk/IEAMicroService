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
    public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        private readonly CargoContext _context;
        public EfCargoDetailDal(CargoContext context) : base(context)
        {
            _context = context;
        }

        public int TotalCargoCount()
        {
            return _context.CargoDetails.Count();
        }
    }
}
