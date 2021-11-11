using DataLayer.DataAccess.DatabaseExceptions;
using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public class TournamentFighterEntity : GenericEntity<TournamentFighter>, ITournamentFighterEntity
    {
        public async Task<List<TournamentFighter>> SelectAllTournamentsByFighterIdAsync(int id)
        {
            try
            {
                using var context = CreateContext();
                return await context.TournamentFighters
                    .Include(tf => tf.Tournament).ThenInclude(t => t.Organizer)
                    .Where(tf => tf.FighterId == id)
                    .ToListAsync();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }

        public async Task<List<TournamentFighter>> SelectAllFightersByTournamentIdAsync(int id)
        {
            try
            {
                using var context = CreateContext();
                return await context.TournamentFighters
                    .Include(t => t.Fighter).ThenInclude(f => f.TestHistory)
                    .Where(t => t.TournamentId == id)
                    .ToListAsync();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }
    }
}
