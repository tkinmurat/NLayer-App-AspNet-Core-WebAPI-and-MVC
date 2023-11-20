using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IService<Product> service, IProductService productService)
        {
            _mapper = mapper;
            
            _service = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {

            return CreateActionResult(await _service.GetProductsWithCategory());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {

            var products = await _service.GetAllAsync();
            var productsDTOs = _mapper.Map<List<ProductDTO>>(products.ToList());

            return CreateActionResult<List<ProductDTO>>(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTOs));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var product = await _service.GetByIdAsync(id);
            var productsDTO = _mapper.Map<ProductDTO>(product);

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productsDTO));

        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {

            var product = await _service.AddAsync(_mapper.Map<Product>(productDTO));
            var productsDTO = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productsDTO));

        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productDTO)
        {

            await _service.UpdateAsync(_mapper.Map<Product>(productDTO));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));

        }
    }
}
