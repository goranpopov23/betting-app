using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinkiBets.Domain.Domain
{
    public enum SportType
    {
        Football,
        Basketball
    }
    public class Match : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime startTime { get; set; }
        public SportType? matchType { get; set; }
        public virtual ICollection<OddSelection> odds { get; set; } = new List<OddSelection>();
    }
}
