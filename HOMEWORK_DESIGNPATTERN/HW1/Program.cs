namespace HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factory Method Pattern Homework\n");

            // Create a car using factory
            VehicleFactory carFactory = new CarFactory("Tesla Model 3", 2023);
            carFactory.OrderVehicle();

            // TODO: Create a motorcycle using the MotorcycleFactory
            // Use brand "Harley Davidson" and engine capacity 1450
            VehicleFactory motorcycleFactory = new MotorcycleFactory("Harley Davidson", 1450);
            motorcycleFactory.OrderVehicle();

            // TODO: Create a truck using the TruckFactory
            // Use load capacity 10 tons and fuel type "Diesel"
            VehicleFactory truckFactory = new TruckFactory(10, "Diesel");
            truckFactory.OrderVehicle();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
