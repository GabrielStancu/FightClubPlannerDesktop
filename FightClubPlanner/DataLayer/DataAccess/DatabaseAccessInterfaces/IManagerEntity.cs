using DataLayer.Models;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public interface IManagerEntity : IUserEntity<Manager>
    {
        new Task<Manager> SelectUserWithLoginInformationAsync(string username, string password);
    }
}