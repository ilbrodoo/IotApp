using System;
using System.Collections.Generic;
using System.IO;

namespace IotLib
{
    public class ConfigFileReader
    {
        private readonly string configFile = @"C:\Net_Training_Example\IotApp\IotApp\Config.txt";

        private readonly Dictionary<string, ISensor> sensorDictionary = new Dictionary<string, ISensor>();

        public ConfigFileReader()
        {
            
            sensorDictionary["temperature"] = new TemperatureSensor();
            sensorDictionary["humidity"] = new HumiditySensor();
            sensorDictionary["co2"] = new CO2Sensor();
        }

        public void ReadConfigFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(configFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            string deviceType = parts[0].Trim();
                            string deviceConfig = parts[1].Trim();

                            Console.WriteLine($"Tipo di dispositivo: {deviceType}");
                            string[] sensors = deviceConfig.Split(' ');

                            // Determina quanti sensori devono essere stampati in base al tipo di dispositivo
                            int sensorCount = 0;
                            switch (deviceType.ToLower())
                            {
                                case "entry":
                                    sensorCount = 1;
                                    break;
                                case "pro":
                                    sensorCount = 4;
                                    break;
                                case "super":
                                    sensorCount = 8;
                                    break;
                                default:
                                    Console.WriteLine($"Tipo di dispositivo sconosciuto: {deviceType}");
                                    break;
                            }

                            // Stampa i dati dei sensori il numero corretto di volte
                            foreach (var sensor in sensors)
                            {
                                if (sensorDictionary.ContainsKey(sensor.Trim()))
                                {
                                    ISensor sensorInstance = sensorDictionary[sensor.Trim()];
                                    for (int i = 0; i < sensorCount; i++)
                                    {
                                        sensorInstance.ReadData();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Tipo di sensore sconosciuto: {sensor}");
                                }
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Errore nella lettura del file di configurazione: {e.Message}");
            }
        }
    }

}



