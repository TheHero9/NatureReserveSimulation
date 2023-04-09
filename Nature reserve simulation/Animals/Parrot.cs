using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.AnimalClass.AnimalBehaviours;
using Nature_reserve_simulation.MapCreation;

namespace Nature_reserve_simulation.Animals
{
    internal class Parrot : Animal
    {
        private static int _numberOfParrots = 0;

        internal Parrot(
            ParrotOnEatBehaviour onEatBehaviour,
            ParrotOnMatureBehaviour changeDietBehaviour,
            Biome[,] map,
            int[] coordinates) : 
            base(
                "parrot",
                "herbivore",
                2,
                new List<string>{"worm", "bugs"},
                onEatBehaviour,
                changeDietBehaviour,
                map,
                coordinates)
        {
            _numberOfParrots++;
            this.Number = _numberOfParrots;
        }

    }
}
