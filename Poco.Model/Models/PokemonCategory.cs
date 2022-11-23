using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poco.Model.Models
{
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        // add virtual to have lazyLoading
        public virtual Pokemon? Pokemon { get; set; }
        // add virtual to have lazyLoading
        public virtual Category? Category { get; set; }
    }
}