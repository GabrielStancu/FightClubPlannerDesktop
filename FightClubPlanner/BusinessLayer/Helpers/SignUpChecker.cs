using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseAccess;
using DataLayer.DataAccess.DatabaseExceptions;
using DataLayer.Models;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public class SignUpChecker : ISignUpChecker
    {
        ISignUpViewModel _model;
        IManagerEntity _managerEntity;
        IFighterEntity _fighterEntity;

        public SignUpChecker(IManagerEntity managerEntity, IFighterEntity fighterEntity)
        {
            _managerEntity = managerEntity;
            _fighterEntity = fighterEntity;
        }

        public async Task<bool> SignUp(ISignUpViewModel model, string password, string repeatedPassword)
        {
            _model = model;
            _model.Password = password;
            _model.RepeatPassword = repeatedPassword;

            if (await AlreadyRegisteredUser())
            {
                throw new UserAlreadyRegisteredException();
            }

            if (BadCredentials())
            {
                return false;
            }

            if (_model.UserType.Equals(SignUpViewModel.ManagerString) && AllManagerFieldsComplete())
            {
                return await RegisterManager();
            }
            else if (AllFighterFieldsComplete())
            {
                return await RegisterFighter();
            }

            return false;
        }

        private async Task<bool> AlreadyRegisteredUser()
        {
            bool registeredManager = await _managerEntity.CheckAlreadyRegisteredUserAsync(_model.Username);

            if (!registeredManager)
            {
                bool registeredFighter = await _fighterEntity.CheckAlreadyRegisteredUserAsync(_model.Username);

                if (!registeredFighter)
                {
                    return false;
                }
            }

            return true;
        }

        private async Task<bool> RegisterManager()
        {
            Manager manager = new Manager()
            {
                Username = _model.Username,
                Password = _model.Password,
                FirstName = _model.FirstName,
                LastName = _model.LastName
            };
            await _managerEntity.InsertAsync(manager);

            return true;
        }

        private async Task<bool> RegisterFighter()
        {
            Fighter fighter = new Fighter()
            {
                Username = _model.Username,
                Password = _model.Password,
                FirstName = _model.FirstName,
                LastName = _model.LastName,
                Height = _model.Height,
                Weight = _model.Weight,
                Birthday = _model.Birthday
            };
            await _fighterEntity.InsertAsync(fighter);

            return true;
        }

        private bool BadCredentials()
        {
            if (!_model.Password.Equals(_model.RepeatPassword))
            {
                return true;
            }

            if (!IsNameValid(_model.FirstName) || !IsNameValid(_model.LastName))
            {
                return true;
            }

            if (_model.UserType.Equals(SignUpViewModel.ManagerString))
            {
                return false;
            }

            if ((DateTime.Today - _model.Birthday).Days / 365 < 18)
            {
                return true;
            }

            if (_model.Height < 100 || _model.Height > 300)
            {
                return true;
            }

            if (_model.Weight < 30 || _model.Weight > 200)
            {
                return true;
            }

            return false;
        }

        private bool IsNameValid(string name)
        {
            string rgx = "[A-Z][a-z]+";
            var match = Regex.Match(name, rgx);

            return match.Value.Equals(name);
        }

        private bool AllManagerFieldsComplete()
        {
            return !_model.Username.Equals(string.Empty) &&
                !_model.Password.Equals(string.Empty) &&
                !_model.FirstName.Equals(string.Empty) &&
                !_model.LastName.Equals(string.Empty);
        }

        private bool AllFighterFieldsComplete()
        {
            return !_model.Username.Equals(string.Empty) &&
                !_model.Password.Equals(string.Empty) &&
                !_model.FirstName.Equals(string.Empty) &&
                !_model.LastName.Equals(string.Empty) &&
                !_model.Birthday.Equals(DateTime.Now) &&
                _model.Height != 0 &&
                _model.Weight != 0;
        }
    }
}
