using FinkiBets.Domain.Domain;
using FinkiBets.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinkiBets.Repository
{
    public class ApplicationDbContext : IdentityDbContext<GamblingUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<OddSelection> Selections { get; set; }
    }
}
