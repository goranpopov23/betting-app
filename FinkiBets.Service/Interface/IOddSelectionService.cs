using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinkiBets.Domain.Domain;

namespace FinkiBets.Service.Interface
{
    public interface IOddSelectionService
    {
        List<OddSelection> GetOddSelectionsByMatchId(Guid id);
        OddSelection GetById(Guid id);
        OddSelection Update(OddSelection odd);
        OddSelection Insert(OddSelection odd);
    }
}
