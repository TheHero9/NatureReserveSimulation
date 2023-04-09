using Nature_reserve_simulation.AnimalClass;
using Nature_reserve_simulation.AnimalClass.AnimalBehaviours;
using Nature_reserve_simulation.MapCreation;

namespace Nature_reserve_simulation.Animals
{
    public class Bear : Animal
    {
        public static int numberOfBears = 0;

        public Bear(
            BearOnEatBehaviour onEatBehaviour,
            BearOnMatureBehaviour changeDietBehaviour,
            Biome[,] map,
            int[] coordinates) : 
            base(
                "bear",
                "carnivore",
                3,
                new List<string> { "fish", "berries", "bugs", "herbivore" },
                onEatBehaviour,
                changeDietBehaviour,
                map,
                coordinates)
        {
            numberOfBears++;
            this.Number = numberOfBears;
        }


        //public override void DeathSound() 
        //{
        //    Console.WriteLine("huff huff...");
        //    DieSound();
        //}

        //protected override bool isMature()
        //{
        //    return (DaysOfLife == 3);
        //}

        //public override void checkReadyToChangeDiet()
        //{
        //    if (isMature()) {
        //        Diet.Add("deer");
        //        MaturingSound();
        //    }

        //}
    }
}
