using BusinessLayer.ViewModels;
using DataLayer.Models;

namespace BusinessLayer.Helpers
{
    public interface IFighterDataLoader
    {
        void LoadModel(IFighterMainWindowViewModel model, Fighter fighter);
    }
}