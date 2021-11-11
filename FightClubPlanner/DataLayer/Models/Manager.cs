using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Manager : User
    {
        public List<Tournament> Tournaments { get; set; }
    }
}
