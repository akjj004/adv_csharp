using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Poco.Dal.EF.Data;
using Poco.Model.Models;
using Poco.Services.Interfaces;
using Poco.Services.VM;

namespace Poco.Services.ConcreteServices
{
    public class PokemonService : BaseService, IPokemonService
    {
        public PokemonService(DataContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public PokemonVm AddOrUpdatePokemon(AddOrUpdatePokemonVm addOrUpdatePokemonVm)
        {
            try
            {
                if (addOrUpdatePokemonVm == null) throw new ArgumentNullException("View model parameter is null");
                var pokemonEntity = Mapper.Map<Pokemon>(addOrUpdatePokemonVm);
                if (addOrUpdatePokemonVm.Id.HasValue || addOrUpdatePokemonVm.Id == 0) DbContext.Pokemons.Update(pokemonEntity);
                else DbContext.Pokemons.Add(pokemonEntity);
                DbContext.SaveChanges();
                var pokemonVm = Mapper.Map<PokemonVm>(pokemonEntity);
                return pokemonVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<PokemonVm> GetPokemons(Expression<Func<Pokemon, bool>>? filterExpression = null)
        {
            try
            {
                var pokemonsQuery = DbContext.Pokemons.AsQueryable();
                if(filterExpression != null) pokemonsQuery = pokemonsQuery.Where(filterExpression);
                var pokemonVms = Mapper.Map<IEnumerable<PokemonVm>> (pokemonsQuery);
                return pokemonVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public PokemonVm GetPokemonVm(Expression<Func<Pokemon, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null) throw new ArgumentNullException("Filter expression parameter is null");
                var pokemonEntity = DbContext.Pokemons.FirstOrDefault(filterExpression);
                var pokemonVm = Mapper.Map<PokemonVm>(pokemonEntity);
                return pokemonVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}