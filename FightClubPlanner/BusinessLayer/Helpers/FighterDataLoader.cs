using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseAccess;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public class FighterDataLoader : IFighterDataLoader
    {
        IFighterMainWindowViewModel _model;
        Fighter _fighter;

        IIsolationBubbleEntity _isolationBubbleEntity;
        IFightEntity _fightEntity;
        ITournamentFighterEntity _tournamentFighterEntity;
        IInviteEntity _inviteEntity;

        public FighterDataLoader(IIsolationBubbleEntity isolationBubbleEntity, IFightEntity fightEntity,
            ITournamentFighterEntity tournamentFighterEntity, IInviteEntity inviteEntity)
        {
            _isolationBubbleEntity = isolationBubbleEntity;
            _fightEntity = fightEntity;
            _tournamentFighterEntity = tournamentFighterEntity;
            _inviteEntity = inviteEntity;
        }

        public void LoadModel(IFighterMainWindowViewModel model, Fighter fighter)
        {
            _model = model;
            _model.RegisterTestEnable = true;
            _model.IsPositive = false;
            LoadFighter(fighter);
            LoadIsolationBubbles();
            LoadCovidTestsForFighter();
            LoadFightsForFighter();
            LoadTournamentsForFighter();
            LoadInvitesForFighter();
        }

        private void LoadFighter(Fighter fighter)
        {
            _fighter = fighter;
            _model.Fighter = _fighter;
            _fighter.IsEligible = _fighter.CanFight(DateTime.Today);
        }

        private void LoadIsolationBubbles()
        {
            Task loadIsolationBubblesTask = Task.Run(async () =>
            {
                _model.IsolationBubbles = new ObservableCollection<IsolationBubble>(
                    await _isolationBubbleEntity.SelectAllIsolationBubblesAsync());
            });

            loadIsolationBubblesTask.Wait();
        }

        private void LoadCovidTestsForFighter()
        {
            _model.Tests = new ObservableCollection<CovidTest>(
                _fighter.TestHistory);
            _model.SelfTestEnable = _model.Tests.Count == 0;
        }

        private void LoadFightsForFighter()
        {
            Task loadFightsTask = Task.Run(async () =>
            {
                _model.Fights = new ObservableCollection<Fight>(
                    await _fightEntity.SelectAllFightsByFighterIdAsync(_fighter.Id));
            });

            loadFightsTask.Wait();
        }

        private void LoadTournamentsForFighter()
        {
            var tournamentFighters = new List<TournamentFighter>();
            Task loadTournamentsTask = Task.Run(async () =>
            {
                tournamentFighters = 
                    await _tournamentFighterEntity.SelectAllTournamentsByFighterIdAsync(_fighter.Id);
            });

            loadTournamentsTask.Wait();
            _model.Tournaments = new ObservableCollection<Tournament>();
            tournamentFighters.ForEach(tf => _model.Tournaments.Add(tf.Tournament));
        }

        private void LoadInvitesForFighter()
        {
            Task loadFighterInvites = Task.Run(async () =>
            {
                _model.Invites = new ObservableCollection<Invite>(
                    await _inviteEntity.SelectAllInvitesByFighterIdAsync(_fighter.Id)
                    );
            });

            loadFighterInvites.Wait();
        }

        
    }
}
