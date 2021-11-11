using BusinessLayer.ViewModels;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public interface ITournamentCreator
    {
        Task<bool> RegisterTournament(IManagerMainWindowViewModel model);
    }
}