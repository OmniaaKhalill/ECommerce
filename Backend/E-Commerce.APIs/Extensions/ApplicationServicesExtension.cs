using E_Commerce.APIs.Helpers;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Services.Contract;
using E_Commerce.Service;
using Microsoft.AspNetCore.Mvc;
using PaymentService = E_Commerce.Service.PaymentService;


namespace E_Commerce.APIs.Controllers
{
    public static class ApplicationServicesExtension
    {                                           
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
          
            services.AddScoped(typeof(IPaymentService), typeof(PaymentService));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericReposity<>));
            services.AddAutoMapper(typeof(MappingProfile));


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0).SelectMany(p => p.Value.Errors).Select(e => e.ErrorMessage).ToArray();

                    var validationErrprRespone = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(validationErrprRespone);
                };

            });
            return services;
        }
    }
}
