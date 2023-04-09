using Nature_reserve_simulation.FoodClass;
using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.AnimalClass.AnimalBehaviours;
using Nature_reserve_simulation.Animals;
using Nature_reserve_simulation.Foods;

namespace Nature_reserve_simulation.MapCreation.Biomes
{
    internal class Plains : Biome
    {
        private static readonly List<string> _animals = new List<string>() {"cow", "parrot"};

        private static readonly List<string> _foods = new List<string>() 
        {
            "berries", "grass"
        };

        public static readonly int maxCapacity = 4;

        public Plains(int x, int y) : base(_animals, _foods, maxCapacity, "plains", x, y)
        {
        }
    }
}
