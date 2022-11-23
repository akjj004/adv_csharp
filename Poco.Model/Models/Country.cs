using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Poco.Model.Models
{
    public class Country
    {
        public int Id { get; set; }
        public String? Name { get; set; }

        // one to many
        public ICollection<Owner>? Owners { get; set; }
    }
}