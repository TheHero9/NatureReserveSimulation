using Nature_reserve_simulation.Animals;
using Nature_reserve_simulation.AnimalClass.AnimalBehaviours;
using Nature_reserve_simulation.MapCreation;

namespace Nature_reserve_simulation.AnimalClass
{
    public class AnimalFactory
    {
        private readonly Dictionary<string, Func<Biome[,], int[], Animal>> _availableAnimals;

        public AnimalFactory(Dictionary<string, Func<Biome[,], int[], Animal>> animals)
        {
            _availableAnimals = animals;
        }

        public Animal Create(Biome[,] map, int[] coordinates, string animal) => _availableAnimals[animal](map, coordinates);
    }
}
