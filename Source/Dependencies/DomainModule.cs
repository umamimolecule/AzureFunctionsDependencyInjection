using Common;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;

namespace Dependencies
{
    public class DomainModule : IModule
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

            // A single instance will be created (eg if injected into an Azure function
            // class via a constructor, then the same instance will be created each time
            // the Azure function is called)
            services.RegisterAssemblyPublicNonGenericClasses(typeof(IMyService).Assembly)
                .Where(c => !c.IsAssignableTo(typeof(INestedService)))
                .AsPublicImplementedInterfaces(ServiceLifetime.Singleton);

            // But make INestedService transient
            services.AddTransient<INestedService, NestedService>();
        }
    }
}
