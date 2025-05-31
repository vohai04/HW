using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    #region Observer Implementations
    internal class CurrentConditionsDisplay : IWeatherObserver
    {
        // TODO: Implement CurrentConditionsDisplay class that implements IWeatherObserver
        // 1. The class should have temperature, humidity, and pressure fields
        // 2. Implement the Update method to update these fields when notified
        // 3. Implement a Display method to show the current conditions
        // 4. The constructor should accept an IWeatherStation and register itself with that station

        // TODO: Implement StatisticsDisplay class that implements IWeatherObserver
        // 1. The class should track min, max, and average temperature
        // 2. Implement the Update method to update these statistics when notified
        // 3. Implement a Display method to show the temperature statistics
        // 4. The constructor should accept an IWeatherStation and register itself with that station

        // TODO: Implement ForecastDisplay class that implements IWeatherObserver
        // 1. The class should track the last pressure reading to predict the forecast
        // 2. Implement the Update method to update the forecast when notified
        // 3. Implement a Display method to show the weather forecast
        // 4. The constructor should accept an IWeatherStation and register itself with that station
        // 5. The forecast logic can be simple: if pressure is rising -> "Improving weather",
        //    if it's falling -> "Cooler, rainy weather", if no change -> "Same weather"
        private float _temperature;
        private float _humidity;
        private float _pressure;
        private IWeatherStation _weatherStation;
        public CurrentConditionsDisplay(IWeatherStation weatherStation)
        {
            _weatherStation = weatherStation;
            _weatherStation.RegisterObserver(this);
        }
        public void Update(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
        }
        public void Display()
        {
            Console.WriteLine("\nCurrent Conditions Display:");
            Console.WriteLine($"Temperature: {_temperature}°C");
            Console.WriteLine($"Humidity: {_humidity}%");
            Console.WriteLine($"Pressure: {_pressure} hPa");
        }
    }
    #endregion
}
