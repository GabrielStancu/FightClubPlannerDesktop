using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public interface ITournamentFighterEntity : IGenericEntity<TournamentFighter>
    {
        Task<List<TournamentFighter>> SelectAllFightersByTournamentIdAsync(int id);
        Task<List<TournamentFighter>> SelectAllTournamentsByFighterIdAsync(int id);
    }
}