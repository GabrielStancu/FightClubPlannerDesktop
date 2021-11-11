using System;
using System.Collections.ObjectModel;

namespace BusinessLayer.ViewModels
{
    public interface ISignUpViewModel
    {
        DateTime Birthday { get; set; }
        bool EnabledFighterFields { get; set; }
        string FirstName { get; set; }
        int Height { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string RepeatPassword { get; set; }
        string Username { get; set; }
        string UserType { get; set; }
        ObservableCollection<string> UserTypes { get; set; }
        int Weight { get; set; }

        void ChangeUserType();
    }
}