using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> CreateCoupon(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.POST,
                Data = couponDto,
                Url = APIDetails.CouponBase + "/api/coupon/CreateANewCoupon/" 

            });
        }

        public async Task<ResponseDto> DeleteCouponByID(int couponId)
        {
            //var url = $"{APIDetails.CouponBase}/api/coupon/Delete/{id}";
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.DELETE, 
                //Data = couponDto,
                Url = $"{APIDetails.CouponBase}/api/coupon/DeleteCouponByID/{couponId}"

            });
        }

        public async Task<ResponseDto> GetAllCoupon()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.GET,
                Url = APIDetails.CouponBase + "/api/coupon/"

            }) ;
        }

        public async Task<ResponseDto> GetCouponByCode(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.GET,
                Url = $"{APIDetails.CouponBase}/api/coupon/GetCouponByCode/{couponCode}"

            });
        }

        public async Task<ResponseDto> GetCouponById(int couponId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.GET,
                Url = $"{APIDetails.CouponBase}/api/coupon/GetCouponById/{couponId}"

            });
        }

        public async Task<ResponseDto> UpdateCoupon(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.PUT,
                Data = couponDto,
                Url = APIDetails.CouponBase + "/api/coupon/UpdateCoupon/" 

            });
        }
        public async Task<ResponseDto> DeleteCouponByCode(int couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.DELETE,
                Url = $"{APIDetails.CouponBase}/api/coupon/DeleteCouponByCode/{couponCode}"

            });
        }
    }
}
