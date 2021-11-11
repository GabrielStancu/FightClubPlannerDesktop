using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class CovidTest : BaseModel
    {
        public bool IsPositive { get; set; }
        public DateTime TestDate { get; set; }
        [ForeignKey("Fighter")]
        public int FighterId { get; set; }
        public Fighter Fighter { get; set; }
        [ForeignKey("IsolationBubble")]
        public int IsolationBubbleId { get; set; }
        public IsolationBubble IsolationBubble {get; set;}
    }
}