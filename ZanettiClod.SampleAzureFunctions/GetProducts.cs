using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ZanettiClod.Core.Interfaces.Data;
using ZanettiClod.Core.Services;
using ZanettiClod.Infrastructure.Data;

namespace ZanettiClod.SampleAzureFunctions
{
    public class GetProducts
    {
        private IProductService _productService;

        public GetProducts(IProductService productService)
        {
            _productService = productService;
        }

        [Function("GetProducts")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] 
            HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("GetProducts");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var products = await _productService.GetAllProducts();

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(products);

            return response;
        }
    }
}
