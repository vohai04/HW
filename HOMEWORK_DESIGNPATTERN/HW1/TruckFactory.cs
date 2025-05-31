using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class TruckFactory : VehicleFactory
    {
        private int loadCapacity;
        private string fuelType;
        public TruckFactory(int loadCapacity, string fuelType)
        {
            this.loadCapacity = loadCapacity;
            this.fuelType = fuelType;
        }
        public override IVehicle CreateVehicle()
        {
            return new Truck(loadCapacity, fuelType);
        }
    }
}
