using TamagotchiPokemon.DTOs;
using TamagotchiPokemon.Models;

namespace TamagotchiPokemon.Views
{
    public class TamagotchiView()
    {
        public void ShowMsgWelcomeUser()
        {
            Console.WriteLine("Bem-vindo ao jogo de adoção de mascotes!");
            Console.Write("Por favor, digite seu nome: ");
            string? userName = Console.ReadLine();
            Console.WriteLine($"Olá, {userName}! Vamos começar a adoção dos mascotes.\n");
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Adoção de Mascotes");
            Console.WriteLine("2. Ver Mascotes Adotados");
            Console.WriteLine("3. Sair do Jogo");
            Console.Write("Escolha uma opção: ");

        }
        public void ShowAdoptionMenu()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu de Adoção de Mascotes:");
            Console.WriteLine("1. Ver Espécies Disponíveis");
            Console.WriteLine("2. Ver Detalhes de uma Espécie");
            Console.WriteLine("3. Adotar um Mascote");
            Console.WriteLine("4. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");
        }

        public int GetPlayerChoice()
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 4)
            {
                Console.Write("Escolha inválida. Por favor, escolha uma opção entre 1 e 4: ");
            }

            return escolha;
        }

        public void ShowSpeciesAvailable(List<PokemonResult> species)
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Espécies Disponíveis para Adoção:");

            int index = 1;
            foreach (var pokemon in species)
            {
                Console.WriteLine($"{index}. {pokemon.Name}");
                index++;
            }
        }
        public int GetSpeciesChosen(List<PokemonResult> species)
        {
            // Obter a escolha do jogador
            Console.WriteLine("\n ──────────────");
            int escolha;
            while (true)
            {
                Console.Write("\nEscolha um número para ver os detalhes ou 0 para voltar ao menu principal: ");
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= species.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                }
            }

            return escolha - 1;
        }
        public void ShowAdoptedMascots(List<TamagotchiDTO> adoptedMascots)
        {
            if (adoptedMascots.Count == 0)
            {
                Console.WriteLine("Nenhum mascote adotado ainda.");
            }
            else
            {
                Console.WriteLine("Mascotes adotados:");
                foreach (var mascote in adoptedMascots)
                {
                    Console.WriteLine(mascote.Name);
                }
            }
            Console.WriteLine();
        }

        public void ShowPokemonDetails(PokemonDetailsResult details)
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Detalhes da Espécie:");
            Console.WriteLine("Nome: " + details.Name);
            Console.WriteLine("Altura: " + details.Height);
            Console.WriteLine("Peso: " + details.Weight);
            Console.WriteLine("Habilidades:");

            foreach (var Ability in details.Abilities)
            {
                Console.WriteLine("- " + Ability.Ability.Name);
            }
        }

        public bool ConfirmAdoption()
        {
            Console.WriteLine("\n ──────────────");
            Console.Write("Você gostaria de adotar este mascote? (s/n): ");

            string resposta = Console.ReadLine();
            return resposta.ToLower() == "s";
        }

        public void DisplayAdoptionMessage(string pokemonName)
        {
            Console.WriteLine($"Parabéns! Você adotou um {pokemonName}!");
            Console.WriteLine("──────────────");
            Console.WriteLine("────▄████▄────");
            Console.WriteLine("──▄████████▄──");
            Console.WriteLine("──██████████──");
            Console.WriteLine("──▀████████▀──");
            Console.WriteLine("─────▀██▀─────");
            Console.WriteLine("──────────────");
        }

        public void ShowInteractionMenu()
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu de Interação:");
            Console.WriteLine("1. Saber como o mascote está");
            Console.WriteLine("2. Alimentar o mascote");
            Console.WriteLine("3. Brincar com o mascote");
            Console.WriteLine("4. Voltar");
            Console.Write("Escolha uma opção: ");
        }

        public int GetPlayerChoice(int maxOpcao)
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > maxOpcao)
            {
                Console.Write($"Escolha inválida. Por favor, escolha uma opção entre 1 e {maxOpcao}: ");
            }
            return escolha;
        }
    }
}