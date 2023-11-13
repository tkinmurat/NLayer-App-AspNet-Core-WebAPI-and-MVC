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
        private readonly IService<Product> _service;

        public ProductsController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {

            var products = await _service.GetAllAsync();
            var productsDTOs = _mapper.Map<List<ProductDTO>>(products.ToList());

            //return Ok(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTOs));

            return CreateActionResult<List<ProductDTO>>(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTOs));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var products = await _service.GetAllAsync();
            var productsDTOs = _mapper.Map<List<ProductDTO>>(products.ToList());

            //return Ok(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTOs));

            return CreateActionResult<List<ProductDTO>>(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTOs));

        }

    }
}
