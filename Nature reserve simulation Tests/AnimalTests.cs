using Nature_reserve_simulation.Animals;
using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.Foods;
using Nature_reserve_simulation.AnimalClass.AnimalBehaviours;

namespace Nature_reserve_simulation_Tests
{
    [TestClass]
    public class AnimalTests
    {

        [TestMethod]
        public void IsDecreasingEnergy()
        {
            AnimalMock testAnimal = new(new AnimalMockOnEatBehaviour(), new AnimalMockOnMatureBehaviour());
            Grass testGrass = new();
            var result = testAnimal.Feed(testGrass);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsIncreasingEnergy()
        {
            AnimalMock testAnimal = new(new AnimalMockOnEatBehaviour(), new AnimalMockOnMatureBehaviour());
            Berries testBerries = new();
            var result = testAnimal.Feed(testBerries);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsAlive()
        {
            AnimalMock testAnimal = new(new AnimalMockOnEatBehaviour(), new AnimalMockOnMatureBehaviour());
            Grass testGrass = new();
            testAnimal.Feed(testGrass);
            testAnimal.Feed(testGrass);
            testAnimal.Feed(testGrass);
            testAnimal.Feed(testGrass);

            testAnimal.UpdateAnimalStatus();
            var result = testAnimal.IsAlive;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetEaten()
        {
            AnimalMock testAnimal1 = new(new AnimalMockOnEatBehaviour(), new AnimalMockOnMatureBehaviour());
            AnimalMock testAnimal2 = new(new AnimalMockOnEatBehaviour(), new AnimalMockOnMatureBehaviour());

            Grass testGrass = new();
            testAnimal1.Feed(testGrass);
            testAnimal1.Feed(testGrass);
            testAnimal1.Feed(testGrass);

            testAnimal2.Type = "herbivore";
            testAnimal1.Feed(testAnimal2);

            var result = testAnimal2.IsAlive;

            Assert.IsFalse(result);
            


        }
    }
}