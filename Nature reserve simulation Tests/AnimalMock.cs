using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.AnimalClass.AnimalBehaviours;
using Nature_reserve_simulation.AnimalClass.AnimalInterfaces;
using Nature_reserve_simulation.FoodClass;
using Nature_reserve_simulation.MapCreation;

namespace Nature_reserve_simulation_Tests
{

    public class AnimalMockOnEatBehaviour : OnEatBehaviour
    {
        public override string Invoke(Animal animal, IFood food)
        {
            return
                base.Invoke(animal, food)
                + "\n"
                + "meow meow";
        }
    }

    public class AnimalMockOnMatureBehaviour : IOnMatureBehaviour
    {

        public int MaturingDay { get; set; }

        public AnimalMockOnMatureBehaviour()
        {
            MaturingDay = 5;
        }

        public string changeDiet() => "deer";
    }

    internal class AnimalMock : Animal
    {
        public static int numberOfAnimalMocks = 0;

        public AnimalMock(
            AnimalMockOnEatBehaviour onEatBehaviour,
            AnimalMockOnMatureBehaviour changeDietBehaviour,
            Biome[,]? map = null,
            int[]? coordinates = null) :
            base(
                "mock",
                "carnivore",
                4,
                new List<string> { "fish", "berries", "bugs", "herbivore" },
                onEatBehaviour,
                changeDietBehaviour,
                map,
                coordinates)
        {
            numberOfAnimalMocks++;
            this.Number = numberOfAnimalMocks;
        }
    }
}
