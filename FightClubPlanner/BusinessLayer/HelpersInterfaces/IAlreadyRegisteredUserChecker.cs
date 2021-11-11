using DataLayer.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public interface IAlreadyRegisteredUserChecker
    {
        Task<bool> Exists(User user);
    }
}