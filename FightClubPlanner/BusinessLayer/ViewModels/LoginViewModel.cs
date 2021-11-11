using DataLayer.Models;

namespace BusinessLayer.ViewModels
{
    public class LoginViewModel : BaseViewModel, ILoginViewModel
    {
        string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                SetProperty<string>(ref _username, value);
            }
        }

        private User _user;
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                SetProperty<User>(ref _user, value);
            }
        }
    }
}
