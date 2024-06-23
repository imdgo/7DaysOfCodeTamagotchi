using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiPokemon.Models;

namespace TamagotchiPokemon.Service
{
    public class PokemonApiService
    {
        public List<PokemonResult> GetPokemonSpecies()
        {
            // Obter a lista de espécies de Pokémons
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine("Erro ao obter a lista de espécies de Pokémons.");               
            }

            return JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content).Results;
        }

        public PokemonDetailsResult GetPokemonDetails(PokemonResult chosenPokemon)
        {
            // Obter detalhes do pokemon escolhido
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{chosenPokemon.Name}");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine("Erro ao obter as características do Pokémon escolhido.");
            }

            return JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);

        }

    }
}
