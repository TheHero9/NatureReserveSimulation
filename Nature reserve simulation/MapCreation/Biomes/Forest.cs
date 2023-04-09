using Nature_reserve_simulation.AnimalClass.AnimalBehaviours;
using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.Animals;
using Nature_reserve_simulation.FoodClass;
using Nature_reserve_simulation.Foods;

namespace Nature_reserve_simulation.MapCreation.Biomes
{
    internal class Forest : Biome
    {
        //private static readonly List<Type> _animals = new List<Type>() { typeof(Bear), typeof(Wolf), typeof(Parrot) };
        private static readonly List<string> _animals = new List<string>() { "bear", "wolf", "parrot" };

        private static readonly List<string> _foods = new List<string>()
        {
            "bugs", "worm", "moose"
        };

        public static readonly int maxCapacity = 5;

        public Forest(int x, int y) : base(_animals, _foods, maxCapacity, "forest", x, y)
        {
        }
    }
}
