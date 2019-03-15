namespace Common
{
    public class NestedService : INestedService
    {
        private readonly IMyService childService;

        public NestedService(IMyService childService)
        {
            this.childService = childService;
        }

        public IMyService ChildService => this.childService;
    }
}
