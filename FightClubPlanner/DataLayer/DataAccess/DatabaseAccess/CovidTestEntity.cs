using DataLayer.DataAccess.DatabaseExceptions;
using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public class CovidTestEntity : GenericEntity<CovidTest>, ICovidTestEntity
    {
        public async Task<List<CovidTest>> SelectCovidTestsForFighterAsync(int id)
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.CovidTests
                        .Include(c => c.IsolationBubble)
                        .Where(c => c.FighterId == id)
                        .ToListAsync();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }
    }
}
