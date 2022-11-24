using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Poco.Services.VM
{
    public class AddOrUpdatePokemonVm
    {
        public int? Id { get; set; }
        [Required]
        public String? Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int ReviewId { get; set; }
        [Required]
        public int PokemonOwnerId { get; set; }
        [Required]
        public int PokemonCategoryId { get; set; }
    }
}