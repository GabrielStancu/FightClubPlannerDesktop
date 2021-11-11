using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseAccess;
using DataLayer;
using DataLayer.Models;
using System;

namespace BusinessLayer.Helpers
{
    public class InviteSender : IInviteSender
    {
        IInviteEntity _inviteEntity;
        public InviteSender(IInviteEntity inviteEntity)
        {
            _inviteEntity = inviteEntity;
        }
        public async void SendInvite(IManagerTournamentDetailsViewModel model, Tournament tournament)
        {
            if (model.CurrentFighter != null)
            {
                Invite invite = new Invite()
                {
                    FighterId = model.CurrentFighter.Id,
                    InviteState = InviteState.NotAnswered,
                    DateSent = DateTime.Today,
                    TournamentId = tournament.Id
                };

                await _inviteEntity.InsertAsync(invite);

                model.InvitableFighters.Remove(model.CurrentFighter);
            }
        }
    }
}
