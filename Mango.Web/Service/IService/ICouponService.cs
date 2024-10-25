using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto> GetCouponById(int couponId);
        Task<ResponseDto> GetAllCoupon();
        Task<ResponseDto> GetCouponByCode(string couponCode);
        Task<ResponseDto> CreateCoupon(CouponDto couponDto);
        Task<ResponseDto> UpdateCoupon(CouponDto couponDto);
        Task<ResponseDto> DeleteCoupon(int id);
    }
}
