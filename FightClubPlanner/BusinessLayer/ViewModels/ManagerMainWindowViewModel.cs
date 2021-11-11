using DataLayer.Models;
using System;
using System.Collections.ObjectModel;

namespace BusinessLayer.ViewModels
{
    public class ManagerMainWindowViewModel : BaseViewModel, IManagerMainWindowViewModel
    {
        private Manager _manager;
        public Manager Manager
        {
            get => _manager;
            set
            {
                _manager = value;
                SetProperty<Manager>(ref _manager, value);
            }
        }

        public ObservableCollection<Tournament> Tournaments { get; set; }

        private Tournament _selectedTournament;
        public Tournament SelectedTournament
        {
            get => _selectedTournament;
            set
            {
                _selectedTournament = value;
                SetProperty<Tournament>(ref _selectedTournament, value);
            }
        }

        //Create tournament side:

        private string _tournamentName;
        public string TournamentName
        {
            get => _tournamentName;
            set
            {
                _tournamentName = value;
                SetProperty<string>(ref _tournamentName, value);
            }
        }

        private string _tournamentLocation;
        public string TournamentLocation
        {
            get => _tournamentLocation;
            set
            {
                _tournamentLocation = value;
                SetProperty<string>(ref _tournamentLocation, value);
            }
        }

        private DateTime _tournamentStartDate = DateTime.Now;
        public DateTime TournamentStartDate
        {
            get => _tournamentStartDate;
            set
            {
                _tournamentStartDate = value;
                SetProperty<DateTime>(ref _tournamentStartDate, value);
            }
        }
    }
}
