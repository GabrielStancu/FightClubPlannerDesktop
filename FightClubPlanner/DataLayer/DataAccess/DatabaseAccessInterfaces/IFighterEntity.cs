using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public interface IFighterEntity : IUserEntity<Fighter>
    {
        Task<List<Fighter>> SelectAllFightersAsync();
        Task<List<Fighter>> SelectAllFightersFromTournamentAsync(int tournamentId);
        new Task<Fighter> SelectUserWithLoginInformationAsync(string username, string password);
    }
}