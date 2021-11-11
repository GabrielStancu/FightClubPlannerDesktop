using DataLayer.DataAccess.DatabaseExceptions;
using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public class ManagerEntity : UserEntity<Manager>, IManagerEntity
    {
        public async override Task<Manager> SelectUserWithLoginInformationAsync(string username, string password)
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.Managers
                        .Include(m => m.Tournaments)
                        .Where(m => m.Username.Equals(username)//, StringComparison.Ordinal)
                            && m.Password.Equals(password))//, StringComparison.Ordinal))
                        .FirstOrDefaultAsync();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }
    }
}
