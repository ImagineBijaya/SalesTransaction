﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTransactionApi.Models;
using SalesTransactionApi.Repositories;

namespace SalesTransactionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
         private  readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getproductlist")]
        public async Task<List<Product>> GetProductListAsync()
        {
            try
            {
                return await _productService.GetProductListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getproductbyid")]
        public async Task<IEnumerable<Product>> GetProductByIdAsync(int Id)
        {
            try
            {
                var response = await _productService.GetProductByIdAsync(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _productService.AddProductAsync(product);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updateproduct")]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _productService.UpdateProductAsync(product);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("deleteproduct")]
        public async Task<int> DeleteProductAsync(int Id)
        {
            try
            {
                var response = await _productService.DeleteProductAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}