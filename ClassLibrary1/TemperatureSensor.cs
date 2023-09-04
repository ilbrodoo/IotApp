using System;

namespace IotLib
{
    // Classe per il sensore di temperatura
    public class TemperatureSensor : ISensor
    {
        public void ReadData()
        {
            double temperature = GenerateRandomValue(0, 100); 
            Console.WriteLine($"Temperature: {temperature}°C");
        }

        private double GenerateRandomValue(double minValue, double maxValue)
        {
            Random random = new Random();
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
