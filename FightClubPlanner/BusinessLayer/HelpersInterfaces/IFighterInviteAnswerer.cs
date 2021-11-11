using BusinessLayer.ViewModels;
using DataLayer;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public interface IFighterInviteAnswerer
    {
        Task AnswerInvite(IFighterMainWindowViewModel model, InviteState result);
    }
}