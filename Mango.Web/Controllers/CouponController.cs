using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> list = new List<CouponDto>();

            ResponseDto responseDto = await _couponService.GetAllCoupon();
            if(responseDto != null && responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto.Message.ToString();
            }

            return View(list);
        }
        public async Task<IActionResult> CreateCoupon()
        {

            return View("CreateCoupon");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto responseDto = await _couponService.CreateCoupon(couponDto);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = " created the Coupon Successfully";
                    return RedirectToAction(nameof(CouponIndex));
                    
                }
                else
                {
                    TempData["error"] = "Not Found";
                }
            }

            return View(couponDto);
        }

        //this is for rendering to delete coupon view
        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> DeleteCouponByID(int id)
        {
            

            ResponseDto responseDto = await _couponService.GetCouponById(id);
            if (responseDto != null && responseDto.IsSuccess)
            {
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responseDto.Result));
                TempData["success"] = "Deleted the Coupon Successfully";
                return View(model);
            }
            else
            {
                TempData["error"] = "Not Found";
            }
            return View();
        }
        //this is for actual deletion from backend
        [HttpPost]
        
        public async Task<IActionResult> DeleteCouponBy([FromForm] CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto responseDto=  await _couponService.DeleteCouponByID(couponDto.CouponId);
                if(responseDto != null && responseDto.IsSuccess)
                {
                    return RedirectToAction(nameof(CouponIndex));
                }


            }
            return View();
           

        }
    }
}
