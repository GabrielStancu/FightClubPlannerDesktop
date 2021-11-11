using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataLayer.Models;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for ManagerTournamentDetailsWindow.xaml
    /// </summary>
    public partial class ManagerTournamentDetailsWindow : Window
    {
        IManagerTournamentDetailsViewModel _model;
        ITournamentDetailsDataLoader _loader;
        IInviteSender _inviteSender;
        IFightsGenerator _fightsGenerator;
        ManagerMainWindow _managerMainWindow;
        Fight _fight;
        public ManagerTournamentDetailsWindow(IManagerTournamentDetailsViewModel model, 
            ITournamentDetailsDataLoader loader, IInviteSender inviteSender,
            IFightsGenerator fightsGenerator)
        {
            InitializeComponent();
            _model = model;
            _loader = loader;
            _inviteSender = inviteSender;
            _fightsGenerator = fightsGenerator;
        }

        public void SetManagerWindowReference(ManagerMainWindow managerMainWindow)
        {
            _managerMainWindow = managerMainWindow;
        }

        public void SetViewModel(Manager manager, Tournament tournament)
        {
            _loader.LoadModel(_model, manager, tournament);
            DataContext = null;
            DataContext = _model;
        }

        private void OnInviteButtonClicked(object sender, RoutedEventArgs e)
        {
            _inviteSender.SendInvite(_model, _model.Tournament);
        }

        private async void OnGenerateButtonClicked(object sender, RoutedEventArgs e)
        {
            bool generated = await _fightsGenerator.GenerateFights(_model, _model.Tournament);

            if(!generated)
            {
                CustomMessageBox msgBox =
                    new CustomMessageBox("Failed", "Cannot create fights in the past!", string.Empty, "OK", string.Empty, false);
                msgBox.Show();
            }
        }

        private void OnFightDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _fight = _model.SelectedFight;

            if(_fight.FightTime > DateTime.Today)
            {
                CustomMessageBox msgBox =
                    new CustomMessageBox("Failed", "Cannot choose winner for fight that had not taken place!", string.Empty, "OK", string.Empty, false);
                msgBox.Show();
                return;
            }

            if (_fight.Winner is null)
            {
                CustomMessageBox msgBox =
                    new CustomMessageBox("Fight Winner", $"Choose winner: {_fight.Fighter1.FullName} : {_fight.Fighter2.FullName}",
                                         _fight.Fighter1.FullName, _fight.Fighter2.FullName, "Cancel", true);
                msgBox.Show();
                msgBox.Closing += OnMsgBoxClosing;
            }
        }

        private void OnMsgBoxClosing(object sender, CancelEventArgs e)
        {
            var result = ((CustomMessageBox)sender).Result;

            if (result == CustomMessageBoxResult.FirstOption)
            {
                _model.SetFightWinner(_fight, _fight.Fighter1);
            }

            if (result == CustomMessageBoxResult.SecondOption)
            {
                _model.SetFightWinner(_fight, _fight.Fighter2);
            }
        }

        private void OnBackButtonClicked(object sender, RoutedEventArgs e)
        {
            Hide();
            _managerMainWindow.Show();
        }

        private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnHeaderGridMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _model.HandleDateChanged();
        }
    }
}
