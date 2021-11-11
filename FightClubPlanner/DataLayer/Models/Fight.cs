using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Fight : BaseModel
    {
        [ForeignKey("Fighter1")]
        public int FighterId1 { get; set; }
        public Fighter Fighter1 { get; set; }
        [ForeignKey("Fighter2")]
        public int FighterId2 { get; set; }
        public Fighter Fighter2 { get; set; }
        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public DateTime FightTime { get; set; }
        [ForeignKey("Winner")]
        public int? WinnerId { get; set; }
        private Fighter _winner;
#nullable enable
        public Fighter? Winner 
        {
            get => _winner; 
            set
            {
                _winner = value;
                OnPropertyChanged("Winner");
            }
        }
        [NotMapped]
        public bool IsWinnerSet { get => Winner == null; }
    }
}