using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public interface IInviteEntity: IGenericEntity<Invite>
    {
        Task<List<Invite>> SelectAllInvitesByFighterIdAsync(int id);
        Task<List<Invite>> SelectAllInvitesByTournamentIdAsync(int id);
    }
}