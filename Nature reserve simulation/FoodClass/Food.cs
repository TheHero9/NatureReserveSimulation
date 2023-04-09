using Nature_reserve_simulation.MapCreation;

namespace Nature_reserve_simulation.FoodClass
{
    public class Food : IFood
    {
        public string Type { get; set; }
        public int MaxNutritionalValue { get; set; }

        public int CurrentNutritionalValue { get; set; }

        public Food(string type, int maxNutritionalValue)
        {
            Type = type;
            MaxNutritionalValue = maxNutritionalValue;
            CurrentNutritionalValue = maxNutritionalValue;
        }

        public void GetEaten()
        {
            //Console.WriteLine("Someone ate me");
        }
    }
}
