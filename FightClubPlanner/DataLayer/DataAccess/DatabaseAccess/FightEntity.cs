using DataLayer.DataAccess.DatabaseExceptions;
using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public class FightEntity : GenericEntity<Fight>, IFightEntity
    {
        public async Task<List<Fight>> SelectAllFightsAsync()
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.Fights
                        .Include(f => f.Fighter1)
                        .Include(f => f.Fighter2)
                        .Include(f => f.Tournament)
                        .Include(f => f.Winner)
                        .ToListAsync();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }

        public async Task<List<Fight>> SelectAllFightsByTournamentIdAsync(int id)
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.Fights
                        .Where(f => f.TournamentId == id)
                        .Include(f => f.Fighter1)
                        .Include(f => f.Fighter2)
                        .Include(f => f.Winner)
                        .OrderByDescending(f => f.FightTime)
                        .ToListAsync();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }

        public async Task<List<Fight>> SelectAllFightsByFighterIdAsync(int id)
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.Fights
                        .Where(f => f.FighterId1 == id || f.FighterId2 == id)
                        .Include(f => f.Tournament)
                        .Include(f => f.Winner)
                        .Include(f => f.Fighter1)
                        .Include(f => f.Fighter2)
                        .ToListAsync();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }

        public async Task<int> SelectCountOfFightsBetweenFightersInTournamentAsync(int fighter1Id, int fighter2Id, int tournamentId)
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.Fights
                        .Where(f => ((f.FighterId1 == fighter1Id && f.FighterId2 == fighter2Id)
                                    || (f.FighterId1 == fighter2Id && f.FighterId2 == fighter1Id))
                                    && f.TournamentId == tournamentId).CountAsync();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }
    }
}
