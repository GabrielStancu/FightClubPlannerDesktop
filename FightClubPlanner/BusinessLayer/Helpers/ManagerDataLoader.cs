using BusinessLayer.ViewModels;
using DataLayer.Models;
using System;
using System.Collections.ObjectModel;

namespace BusinessLayer.Helpers
{
    public class ManagerDataLoader : IManagerDataLoader
    {
        public void LoadModel(IManagerMainWindowViewModel model, Manager manager)
        {
            model.Manager = manager;
            model.Tournaments = new ObservableCollection<Tournament>(manager.Tournaments);
            model.TournamentLocation = string.Empty;
            model.TournamentName = string.Empty;
            model.TournamentStartDate = DateTime.Today;
        }
    }
}
