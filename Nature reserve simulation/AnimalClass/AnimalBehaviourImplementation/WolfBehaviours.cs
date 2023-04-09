using Nature_reserve_simulation.AnimalClass.AnimalInterfaces;
using Nature_reserve_simulation.FoodClass;

namespace Nature_reserve_simulation.AnimalClass.AnimalBehaviours
{
    public class WolfOnEatBehaviour : OnEatBehaviour
    {
        public override string Invoke(Animal animal, IFood food)
        {
            return
                base.Invoke(animal, food)
                + "\n"
                + "au auauuu";
        }
    }

    internal class WolfOnMatureBehaviour : IOnMatureBehaviour
    {
        public int MaturingDay { get; set; }

        public WolfOnMatureBehaviour()
        {
            MaturingDay = 4;
        }
        public string changeDiet() => "deer";
    }
}
