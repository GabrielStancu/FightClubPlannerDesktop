using DataLayer.DataAccess.DatabaseExceptions;
using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public abstract class UserEntity<T> : GenericEntity<T>, IUserEntity<T> where T : User
    {
        public abstract Task<T> SelectUserWithLoginInformationAsync(string username, string password);
        public async Task<bool> CheckAlreadyRegisteredUserAsync(string username)
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.Set<T>()
                        .FirstOrDefaultAsync(
                            u => u.Username.Equals(username)//, StringComparison.Ordinal)
                        ) != null;
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }

        public async Task RegisterUserAsync(T user)
        {
            using var context = CreateContext();

            try
            {
                await InsertAsync(user);
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }

        }
    }
}
