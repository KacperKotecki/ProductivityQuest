using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{

    public class Manage
    {
        public List<Task> Tasks = new List<Task>();
        private JsonStorageService saveRead = new JsonStorageService();

        public void LoadTasks()
        {
            Tasks = saveRead.LoadFromFile<List<Task>>("data.json") ?? new List<Task>();
        }

        public void SaveTasks()
        {
            saveRead.SaveToFile(Tasks, "data.json");
        }
    }
}



