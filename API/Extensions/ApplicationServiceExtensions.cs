using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static  IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.Configure<ApiBehaviorOptions>(options=>{
                options.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var errors=ActionContext.ModelState
                    .Where(e=>e.Value.Errors.Count>0)
                    .SelectMany(x=>x.Value.Errors)
                    .Select(x=>x.ErrorMessage).ToArray();

                    var errorResponse=new ApiValidationErrorResponse
                     
                     {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
             });
             return services;
        }

            
        
    }
}