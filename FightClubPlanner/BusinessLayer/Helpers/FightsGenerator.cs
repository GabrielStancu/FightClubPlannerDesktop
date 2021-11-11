using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseAccess;
using DataLayer.Models;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public class FightsGenerator : IFightsGenerator
    {
        IFightEntity _fightEntity;
        IFighterEntity _fighterEntity;
        ITournamentBuilder _builder;
        public FightsGenerator(IFightEntity fightEntity, IFighterEntity fighterEntity, ITournamentBuilder builder)
        {
            _fightEntity = fightEntity;
            _fighterEntity = fighterEntity;
            _builder = builder;
        }
        public async Task<bool> GenerateFights(IManagerTournamentDetailsViewModel model, Tournament tournament)
        {
            if (DateTime.Today > model.SelectedDate)
            {
                return false;
            }

            int fightsNumber = new Random().Next(2, 2 + tournament.TournamentFighters.Count / 10);

            for (int fightIndex = 0; fightIndex < fightsNumber; fightIndex++)
            {
                DateTime fightDate = model.SelectedDate;
                (Fighter Fighter1, Fighter Fighter2) = await GetBestMatch(fightDate, tournament);

                if (Fighter1.Id > 0 && Fighter2.Id > 0)
                {
                    Fight fight = new Fight()
                    {
                        TournamentId = tournament.Id,
                        FightTime = fightDate,
                        FighterId1 = Fighter1.Id,
                        FighterId2 = Fighter2.Id
                    };

                    await _fightEntity.InsertAsync(fight);

                    fight.Fighter1 = Fighter1;
                    fight.Fighter2 = Fighter2;
                    model.DisplayFights.Add(fight);
                }
            }

            return true;
        }

        private async Task<(Fighter Fighter1, Fighter Fighter2)> GetBestMatch(DateTime fightDate, Tournament tournament)
        {
            var fighters = await _fighterEntity.SelectAllFightersFromTournamentAsync(tournament.Id);
            double minQuota = - 1;
            Fighter fighter1 = new Fighter();
            Fighter fighter2 = new Fighter();

            foreach (var f1 in fighters)
            {
                if (!f1.CanFight(fightDate))
                {
                    continue;
                }
                foreach (var f2 in fighters)
                {
                    if (!f2.CanFight(fightDate))
                    {
                        continue;
                    }
                    if (f1 != f2)
                    {
                        double crtQuota = await ComputeQuota(f1, f2, tournament);

                        if (minQuota == -1)
                        {
                            minQuota = crtQuota;
                            fighter1 = f1;
                            fighter2 = f2;
                        }
                        else if (crtQuota < minQuota)
                        {
                            minQuota = crtQuota;
                            fighter1 = f1;
                            fighter2 = f2;
                        }
                    }
                }
            }

            return (fighter1, fighter2);
        }

        private async Task<double> ComputeQuota(Fighter f1, Fighter f2, Tournament tournament)
        {
            int ageDifference = Math.Abs(f1.Age - f2.Age);
            int heightDifference = Math.Abs(f1.Height - f2.Height);
            int weightDifference = Math.Abs(f1.Weight - f2.Weight);
            int fightersCount =
                await _fightEntity.SelectCountOfFightsBetweenFightersInTournamentAsync(f1.Id, f2.Id, tournament.Id);

            return 0.05 * ageDifference +
                    0.05 * weightDifference +
                    0.05 * heightDifference +
                    1.85 * fightersCount;
        }
    }
}
