using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class MotorcycleFactory : VehicleFactory
    {
        private string brand;
        private int engineCapacity;
        public MotorcycleFactory(string brand, int engineCapacity)
        {
            this.brand = brand;
            this.engineCapacity = engineCapacity;
        }
        public override IVehicle CreateVehicle()
        {
            return new Motorcycle(brand, engineCapacity);
        }
    }
}
