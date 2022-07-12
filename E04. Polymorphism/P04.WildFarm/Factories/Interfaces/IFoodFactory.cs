namespace P04.WildFarm.Factories.Interfaces
{
    using Models.Foods;

    public interface IFoodFactory
    {
        Food CreateFood(string type, int quantity);
    }
}
