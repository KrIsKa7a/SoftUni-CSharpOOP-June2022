namespace P01.Vehicles.Factories.Interfaces
{
    using Models;

    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption);
    }
}
