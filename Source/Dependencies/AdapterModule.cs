using Adapters;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace Dependencies
{
    public class AdapterModule : IModule
    {
        public void Configure(IWebJobsBuilder builder)
        {
            this.ConfigureServices(builder.Services);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Service can be registered manually, for example:
            // services.AddTransient<ITransientGreeter, Greeter>();
            // services.AddScoped<IScopedGreeter, Greeter>();
            // services.AddSingleton<ISingletonGreeter, Greeter>();

            // A new instance will be created each time the dependency is required
            // (eg if injected into an Azure function via a constructor, then a
            // new instance will be created each time the Azure function is called)
            services.RegisterAssemblyPublicNonGenericClasses(typeof(MyService).Assembly)
                .AsPublicImplementedInterfaces(ServiceLifetime.Transient);
        }
    }
}
