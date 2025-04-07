using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Productivity_Quest_1._0
{
    public class JsonStorageService
    {
        public void SaveToFile<T>(T data, string fileName)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, json);
        }

        public T LoadFromFile<T>(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                T result = JsonSerializer.Deserialize<T>(json);
                return result;
            }
            else
            {
                return default;
            }
        }
    }
}


