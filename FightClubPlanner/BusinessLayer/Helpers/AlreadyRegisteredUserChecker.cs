using DataLayer.DataAccess.DatabaseAccess;
using DataLayer.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public class AlreadyRegisteredUserChecker : IAlreadyRegisteredUserChecker
    {
        IManagerEntity _managerEntity;
        IFighterEntity _fighterEntity;
        public AlreadyRegisteredUserChecker(IManagerEntity managerEntity, IFighterEntity fighterEntity)
        {
            _managerEntity = managerEntity;
            _fighterEntity = fighterEntity;
        }
        public async Task<bool> Exists(User user)
        {
            bool existsManager = await _managerEntity.CheckAlreadyRegisteredUserAsync(user.Username);
            bool existsFighter = await _fighterEntity.CheckAlreadyRegisteredUserAsync(user.Username);

            return existsManager && existsFighter;
        }
    }
}
