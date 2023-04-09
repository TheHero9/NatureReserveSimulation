using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.FoodClass;
using Nature_reserve_simulation.Foods;
using Nature_reserve_simulation.MapCreation;

namespace Nature_reserve_simulation.Simulation
{
    public class SimulationClass
    {

        private List<Animal> Animals { get; set; }
        private List<IFood> Foods { get; set; }
        private Biome[,] MapOfWorld { get; set; }

        private readonly int _numberOfAnimals;
        private int _dayOfSimulation = 0;

        public SimulationClass(Biome[,] map)
        {
            MapOfWorld = map;

            Animals = new List<Animal>();
            Foods = new List<IFood>();

            //Fill the Lists
            GetActiveAnimals();
            GetActiveFoods();

            _numberOfAnimals = Animals.Count;
        }

        public void GetActiveAnimals()
        {
            for (int row = 0; row < MapOfWorld.GetLength(0); row++)
            {
                for (int col = 0; col < MapOfWorld.GetLength(1); col++)
                {
                    Biome currentBiome = MapOfWorld[row, col];
                 
                    Animals.AddRange(currentBiome.Population);
                }
            }
        }

        public void GetActiveFoods()
        {
            for (int row = 0; row < MapOfWorld.GetLength(0); row++)
            {
                for (int col = 0; col < MapOfWorld.GetLength(1); col++)
                {
                    Biome currentBiome = MapOfWorld[row, col];

                    Foods.AddRange(currentBiome.Foods);
                }
            }
        }


        public void SimulateWorld()
        {
            Console.WriteLine("");
            Console.WriteLine("Simulation started...");

            Console.WriteLine("Map of the world: ");
            PrintMap();
            

            while (Animals.Any(a => a.IsAlive))
            {
                _dayOfSimulation++;

                Console.WriteLine("");
                Console.WriteLine("___________");
                Console.WriteLine("|  Day " + _dayOfSimulation + "  |");
                Console.WriteLine("|_________|");
                Console.WriteLine("");

                AnimalsState();
                AnimalsEnergyStats();

                Console.WriteLine("");
                Console.WriteLine("Actions: ");

                // Loop through each animal and simulate a day
                foreach(Animal currentAnimal in Animals)
                {
                    if (currentAnimal.IsAlive) 
                    {
                        SimulateDay(currentAnimal); 
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("____________");

                RegrowPlants();
                
            }



            // Conclusion secton
            string minimalSurvivedAnimal = GetMinimalSurvivedAnimal();
            string maximumSurvivedAnimal = GetMaxSurvivedAnimal();
            int averageSurvivedDays = GetAverageDaysSurvived();
            GetConclusion(_dayOfSimulation, averageSurvivedDays, minimalSurvivedAnimal, maximumSurvivedAnimal);     
        }

        // Main Simulation day for each animal
        private void SimulateDay(Animal currentAnimal)
        {
            var availableFoods = currentAnimal.CurrentBiome.Foods;
            IFood selectedFood = availableFoods[GetRandomFood(availableFoods)];

            currentAnimal.Feed(selectedFood);

            currentAnimal.TryToMove();

            currentAnimal.UpdateAnimalStatus();

            currentAnimal.CheckReadyToMature();
        }

        private void RegrowPlants()
        {
            foreach(var plant in Foods.OfType<IPlant>())
            {
                plant.RegrowNutritionalValue();
            }
        }

        private int GetRandomFood(List<IFood> availableFoods)
        {
            Random rnd = new Random();
            int foodNumber = rnd.Next(0, availableFoods.Count);
   

            return foodNumber;
        }

        private void PrintMap()
        {
            int rows = MapOfWorld.GetLength(0);
            int cols = MapOfWorld.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"|{MapOfWorld[i, j].Name}| ");
                }
                Console.WriteLine();
            }
        }
        private void AnimalsState()
        {
            Console.WriteLine("");
            Console.WriteLine("Alive animals: ");
            foreach (Animal currentAnimal in Animals)
            {
                Console.WriteLine($"{currentAnimal.Name} {currentAnimal.Number} alive: {currentAnimal.IsAlive}");
            }
            Console.WriteLine("____________");
        }

        private void AnimalsEnergyStats()
        {
            Console.WriteLine("");
            Console.WriteLine("Animal Information: ");
            foreach (Animal currentAnimal in Animals)
            {
                Console.WriteLine($"{currentAnimal.Name} {currentAnimal.Number} energy: {currentAnimal.CurrentEnergy}/{currentAnimal.MaxEnergy} ");
            }
            Console.WriteLine("____________");
        }

        private string GetMinimalSurvivedAnimal()
        {
            Animal worstAnimal = Animals[0];
            foreach(Animal animal in Animals)
            {
                if(animal.DaysOfLife < worstAnimal.DaysOfLife)
                {
                    worstAnimal = animal;
                }
            }

            return $"Worst animal: {worstAnimal.Name} {worstAnimal.Number} survived only {worstAnimal.DaysOfLife} days.";
        }

        private string GetMaxSurvivedAnimal()
        {
            Animal bestAnimal = Animals[0];
            foreach (Animal animal in Animals)
            {
                if (animal.DaysOfLife > bestAnimal.DaysOfLife)
                {
                    bestAnimal = animal;
                }
            }

            return $"Best animal: {bestAnimal.Name} {bestAnimal.Number} survived {bestAnimal.DaysOfLife} days.";
        }

        private int GetAverageDaysSurvived()
        {
            int totalSurvivedDays = 0;
            foreach(Animal animal in Animals)
            {
                totalSurvivedDays += animal.DaysOfLife;
            }

            int averageDays = totalSurvivedDays/(_numberOfAnimals);
            return averageDays;
        }
        private static void GetConclusion(int dayOfSimulation, int averageSurvived, string minSurvivedAnimal, string maxSurvivedAnimal)
        {

            Console.WriteLine(" ");
            Console.WriteLine("Summary:");
            Console.WriteLine($"-->The simulation ended on day {dayOfSimulation}.");
            Console.WriteLine($"-->Average turns survived among all animals: {averageSurvived}.");
            Console.WriteLine("-->" + minSurvivedAnimal);
            Console.WriteLine("-->" + maxSurvivedAnimal);
        }   
    }
}
//Number or lines after each refactoring
//448 -> //303 -> //273 -> //235 -> //172