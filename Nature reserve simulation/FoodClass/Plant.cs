namespace Nature_reserve_simulation.FoodClass
{
    public class Plant : IPlant
    {
        public string Type { get; set; }
        public int MaxNutritionalValue { get; set; }
        public int CurrentNutritionalValue { get; set; }

        public Plant(string type, int maxNutritionValue)
        {
            Type = type;
            MaxNutritionalValue = maxNutritionValue;
            CurrentNutritionalValue = maxNutritionValue;
        }

         public void RegrowNutritionalValue()
        {
            if (CurrentNutritionalValue < MaxNutritionalValue)
            {
                CurrentNutritionalValue++;
            }
        }

        public void GetEaten()
        {

            CurrentNutritionalValue = 0;
        }
    }

}
