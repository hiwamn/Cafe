using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Province
    {
        public int Id { get; set; }
        public string Name{ get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<City> City { get; set; }

    }


}


