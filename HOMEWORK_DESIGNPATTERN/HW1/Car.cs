using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class Car : IVehicle {
        public string Model { get; private set; }
        public int Year { get; private set; }
        public Car(string model, int year)
        {
            Model = model;
            Year = year;

        }
        public void Drive()
        {
            Console.WriteLine($"Driving {Model} car on the road");
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Car: {Model}, Year: {Year}");
        }
    }
}
