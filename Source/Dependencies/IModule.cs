using Microsoft.Azure.WebJobs;

namespace Dependencies
{
    public interface IModule
    {
        void Configure(IWebJobsBuilder builder);
    }
}
