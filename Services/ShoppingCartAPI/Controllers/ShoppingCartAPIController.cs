using AutoMapper;
using Mango.Services.ShoppingCartAPI.Data;
using Mango.Services.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace Mango.Services.ShoppingCartAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartAPIController : ControllerBase
    {
        private readonly ResponseDto _responseDto;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public ShoppingCartAPIController(IMapper mapper, AppDbContext appDbContext)
        {
            _responseDto = new ResponseDto();
            _mapper = mapper;
            _appDbContext = appDbContext;
        }
        //load cart details for specific user
        [HttpGet("GetCart/{userId}")]
        public async Task<ResponseDto> GetCart(string userId)
        {
            try
            {
                CartDto cartDto = new()
                {
                    CartHeader = _mapper.Map<CartHeaderDto>(_appDbContext.CartHeaders.First(u => u.UserId == userId))


                };
                cartDto.CartDetails =_mapper.Map<IEnumerable<CartDetailsDto>> 
                    (_appDbContext.CartDetails.Where(u => u.CartHeaderId == cartDto.CartHeader.CartHeaderId));
                foreach(var item in cartDto.CartDetails)
                {
                    cartDto.CartHeader.CartTotal += (item.Count * item.Product.Price)
                }
                _responseDto.Result = cartDto;
            }
            catch(Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
        //user adds first item to the cart
        // 1. Create Cart Header
        // 2. Create Cart Details
        //User adds a new item in an existing Shopping Cart:
        // 1. Find Cart header
        // 2. Add cart details under same cart header Id
        //User updates quantity of an existing item in the cart
        // 1. Find Details
        // 2. Update count in cart details
        [HttpPost("CartUpsert")]
        public async Task<ResponseDto> Upsert( CartDto cartDto)
        {
            try
            {
                var cartHeaderFromDb = await _appDbContext.CartHeaders.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == cartDto.CartHeader.UserId);
                if(cartHeaderFromDb == null)
                {
                    //add new cart
                    CartHeader cartHeader = _mapper.Map<CartHeader>(cartDto.CartHeader);
                    _appDbContext.CartHeaders.Add(cartHeader);
                    await _appDbContext.SaveChangesAsync();
                    cartDto.CartDetails.First().CartHeaderId = cartHeader.CartHeaderId;
                    CartDetails cartDetails = _mapper.Map<CartDetails>(cartDto.CartDetails.First());
                    _appDbContext.CartDetails.Add(cartDetails);
                    await _appDbContext.SaveChangesAsync();
                }
                else
                {
                    //check if the cart has same product or not
                    var cartDetailsFromDb = await _appDbContext.CartDetails.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == cartDto.CartDetails.First().ProductId &&
                                             x.CartHeaderId == cartHeaderFromDb.CartHeaderId);
                    if( cartDetailsFromDb == null)
                    {
                        //add that product in the cart
                        cartDto.CartDetails.First().CartHeaderId = cartHeaderFromDb.CartHeaderId;
                        CartDetails cartDetails = _mapper.Map<CartDetails>(cartDto.CartDetails.First());
                        _appDbContext.CartDetails.Add(cartDetails);
                        await _appDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        //increase quantity of that product in the cart
                        cartDto.CartDetails.First().Count += cartDetailsFromDb.Count;
                        cartDto.CartDetails.First().CartHeaderId = cartHeaderFromDb.CartHeaderId;
                        cartDto.CartDetails.First().CartDetailId = cartDetailsFromDb.CartDetailId;

                        CartDetails cartDetails = _mapper.Map<CartDetails>(cartDto.CartDetails.First());
                         _appDbContext.CartDetails.Update(cartDetails);
                        await _appDbContext.SaveChangesAsync();
                    }
                    _responseDto.Result = cartDto;
                }
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message.ToString();
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }
        [HttpPost("RemoveCart")]
        public async Task<ResponseDto> RemoveCart([FromBody]int cartDetailsId)
        {
            try
            {
                CartDetails cartDetails = _appDbContext.CartDetails.First(c=>c.CartDetailId == cartDetailsId);
                int totalCountofCartItem = _appDbContext.CartDetails.Where(c => c.CartHeaderId == cartDetails.CartHeaderId).Count();
                _appDbContext.CartDetails.Remove(cartDetails);
                if(totalCountofCartItem == 1)
                {
                    var cartHeaderToRemove = await _appDbContext.CartHeaders.FirstOrDefaultAsync(c => c.CartHeaderId == cartDetails.CartHeaderId);
                    _appDbContext.CartHeaders.Remove(cartHeaderToRemove);
                }
                await _appDbContext.SaveChangesAsync();
                _responseDto.Result = cartDetails;
                _responseDto.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message.ToString();
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }
    }
}
