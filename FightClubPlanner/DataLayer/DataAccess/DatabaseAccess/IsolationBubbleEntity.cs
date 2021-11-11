using DataLayer.DataAccess.DatabaseExceptions;
using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public class IsolationBubbleEntity : GenericEntity<IsolationBubble>, IIsolationBubbleEntity
    {
        public async Task<List<IsolationBubble>> SelectAllIsolationBubblesAsync()
        {
            try
            {
                using var context = CreateContext();
                return await
                    context.IsolationBubbles
                        .ToListAsync();
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }

        public async Task<bool> CheckIfBubbleAlreadyExistsAsync(string name)
        {
            try
            {
                using var context = CreateContext();
                var bubbles = await
                    context.IsolationBubbles
                        .Where(ib => ib.Name.Equals(name))
                        .ToListAsync();
                return bubbles.Count > 0;
            }
            catch (SqlException)
            {
                throw new ConnectionFailedException();
            }
        }
    }
}
