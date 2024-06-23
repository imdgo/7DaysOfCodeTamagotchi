using TamagotchiPokemon.Controllers;

namespace TamagotchiPokemon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TamagotchiController menu = new();
            menu.Play();
        }
    }
}