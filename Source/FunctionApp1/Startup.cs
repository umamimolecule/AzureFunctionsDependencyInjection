using Dependencies;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(FunctionApp1.Startup))]
namespace FunctionApp1
{
    internal class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            AdapterModule module = new AdapterModule();
            module.Configure(builder);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // TODO: Register services here if required
            //services.AddTransient<ITransientGreeter, Greeter>();
            //services.AddScoped<IScopedGreeter, Greeter>();
            //services.AddSingleton<ISingletonGreeter, Greeter>();
        }
    }
}
