namespace P01.Vehicles
{
    using System;

    using Core;
    using Factories;
    using Factories.Interfaces;
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialization of the application
            string[] carData = Console.ReadLine()
                .Split();
            string[] truckData = Console.ReadLine()
                .Split();

            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle car = vehicleFactory
                .CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));
            Vehicle truck = vehicleFactory
                .CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]));

            IEngine engine = new Engine(car, truck);
            engine.Start(); //Starts business logic
        }
    }
}
