using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.AnimalClass.AnimalBehaviours;
using Nature_reserve_simulation.MapCreation;

namespace Nature_reserve_simulation.Animals
{
    internal class Wolf : Animal
    {
        private static int _numberOfWolves = 0;
        internal Wolf(
            WolfOnEatBehaviour onEatBehaviour,
            WolfOnMatureBehaviour changeDietBehaviour,
            Biome[,] map,
            int[] coordinates) : 
            base("wolf",
                "carnivore",
                3,
                new List<string> { "beef", "fish", "moose", "herbivore" },
                onEatBehaviour,
                changeDietBehaviour,
                map,
                coordinates)
        {
            _numberOfWolves++;
            this.Number = _numberOfWolves;
        }
    }
}
