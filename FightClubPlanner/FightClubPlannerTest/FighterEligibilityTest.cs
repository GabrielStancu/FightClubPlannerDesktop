using DataLayer.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FightClubPlannerTest
{
    public class FighterEligibilityTest
    {
        private Fighter _eligibleFighter;
        private Fighter _nonEligibleFighterPositiveTested;
        private Fighter _nonEligibleFighterNotTestedEnough;

        [SetUp]
        public void Setup()
        {
            InstantiateEligibleFighter();
            InstantiateNotEligibleFighterPositiveTested();
            InstantiateNotEligibleFighterNotTestedEnough();
        }

        [Test]
        public void GivenEligibleFighterItCanFight()
        {
            Assert.True(_eligibleFighter.CanFight(DateTime.Today));
        }

        [Test]
        public void GivenPositiveTestedFighterItCannotFight()
        {
            Assert.False(_nonEligibleFighterPositiveTested.CanFight(DateTime.Today));
        }

        [Test]
        public void GivenNotTestedEnoughFighterItCannotFight()
        {
            Assert.False(_nonEligibleFighterNotTestedEnough.CanFight(DateTime.Today));
        }

        private void InstantiateEligibleFighter()
        {
            var covidTests = new List<CovidTest>()
            {
                new CovidTest()
                {
                    IsPositive = false,
                    TestDate = DateTime.Today
                },
                new CovidTest()
                {
                    IsPositive = false,
                    TestDate = DateTime.Today.AddDays(-7)
                },
                new CovidTest()
                {
                    IsPositive = false,
                    TestDate = DateTime.Today.AddDays(-14)
                }
            };

            _eligibleFighter = new Fighter()
            {
                TestHistory = covidTests
            };
        }

        private void InstantiateNotEligibleFighterPositiveTested()
        {
            var covidTests = new List<CovidTest>()
            {
                new CovidTest()
                {
                    IsPositive = false,
                    TestDate = DateTime.Today
                },
                new CovidTest()
                {
                    IsPositive = true,
                    TestDate = DateTime.Today.AddDays(-7)
                },
                new CovidTest()
                {
                    IsPositive = false,
                    TestDate = DateTime.Today.AddDays(-14)
                }
            };

            _nonEligibleFighterPositiveTested = new Fighter()
            {
                TestHistory = covidTests
            };
        }

        private void InstantiateNotEligibleFighterNotTestedEnough()
        {
            var covidTests = new List<CovidTest>()
            {
                new CovidTest()
                {
                    IsPositive = false,
                    TestDate = DateTime.Today
                },
                new CovidTest()
                {
                    IsPositive = false,
                    TestDate = DateTime.Today.AddDays(-14)
                }
            };

            _nonEligibleFighterNotTestedEnough = new Fighter()
            {
                TestHistory = covidTests
            };
        }
    }
}
