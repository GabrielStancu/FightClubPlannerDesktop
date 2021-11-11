using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Helpers
{
    public interface ITournamentBuilder
    {
        Tournament Build();
        ITournamentBuilder WithName(string name);
        ITournamentBuilder WithLocation(string location);
        ITournamentBuilder WithOrganizer(Manager manager);
        ITournamentBuilder WithOrganizerId(int id);
        ITournamentBuilder WithFight(Fight fight);
        ITournamentBuilder WithFightDetails(Fighter fighter1, Fighter fighter2, Tournament tournament, DateTime fightTime, Fighter winner);
        ITournamentBuilder WithInitializedValues(string name, string location, Manager manager, List<Fight> fights,
            List<TournamentFighter> tournamentFighters, DateTime startDate);
        ITournamentBuilder WithFights(List<Fight> fights);
        ITournamentBuilder WithTournamentFighter(TournamentFighter tf);
        ITournamentBuilder WithTournamentFighters(List<TournamentFighter> tfs);
        ITournamentBuilder WithStartDate(DateTime startDate);
    }
}