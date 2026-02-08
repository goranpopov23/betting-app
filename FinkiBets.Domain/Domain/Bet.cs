using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinkiBets.Domain.Domain
{
    public class Bet : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public Guid? OddSelectionId { get; set; }
        public OddSelection? OddSelection { get; set; }
    }
}
