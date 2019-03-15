using Dependencies;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(FunctionApp.Startup))]
namespace FunctionApp
{
    internal class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddModule(new AdapterModule())
                   .AddModule(new DomainModule());
        }
    }
}
