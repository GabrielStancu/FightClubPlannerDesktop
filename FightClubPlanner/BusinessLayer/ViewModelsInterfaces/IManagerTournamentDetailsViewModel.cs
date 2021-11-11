using DataLayer.Models;
using System;
using System.Collections.ObjectModel;

namespace BusinessLayer.ViewModels
{
    public interface IManagerTournamentDetailsViewModel
    {
        Fighter CurrentFighter { get; set; }
        ObservableCollection<Fighter> DisplayFighters { get; set; }
        ObservableCollection<Fight> DisplayFights { get; set; }
        ObservableCollection<Fighter> InvitableFighters { get; set; }
        Manager Manager { get; set; }
        bool ReadOnlyWinner { get; set; }
        DateTime SelectedDate { get; set; }
        Fight SelectedFight { get; set; }
        Tournament Tournament { get; set; }

        void HandleDateChanged();
        void SetFightWinner(Fight fight, Fighter fighter);
    }
}