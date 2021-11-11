using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public interface IIsolationBubbleEntity : IGenericEntity<IsolationBubble>
    {
        Task<bool> CheckIfBubbleAlreadyExistsAsync(string name);
        Task<List<IsolationBubble>> SelectAllIsolationBubblesAsync();
    }
}