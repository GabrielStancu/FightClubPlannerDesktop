using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataLayer.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for ManagerMainWindow.xaml
    /// </summary>
    public partial class ManagerMainWindow : Window
    {
        IManagerMainWindowViewModel _model;
        ITournamentCreator _creator;
        IManagerDataLoader _managerDataLoader;
        ManagerTournamentDetailsWindow _managerTournamentDetailsWindow;
        AddIsolationBubbleWindow _addIsolationBubbleWindow;
        LoginWindow _loginWindow;

        public ManagerMainWindow(IManagerMainWindowViewModel model, 
            IManagerDataLoader managerDataLoader, ITournamentCreator creator, 
            ManagerTournamentDetailsWindow managerTournamentDetailsWindow,
            AddIsolationBubbleWindow addIsolationBubbleWindow)
        {
            InitializeComponent();
            _model = model;
            _creator = creator;
            _managerDataLoader = managerDataLoader;
            _managerTournamentDetailsWindow = managerTournamentDetailsWindow;
            _addIsolationBubbleWindow = addIsolationBubbleWindow;
        }

        public void SetLoginWindowReference(LoginWindow loginWindow)
        {
            _loginWindow = loginWindow;
        }

        public void SetViewModel(Manager manager)
        {
            _managerDataLoader.LoadModel(_model, manager);
            this.DataContext = null;
            this.DataContext = _model;
        }

        private async void OnCreateTournamentButtonClicked(object sender, RoutedEventArgs e)
        {
            bool registeredTournament = await _creator.RegisterTournament(_model);

            if(registeredTournament)
            {
                CustomMessageBox msgBox =
                    new CustomMessageBox("Success", "Tournament was created!", string.Empty, "OK", string.Empty, false);
                msgBox.Show();
            }
            else
            {
                CustomMessageBox msgBox =
                    new CustomMessageBox("Failed", "Required fields not complete, tournament name taken or start date is set in the past!", string.Empty, "OK", string.Empty, false);
                msgBox.Show();
            }
        }

        private void OnTournamentsDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hide();
            _managerTournamentDetailsWindow.SetViewModel(_model.Manager, _model.SelectedTournament);         
            _managerTournamentDetailsWindow.SetManagerWindowReference(this);
            _managerTournamentDetailsWindow.Show();
        }

        private void OnSettingsButtonClicked(object sender, RoutedEventArgs e)
        {
            _addIsolationBubbleWindow.Show();
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

        private void OnHeaderGridMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
