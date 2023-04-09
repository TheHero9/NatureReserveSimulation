using Nature_reserve_simulation.FoodClass;

namespace Nature_reserve_simulation.AnimalClass.AnimalInterfaces
{
    public abstract class OnEatBehaviour
    {
        public virtual string Invoke(Animal animal, IFood food)
        {
            return "Eating: " + animal.Name + " with number " + animal.Number + " will eat " + food.Type;
        }
    }



}
