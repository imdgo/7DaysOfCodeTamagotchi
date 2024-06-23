
public class PokemonDetailsResult
{
    public string Name { get; set; }
    public string Height { get; set; }
    public string Weight { get; set; }

    public List<AbilitiesDetail> Abilities { get; set; }
    public List<TypeDetail> Types { get; set; }


    public class AbilitiesDetail
    {
        public Ability Ability { get; set; }

    }

    public class Ability
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class TypeDetail
    {
        public Type Type { get; set; }
    }

    public class Type
    {
        public string Name { get; set; }
    }
}
