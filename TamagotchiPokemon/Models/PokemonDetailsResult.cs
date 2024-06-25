using static TamagotchiPokemon.Models.Ability;
using static TamagotchiPokemon.Models.Type;

namespace TamagotchiPokemon.Models
{
    public class PokemonDetailsResult
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        public List<AbilitiesDetail> Abilities { get; set; }
        public List<TypeDetail> Types { get; set; }
    }
}