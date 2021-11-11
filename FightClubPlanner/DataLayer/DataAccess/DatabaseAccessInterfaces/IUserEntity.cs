using DataLayer.Models;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public interface IUserEntity<T> : IGenericEntity<T> where T : User
    {
        Task<bool> CheckAlreadyRegisteredUserAsync(string username);
        Task RegisterUserAsync(T user);
        Task<T> SelectUserWithLoginInformationAsync(string username, string password);
    }
}