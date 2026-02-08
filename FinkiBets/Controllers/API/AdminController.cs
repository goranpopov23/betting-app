using FinkiBets.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinkiBets.Domain.Domain;
using FinkiBets.Domain.DTO;
namespace FinkiBets.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMatchService _matchService;
        private readonly IOddSelectionService _oddSelectionService;
        public AdminController(ITicketService ticketService, IMatchService matchService, IOddSelectionService oddSelectionService)
        {
            _ticketService = ticketService;
            _matchService = matchService;
            _oddSelectionService = oddSelectionService;
        }

        [HttpGet("[action]")]
        public List<Ticket> GetAllTickets()
        {
            return _ticketService.GetAll();
        }

        [HttpPost("[action]")]
        public Ticket GetTicketDetails(Guid id)
        {
            return _ticketService.GetById(id);
        }

        [HttpPost("[action]")]
        public bool ImportFM(List<MatchImportDto> dto)
        {
            foreach (var item in dto)
            {
                var match = new Match
                {
                    Id = Guid.NewGuid(),
                    Name = item.Name,
                    startTime = item.StartTime,
                    matchType = SportType.Football,
                    odds = new List<OddSelection>()
                };

                foreach (var oddDto in item.Odds)
                {
                    match.odds.Add(new OddSelection
                    {
                        Id = Guid.NewGuid(),
                        MatchId = match.Id,
                        Odds = oddDto.Value,
                        Label = oddDto.Label
                    });
                }
                _matchService.Insert(match);
            }
            return true;
        }
        [HttpPost("[action]")]
        public bool ImportBP(List<MatchImportDto> dto)
        {
            foreach (var item in dto)
            {
                var match = new Match
                {
                    Id = Guid.NewGuid(),
                    Name = item.Name,
                    startTime = item.StartTime,
                    matchType = SportType.Basketball,
                    odds = new List<OddSelection>()
                };

                foreach (var oddDto in item.Odds)
                {
                    match.odds.Add(new OddSelection
                    {
                        Id = Guid.NewGuid(),
                        MatchId = match.Id,
                        Odds = oddDto.Value,
                        Label = oddDto.Label
                    });
                }
                _matchService.Insert(match);
            }
            return true;
        }
    }
}
