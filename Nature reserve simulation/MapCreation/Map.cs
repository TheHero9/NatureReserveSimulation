
using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.AnimalClass.AnimalBehaviours;
using Nature_reserve_simulation.Animals;
using Nature_reserve_simulation.FoodClass;

namespace Nature_reserve_simulation.MapCreation
{
    public class Map
    {
        private int _rows { get; }
        private int _columns { get; }
        private BiomeFactory BiomeFactory { get; set; }
        private AnimalFactory AnimalFactory { get; set;}
        private FoodFactory FoodFactory { get; set; }
        private Biome[,] Matrix { get; }

        public Map(
            BiomeFactory biomeFactory,
            AnimalFactory animalFactory,
            FoodFactory foodFactory,
            int rows, int columns)
        {
            BiomeFactory = biomeFactory;
            AnimalFactory = animalFactory;
            FoodFactory = foodFactory;
            _rows = rows;
            _columns = columns;


            Matrix = GenerateMap(_rows, _columns);
            GenerateAnimals();
            GenerateFoods();
            
        }



        private Biome[,] GenerateMap(int _rows, int _columns)
        {
            Biome[,] map = new Biome[_rows, _columns];

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    map[i, j] = GetRandomBiome(i, j);
                }
            }
            return map;
        }


        private Biome GetRandomBiome(int x, int y)
        {
            var availableBiomesDict = BiomeFactory.availableBiomes;

            string randomKey = availableBiomesDict.Keys.ElementAt(GetRandomNumber(availableBiomesDict.Count));

            var randomBiome = BiomeFactory.Create(x, y, randomKey);

            return randomBiome;
        }
        private void GenerateAnimals()
        {
           Random random = new Random();

            for (int row = 0; row < Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < Matrix.GetLength(1); col++)
                {
                    var currentBiome = Matrix[row, col];
                    int[] coordinates = { row, col };

                    int randomNumberOfAnimalsInBiome = random.Next(1, currentBiome.MaxCapacity);

                    for (int i = 0; i<randomNumberOfAnimalsInBiome; i++)
                    {
                        var randomAnimal = GetRandomAnimal(currentBiome, coordinates);
                        currentBiome.AddAnimal(randomAnimal);
                    }
                }
            }
        }
        private Animal GetRandomAnimal(Biome currentBiome, int[]coordinates)
        {
            var supportedAnimals = currentBiome.SupportedAnimals;
            var chosenSupportedAnimalName = supportedAnimals[GetRandomNumber(supportedAnimals.Count)];

            var randomAnimal = AnimalFactory.Create(Matrix, coordinates, chosenSupportedAnimalName);

            return randomAnimal;
        }

        private void GenerateFoods()
        {
            for (int row = 0; row < Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < Matrix.GetLength(1); col++)
                {
                    var currentBiome = Matrix[row, col];
                    var supportedFoods = currentBiome.SupportedFoods;

                    foreach( string food in supportedFoods )
                    {
                        currentBiome.Foods.Add(FoodFactory.Create(food));
                    }
                }
            }
        }
        private static int GetRandomNumber(int maxNumber)
        {
            Random random = new Random();
            int randomIndex = random.Next(maxNumber);

            return randomIndex;
        }

        public Biome[,] GetMatrix() => Matrix;

    }
}
