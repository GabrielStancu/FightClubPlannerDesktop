using System;
using System.Collections.ObjectModel;

namespace BusinessLayer.ViewModels
{
    public class SignUpViewModel : BaseViewModel, ISignUpViewModel
    {
        internal const string ManagerString = "Manager";
        internal const string FighterString = "Fighter";
        public ObservableCollection<string> UserTypes { get; set; } =
            new ObservableCollection<string>() { ManagerString, FighterString };

        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                SetProperty<string>(ref _username, value);
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                SetProperty<string>(ref _password, value);
            }
        }

        private string _repeatPassword = string.Empty;
        public string RepeatPassword
        {
            get => _repeatPassword;
            set
            {
                _repeatPassword = value;
                SetProperty<string>(ref _repeatPassword, value);
            }
        }

        private string _firstName = string.Empty;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                SetProperty<string>(ref _firstName, value);
            }
        }

        private string _lastName = string.Empty;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                SetProperty<string>(ref _lastName, value);
            }
        }

        private int _weight;
        public int Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                SetProperty<int>(ref _weight, value);
            }
        }

        private int _height;
        public int Height
        {
            get => _height;
            set
            {
                _height = value;
                SetProperty<int>(ref _height, value);
            }
        }

        private DateTime _birthday = DateTime.Now;
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                SetProperty<DateTime>(ref _birthday, value);
            }
        }

        private bool _enabledFighterFields = true;
        public bool EnabledFighterFields
        {
            get => _enabledFighterFields;
            set
            {
                _enabledFighterFields = value;
                SetProperty<bool>(ref _enabledFighterFields, value);
            }
        }

        private string _userType = FighterString;
        public string UserType
        {
            get => _userType;
            set
            {
                _userType = value;
                SetProperty<string>(ref _userType, value);
            }
        }

        public void ChangeUserType()
        {
            EnabledFighterFields = UserType.Equals(FighterString);
        }
    }
}
