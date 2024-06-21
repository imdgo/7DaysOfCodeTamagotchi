public class PokemonDetailsResult
{
    public string Name { get; set; }
    public List<AbilitiesDetail> Abilities { get; set; }

    public class AbilitiesDetail
    {
        public Ability Ability { get; set; }

    }
    public class Ability
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}