using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class TournamentFighter : BaseModel 
    {
        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        [ForeignKey("Fighter")]
        public int FighterId { get; set; }
        public Fighter Fighter { get; set; }
    }
}
