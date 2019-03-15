using System;
using Adapters;
using Common;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;

namespace Dependencies
{
    public class AdapterModule
    {
        public void Configure(IWebJobsBuilder builder)
        {
            this.ConfigureServices(builder.Services);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // TODO: Register types here!
            // services.AddTransient<ITransientGreeter, Greeter>();
            // services.AddScoped<IScopedGreeter, Greeter>();
            // services.AddSingleton<ISingletonGreeter, Greeter>();

            // A new instance will be created each time the dependency is required
            // (eg if injected into Azure funcitons class via constructor, then a
            // new instance will be created each time the Azure function is called)
            services.AddTransient<IMyService, MyService>();
        }
    }
}
