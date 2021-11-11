using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataLayer;
using DataLayer.Models;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for FighterMainWindow.xaml
    /// </summary>
    public partial class FighterMainWindow : Window
    {
        IFighterMainWindowViewModel _model;
        IFighterDataLoader _loader;
        IFighterHealthTester _healthTester;
        IFighterInviteAnswerer _inviteAnswerer;
        LoginWindow _loginWindow;
        public FighterMainWindow(IFighterMainWindowViewModel model, IFighterDataLoader loader,
            IFighterHealthTester healthTester, IFighterInviteAnswerer inviteAnswerer)
        {
            InitializeComponent();

            _model = model;
            _loader = loader;
            _healthTester = healthTester;
            _inviteAnswerer = inviteAnswerer;
        }

        public void SetLoginWindowReference(LoginWindow loginWindow)
        {
            _loginWindow = loginWindow;
        }

        public void SetViewModel(Fighter fighter)
        {
            _loader.LoadModel(_model, fighter);
            DataContext = null;
            DataContext = _model;
        }

        private void OnRegisterTestButtonClicked(object sender, RoutedEventArgs e)
        {
            _healthTester.TestFighter(_model);
            _model.SelfTestEnable = false;
        }

        private void OnInvitesDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var invite = _model.SelectedInvite;

            if(invite.InviteState == InviteState.NotAnswered)
            {
                CustomMessageBox msgBox =
                    new CustomMessageBox("Tournament invite", $"Do you accept the invite for {invite.Tournament.Name}", "Yes", "No", "Cancel", true);
                msgBox.Show();

                msgBox.Show();
                msgBox.Closing += OnMsgBoxClosing;
            }
        }

        private async void OnMsgBoxClosing(object sender, CancelEventArgs e)
        {
            var result = ((CustomMessageBox)sender).Result;

            if (result == CustomMessageBoxResult.FirstOption)
            {
                await _inviteAnswerer.AnswerInvite(_model, InviteState.Accepted);
            }

            else if (result == CustomMessageBoxResult.SecondOption)
            {
                await _inviteAnswerer.AnswerInvite(_model, InviteState.Declined);
            }

            else
            {
                await _inviteAnswerer.AnswerInvite(_model, InviteState.NotAnswered);
            }
        }

        private void OnHeaderGridMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void OnBackButtonClicked(object sender, RoutedEventArgs e)
        {
            Hide();
            _loginWindow.Show();
        }

        private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
