using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataLayer.Models
{
    public class Fighter : User
    {
        [NotMapped]
        public List<Fight> FightHistory { get; set; }
        public List<CovidTest> TestHistory { get; set; }
        public DateTime Birthday { get; set; }
        [NotMapped]
        public int Age { get => (DateTime.Today - Birthday).Days / 365; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public List<TournamentFighter> TournamentFighters { get; set; }
        private bool _isEligible = true;
        [NotMapped]
        public bool IsEligible {
            get
            {
                return _isEligible;
            } 
            set
            {
                _isEligible = value;
                OnPropertyChanged("IsEligible");
            }
        }

        public bool CanFight(DateTime fightDate)
        {
            if (TestHistory is null)
            {
                return false;
            }

            Func<CovidTest, bool> testsTwoWeeksAgo = t => (fightDate - t.TestDate).Days <= 20 && (fightDate - t.TestDate).Days >= 14;
            Func<CovidTest, bool> testsOneWeekAgo = t => (fightDate - t.TestDate).Days <= 13 && (fightDate - t.TestDate).Days >= 7;
            Func<CovidTest, bool> testsThisWeek = t => (fightDate - t.TestDate).Days <= 6 && (fightDate - t.TestDate).Days >= 0;

            return TestHistory.Count > 0 &&
                    TestHistory.Any(testsTwoWeeksAgo) &&
                    TestHistory.Any(testsOneWeekAgo) &&
                    TestHistory.Any(testsThisWeek) &&
                    TestHistory.Where(testsTwoWeeksAgo).All(t => t.IsPositive == false) &&
                    TestHistory.Where(testsOneWeekAgo).All(t => t.IsPositive == false) &&
                    TestHistory.Where(testsThisWeek).All(t => t.IsPositive == false);
        }
    }
}