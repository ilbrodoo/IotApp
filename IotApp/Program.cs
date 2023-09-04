using IotLib;
using System;




/* Inizialmente avevo piu classi , volevo creare per ogni tipologia di Device esistente una classe a se in cui poter inizializzare il numero di sensori di cui dispone.
ho provato per diverso tempo a farlo non arrivando a una soluzione cosi ho optato per quest'altra che funziona ma non come vorrei.*/

namespace IotApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lettura del file di configurazione:");

          
            ConfigFileReader configFileReader = new ConfigFileReader();

           
            configFileReader.ReadConfigFile();
        }
    }
}
