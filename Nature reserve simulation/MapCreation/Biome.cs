using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.FoodClass;

namespace Nature_reserve_simulation.MapCreation
{
    public abstract class Biome
    {

        public List<string> SupportedAnimals { get; private set; } 
        public List<string> SupportedFoods {  get; private set; }

        public List<Animal> Population { get; set; }
        public List<IFood> Foods { get; set; }

        public readonly int MaxCapacity;

        public string Name { get; private set; }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }


        public Biome(List<string> supportedAnimals, List<string> supportedFoods, int maxCapacity, string name, int x, int y)
        {
            SupportedAnimals = supportedAnimals;
            SupportedFoods = supportedFoods;


            Population = new List<Animal>();
            Foods = new List<IFood>();

            MaxCapacity = maxCapacity;
            Name = name;
            PositionX = x;
            PositionY = y;
        }

        public bool AddAnimal(Animal animal)
        {
            if (CanAddAnimal(animal))
            {
                Population.Add(animal);
                Foods.Add(animal);

                return true;
            }

            throw new Exception("Can't add.");

        }
        public bool CanAddAnimal(Animal animal)
        {
            return SupportedAnimals.Contains(animal.Name);
        }

        public bool RemoveAnimal(Animal animal)
        {
            if (Population.Contains(animal))
            {
                Population.Remove(animal);
                Foods.Remove(animal);

                return true;
            }

            throw new Exception("Animal is not living here.");

        }

    }
}
