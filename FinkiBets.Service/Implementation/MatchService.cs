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
    public class MatchService : IMatchService
    {
        private readonly IRepository<Match> _repository;
        public MatchService(IRepository<Match> repository)
        {
            _repository = repository;
        }
        public List<Match> GetAll()
        {
            return _repository.GetAll(selector: x => x,
                                      include: x => x.Include(z => z.odds)).ToList();
        }
        public List<Match> GetAllFootballMatches()
        {
            return _repository.GetAll(selector: x => x,
                                      predicate: x => x.matchType == SportType.Football,
                                      include: x => x.Include(z => z.odds)).ToList();
        }

        public List<Match> GetAllBasketballPlayerMatches()
        {
            return _repository.GetAll(selector: x => x,
                                      predicate: x => x.matchType == SportType.Basketball,
                                      include: x => x.Include(z => z.odds)).ToList();
        }

        public Match GetById(Guid id)
        {
            return _repository.Get(selector: x => x,
                                    predicate: x => x.Id == id,
                                    include: x => x.Include(z => z.odds));
        }

        public Match Delete(Guid id)
        {
            var delete = GetById(id);
            _repository.Delete(delete);
            return delete;
        }

        public Match Insert(Match match)
        {
            return _repository.Insert(match);
        }

        public Match Update(Match match)
        {
            return _repository.Update(match);
        }
    }
}
