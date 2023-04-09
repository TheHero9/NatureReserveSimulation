using Nature_reserve_simulation.AnimalClass.AnimalInterfaces;
using Nature_reserve_simulation.FoodClass;
using Nature_reserve_simulation.MapCreation;
using System.Collections.Generic;

namespace Nature_reserve_simulation.AnimalClass
{
    public abstract class Animal : IFood
    {
        //public ISpeak speakerbehaviour;
        public IOnMatureBehaviour dietBehaviour;

        private OnEatBehaviour _onEat;
        public string Name { get; set; }
        public int MaxNutritionalValue { get; set; }
        public int CurrentNutritionalValue { get; set; }

        public int Number { get; set; }
        public string Type { get; set; }
        public int DaysOfLife { get; private set; }
        public int MaxEnergy { get; private set; }
        public int CurrentEnergy { get; private set; }
        public bool IsAlive { get; private set; }

        protected List<string> Diet { get; }
        public Biome[,]? GeneratedMap { get; }
        public int[]? Coordinates { get; }
        public Biome? CurrentBiome { get; private set; }

        public Animal(
            string name,
            string type,
            int maxEnergy,
            List<string> diet,
            OnEatBehaviour onEat,
            IOnMatureBehaviour dietBehaviour,
            Biome[,]? map,
            int[]? coordinates){

            Name = name;
            Type = type;
            MaxEnergy = maxEnergy;
            MaxNutritionalValue = maxEnergy;
            CurrentEnergy = maxEnergy;
            Diet = diet;
            this._onEat = onEat;
            this.dietBehaviour = dietBehaviour;
            GeneratedMap = map;
            Coordinates = coordinates;

            int x = Coordinates?[0] ?? 0;
            int y = Coordinates?[1] ?? 0;
            CurrentBiome = GeneratedMap?[x, y] ?? null;

            IsAlive = true;
            DaysOfLife = 1;
        }



        public bool Feed(IFood food)
        {
            if(Diet.Contains(food.Type))
            {
                CurrentEnergy = Math.Min(CurrentEnergy + food.CurrentNutritionalValue, MaxEnergy);

                //Console.WriteLine($"{food.Type} and {food.CurrentNutritionalValue}");
                //EatingSound(food);
                _onEat.Invoke(this, food);

                food.GetEaten();

                return true;
            }
            else
            {
                if (IsStarving())
                {
                    StarvingSound();
                }

                CurrentEnergy--;

                NotEatingSound(food);

                return false;
            }
        }

        public void GetEaten()
        {
            IsAlive = false;
            CurrentEnergy = 0;
            DeathSound();
        }

        private void AddDayOfLife() { DaysOfLife++; }
        private bool IsMature() => DaysOfLife == dietBehaviour.MaturingDay;
        public void CheckReadyToMature()
        {
            if (IsMature())
            {
                Diet.Add(dietBehaviour.changeDiet());
                MaturingSound();
            }
        }
        private bool IsStarving() => (CurrentEnergy <= MaxEnergy / 2);

        public void UpdateAnimalStatus()
        {
            if (CurrentEnergy <= 0)
            {
                IsAlive = false;
                DeathSound();
            }
            else
            {
                AddDayOfLife();
            }

        }

        public void TryToMove()
        {
            if(GeneratedMap.Length > 1)
            {
                var neighbores = GetNeigbores();

                Random random = new Random();
                int index = random.Next(neighbores.Count);

                var chosenBiome = neighbores[index];

                if (chosenBiome.CanAddAnimal(this))
                {
                    chosenBiome.AddAnimal(this);
                    CurrentBiome.RemoveAnimal(this);

                    MovingSound(chosenBiome);

                    CurrentBiome = chosenBiome;
                    Coordinates[0] = chosenBiome.PositionX;
                    Coordinates[1] = chosenBiome.PositionY;


                }
            }
            
        }

        private List<Biome> GetNeigbores()
        {
            int x = Coordinates[0];
            int y = Coordinates[1];

            List<Biome> neighbors = new();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    int neighborX = x + i;
                    int neighborY = y + j;

                    if (neighborX >= 0 && neighborX < GeneratedMap.GetLength(0) &&
                        neighborY >= 0 && neighborY < GeneratedMap.GetLength(1))
                    {
                        neighbors.Add(GeneratedMap[neighborX, neighborY]);
                    }
                }
            }

            return neighbors;
        }

        private void NotEatingSound(IFood selectedFood)
        {
            Console.WriteLine("Not Eating: " + Name + " with number " + Number + " won't eat " + selectedFood.Type);
        }
        public  virtual void DeathSound()
        {
            //Console.WriteLine(speakerbehaviour.makeSound());
            Console.WriteLine("Death: " + Name + " " + Number + " just died.");
            Console.WriteLine("Final: " + Name + " " + Number + " survived days: " + DaysOfLife);
        }

        private void StarvingSound()
        {
            Console.WriteLine($"Starving: {Name} number {Number} with {CurrentEnergy}/{MaxEnergy} energy.");
        }

        private void MaturingSound()
        {
            Console.WriteLine($"Maturing: {Name} number {Number} is maturing.");
        }

        private void MovingSound(Biome chosenBiome)
        {
            Console.WriteLine(
                   $"Moving: {Name} {Number} moved from {CurrentBiome.Name} (x:{CurrentBiome.PositionX} y:{CurrentBiome.PositionY})" +
                   $" to {chosenBiome.Name} (x:{chosenBiome.PositionX} y:{chosenBiome.PositionY})");
        }

    }
}
