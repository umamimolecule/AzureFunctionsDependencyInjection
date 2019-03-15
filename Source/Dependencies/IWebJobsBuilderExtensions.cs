using Microsoft.Azure.WebJobs;

namespace Dependencies
{
    public static class IWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddModule(this IWebJobsBuilder builder, IModule module)
        {
            module.Configure(builder);
            return builder;
        }
    }
}
