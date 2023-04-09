using Nature_reserve_simulation.AnimalClass.AnimalInterfaces;
using Nature_reserve_simulation.FoodClass;

namespace Nature_reserve_simulation.AnimalClass.AnimalBehaviours
{
    public class CowOnEatBehaviour : OnEatBehaviour
    {
        public override string Invoke(Animal animal, IFood food)
        {
            return
                base.Invoke(animal, food)
                + "\n"
                + "mooo mooo";
        }
    }

    internal class CowOnMatureBehaviour : IOnMatureBehaviour
    {
        public int MaturingDay { get; set; }

        public CowOnMatureBehaviour()
        {
            MaturingDay = 2;
        }

        public string changeDiet() => "berries";
    }
}
