using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseExceptions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        ISignUpViewModel _model;
        ISignUpChecker _signUpChecker;
        LoginWindow _loginWindow;
        public SignUpWindow(ISignUpViewModel model, ISignUpChecker signUpChecker)
        {
            InitializeComponent();
            _model = model;
            _signUpChecker = signUpChecker;

            DataContext = _model;
        }

        public void SetLoginWindowReference(LoginWindow loginWindow)
        {
            _loginWindow = loginWindow;
        }

        private async void OnSignUpButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                bool signedUp = await _signUpChecker.SignUp(_model, passwordBox.Password, repeatPasswordBox.Password);

                if (signedUp)
                {
                    CustomMessageBox msgBox =
                        new CustomMessageBox("Success", "User successfully registered!", string.Empty, "OK", string.Empty, false);
                    msgBox.Show();
                    Hide();
                    _loginWindow.Show();
                }
                else
                {
                    CustomMessageBox msgBox =
                        new CustomMessageBox("Failed", "Some credentials are missing or not correct!", string.Empty, "OK", string.Empty, false);
                    msgBox.Show();
                }
            }
            catch(UserAlreadyRegisteredException ex)
            {
                CustomMessageBox msgBox =
                        new CustomMessageBox("Failed",ex.Message, string.Empty, "OK", string.Empty, false);
                msgBox.Show();
            }
        }

        private void OnUserTypeChanged(object sender, SelectionChangedEventArgs e)
        {
            _model.ChangeUserType();
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
