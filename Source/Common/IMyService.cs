using System.Threading.Tasks;

namespace Common
{
    public interface IMyService
    {
        Task DoStuffAsync(string data);
    }
}
