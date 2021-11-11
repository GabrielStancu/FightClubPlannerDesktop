using BusinessLayer.ViewModels;
using DataLayer.Models;

namespace BusinessLayer.Helpers
{
    public interface IInviteSender
    {
        void SendInvite(IManagerTournamentDetailsViewModel model, Tournament tournament);
    }
}