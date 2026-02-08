using FinkiBets.Domain.Domain;

namespace FinkiBets.Domain.DTO
{
    internal class TicketDTO
    {
        public Guid TicketId { get; set; }
        public ICollection<Bet> ticketBets { get; set; }
        public double totalOdds { get; set; }
        public double accountBalance { get; set; }
    }
}