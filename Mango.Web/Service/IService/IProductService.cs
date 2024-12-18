using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto> GetProductById(int productId);
        Task<ResponseDto> GetAllProduct();
        
        Task<ResponseDto> CreateProduct(ProductDto productDto);
        Task<ResponseDto> UpdateProduct(ProductDto productDto);
        Task<ResponseDto> DeleteProductByID(int productId);
        
    }
}
