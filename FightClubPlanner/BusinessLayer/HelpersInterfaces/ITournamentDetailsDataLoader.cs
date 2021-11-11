using BusinessLayer.ViewModels;
using DataLayer.Models;

namespace BusinessLayer.Helpers
{
    public interface ITournamentDetailsDataLoader
    {
        void LoadModel(IManagerTournamentDetailsViewModel model, Manager manager, Tournament tournament);
    }
}