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
        public ProductsWithTypesAndBrandSpecifications()
        {
            AddInclude(P=>P.productBrand);
            AddInclude(P=>P.productType);
        }

        public ProductsWithTypesAndBrandSpecifications(int id) : base(x=>x.ID==id)
        {
            AddInclude(P=>P.productBrand);
            AddInclude(P=>P.productType);
        }
    }
}