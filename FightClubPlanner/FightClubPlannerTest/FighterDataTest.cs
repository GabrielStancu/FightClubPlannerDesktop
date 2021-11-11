using DataLayer.DataAccess.DatabaseContext;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace FightClubPlannerTests
{
    public class FighterDataTest
    {
        private FightClubContext _context;
        [SetUp]
        public void Setup()
        {
            _context = (FightClubContext)Activator.CreateInstance(typeof(FightClubContext));
            _context.Database.EnsureCreated();
            _context.Fighters.Add(new Fighter()
            {
                FirstName = "Test",
                LastName = "Fighter",
                Birthday = DateTime.Today
            });
            _context.SaveChanges();
        }

        [Test]
        public void GivenValidDbReadFightersWorks()
        {
            var fighter = _context.Fighters.FirstOrDefault(f => f.FirstName.Equals("Test")); //and remove if to clear database
            Cleanup(fighter);
            Assert.NotNull(fighter);
        }

        [Test]
        public void GivenValidDbRemoveFighterWorks()
        {
            var fighter = _context.Fighters.FirstOrDefault(f => f.FirstName.Equals("Test"));
            _context.Fighters.Remove(fighter);
            _context.SaveChanges();

            var exists = _context.Fighters.Find(fighter.Id);
            Assert.Null(exists);
        }

        //remove the inserted entity from the database
        private void Cleanup(Fighter fighter)
        {
            _context.Fighters.Remove(fighter);
            _context.SaveChanges();
        }
    }
}
