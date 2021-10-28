using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ZanettiClod.Core.Services;
using ZanettiClod.Domain;
using ZanettiClod.Infrastructure.Data;

namespace ZanettiClod.SampleAzureFunctions
{
    public class CreateProduct
    {
        private readonly IProductService _productService;

        public CreateProduct(IProductService productService)
        {
            _productService = productService;
        }

        [Function("CreateProduct")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("CreateProduct");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var product = await req.ReadFromJsonAsync<Product>();

            _productService.CreateProduct(product);

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(
                new
                {
                    Result = true,
                    Message = $"Name: {product.Name}, Price: {product.Price}"
                });

            return response;
        }
    }
}
