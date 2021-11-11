using DataLayer.Models;
using System.Collections.ObjectModel;

namespace BusinessLayer.ViewModels
{
    public class FighterMainWindowViewModel : BaseViewModel, IFighterMainWindowViewModel
    {
        public ObservableCollection<IsolationBubble> IsolationBubbles { get; set; }
        public ObservableCollection<Tournament> Tournaments { get; set; }
        public ObservableCollection<Fight> Fights { get; set; }
        public ObservableCollection<CovidTest> Tests { get; set; }
        public ObservableCollection<Invite> Invites { get; set; }

        private Fighter _fighter;
        public Fighter Fighter
        {
            get => _fighter;
            set
            {
                _fighter = value;
                SetProperty<Fighter>(ref _fighter, value);
            }
        }

        private IsolationBubble _isolationBubble;
        public IsolationBubble IsolationBubble
        {
            get => _isolationBubble;
            set
            {
                _isolationBubble = value;
                SetProperty<IsolationBubble>(ref _isolationBubble, value);
            }
        }

        private bool _isPositive;
        public bool IsPositive
        {
            get => _isPositive;
            set
            {
                _isPositive = value;
                SetProperty<bool>(ref _isPositive, value);
            }
        }

        private bool _registerTestEnable = true;
        public bool RegisterTestEnable
        {
            get => _registerTestEnable;
            set
            {
                _registerTestEnable = value;
                SetProperty<bool>(ref _registerTestEnable, value);
            }
        }

        private bool _selfTestEnable = true;
        public bool SelfTestEnable
        {
            get => _selfTestEnable;
            set
            {
                _selfTestEnable = value;
                SetProperty<bool>(ref _selfTestEnable, value);
            }
        }

        private Invite _selectedInvite;
        public Invite SelectedInvite
        {
            get => _selectedInvite;
            set
            {
                _selectedInvite = value;
                SetProperty<Invite>(ref _selectedInvite, value);
            }
        }
    }
}
