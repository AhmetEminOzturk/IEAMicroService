using AutoMapper;
using Dapper;
using IEAMicroService.Discount.Context;
using IEAMicroService.Discount.Dtos;
using IEAMicroService.Shared.Dtos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace IEAMicroService.Discount.Services
{
    public class DiscountCouponService : IDiscountCouponService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IDbConnection _dbConnection;
        private readonly DapperContext _dapperContext;

        public DiscountCouponService(IConfiguration configuration, IMapper mapper, DapperContext dapperContext)
        {
            _configuration = configuration;
            _mapper = mapper;
            _dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            _dapperContext = dapperContext;
        }

        public async Task<Response<NoContent>> CreateDiscountCoupon(CreateDiscountCouponDtos createDiscountCouponDtos)
        {
            var status = await _dbConnection.ExecuteAsync("Insert into DiscountCoupons (UserId,Rate,Code,CreatedDate) Values (@UserId,@Rate,@Code,@CreatedDate)",createDiscountCouponDtos);
            var paramaters = new DynamicParameters();
            paramaters.Add("@UserId", createDiscountCouponDtos.UserId);
            paramaters.Add("@Rate", createDiscountCouponDtos.Rate);
            paramaters.Add("@Code", createDiscountCouponDtos.Code);
            paramaters.Add("@CreatedDate", DateTime.Parse(createDiscountCouponDtos.CreatedDate.ToShortDateString()));

            if (status>0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail(500, "Bir Hata Oluştu");
        }

        public async Task<Response<NoContent>> DeleteDiscountCoupon(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from DiscountCoupons where DiscountCouponId=@DiscountCouponId", new { DiscountCouponId = id });
            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail(500, "Bir Hata Oluştu");
        }

        public async Task<Response<List<ResultDiscountCouponDtos>>> GetListAll()
        {
            var values = await _dbConnection.QueryAsync<ResultDiscountCouponDtos>("select * from DiscountCoupons");
            return Response<List<ResultDiscountCouponDtos>>.Success(_mapper.Map<List<ResultDiscountCouponDtos>>(values), 200);
        }

        public async Task<Response<NoContent>> UpdateDiscountCoupon(UpdateDiscountCouponDtos updateDiscountCouponDtos)
        {
            //var status = await _dbConnection.ExecuteAsync("update DiscountCoupons set UserId=@UserId,Rate=@RateId,Code=@Code,CreatedDate=@CreatedDate where DiscountId=@DiscountCouponId");
            string sql = ("update DiscountCoupons set UserId=@UserId,Rate=@Rate,Code=@Code,CreatedDate=@CreatedDate where DiscountCouponId=@DiscountCouponId");

            var paramaters = new DynamicParameters();
            paramaters.Add("@DiscountCouponId", updateDiscountCouponDtos.DiscountCouponId);
            paramaters.Add("@UserId", updateDiscountCouponDtos.UserId);
            paramaters.Add("@Rate", updateDiscountCouponDtos.Rate);
            paramaters.Add("@Code", updateDiscountCouponDtos.Code);
            paramaters.Add("@CreatedDate", DateTime.Parse(updateDiscountCouponDtos.CreatedDate.ToShortDateString()));

            await _dbConnection.ExecuteAsync(sql, paramaters);
            return Response<NoContent>.Success(200);
        }
    }
}
