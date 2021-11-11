using BusinessLayer.ViewModels;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public interface ISignUpChecker
    {
        Task<bool> SignUp(ISignUpViewModel model, string password, string repeatedPassword);
    }
}