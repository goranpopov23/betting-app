using FinkiBets.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinkiBets.Service.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAll();
        Ticket GetActiveTicketForUser(string userId);
        Ticket InsertBetInTicket(Guid id, string userId);
        Ticket GetById(Guid id);
        Ticket Delete(Guid id);
        Ticket Insert(Ticket ticket);
        Ticket Update(Ticket ticket);
    }
}
