using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{

    public class Manage
    {
        public List<Zadanie> Tasks = new List<Zadanie>();
        private JsonStorageService saveRead = new JsonStorageService();

        private readonly Dictionary<string, Tuple<int, int>> PriorityXP = new Dictionary<string, Tuple<int, int>>()
        {
             { "Niski", Tuple.Create(50, 1) },
             { "Średni", Tuple.Create(80, 2) },
             { "Wysoki", Tuple.Create(100, 2) }
        };

        public void LoadTasks()
        {
            Tasks = saveRead.LoadFromFile<List<Zadanie>>("data.json") ?? new List<Zadanie>();
        }

        public void SaveTasks()
        {
            saveRead.SaveToFile(Tasks, "data.json");
        }
        public string TaskCompleted(Zadanie done, Player player)
        {
            

                

            done.IsCompleted = true;
            
            Tuple<int, int> item;
            if (!PriorityXP.TryGetValue(done.Priority, out item))
            {
                item = Tuple.Create(10, 1);
                
            }

            int points = item.Item1;
            int multiplier = item.Item2;

            int earnedXP = points * multiplier + (int)done.DurationMinutes;

            
            player.AddExperience(earnedXP);
            player.RegisterTaskDay();

            return $"Zadanie wykonane! Zdobyto {earnedXP} XP. Brawo!";
        }
    }

    

}



