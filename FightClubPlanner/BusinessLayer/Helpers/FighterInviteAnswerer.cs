using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseAccess;
using DataLayer;
using DataLayer.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public class FighterInviteAnswerer : IFighterInviteAnswerer
    {
        IInviteEntity _inviteEntity;
        ITournamentFighterEntity _tournamentFighterEntity;
        public FighterInviteAnswerer(ITournamentFighterEntity tournamentFighterEntity,
            IInviteEntity inviteEntity)
        {
            _tournamentFighterEntity = tournamentFighterEntity;
            _inviteEntity = inviteEntity;
        }
        public async Task AnswerInvite(IFighterMainWindowViewModel model, InviteState result)
        {
            model.SelectedInvite.InviteState = result;

            await _inviteEntity.UpdateAsync(model.SelectedInvite);

            if (result == InviteState.Accepted)
            {
                model.Tournaments.Add(model.SelectedInvite.Tournament);

                var tf = new TournamentFighter()
                {
                    FighterId = model.Fighter.Id,
                    TournamentId = model.SelectedInvite.Tournament.Id
                };
                await _tournamentFighterEntity.InsertAsync(tf);
            }
        }
    }
}
