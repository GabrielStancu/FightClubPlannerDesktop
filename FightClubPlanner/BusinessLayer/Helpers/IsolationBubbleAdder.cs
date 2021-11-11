using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseAccess;
using DataLayer.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public class IsolationBubbleAdder : IIsolationBubbleAdder
    {
        IIsolationBubbleEntity _isolationBubbleEntity;
        public IsolationBubbleAdder(IIsolationBubbleEntity isolationBubbleEntity)
        {
            _isolationBubbleEntity = isolationBubbleEntity;
        }
        public async Task<bool> AddBubble(IAddIsolationBubbleViewModel model)
        {
            if (await CheckIfBubbleAlreadyExists(model.BubbleName))
            {
                return false;
            }

            var isolationBubble = new IsolationBubble()
            {
                Name = model.BubbleName
            };
            await _isolationBubbleEntity.InsertAsync(isolationBubble);
            model.BubbleName = string.Empty;

            return true;
        }

        private async Task<bool> CheckIfBubbleAlreadyExists(string name)
        {
            return await _isolationBubbleEntity.CheckIfBubbleAlreadyExistsAsync(name);
        }
    }
}
