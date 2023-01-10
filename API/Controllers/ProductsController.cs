using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductRepository _repo;

            public ProductsController(IProductRepository repo)
            {
                _repo = repo;
            }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var product= await _repo.GetProductsAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            return await _repo.GetProductByIdAsync(id);
        }
        [HttpGet("{brands}")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
            var brand =  await _repo.GetProductBrandsAsync();
            return Ok(brand);
        }
        [HttpGet("{types}")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes(){
            var type =  await _repo.GetProductTypesAsync();
            return Ok(type);
        }
    }
}