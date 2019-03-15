using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Common;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public class MyFunction
    {
        // The services that are injected via constructor
        private readonly IMyService myService;
        private readonly IAnotherService anotherService;
        private readonly INestedService nestedService;

        public MyFunction(
            IMyService myService,
            IAnotherService anotherService,
            INestedService nestedService)
        {
            this.myService = myService;
            this.anotherService = anotherService;
            this.nestedService = nestedService;
        }

        [FunctionName("MyFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, ILogger logger)
        {
            logger.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            this.anotherService.DoStuff(name);
            await this.myService.DoStuffAsync(name);
            await this.nestedService.ChildService.DoStuffAsync($"{name} (Nested)");

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
