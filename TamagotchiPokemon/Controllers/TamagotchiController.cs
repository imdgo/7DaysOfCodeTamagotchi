using Newtonsoft.Json;
using TamagotchiPokemon.DTOs;
using TamagotchiPokemon.Models;
using TamagotchiPokemon.Service;
using TamagotchiPokemon.Views;

namespace TamagotchiPokemon.Controllers
{
    public class TamagotchiController
    {
        #region Fields

        private readonly List<TamagotchiDTO> _adoptedPets;
        private readonly TamagotchiView _tamagotchiView;
        private readonly PokemonApiService pokemonApiService;
        private readonly List<PokemonResult> speciesAvailable;

        #endregion

        #region Constructor

        public TamagotchiController()
        {
            _tamagotchiView = new TamagotchiView();
            pokemonApiService = new PokemonApiService();

            speciesAvailable = pokemonApiService.GetPokemonSpecies();
            _adoptedPets = new List<TamagotchiDTO>();
        }

        #endregion

        #region Public Methods

        public void Play()
        {
            _tamagotchiView.ShowMsgWelcomeUser();

            while (true)
            {
                _tamagotchiView.ShowMainMenu();
                var choice = _tamagotchiView.GetPlayerChoice();

                try
                {
                    switch (choice)
                    {
                        case 1:
                            HandleAdoptionMenu();
                            break;
                        case 2:
                            HandleInteractionMenu();
                            break;
                        case 3:
                            ExitGame();
                            return;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }
        }

        #endregion

        #region Private Methods

        private void HandleAdoptionMenu()
        {
            _tamagotchiView.ShowAdoptionMenu();
            var choice = _tamagotchiView.GetPlayerChoice();

            switch (choice)
            {
                case 1:
                    _tamagotchiView.ShowSpeciesAvailable(speciesAvailable);
                    break;
                case 2:
                    ShowPokemonDetails();
                    break;
                case 3:
                    AdoptPokemon();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        private void HandleInteractionMenu()
        {
            if (_adoptedPets.Count == 0)
            {
                Console.WriteLine("Você ainda não adotou nenhum Pokémon.");
                return;
            }

            Console.WriteLine("Escolha um mascote para interagir:");
            for (int i = 0; i < _adoptedPets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_adoptedPets[i].Name}");
            }

            int petIndex = _tamagotchiView.GetPlayerChoice(_adoptedPets.Count) - 1;
            var chosenPet = _adoptedPets[petIndex];

            bool exitMenu = false;

            while (!exitMenu)
            {
                _tamagotchiView.ShowInteractionMenu();
                int interactionOption = _tamagotchiView.GetPlayerChoice(4);

                switch (interactionOption)
                {
                    case 1:
                        chosenPet.ShowStatus();
                        break;
                    case 2:
                        chosenPet.Feed();
                        break;
                    case 3:
                        chosenPet.Play();
                        break;
                    case 4:
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                        break;
                }
            }
        }

        private void ShowPokemonDetails()
        {
            var pokemonIndex = _tamagotchiView.GetSpeciesChosen(speciesAvailable);
            var pokemonDetails = pokemonApiService.GetPokemonDetails(speciesAvailable[pokemonIndex]);
            _tamagotchiView.ShowPokemonDetails(pokemonDetails);
        }

        private void AdoptPokemon()
        {
            _tamagotchiView.ShowSpeciesAvailable(speciesAvailable);
            var pokemonIndex = _tamagotchiView.GetSpeciesChosen(speciesAvailable);
            var pokemonDetails = pokemonApiService.GetPokemonDetails(speciesAvailable[pokemonIndex]);
            _tamagotchiView.ShowPokemonDetails(pokemonDetails);

            if (_tamagotchiView.ConfirmAdoption())
            {
                var tamagotchi = new TamagotchiDTO();
                tamagotchi.UpdateProps(pokemonDetails);
                _adoptedPets.Add(tamagotchi);
                _tamagotchiView.DisplayAdoptionMessage(tamagotchi.Name);
            }
        }

        private void ShowAdoptedPokemons()
        {
            _tamagotchiView.ShowAdoptedMascots(_adoptedPets);
        }

        private void ExitGame()
        {
            Console.WriteLine("Obrigado por jogar! Até a próxima.");
        }

        #endregion
    }
}
