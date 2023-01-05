﻿using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DAL.ViewModels;
using ProductsAPI.Service.ProductService;

namespace ProductsAPI.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public ProductListViewModel GetPaginatedProducts([FromQuery]FilterViewModel filters)
        {
            return this._productService.GetPaginatedProducts(filters);
        }

        [HttpGet("{id}")]
        public ProductViewModel GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ProductViewModel formData)
        {
            _productService.Create(formData);
            return CreatedAtAction(nameof(GetProductById), new { id = formData.Id }, formData);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ProductViewModel> Update(ProductViewModel formData)
        {
            return await _productService.Update(formData);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _productService.Delete(id);
            return NoContent();
        }
    }
}
