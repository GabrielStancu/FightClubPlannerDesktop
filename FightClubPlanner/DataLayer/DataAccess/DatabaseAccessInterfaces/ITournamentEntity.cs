using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public interface ITournamentEntity : IGenericEntity<Tournament>
    {
        Task<List<Tournament>> SelectAllTournamentsAsync();
        Task<List<Tournament>> SelectTournamentsByManagerIdAsync(int id);
    }
}