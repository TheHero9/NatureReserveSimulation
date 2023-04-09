using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.AnimalClass.AnimalBehaviours;
using Nature_reserve_simulation.MapCreation;

namespace Nature_reserve_simulation.Animals
{
    internal class Cow : Animal
    {
        private static int _numberOfCows = 0;
        internal Cow(
            CowOnEatBehaviour onEatBehaviour,
            CowOnMatureBehaviour changeDietBehaviour,
            Biome[,] map,
            int[] coordinates
            ) : 
            base(
                "cow",
                "herbivore",
                3,
                new List<string> { "grass" },
                onEatBehaviour,
                changeDietBehaviour,
                map,
                coordinates)
        {
            _numberOfCows++;
            this.Number = _numberOfCows;
        }
    }
}
