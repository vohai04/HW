using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    public class StatisticsDisplay : IWeatherObserver
    {
        private float _minTemperature = float.MaxValue;
        private float _maxTemperature = float.MinValue;
        private float _sumTemperature = 0;
        private int _count = 0;
        private IWeatherStation _weatherStation;
        public StatisticsDisplay(IWeatherStation weatherStation)
        {
            _weatherStation = weatherStation;
            _weatherStation.RegisterObserver(this);
        }
        public void Update(float temperature, float humidity, float pressure)
        {
            _count++;
            _sumTemperature += temperature;
            if (temperature < _minTemperature) _minTemperature = temperature;
            if (temperature > _maxTemperature) _maxTemperature = temperature;
        }
        public void Display()
        {
            float avgTemperature = _count > 0 ? _sumTemperature / _count : 0;
            Console.WriteLine("\nStatistics Display:");
            Console.WriteLine($"Min Temperature: {_minTemperature}°C");
            Console.WriteLine($"Max Temperature: {_maxTemperature}°C");
            Console.WriteLine($"Avg Temperature: {avgTemperature:F1}°C");
        }
    }
}
