using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public abstract class VehicleFactory
    {
        public abstract IVehicle CreateVehicle();
        public void OrderVehicle()
        {
            IVehicle vehicle = CreateVehicle();

            Console.WriteLine("Ordering a new vehicle...");
            vehicle.DisplayInfo();
            vehicle.Drive();
            Console.WriteLine("Vehicle delivered!\n");
        }

    }
}
