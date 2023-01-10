using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(ILoggerFactory loggerFactory,StoreContext context){
            try{
                if(!context.productBrand.Any()){
                    var BrandData= File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brand =JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);
                    foreach (var item in brand)
                    {
                        context.productBrand.Add(item);
                    }
                        await context.SaveChangesAsync();
                }
                if(!context.productType.Any()){
                    var TypeData=File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var type=JsonSerializer.Deserialize<List<ProductType>>(TypeData);
                    foreach (var item in type)
                    {
                        context.productType.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.Product.Any()){
                    var ProductData=File.ReadAllText("..Infrastructure/Data/SeedData/products.json");
                    var product=JsonSerializer.Deserialize<List<Product>>(ProductData);
                    foreach (var item in product)
                    {
                        context.Product.Add(item);                        
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex){
                var logger=loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}