using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using core.Interfaces;
using core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;
using API.Helpers;

namespace API.Controllers
{
    
    public class ProductsController:BaseApiController
    {
        private readonly IGenericRepository<Product> _produtsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
            public ProductsController(IGenericRepository<Product> produtsRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo,IMapper mapper)
            {
            _mapper = mapper;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _produtsRepo = produtsRepo;
                
            }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(
            [FromQuery]ProductSpecParams productParams){
            var spec= new ProductsWithTypesAndBrandSpecifications(productParams);

            var countSpec=new ProductWithFilterForCountSpecification(productParams);

            var totalItems= await _produtsRepo.CountAsync(countSpec);

            var products=await _produtsRepo.ListAsync(spec);

            var data=_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products);
            
            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex,productParams.PageSize,totalItems,data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id){
            var spec=new ProductsWithTypesAndBrandSpecifications(id);
            var product= await _produtsRepo.GetEntityWithSpec(spec);
            if(product==null) return NotFound(new ApiResponse(404));;
            return _mapper.Map<Product,ProductToReturnDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
            var brand =  await _productBrandRepo.ListAllAsync();
            return Ok(brand);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes(){
            var type =  await _productTypeRepo.ListAllAsync();
            return Ok(type);
        }
    }
}