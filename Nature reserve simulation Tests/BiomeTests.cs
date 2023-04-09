using Nature_reserve_simulation.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nature_reserve_simulation_Tests
{
    [TestClass]
    public class BiomeTests
    {

        [TestMethod]
        public void CanAddAnimal()
        {
            BiomeMock testBiome = new(0,0);
            AnimalMock testAnimal = new(new AnimalMockOnEatBehaviour(), new AnimalMockOnMatureBehaviour());

            var result = testBiome.AddAnimal(testAnimal);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CannotAddAnimal()
        {
            BiomeMock testBiome = new(0, 0);
            AnimalMock testAnimal = new(new AnimalMockOnEatBehaviour(), new AnimalMockOnMatureBehaviour());

            testAnimal.Name = "parrot";
            var result = testBiome.AddAnimal(testAnimal);

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void CanRemoveAnimal()
        {
            BiomeMock testBiome = new(0, 0);
            AnimalMock testAnimal = new(new AnimalMockOnEatBehaviour(), new AnimalMockOnMatureBehaviour());

            testBiome.AddAnimal(testAnimal);

            var result = testBiome.RemoveAnimal(testAnimal);

            Assert.IsTrue(result);
        }




    }
}
