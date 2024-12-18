using AutoMapper;
using Azure;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ResponseDto _responseDto;
        private IMapper _mapper;
        public CouponAPIController(AppDbContext appDbContext, IMapper mapper)
        {
          _appDbContext = appDbContext;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }
        [HttpGet]
        public object GetCoupons()
        {
            try
            {
                IEnumerable<Coupon> couponList = _appDbContext.Coupons.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(couponList);
               // return couponList;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                //throw new Exception("Connection failed with Coupon DB");

            }
            return _responseDto;
        }
        [HttpGet]
        [Route("GetCouponById/{couponId:int}")]
        public ResponseDto GetCoupon(int couponId)
        {
            try
            {
                Coupon? coupon = _appDbContext.Coupons.FirstOrDefault(c => c.CouponId == couponId);
                _responseDto.Result=_mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                //throw new Exception("Connection failed with Coupon DB");

            }
            return _responseDto;
        }
        [HttpGet]
        [Route("GetCouponByCode/{couponId:int}")]
        public ResponseDto GetCouponByCode(string code)
        {
            try
            {
                Coupon? coupon = _appDbContext.Coupons.FirstOrDefault(c => c.CouponCode.ToLower() == code.ToLower());
                if(coupon == null)
                {
                    _responseDto.IsSuccess=false;
                }
                _responseDto.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                //throw new Exception("Connection failed with Coupon DB");

            }
            return _responseDto;
        }
        [HttpPost]
        [Route("CreateANewCoupon")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] CouponDto coupondto)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(coupondto);
                _appDbContext.Add(coupon);
                _appDbContext.SaveChanges();
                _responseDto.Result = coupondto;
                _responseDto.Message = "Successfully Added the Coupon";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                //throw new Exception("Connection failed with Coupon DB");

            }
            return _responseDto;
        }
        [HttpPut]
        [Route("UpdateCoupon")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] CouponDto coupondto)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(coupondto);
                _appDbContext.Update(coupon);
                _appDbContext.SaveChanges();
                _responseDto.Result = coupondto;
                _responseDto.Message = "Successfully Updated the Coupon";
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                //throw new Exception("Connection failed with Coupon DB");

            }
            return _responseDto;
        }
        [HttpDelete]
        [Route("DeleteCouponByID/{id}")]
        //[Authorize(Roles ="ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon? coupon = _appDbContext.Coupons.Where(c=>c.CouponId == id).FirstOrDefault();
                if(coupon != null)
                {
                    _appDbContext.Coupons.Remove(coupon);
                    _responseDto.Result = coupon;
                    _responseDto.Message = "Deleted";
                }
                else
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "No coupon found";
                }
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                //throw new Exception("Connection failed with Coupon DB");

            }
            return _responseDto;
        }
        [HttpDelete]
        [Route("DeleteCouponByCode/{couponCode}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto DeleteCouponByCode(string couponCode)
        {
            try
            {
                Coupon? coupon = _appDbContext.Coupons.Where(c => c.CouponCode == couponCode).FirstOrDefault();
                if (coupon != null)
                {
                    _appDbContext.Coupons.Remove(coupon);
                    _responseDto.Result = coupon;
                    _responseDto.Message = "Deleted";
                }
                else
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "No coupon found";
                }
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
                //throw new Exception("Connection failed with Coupon DB");

            }
            return _responseDto;
        }

    }
}
