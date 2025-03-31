using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Productivity_Quest_1._0
{
    internal class Save_read
    {
        public void SaveFileJSON<T>(T dane, string nazwaPliku)
        {
            string savetojson = JsonSerializer.Serialize(dane);
            File.WriteAllText(nazwaPliku, savetojson);
            Console.WriteLine($"Zapisano dane do pliku {nazwaPliku}");
        }
        public T ReadFileJSON<T>(string nazwaPliku)
        {
            if (File.Exists(nazwaPliku))
            {
                string readfromjson = File.ReadAllText(nazwaPliku);
                T daneZPliku = JsonSerializer.Deserialize<T>(readfromjson);
                Console.WriteLine("Wczytano dane z pliku");
                return daneZPliku;
            }
            else
            {
                Console.WriteLine("Brak pliku...");
                return default(T);
            }

        }
    }
}


