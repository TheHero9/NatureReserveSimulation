using Nature_reserve_simulation.AnimalClass.AnimalInterfaces;
using Nature_reserve_simulation.FoodClass;

namespace Nature_reserve_simulation.AnimalClass.AnimalBehaviours
{
    public class ParrotOnEatBehaviour : OnEatBehaviour
    {
        public override string Invoke(Animal animal, IFood food)
        {
            return
                base.Invoke(animal, food)
                + "\n"
                + "kakaaa";
        }
    }

    internal class ParrotOnMatureBehaviour : IOnMatureBehaviour
    {
        public int MaturingDay { get; set; }

        public ParrotOnMatureBehaviour()
        {
            MaturingDay = 3;
        }
        public string changeDiet() => "berries";
    }
}
