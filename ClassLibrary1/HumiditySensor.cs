using System;

namespace IotLib
{
    // Classe per il sensore di umidità
    public class HumiditySensor : ISensor
    {
        public void ReadData()
        {
            double humidity = GenerateRandomValue(0, 100); 
            Console.WriteLine($"Humidity: {humidity}%");
        }

        private double GenerateRandomValue(double minValue, double maxValue)
        {
            Random random = new Random();
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
