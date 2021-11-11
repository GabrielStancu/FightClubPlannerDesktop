using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Helpers
{
    public class TournamentBuilder : ITournamentBuilder
    {
        private string _name;
        private string _location;
        private int _organizerId;
        private Manager _organizer;
        private List<Fight> _fights;
        private List<TournamentFighter> _tournamentFighters;
        private DateTime _startDate;

        public ITournamentBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ITournamentBuilder WithLocation(string location)
        {
            _location = location;
            return this;
        }

        public ITournamentBuilder WithOrganizer(Manager manager)
        {
            _organizer = manager;
            return this;
        }

        public ITournamentBuilder WithOrganizerId(int id)
        {
            _organizerId = id;
            return this;
        }

        public ITournamentBuilder WithFight(Fight fight)
        {
            InitializeFightsList();
            _fights.Add(fight);

            return this;
        }

        public ITournamentBuilder WithFightDetails(Fighter fighter1, Fighter fighter2, Tournament tournament, DateTime fightTime, Fighter winner)
        {
            Fight fight = new Fight()
            {
                Fighter1 = fighter1,
                Fighter2 = fighter2,
                FighterId1 = fighter1.Id,
                FighterId2 = fighter2.Id,
                Tournament = tournament,
                TournamentId = tournament.Id,
                FightTime = fightTime,
                Winner = winner,
                WinnerId = winner?.Id
            };

            return WithFight(fight);
        }

        public ITournamentBuilder WithFights(List<Fight> fights)
        {
            InitializeFightsList();
            fights.ForEach(f => _fights.Add(f));

            return this;
        }

        public ITournamentBuilder WithTournamentFighter(TournamentFighter tf)
        {
            InitializeTournamentFightersList();
            _tournamentFighters.Add(tf);

            return this;
        }

        public ITournamentBuilder WithTournamentFighters(List<TournamentFighter> tfs)
        {
            InitializeTournamentFightersList();
            tfs.ForEach(tf => _tournamentFighters.Add(tf));

            return this;
        }

        public ITournamentBuilder WithStartDate(DateTime startDate)
        {
            _startDate = startDate;

            return this;
        }

        public ITournamentBuilder WithInitializedValues(string name, string location, Manager manager, List<Fight> fights, 
            List<TournamentFighter> tournamentFighters, DateTime startDate)
        {
            _name = name;
            _location = location;
            _organizer = manager;
            _organizerId = manager.Id;
            _fights = fights;
            _tournamentFighters = tournamentFighters;
            _startDate = startDate;

            return this;
        }

        public Tournament Build()
        {
            var instance = new Tournament()
            {
                Name = _name,
                Location = _location,
                Organizer = _organizer,
                OrganizerId = _organizerId,
                Fights = _fights,
                TournamentFighters = _tournamentFighters,
                StartDate = _startDate
            };

            return instance;
        }

        private void InitializeFightsList()
        {
            if (_fights is null)
            {
                _fights = new List<Fight>();
            }
        }

        private void InitializeTournamentFightersList()
        {
            if (_tournamentFighters is null)
            {
                _tournamentFighters = new List<TournamentFighter>();
            }
        }
    }
}
