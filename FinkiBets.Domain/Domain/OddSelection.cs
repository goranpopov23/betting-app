using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinkiBets.Domain.Domain
{
    public class OddSelection : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MatchId { get; set; }
        public Match Match { get; set; }
        public string Label { get; set; } // "1", "X", "2", "Over", or "Under"
        public double Odds { get; set; } // e.g., 1.85
    }
}
