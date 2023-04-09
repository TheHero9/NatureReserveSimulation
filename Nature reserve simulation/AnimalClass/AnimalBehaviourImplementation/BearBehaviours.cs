
using Nature_reserve_simulation.AnimalClass.AnimalInterfaces;
using Nature_reserve_simulation.FoodClass;
namespace Nature_reserve_simulation.AnimalClass.AnimalBehaviours
{
    public class BearOnEatBehaviour : OnEatBehaviour
    {
        public override string Invoke(Animal animal, IFood food)
        {
            return
                base.Invoke(animal, food)
                + "\n"
                + "huff huff";
        }
    }

    public class BearOnMatureBehaviour : IOnMatureBehaviour
    {

        public int MaturingDay { get; set;  }

        public BearOnMatureBehaviour()
        {
            MaturingDay = 5;
        }

        public string changeDiet() => "deer";
    }
}
