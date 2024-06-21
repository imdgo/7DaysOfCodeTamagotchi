using Newtonsoft.Json;
using RestSharp;
using Tamagotchi;

public class Menu()
{
    private List<PokemonDetailsResult> adoptedMascots = [];

    public List<PokemonDetailsResult> AdoptedMascots { get => adoptedMascots; set => adoptedMascots = value; }

    public void Run()
    {
        WelcomeUser();
        MainMenu();
    }

    private void WelcomeUser()
    {
        Console.WriteLine("Bem-vindo ao jogo de adoção de mascotes!");
        Console.Write("Por favor, digite seu nome: ");
        string userName = Console.ReadLine();
        Console.WriteLine($"Olá, {userName}! Vamos começar a adoção dos mascotes.\n");
    }

    private void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Adoção de mascotes");
            Console.WriteLine("2. Ver mascotes adotados");
            Console.WriteLine("3. Sair do Jogo");
            Console.Write("Escolha uma opção: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AdoptionMenu();
                    break;
                case "2":
                    ShowAdoptedMascots();
                    break;
                case "3":
                    Console.WriteLine("Obrigado por jogar! Até a próxima.");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    void AdoptionMenu()
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
            Console.Write("\nEscolha um número para ver os detalhes ou 0 para voltar ao menu principal: ");
            if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 0 && escolha <= pokemonEspeciesResposta.Results.Count)
            {
                if (escolha == 0) return;
                ShowPokemonDetails(pokemonEspeciesResposta.Results[escolha - 1]);
            }
            else
            {
                Console.WriteLine("Escolha inválida. Tente novamente.");
            }
        }
    }

    private void ShowPokemonDetails(PokemonResult chosenPokemon)
    {
        var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{chosenPokemon.Name}");
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request);

        if (!response.IsSuccessful)
        {
            Console.WriteLine("Erro ao obter as características do Pokémon escolhido.");
            return;
        }

        var pokemonDetalhes = JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);

        Console.WriteLine($"Você escolheu: {chosenPokemon.Name}");
        Console.WriteLine("Habilidades:");
        foreach (var habilidade in pokemonDetalhes.Abilities)
        {
            Console.WriteLine(habilidade.Ability.Name);
        }

        Console.WriteLine("Altura: " + pokemonDetalhes.Height);
        Console.WriteLine("Peso: " + pokemonDetalhes.Weight);
        Console.WriteLine("Tipos:");
        foreach (var tipo in pokemonDetalhes.Types)
        {
            Console.WriteLine(tipo.Type.Name);
        }

        Console.Write("\nDeseja adotar este mascote? (s/n): ");
        string adoptChoice = Console.ReadLine().ToLower();
        if (adoptChoice == "s")
        {
            AdoptedMascots.Add(pokemonDetalhes);
            Console.WriteLine($"{chosenPokemon.Name} foi adotado com sucesso!\n");
        }
        else
        {
            Console.WriteLine($"{chosenPokemon.Name} não foi adotado.\n");
        }
    }

    private void ShowAdoptedMascots()
    {
        if (AdoptedMascots.Count == 0)
        {
            Console.WriteLine("Nenhum mascote adotado ainda.");
        }
        else
        {
            Console.WriteLine("Mascotes adotados:");
            foreach (var mascote in AdoptedMascots)
            {
                Console.WriteLine(mascote.Name);
            }
        }
        Console.WriteLine();
    }
}
