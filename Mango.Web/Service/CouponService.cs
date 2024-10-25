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
                Url = APIDetails.CouponBase + "/api/coupon/CreateANewCoupon/" + couponDto

            });
        }

        public async Task<ResponseDto> DeleteCoupon(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.DELETE,
                Url = APIDetails.CouponBase + "/api/coupon/DeleteCoupon/" + id

            });
        }

        public async Task<ResponseDto> GetAllCoupon()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.GET,
                Url = APIDetails.CouponBase + "/api/coupon/GetCoupons"

            }) ;
        }

        public async Task<ResponseDto> GetCouponByCode(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.GET,
                Url = APIDetails.CouponBase + "/api/coupon/GetCouponByCode/" +couponCode

            });
        }

        public async Task<ResponseDto> GetCouponById(int couponId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.GET,
                Url = APIDetails.CouponBase + "/api/coupon/GetCouponById/" + couponId

            });
        }

        public async Task<ResponseDto> UpdateCoupon(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.PUT,
                Url = APIDetails.CouponBase + "/api/coupon/UpdateCoupon" + couponDto

            });
        }
    }
}
