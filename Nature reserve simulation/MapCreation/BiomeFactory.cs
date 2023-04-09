using Nature_reserve_simulation.AnimalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nature_reserve_simulation.MapCreation
{
    public class BiomeFactory
    {
        public readonly Dictionary<string, Func<int, int, Biome>> availableBiomes;

        public BiomeFactory(Dictionary<string, Func<int, int, Biome>> biomes)
        {
            availableBiomes = biomes;
        }

        public Biome Create(int x, int y, string biome) => availableBiomes[biome](x, y);
    }
}
