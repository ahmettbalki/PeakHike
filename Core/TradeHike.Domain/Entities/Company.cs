using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeHike.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public int YearFounded { get; set; }
        public string Name { get; set; }
        public string Investors { get; set; }
        public DateTime DateJoined { get; set; }
        public string Funding { get; set; }
        public string Industry { get; set; }
        public string Valuation { get; set; }
        public string City { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
    }
}
