using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
       
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> CreateProduct(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.POST,
                Data = productDto,
                Url = $"{APIDetails.ProductBase}/api/product/CreateANewProduct/"
            });
        }

        public async Task<ResponseDto> DeleteProductByID(int productId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.DELETE,
                //Data = productDto,
                Url = $"{APIDetails.ProductBase}/api/product/DeleteProductById/{productId}"
            });
        }

        public async Task<ResponseDto> GetAllProduct()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.GET,
                //Data = productDto,
                Url = $"{APIDetails.ProductBase}/api/product/GetAllProducts/"
            });
        }

        public async Task<ResponseDto> GetProductById(int productId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.GET,
                //Data = productDto,
                Url = $"{APIDetails.ProductBase}/api/product/GetProductById/{productId}"
            });
        }

        public async Task<ResponseDto> UpdateProduct(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiTypeEnum.ApiType.PUT,
                Data = productDto,
                Url = $"{APIDetails.ProductBase}/api/product/UpdateProduct"
            });
        }
    }
}
