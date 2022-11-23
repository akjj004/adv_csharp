using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poco.Model.Models
{
    public class Category
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        // many to many
        public ICollection<PokemonCategory>? PokemonCategories { get; set; }
        
    }
}