using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinkiBets.Domain.Domain;
using FinkiBets.Repository.Interface;
using FinkiBets.Service;
using FinkiBets.Service.Interface;
using Microsoft.EntityFrameworkCore;
namespace FinkiBets.Service.Implementation
{
    public class OddSelectionService : IOddSelectionService
    {
        private readonly IRepository<OddSelection> _repository;
        public OddSelectionService(IRepository<OddSelection> repository)
        {
            _repository = repository;
        }

        public OddSelection GetById(Guid id)
        {
            return _repository.Get(selector: x => x,
                                      predicate: x => x.Id == id,
                                      include: x => x.Include(z => z.Match));
        }

        public List<OddSelection> GetOddSelectionsByMatchId(Guid id)
        {
            return _repository.GetAll(selector: x => x,
                                      predicate: x => x.MatchId == id,
                                      include: x => x.Include(z => z.Match)).ToList();
        }

        public OddSelection Insert(OddSelection odd)
        {
            return _repository.Insert(odd);
        }

        public OddSelection Update(OddSelection odd)
        {
            return _repository.Update(odd);
        }
    }
}
