using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Poco.Model.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public DateTime BirthDate { get; set; }

        // one to many
        public ICollection<Review>? Reviews { get; set; }
        // many to many
        public ICollection<PokemonOwner>? PokemonOwners { get; set; }
        // many to many
        public ICollection<PokemonCategory>? PokemonCategories { get; set; }
       
    }
}