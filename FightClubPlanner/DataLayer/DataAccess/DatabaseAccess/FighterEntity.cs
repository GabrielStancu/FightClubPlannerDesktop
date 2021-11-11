using DataLayer.DataAccess.DatabaseExceptions;
using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public class FighterEntity : UserEntity<Fighter>, IFighterEntity
    {
        public async override Task<Fighter> SelectUserWithLoginInformationAsync(string username, string password)
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.Fighters
                        .Include(f => f.TestHistory).ThenInclude(t => t.IsolationBubble)
                        .Include(f => f.TournamentFighters).ThenInclude(tf => tf.Tournament)
                        .FirstOrDefaultAsync(
                            f => f.Username.Equals(username)//, StringComparison.Ordinal)
                            && f.Password.Equals(password)//, StringComparison.Ordinal)
                        ) ??
                        throw new UserNotRegisteredException();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }

        public async Task<List<Fighter>> SelectAllFightersAsync()
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.Fighters
                        .Include(f => f.TestHistory)
                        .ToListAsync();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }

        public async Task<List<Fighter>> SelectAllFightersFromTournamentAsync(int tournamentId)
        {
            try
            {
                var fighters = new List<Fighter>();

                //using var context = CreateContext();
                var tournamentFighters = await new TournamentFighterEntity().SelectAllFightersByTournamentIdAsync(tournamentId);
                tournamentFighters.ForEach(tf => fighters.Add(tf.Fighter));

                return fighters;
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }
    }
}
