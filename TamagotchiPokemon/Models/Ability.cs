﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiPokemon.Models
{
    public class Ability
    {
        public string Name { get; set; }
        public string Url { get; set; }


        public class AbilitiesDetail
        {
            public Ability Ability { get; set; }

        }
    }
}