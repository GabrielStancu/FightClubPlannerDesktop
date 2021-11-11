using BusinessLayer.Helpers;
using DataLayer.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FightClubPlannerTest
{
    public class BuilderTest
    {
        private Tournament _tournament;
        private Manager _manager;
        private List<Fight> _fights;
        private List<TournamentFighter> _tournamentFighters;
        [SetUp]
        public void Setup()
        {
            SetTournamentManager();
            SetTournamentFights();
            SetTournamentFighters();
            SetTournament();
        }

        [Test]
        public void GivenRequiredDataBuilderConstructsTournamentCorrectly()
        {
            var builder = new TournamentBuilder();
            var tournament = builder
                .WithLocation("Test location")
                .WithName("Test name")
                .WithOrganizer(_manager)
                .WithOrganizerId(_manager.Id)
                .WithStartDate(DateTime.Today)
                .WithFights(_fights)
                .WithTournamentFighters(_tournamentFighters)
                .Build();

            Assert.True(SameTournament(tournament, _tournament));
        }

        private bool SameTournament(Tournament tournament1, Tournament tournament2)
        {
            return
                tournament1.Location.Equals(tournament2.Location) &&
                tournament1.Name.Equals(tournament2.Name) &&
                tournament1.Organizer == tournament2.Organizer &&
                tournament1.OrganizerId == tournament2.OrganizerId &&
                tournament1.StartDate == tournament2.StartDate &&
                tournament1.Fights
                    .TrueForAll(f => tournament2.Fights[tournament1.Fights.IndexOf(f)] == f) &&
                tournament1.TournamentFighters
                    .TrueForAll(f => tournament2.TournamentFighters[tournament1.TournamentFighters.IndexOf(f)] == f);
        }

        private void SetTournamentManager()
        {
            _manager = new Manager()
            {
                Id = 100,
                FirstName = "Test",
                LastName = "Manager"
            };
        }

        private void SetTournamentFights()
        {
            _fights = new List<Fight>()
            {
                new Fight()
                {
                    Id = 101,
                    FighterId1 = 103,
                    FighterId2 = 104,
                    FightTime = DateTime.Today
                }
            };
        }

        private void SetTournamentFighters()
        {
            _tournamentFighters = new List<TournamentFighter>()
            {
                new TournamentFighter()
                {
                    Id = 102,
                    FighterId = 101,
                    TournamentId = 100
                }
            };
        }

        private void SetTournament()
        {
            _tournament = new Tournament()
            {
                Id = 100,
                Location = "Test location",
                Name = "Test name",
                Organizer = _manager,
                OrganizerId = _manager.Id,
                StartDate = DateTime.Today,
                Fights = _fights,
                TournamentFighters = _tournamentFighters
            };
        }
    }
}
