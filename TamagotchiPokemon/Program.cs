using TamagotchiPokemon.Controllers;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

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