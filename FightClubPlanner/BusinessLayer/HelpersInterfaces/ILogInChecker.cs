using BusinessLayer.ViewModels;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public interface ILogInChecker
    {
        Task LoginCommand(ILoginViewModel model, string parameter);
    }
}