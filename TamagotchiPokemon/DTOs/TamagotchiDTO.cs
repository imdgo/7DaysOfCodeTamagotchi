using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiPokemon.Models;

namespace TamagotchiPokemon.DTOs
{
    public class TamagotchiDTO : PokemonDetailsResult
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public int FoodStatus { get; private set; }
        public int Mood { get; private set; }
        public int Energy { get; private set; }
        public int HealthStatus { get; private set; }

        public TamagotchiDTO()
        {
            var rand = new Random();
            FoodStatus = rand.Next(11);
            Mood = rand.Next(11);
            Energy = rand.Next(11);
            HealthStatus = rand.Next(11);
        }

        public void UpdateProps(PokemonDetailsResult pokemonDetailsResult)
        {
            Name = pokemonDetailsResult.Name;
            Height = pokemonDetailsResult.Height;
            Weight = pokemonDetailsResult.Weight;
            Abilities = pokemonDetailsResult.Abilities;
        }

        internal void Feed()
        {
            FoodStatus = Math.Min(FoodStatus + 2, 10);
            Energy = Math.Max(Energy - 1, 0);

            Console.WriteLine("Mascote Alimentado!");
        }

        internal void Play()
        {
            Mood = Math.Min(Mood + 3, 10);
            Energy = Math.Max(Energy - 2, 0);
            FoodStatus = Math.Max(FoodStatus - 1, 0);

            Console.WriteLine("Mascote Feliz!");
        }

        internal void ShowStatus()
        {
            Console.WriteLine("Status do Mascote:");
            Console.WriteLine($"Alimentação: {FoodStatus}");
            Console.WriteLine($"Humor: {Mood}");
            Console.WriteLine($"Energia: {Energy}");
            Console.WriteLine($"Saúde: {HealthStatus}");
        }

        public void DarCarinho()
        {
            Mood = Math.Min(Mood + 2, 10);
            HealthStatus = Math.Min(HealthStatus + 1, 10);

            Console.WriteLine("Mascote Amado!");
        }
    }
}
