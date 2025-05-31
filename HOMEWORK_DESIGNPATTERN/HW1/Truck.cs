using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class Truck : IVehicle
    {
        private int loadCapacity;
        private string fuelType;
        public Truck(int loadCapacity, string fuelType)
        {
            this.loadCapacity = loadCapacity;
            this.fuelType = fuelType;
        }
        public void Drive()
        {
            Console.WriteLine($"Driving truck with load capacity {loadCapacity} tons and fuel type {fuelType}");
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Truck: Load Capacity = {loadCapacity} tons, Fuel Type = {fuelType}");
        }
    }
}
