using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Invite : BaseModel
    {
        [ForeignKey("Fighter")]
        public int FighterId { get; set; }
        public Fighter Fighter { get; set; }
        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public DateTime DateSent { get; set; }
        private InviteState _inviteState;
        public InviteState InviteState
        {
            get => _inviteState;
            set
            {
                _inviteState = value;
                OnPropertyChanged("InviteState");
            }
        }
    }
}
