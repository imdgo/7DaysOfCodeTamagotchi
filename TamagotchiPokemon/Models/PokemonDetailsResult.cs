namespace TamagotchiPokemon.Models
{
    public class PokemonDetailsResult
    {
        public List<AbilityDetail> Abilities { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        public class AbilityDetail
        {
            public Ability Ability { get; set; }
            public bool IsHidden { get; set; }
            public int Slot { get; set; }
        }

        public class Ability
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}