using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.Foods;

namespace Nature_reserve_simulation.FoodClass
{
    public class FoodFactory
    {
        private readonly Dictionary<string, Func<IFood>> _availableFoods;

        public FoodFactory(Dictionary<string, Func<IFood>> foods)
        {
            _availableFoods = foods;
        }

        public IFood Create(string food) => _availableFoods[food]();
    }
}
