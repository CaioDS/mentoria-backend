using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using GetProductList.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace GetProductList
{
    public class Function
    {
        private readonly ILogger<Function> _logger;

        public Function(ILogger<Function> logger)
        {
            _logger = logger;
        }

        [Function("GetProductList")]
        //[TableOutput("Products", Connection = "AzureWebJobsStorage")]
        public static IEnumerable<Products> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
            [TableInput("Products", Connection = "AzureWebJobsStorage")] IEnumerable<Products> products,
            FunctionContext context
            )
        {
            var logger = context.GetLogger("TableFunction");

            logger.LogInformation($"Get all records from Products ({products.Count()})");

            return products;
        }
    }
}
