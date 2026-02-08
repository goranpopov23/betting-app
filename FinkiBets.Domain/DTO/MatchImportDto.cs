using FinkiBets.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinkiBets.Domain.DTO
{
    public class MatchImportDto
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public SportType MatchType { get; set; }
        public List<OddDto> Odds { get; set; }
    }
}
