using System;
using System.IO;
using System.Text.Json;
namespace Productivity_Quest_1._0
{
    public class JsonStorageService
    {
        public void SaveToFile<T>(T data, string fileName)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(GetPath(fileName), json);
        }

        public T LoadFromFile<T>(string fileName)
        {
            string fullPath = GetPath(fileName);

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                return JsonSerializer.Deserialize<T>(json);
            }

            return default;
        }
        private string GetPath(string fileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }
    }
}


