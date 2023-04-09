namespace Nature_reserve_simulation.FoodClass
{
    public interface IFood
    {
        public string Type { get; set; }
        public int MaxNutritionalValue { get; set; }
        public int CurrentNutritionalValue { get; set; }
        void GetEaten();
    }
}
