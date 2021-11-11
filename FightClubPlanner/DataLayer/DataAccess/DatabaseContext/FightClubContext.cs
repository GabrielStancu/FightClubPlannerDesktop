using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataAccess.DatabaseContext
{
    public class FightClubContext : BaseContext
    {
        public DbSet<CovidTest> CovidTests { get; set; }
        public DbSet<Fight> Fights { get; set; }
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<IsolationBubble> IsolationBubbles { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentFighter> TournamentFighters { get; set; }

        private static string _connectionString = "Data Source=localhost;Initial Catalog=FightClubDb;persist security info=True; Integrated Security = SSPI;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(_connectionString);

        public FightClubContext(string connectionString)
            => _connectionString = connectionString;

        public FightClubContext() { }
    }
}
