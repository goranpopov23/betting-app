using FinkiBets.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinkiBets.Domain.Domain
{
    public class Ticket : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public GamblingUser User { get; set; }
        public double stake { get; set; }
        public double totalOdds { get; set; }
        public bool isClosed { get; set; }
        public virtual ICollection<Bet> bets { get; set; }
    }
}
