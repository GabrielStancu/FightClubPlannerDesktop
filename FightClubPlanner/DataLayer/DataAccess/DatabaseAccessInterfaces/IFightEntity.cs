using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public interface IFightEntity : IGenericEntity<Fight>
    {
        Task<List<Fight>> SelectAllFightsAsync();
        Task<List<Fight>> SelectAllFightsByFighterIdAsync(int id);
        Task<List<Fight>> SelectAllFightsByTournamentIdAsync(int id);
        Task<int> SelectCountOfFightsBetweenFightersInTournamentAsync(int fighter1Id, int fighter2Id, int tournamentId);
    }
}