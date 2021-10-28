using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZanettiClod.Core.Interfaces.Data;
using ZanettiClod.Core.Services;
using ZanettiClod.Domain;
using ZanettiClod.Infrastructure.Data;

namespace ZanettiClod.SampleAzureFunctions
{
    public class Program
    {
        public static void Main()
        {

            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s =>
                {
                    s.AddHttpClient();
                    s.AddSingleton<IProductService, ProductService>();
                    s.AddSingleton<IProductRepository<Product>, ProductRepository>();
                })
                .Build();
            host.Run();
        }
    }
}