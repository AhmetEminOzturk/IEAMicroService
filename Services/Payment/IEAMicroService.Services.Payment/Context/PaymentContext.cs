using IEAMicroService.Services.Payment.DAL;
using Microsoft.EntityFrameworkCore;

namespace IEAMicroService.Services.Payment.Context
{
    public class PaymentContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=IEAMicroServicePaymentDb;user=sa;password=123456aA*");
        }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
