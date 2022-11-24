using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Poco.Model.Models;
using Poco.Services.VM;
namespace Poco.Services.Interfaces
{
    public interface IPokemonService
    {
        PokemonVm AddOrUpdatePokemon(AddOrUpdatePokemonVm addOrUpdatePokemonVm);
        PokemonVm GetPokemonVm(Expression<Func<Pokemon, bool>> filterExpression);
        IEnumerable<PokemonVm> GetPokemons(Expression<Func<Pokemon, bool>>? filterExpression = null);
    }
}