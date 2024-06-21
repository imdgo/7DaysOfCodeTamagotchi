using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using Tamagotchi;

public class Program
{
    public static void Main(string[] args)
    {
        // Obter a lista de espécies de Pokémons
        var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request);

        if (!response.IsSuccessful)
        {
            Console.WriteLine("Erro ao obter a lista de espécies de Pokémons.");
            return;
        }

        var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);

        // Apresentar as opções ao jogador
        Console.WriteLine("Escolha um Tamagotchi:");
        for (int i = 0; i < pokemonEspeciesResposta.Results.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pokemonEspeciesResposta.Results[i].Name}");
        }

        // Obter a escolha do jogador
        int escolha;

        while (true)
        {
            Console.Write("\nEscolha um número: ");
            if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokemonEspeciesResposta.Results.Count)
            {
                break;
            }
            else
            {
                Console.WriteLine("Escolha inválida. Tente novamente.");
            }
        }

        // Obter as características do Pokémon escolhido
        var chosenPokemon = pokemonEspeciesResposta.Results[escolha - 1];
        client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{chosenPokemon.Name}");
        request = new RestRequest("", Method.Get);
        response = client.Execute(request);

        if (!response.IsSuccessful)
        {
            Console.WriteLine("Erro ao obter as características do Pokémon escolhido.");
            return;
        }

        var pokemonDetalhes = JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);

        // Mostrar as características ao jogador
        Console.WriteLine($"Você escolheu: {chosenPokemon.Name}");
        Console.WriteLine("Habilidades:");

        foreach (var habilidade in pokemonDetalhes.Abilities)
        {
            Console.WriteLine(habilidade.Ability.Name);
        }
    }
}