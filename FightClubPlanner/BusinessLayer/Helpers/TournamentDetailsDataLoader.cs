using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseAccess;
using DataLayer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    public class TournamentDetailsDataLoader : ITournamentDetailsDataLoader
    {
        IManagerTournamentDetailsViewModel _model;
        IFighterEntity _fighterEntity;
        IFightEntity _fightEntity;
        ITournamentFighterEntity _tournamentFighterEntity;
        IInviteEntity _inviteEntity;
        Tournament _tournament;

        public TournamentDetailsDataLoader(IFighterEntity fighterEntity, IFightEntity fightEntity,
            ITournamentFighterEntity tournamentFighterEntity, IInviteEntity inviteEntity)
        {
            _fighterEntity = fighterEntity;
            _fightEntity = fightEntity;
            _tournamentFighterEntity = tournamentFighterEntity;
            _inviteEntity = inviteEntity;
        }

        public void LoadModel(IManagerTournamentDetailsViewModel model, Manager manager, Tournament tournament)
        {
            _model = model;
            _tournament = tournament;

            _model.Manager = manager;
            _model.Tournament = tournament;

            SelectFightsByTournament();
            MapFights();

            SelectTournamentFightersByTournament();
            MapFighters();

            GetAvailableFighters();
        }

        private void GetAvailableFighters()
        {
            var fighters = new List<Fighter>();
            Task loadFighterssTask = Task.Run(async () =>
            {
                fighters = await _fighterEntity.SelectAllFightersAsync();
            });

            loadFighterssTask.Wait();

            _model.InvitableFighters = new ObservableCollection<Fighter>(fighters);

            SetInvitableFighters(fighters);
        }

        private void SelectFightsByTournament()
        {
            Task loadFightsTask = Task.Run(async () =>
            {
                _tournament.Fights =
                    await _fightEntity.SelectAllFightsByTournamentIdAsync(_tournament.Id);
            });

            loadFightsTask.Wait();
        }
        private void MapFights()
        {
            if (_model.Tournament.Fights != null)
            {
                _model.DisplayFights = new ObservableCollection<Fight>(_tournament.Fights);
            }
        }

        private void SelectTournamentFightersByTournament()
        {
            Task loadTournamentFightersTask = Task.Run(async () =>
            {
                _tournament.TournamentFighters =
                    await _tournamentFighterEntity.SelectAllFightersByTournamentIdAsync(_tournament.Id);
            });

            loadTournamentFightersTask.Wait();
        }

        private void MapFighters()
        {
            if (_tournament.TournamentFighters != null)
            {
                _model.DisplayFighters = new ObservableCollection<Fighter>();
                _tournament.TournamentFighters.ForEach(tf => _model.DisplayFighters.Add(tf.Fighter));
            }
        }

        private void SetInvitableFighters(List<Fighter> fighters)
        {
            RemoveAlreadyRegisteredFighters(fighters);
            RemoveAlreadyInvitedFighters(fighters);

            _model.InvitableFighters = new ObservableCollection<Fighter>(fighters);
        }

        private void RemoveAlreadyRegisteredFighters(List<Fighter> fighters)
        {
            foreach (var tournamentFighter in _tournament.TournamentFighters)
            {
                foreach (var fighter in _model.InvitableFighters)
                {
                    if (fighter.Id == tournamentFighter.Id)
                    {
                        fighters.Remove(fighter);
                    }
                }
            }
        }

        private void RemoveAlreadyInvitedFighters(List<Fighter> fighters)
        {
            var sentInvites = new List<Invite>();
            Task selectSentInvitesTask = Task.Run(async () =>
            {
                sentInvites =
                    await _inviteEntity.SelectAllInvitesByTournamentIdAsync(_tournament.Id);
            });

            selectSentInvitesTask.Wait();

            foreach (var invite in sentInvites)
            {
                foreach (var fighter in _model.InvitableFighters)
                {
                    if (fighter.Id == invite.FighterId)
                    {
                        fighters.Remove(fighter);
                    }
                }
            }
        }
    }
}
