using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nature_reserve_simulation.MapCreation.Biomes
{
    internal class Jungle : Biome
    {
        private static readonly List<string> _animals = new List<string>() { "bear", "parrot", "wolf" };

        private static readonly List<string> _foods = new List<string>()
        {
            "berries", "grass", "bugs", "worm"
        };

        public static readonly int maxCapacity = 7;

        public Jungle(int x, int y) : base(_animals, _foods, maxCapacity, "jungle", x, y)
        {
        }
    }
}
