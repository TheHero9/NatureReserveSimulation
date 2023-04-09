
namespace Nature_reserve_simulation.AnimalClass.AnimalInterfaces
{
    public interface IOnMatureBehaviour
    {
        public int MaturingDay { get; set; } 
        public string changeDiet();
    }
}
