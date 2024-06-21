using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using Tamagotchi;

public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.Run();
    }
}
