using DataLayer.DataAccess.DatabaseExceptions;
using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public class TournamentEntity : GenericEntity<Tournament>, ITournamentEntity
    {
        public async Task<List<Tournament>> SelectAllTournamentsAsync()
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.Tournaments
                        .Include(t => t.Organizer)
                        .Include(t => t.Fights).ThenInclude(f => f.Winner)
                        .Include(t => t.TournamentFighters).ThenInclude(tf => tf.Fighter)
                        .ToListAsync();


            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }

        public async Task<List<Tournament>> SelectTournamentsByManagerIdAsync(int id)
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.Tournaments
                        .Include(t => t.Organizer)
                        .Include(t => t.Fights)
                        .Include(t => t.Fights.Select(f => f.Fighter1))
                        .Include(t => t.Fights.Select(f => f.Fighter2))
                        .Include(t => t.Fights.Select(f => f.Winner))
                        .Include(t => t.TournamentFighters).ThenInclude(tf => tf.Fighter)
                        .Where(t => t.Id == id)
                        .ToListAsync();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }
    }
}
