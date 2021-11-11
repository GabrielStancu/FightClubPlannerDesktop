using BusinessLayer.ViewModels;
using DataLayer.Models;

namespace BusinessLayer.Helpers
{
    public interface IManagerDataLoader
    {
        void LoadModel(IManagerMainWindowViewModel model, Manager manager);
    }
}