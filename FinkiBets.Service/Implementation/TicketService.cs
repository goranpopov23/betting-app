using FinkiBets.Domain.Domain;
using FinkiBets.Repository.Interface;
using FinkiBets.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinkiBets.Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _repository;
        private readonly IRepository<Bet> _betRepository;
        private readonly IOddSelectionService _oddSelectionService;
        public TicketService(IRepository<Ticket> repository, IOddSelectionService oddSelectionService, IRepository<Bet> betRepository)
        {
            _repository = repository;
            _oddSelectionService = oddSelectionService;
            _betRepository = betRepository;
        }
        public Ticket Delete(Guid id)
        {
            var ticket = GetById(id);
            return _repository.Delete(ticket);
            return ticket;
        }

        public Ticket GetActiveTicketForUser(string userId)
        {
            var ticket = _repository.Get(selector:x => x,
                                         predicate: x => x.UserId.Equals(userId) && x.isClosed == false,
                                         include: x => x.Include(z => z.bets).ThenInclude(z => z.OddSelection).ThenInclude(z => z.Match));
            if(ticket == null)
            {
                ticket = new Ticket
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    isClosed = false,
                    bets = new List<Bet>(),
                    totalOdds = 1.0,
                    stake = 0
                };
                Insert(ticket);
            }
            return ticket;
        }

        public List<Ticket> GetAll()
        {
            return _repository.GetAll(selector: x => x,
                                      include: x => x.Include(z => z.bets)
                                      .ThenInclude(z => z.OddSelection)
                                      .ThenInclude(y => y.Match)).ToList();
        }

        public Ticket GetById(Guid id)
        {
            return _repository.Get(selector: x => x,
                                    predicate: x => x.Id == id,
                                    include: x => x.Include(z => z.bets).ThenInclude(y => y.OddSelection).ThenInclude(y => y.Match));
        }

        public Ticket Insert(Ticket ticket)
        {
            return _repository.Insert(ticket);
        }

        public Ticket InsertBetInTicket(Guid id, string userId)
        {
            var ticket = GetActiveTicketForUser(userId);
            var selectedOdd = _oddSelectionService.GetById(id);
            foreach(var b in ticket.bets)
            {
                if(selectedOdd.MatchId == b.OddSelection.MatchId)
                {
                    b.OddSelection = selectedOdd;
                    _oddSelectionService.Update(b.OddSelection);
                    UpdateTotalOdds(ticket.bets, ticket);
                    return ticket;
                }
            }
            var bet = new Bet
                {
                    Id = Guid.NewGuid(),
                    TicketId = ticket.Id,
                    Ticket = ticket,
                    OddSelection = selectedOdd,
                    OddSelectionId = selectedOdd.Id
                };
            _betRepository.Insert(bet);
            UpdateTotalOdds(ticket.bets, ticket);
            _repository.Update(ticket);
            return ticket;
        }

        public Ticket Update(Ticket ticket)
        {
            return _repository.Update(ticket);
        }
        public void UpdateTotalOdds(ICollection<Bet> bets, Ticket ticket)
        {
            ticket.totalOdds = 1.0;
            foreach (var b in ticket.bets)
            {
                ticket.totalOdds = ticket.totalOdds * b.OddSelection.Odds;
            }
            _repository.Update(ticket);
        }
    }
}
