using BusinessLayer.ViewModels;
using DataLayer.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public interface IFightsGenerator
    {
        Task<bool> GenerateFights(IManagerTournamentDetailsViewModel model, Tournament tournament);
    }
}