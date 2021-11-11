using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public interface ICovidTestEntity : IGenericEntity<CovidTest>
    {
        Task<List<CovidTest>> SelectCovidTestsForFighterAsync(int id);
    }
}