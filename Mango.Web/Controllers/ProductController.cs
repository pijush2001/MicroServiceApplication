using Mango.Web.Models;
using Mango.Web.Service;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto>? productDtos = new List<ProductDto>();
            ResponseDto responseDto =await _productService.GetAllProduct();
            if(responseDto != null&& responseDto.IsSuccess)
            {
                productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto.Message;
            }
            return View(productDtos);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {

            return View("CreateProduct");
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto responseDto = await _productService.CreateProduct(productDto);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = " Added the product Successfully";
                    return RedirectToAction(nameof(ProductIndex));

                }
                else
                {
                    TempData["error"] = "Unauthorized";
                }
            }

            return View(productDto);
        }
        [HttpGet]
       
        
        public async Task<IActionResult> DeleteProductByID(int id)
        {


            ResponseDto responseDto = await _productService.GetProductById(id);
            if (responseDto != null && responseDto.IsSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result));
                TempData["success"] = "Deleted the Product Successfully";
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

        public async Task<IActionResult> DeleteProductBy([FromForm] ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto responseDto = await _productService.DeleteProductByID(productDto.ProductId);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }


            }
            return View();


        }
    }
}
