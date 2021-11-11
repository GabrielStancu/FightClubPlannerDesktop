using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseAccess;
using DataLayer.Models;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public class TournamentCreator : ITournamentCreator
    {
        ITournamentBuilder _tournamentBuilder;
        ITournamentEntity _tournamentEntity;
        public TournamentCreator(ITournamentBuilder tournamentBuilder, ITournamentEntity tournamentEntity)
        {
            _tournamentBuilder = tournamentBuilder;
            _tournamentEntity = tournamentEntity;
        }
        public async Task<bool> RegisterTournament(IManagerMainWindowViewModel model)
        {
            if (model.TournamentStartDate < DateTime.Today || 
                model.TournamentLocation is null || model.TournamentLocation.Equals(string.Empty) ||
                model.TournamentName is null || model.TournamentName.Equals(string.Empty))
            {
                return false;
            }

            Tournament tournament = _tournamentBuilder
                .WithName(model.TournamentName)
                .WithLocation(model.TournamentLocation)
                .WithOrganizerId(model.Manager.Id)
                .WithStartDate(model.TournamentStartDate)
                .Build();

            await _tournamentEntity.InsertAsync(tournament);

            model.Tournaments.Add(tournament);

            return true;
        }
    }
}
