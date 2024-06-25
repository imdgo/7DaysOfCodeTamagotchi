using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiPokemon.Models
{
    public class Type
    {
        public string Name { get; set; }

        public class TypeDetail
        {
            public Type Type { get; set; }
        }
    }
}
