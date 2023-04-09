using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.FoodClass;
using Nature_reserve_simulation.Simulation;
using Nature_reserve_simulation.MapCreation;
using Nature_reserve_simulation.MapCreation.Biomes;
using Nature_reserve_simulation.Animals;
using Nature_reserve_simulation.AnimalClass.AnimalBehaviours;
using Nature_reserve_simulation.Foods;

namespace Nature_reserve_simulation
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Create factories
            var biomeDict = new Dictionary<string, Func<int, int, Biome>>
            {
                {"plains",(x, y) => new Plains(x, y) },
                {"forest",(x, y) => new Forest(x, y) },
                {"jungle",(x, y) => new Jungle(x, y) },
            };
            var animalDict = new Dictionary<string, Func<Biome[,], int[], Animal>>
            {
                {"bear", (Biome[,] map, int[] coordinates) => new Bear(new BearOnEatBehaviour(), new BearOnMatureBehaviour(), map, coordinates) },
                {"cow", (Biome[,] map, int[] coordinates) => new Cow(new CowOnEatBehaviour(), new CowOnMatureBehaviour(), map, coordinates) },
                {"parrot", (Biome[,] map, int[] coordinates) => new Parrot(new ParrotOnEatBehaviour(), new ParrotOnMatureBehaviour(), map, coordinates) },
                {"wolf", (Biome[,] map, int[] coordinates) => new Wolf(new WolfOnEatBehaviour(), new WolfOnMatureBehaviour(), map, coordinates) },
            };
            var foodDict = new Dictionary<string, Func<IFood>>
            {
                {"beef", ()=> new Beef() },
                {"berries", ()=> new Berries() },
                {"bugs", ()=> new Bugs() },
                {"deer", ()=> new Deer() },
                {"fish", ()=> new Fish() },
                {"grass", ()=> new Grass() },
                {"moose", ()=> new Moose() },
                {"worm", ()=> new Worm() },
            };

            var biomeFactory = new BiomeFactory(biomeDict);
            var animalFactory = new AnimalFactory(animalDict);
            var foodFactory = new FoodFactory(foodDict);

            // Input
            //Console.WriteLine("Enter X-axis of the world ");
            //int xAxis = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter Y-axis of the world ");
            //int yAxis = int.Parse(Console.ReadLine());



            // Output
            var Map = new Map(biomeFactory, animalFactory, foodFactory, 3,3);

            SimulationClass simulationWorld = new(Map.GetMatrix());
            simulationWorld.SimulateWorld();
        }
    }
}   