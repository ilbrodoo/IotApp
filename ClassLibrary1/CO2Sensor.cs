using IotLib;
using System;

namespace IotLib
{

    // Classe per il sensore di CO2
    public class CO2Sensor : ISensor
    {
        public void ReadData()
        {
            double humidity = GenerateRandomValue(0, 100); 
            Console.WriteLine($"CO2: {humidity}");
        }

        private double GenerateRandomValue(double minValue, double maxValue)
        {
            Random random = new Random();
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }

}

