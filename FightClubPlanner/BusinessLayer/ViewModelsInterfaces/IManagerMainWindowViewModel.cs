using DataLayer.Models;
using System;
using System.Collections.ObjectModel;

namespace BusinessLayer.ViewModels
{
    public interface IManagerMainWindowViewModel
    {
        Manager Manager { get; set; }
        Tournament SelectedTournament { get; set; }
        string TournamentLocation { get; set; }
        string TournamentName { get; set; }
        ObservableCollection<Tournament> Tournaments { get; set; }
        DateTime TournamentStartDate { get; set; }
    }
}