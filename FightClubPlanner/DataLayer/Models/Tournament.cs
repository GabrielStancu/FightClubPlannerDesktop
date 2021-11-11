using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Tournament : BaseModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        [ForeignKey("Manager")]
        public int OrganizerId { get; set; }
        public Manager Organizer { get; set; }
        public List<Fight> Fights { get; set; }
        public List<TournamentFighter> TournamentFighters { get; set; }
        public DateTime StartDate { get; set; }

        public bool HasStarted()
            => DateTime.Today >= StartDate;
    }
}
