using DataLayer.DataAccess.DatabaseAccess;
using DataLayer.Models;
using System;
using System.Collections.ObjectModel;

namespace BusinessLayer.ViewModels
{
    public class ManagerTournamentDetailsViewModel : BaseViewModel, IManagerTournamentDetailsViewModel
    {
        public ObservableCollection<Fighter> InvitableFighters { get; set; }
        public ObservableCollection<Fighter> DisplayFighters { get; set; }
        public ObservableCollection<Fight> DisplayFights { get; set; }

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

        private Tournament _tournament;
        public Tournament Tournament
        {
            get => _tournament;
            set
            {
                _tournament = value;
                SetProperty<Tournament>(ref _tournament, value);
            }
        }

        private Fight _selectedFight;
        public Fight SelectedFight
        {
            get => _selectedFight;
            set
            {
                _selectedFight = value;
                SetProperty<Fight>(ref _selectedFight, value);
            }
        }

        private Fighter _currentFighter;
        public Fighter CurrentFighter
        {
            get => _currentFighter;
            set
            {
                _currentFighter = value;
                SetProperty<Fighter>(ref _currentFighter, value);
            }
        }

        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                SetProperty<DateTime>(ref _selectedDate, value);
            }
        }

        private bool _readOnlyWinner = true;
        public bool ReadOnlyWinner
        {
            get => _readOnlyWinner;
            set
            {
                _readOnlyWinner = value;
                SetProperty<bool>(ref _readOnlyWinner, value);
            }
        }

        public async void SetFightWinner(Fight fight, Fighter fighter)
        {
            ReadOnlyWinner = false;
            fight.WinnerId = fighter.Id;
            await new FightEntity().UpdateAsync(fight);
            fight.Winner = fighter;
            ReadOnlyWinner = true;
        }

        public void HandleDateChanged()
        {
            foreach (Fighter f in DisplayFighters)
            {
                f.IsEligible = f.CanFight(SelectedDate);
            }
        }
    }
}
