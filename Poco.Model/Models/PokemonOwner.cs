using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poco.Model.Models
{
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        // add virtual to have lazyLoading
        public virtual Pokemon? Pokemon { get; set; }
        // add virtual to have lazyLoading
        public virtual Owner? Owner { get; set; }
    }
}