using FinkiBets.Domain.DTO;
using FinkiBets.Domain.Identity;
using FinkiBets.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinkiBets.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly UserManager<GamblingUser> _userManager;
        public TicketController(ITicketService ticketService, UserManager<GamblingUser> userManager)
        {
            _ticketService = ticketService;
            _userManager = userManager; 
        }

        [HttpPost]
        public IActionResult AddBetToTicket(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId == null)
            {
                throw new Exception("");
            }
            var updatedTicket = _ticketService.InsertBetInTicket(id, userId);
            return Json(new { success = true, message = "Bet added successfully" });
        }
        public IActionResult MyTicket()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.GetUserAsync(User).Result;
            var ticket = _ticketService.GetActiveTicketForUser(userId);
            if(ticket == null || userId == null)
            {
                throw new Exception("");
            }
            var dto = new TicketDTO
            {
                TicketId = ticket.Id,
                ticketBets = ticket.bets,
                totalOdds = ticket.totalOdds,
                accountBalance = user.accountBalance
            };
            return View(dto);
        }
        [HttpPost]
        public IActionResult PlaceBet(Guid ticketId, double stake)
        {
            var user = _userManager.GetUserAsync(User).Result;
            user.accountBalance -= stake;
            var ticket = _ticketService.GetById(ticketId);
            ticket.isClosed = true;
            ticket.stake = stake;
            _ticketService.Update(ticket);
            return Ok(new { success = true, newBalance = user.accountBalance });
        }
    }
}
