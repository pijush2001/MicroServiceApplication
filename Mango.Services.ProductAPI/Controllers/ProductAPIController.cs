using AutoMapper;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    //[Authorize]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ResponseDto _responseDto;
        private readonly IMapper _mapper;
        public ProductAPIController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public object GetProducts()
        {
            try
            {
                IEnumerable<Product> productList = _appDbContext.Products.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<ProductDto>>(productList);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;

            }
            return _responseDto;
        }
        [HttpGet]
        [Route("GetProductById/{productId:int}")]
        public ResponseDto GetProdctById(int productId)
        {
            try
            {
                Product? product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
                ProductDto productDto = _mapper.Map<ProductDto>(product);
                _responseDto.Result = productDto;
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;

        }
        [HttpPost]
        [Route("CreateANewProduct")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] ProductDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto);
                _appDbContext.Products.Add(product);
                _appDbContext.SaveChanges();
                _responseDto.Result = productDto;
                _responseDto.Message = "Product added successfully";
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return (_responseDto);
        }
        [HttpPut]
        [Route("UpdateProduct")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] ProductDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto);
                _appDbContext.Update(product);
                _appDbContext.SaveChanges();
                _responseDto.Result = productDto;
                _responseDto.Message = "Product updated successfully";
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }
        [HttpDelete]
        [Route("DeleteProductById/{productId:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int productId)
        {
            try
            {
                Product? product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
                _appDbContext.Remove(product);
                _appDbContext.SaveChanges();
                _responseDto.Result = _mapper.Map<ProductDto>(product);
                _responseDto.Message = "Product deleted succesfully";
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }
    }
}
