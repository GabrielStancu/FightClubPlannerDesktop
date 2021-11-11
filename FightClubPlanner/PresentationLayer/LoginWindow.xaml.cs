using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseExceptions;
using DataLayer.Models;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        ILoginViewModel _model;
        ILogInChecker _logInChecker;
        ManagerMainWindow _managerMainWindow;
        FighterMainWindow _fighterMainWindow;
        SignUpWindow _signUpWindow;

        public LoginWindow(ILoginViewModel model, ILogInChecker logInChecker,
            ManagerMainWindow managerMainWindow, FighterMainWindow fighterMainWindow,
            SignUpWindow signUpWindow)
        {
            InitializeComponent();

            _model = model;
            _logInChecker = logInChecker;
            _managerMainWindow = managerMainWindow;
            _fighterMainWindow = fighterMainWindow;
            _signUpWindow = signUpWindow;

            this.DataContext = _model;
        }

        private async void OnLoginButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                await _logInChecker.LoginCommand(_model, passwordBox.Password);
                
                if (_model.User.GetType() == typeof(Manager))
                {
                    Hide();
                    _managerMainWindow.SetViewModel((Manager)_model.User);
                    _managerMainWindow.Show();
                    _managerMainWindow.SetLoginWindowReference(this);
                }
                else
                {
                    Hide();
                    _fighterMainWindow.SetViewModel((Fighter)_model.User);
                    _fighterMainWindow.Show();
                    _fighterMainWindow.SetLoginWindowReference(this);
                }

            }
            catch(UserNotRegisteredException ex)
            {
                CustomMessageBox msgBox =
                    new CustomMessageBox("User does not exist", ex.Message, string.Empty, "OK", string.Empty, false);
                msgBox.Show();
            }
            catch(ConnectionFailedException ex)
            {
                //if this gets caught it means the connection string is not correct
                //check the DataLayer.DataAccess.DatabaseContext.FightClubContext class
                CustomMessageBox msgBox =
                    new CustomMessageBox("Bad connection string", ex.Message, string.Empty, "OK", string.Empty, false);
                msgBox.Show();
            }
        }

        private void OnSignUpButtonClicked(object sender, RoutedEventArgs e)
        {
            Hide();
            _signUpWindow.Show();
            _signUpWindow.SetLoginWindowReference(this);
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
