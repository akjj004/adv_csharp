using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poco.Model.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Gym { get; set; }

        // One relationship
        public Country? Country { get; set; }
    }
}