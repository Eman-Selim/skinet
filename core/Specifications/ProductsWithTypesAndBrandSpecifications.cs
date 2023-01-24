using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using core.Entities;

namespace core.Specifications
{
    public class ProductsWithTypesAndBrandSpecifications : BaseSpecifications<Product>
    {
        public ProductsWithTypesAndBrandSpecifications(ProductSpecParams productParams)
        :base(x=>
            (string.IsNullOrEmpty(productParams.Search)||x.Name.ToLower().Contains(productParams.Search))&&
            (!productParams.BrandId.HasValue||x.ProductBrandId==productParams.BrandId)&&
            (!productParams.TypeId.HasValue||x.ProductTypeId==productParams.TypeId)
        )
        {
            AddInclude(P=>P.productBrand);
            AddInclude(P=>P.productType);
            AddInclude(x=>x.Name);
            ApplyPaging(productParams.PageSize*(productParams.PageIndex-1),productParams.PageSize);
            if(!string.IsNullOrEmpty(productParams.Sort)){
                switch(productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p=>p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p=>p.Price);
                        break;
                    default:
                        AddOrderBy(n=>n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandSpecifications(int id) : base(x=>x.ID==id)
        {
            AddInclude(P=>P.productBrand);
            AddInclude(P=>P.productType);
        }
    }
}