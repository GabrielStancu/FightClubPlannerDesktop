using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public class InviteEntity : GenericEntity<Invite>, IInviteEntity
    {
        public async Task<List<Invite>> SelectAllInvitesByFighterIdAsync(int id)
        {
            using var context = CreateContext();
            return await context.Invites
                .Where(i => i.FighterId == id)
                .Include(i => i.Tournament).ThenInclude(t => t.Organizer)
                .ToListAsync();
        }

        public async Task<List<Invite>> SelectAllInvitesByTournamentIdAsync(int id)
        {
            using var context = CreateContext();
            return await context.Invites
                .Where(i => i.TournamentId == id)
                .Include(i => i.Fighter)
                .ToListAsync();
        }
    }
}
