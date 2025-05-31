using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    public class ForecastDisplay : IWeatherObserver
    {
        private float _lastPressure;
        private float _currentPressure;
        private bool _isFirstUpdate = true;
        private IWeatherStation _weatherStation;
        public ForecastDisplay(IWeatherStation weatherStation)
        {
            _weatherStation = weatherStation;
            _weatherStation.RegisterObserver(this);
        }
        public void Update(float temperature, float humidity, float pressure)
        {
            if (_isFirstUpdate)
            {
                _lastPressure = pressure;
                _isFirstUpdate = false;
            }
            else
            {
                _lastPressure = _currentPressure;
            }
            _currentPressure = pressure;
        }
        public void Display()
        {
            string forecast;
            Console.WriteLine("\nForecast Display:");
            if (_isFirstUpdate)
            {
                forecast = "No forecast available (initial reading)";
            }
            else if (_currentPressure > _lastPressure)
            {
                forecast = "Improving weather";
            }
            else if (_currentPressure < _lastPressure)
            {
                forecast = "Cooler, rainy weather";
            }
            else
            {
                forecast = "Same weather";
            }
            Console.WriteLine($"Forecast: {forecast}");
        }
    }
}
