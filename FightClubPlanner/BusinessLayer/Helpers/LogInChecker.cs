using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseAccess;
using DataLayer.DataAccess.DatabaseAccess;
using DataLayer.DataAccess.DatabaseExceptions;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public class LogInChecker : ILogInChecker
    {
        IManagerEntity _managerEntity;
        IFighterEntity _fighterEntity;
        public LogInChecker(IManagerEntity managerEntity, IFighterEntity fighterEntity)
        {
            _managerEntity = managerEntity;
            _fighterEntity = fighterEntity;
        }
        public async Task LoginCommand(ILoginViewModel model, string parameter)
        {
            try
            {
                var manager = await _managerEntity.SelectUserWithLoginInformationAsync(model.Username, parameter);

                if (manager is null)
                {
                    var fighter = await _fighterEntity.SelectUserWithLoginInformationAsync(model.Username, parameter);

                    if (fighter is null)
                    {
                        throw new UserNotRegisteredException();
                    }
                    else
                    {
                        model.User = fighter;
                    }
                }
                else
                {
                    model.User = manager;
                }
            }
            catch (ConnectionFailedException ex)
            {
                throw ex;
            }
        }
    }
}
