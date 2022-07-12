namespace P01.Vehicles.Models.Interfaces
{
    //Open to extension, application must be scalable
    //This interface will not be used in my business logic FOR NOW...
    //I can use this interface lately to implement Dependency Injection
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        string Drive(double distance);

        void Refuel(double liters);
    }
}
