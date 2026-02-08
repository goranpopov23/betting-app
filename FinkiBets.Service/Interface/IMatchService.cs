using FinkiBets.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinkiBets.Service.Interface
{
    public interface IMatchService
    {
        List<Match> GetAll();
        List<Match> GetAllFootballMatches();
        List<Match> GetAllBasketballPlayerMatches();
        Match GetById(Guid id);
        Match Delete(Guid id);
        Match Insert(Match match);
        Match Update(Match match);  
    }
}
