//using Microsoft.Azure.Functions.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using ZanettiClod.Core.Interfaces.Data;
//using ZanettiClod.Core.Services;
//using ZanettiClod.Domain;
//using ZanettiClod.Infrastructure.Data;
//using ZanettiClod.SampleAzureFunctions;

//[assembly: FunctionsStartup(typeof(Startup))]

//namespace ZanettiClod.SampleAzureFunctions
//{
//    public class Startup : FunctionsStartup
//    {
//        public override void Configure(IFunctionsHostBuilder builder)
//        {
//            builder.Services.AddHttpClient();
//            builder.Services.AddSingleton<IConfiguration>();
//            builder.Services.AddSingleton<IProductService, ProductService>();
//            builder.Services.AddSingleton<IProductRepository<Product>, ProductRepository>();
//        }
//    }
//}
