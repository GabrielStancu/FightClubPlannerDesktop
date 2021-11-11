using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseAccess;
using DataLayer.Models;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public class FighterHealthTester : IFighterHealthTester
    {
        ICovidTestEntity _covidTestEntity;
        public FighterHealthTester(ICovidTestEntity covidTestEntity)
        {
            _covidTestEntity = covidTestEntity;
        }
        public async void TestFighter(IFighterMainWindowViewModel model)
        {
            model.RegisterTestEnable = false;
            var fighter = model.Fighter;

            if (fighter.TestHistory.Count == 0)
            {
                CovidTest ownTest = await RegisterOwnTest(model);
                model.Tests.Add(ownTest);
                fighter.TestHistory.Add(ownTest);
            }

            CovidTest bubbleTest = await RegisterTestBubbleTest(model);
            model.Tests.Add(bubbleTest);
            fighter.TestHistory.Add(bubbleTest);

            fighter.IsEligible = fighter.CanFight(DateTime.Today);
        }

        private async Task<CovidTest> RegisterOwnTest(IFighterMainWindowViewModel model)
        {
            var fighter = model.Fighter;

            CovidTest fighterTest = new CovidTest()
            {
                FighterId = fighter.Id,
                IsPositive = model.IsPositive,
                IsolationBubbleId = model.IsolationBubble.Id,
                TestDate = DateTime.Today
            };
            await _covidTestEntity.InsertAsync(fighterTest);

            fighterTest.IsolationBubble = model.IsolationBubble;

            return fighterTest;
        }

        private async Task<CovidTest> RegisterTestBubbleTest(IFighterMainWindowViewModel model)
        {
            var fighter = model.Fighter;

            CovidTest onTheSpotTest = new CovidTest()
            {
                FighterId = fighter.Id,
                IsPositive = new Random().Next(0, 100) >= 92,
                IsolationBubbleId = model.IsolationBubble.Id,
                TestDate = DateTime.Today
            };
            await _covidTestEntity.InsertAsync(onTheSpotTest);

            onTheSpotTest.IsolationBubble = model.IsolationBubble;

            return onTheSpotTest;
        }
    }
}
