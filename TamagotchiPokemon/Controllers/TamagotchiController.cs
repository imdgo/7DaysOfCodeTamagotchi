using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiPokemon.Models;
using TamagotchiPokemon.Service;
using TamagotchiPokemon.Views;

namespace TamagotchiPokemon.Controllers
{
    public class TamagotchiController
    {
        #region CTOR
        private readonly List<PokemonDetailsResult> adoptedMascots;
        private readonly TamagotchiView menu;
        private readonly PokemonApiService pokemonApiService;
        private readonly List<PokemonResult> speciesAvailable;


        public TamagotchiController()
        {
            menu = new TamagotchiView();
            pokemonApiService = new PokemonApiService();

            speciesAvailable = pokemonApiService.GetPokemonSpecies();
            adoptedMascots = [];

        }

        #endregion

        public void Play()
        {
            menu.ShowMsgWelcomeUser();


            while (true)
            {
                menu.ShowMainMenu();
                int choice = menu.GetPlayerChoice();
                PokemonDetailsResult pokemonDetails;
                int pokemon;

                switch (choice)
                {

                    case 1:
                        menu.ShowAdoptionMenu();
                        choice = menu.GetPlayerChoice();

                        switch (choice)
                        {
                            case 1:
                                menu.ShowSpeciesAvailable(speciesAvailable);
                                break;
                            case 2:
                                pokemon = menu.GetSpeciesChosen(speciesAvailable);
                                pokemonDetails = pokemonApiService.GetPokemonDetails(speciesAvailable[pokemon]);
                                menu.ShowPokemonDetails(pokemonDetails);
                                break;
                            case 3:
                                menu.ShowSpeciesAvailable(speciesAvailable);
                                pokemon = menu.GetSpeciesChosen(speciesAvailable);
                                pokemonDetails = pokemonApiService.GetPokemonDetails(speciesAvailable[pokemon]);
                                menu.ShowPokemonDetails(pokemonDetails);
                                if (menu.ConfirmAdoption())
                                {
                                    adoptedMascots.Add(pokemonDetails);
                                    Console.WriteLine("Parabéns! Você adotou um " + pokemonDetails.Name + "!");
                                    Console.WriteLine("──────────────");
                                    Console.WriteLine("────▄████▄────");
                                    Console.WriteLine("──▄████████▄──");
                                    Console.WriteLine("──██████████──");
                                    Console.WriteLine("──▀████████▀──");
                                    Console.WriteLine("─────▀██▀─────");
                                    Console.WriteLine("──────────────");
                                }
                                break;
                        }
                        break;
                    case 2:
                        menu.ShowAdoptedMascots(adoptedMascots);
                        break;
                    case 3:
                        Console.WriteLine("Obrigado por jogar! Até a próxima.");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
