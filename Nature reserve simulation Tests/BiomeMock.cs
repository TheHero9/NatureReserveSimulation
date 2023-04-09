using Nature_reserve_simulation.MapCreation;

namespace Nature_reserve_simulation_Tests
{
    internal class BiomeMock : Biome
    {
        //private static readonly List<Type> _animals = new List<Type>() { typeof(Bear), typeof(Wolf), typeof(Parrot) };
        private static readonly List<string> _animals = new List<string>() { "bear", "mock" };

        private static readonly List<string> _foods = new List<string>()
        {
            "bugs", "worm", "moose"
        };

        public static readonly int maxCapacity = 3;

        public BiomeMock(int x, int y) : base(_animals, _foods, maxCapacity, "mock", x, y)
        {
        }
    }
}
