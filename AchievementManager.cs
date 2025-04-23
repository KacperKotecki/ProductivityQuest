using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    public class AchievementManager
    {

        private Player player;
        private List<Zadanie> tasks;
        private JsonStorageService saveRead;
        private List<Achievement> achievements = new List<Achievement>();

        public AchievementManager(Player player, List<Zadanie> tasks, JsonStorageService saveRead)
        {
            this.player = player;
            this.tasks = tasks;
            this.saveRead = saveRead;
        }


        public void LoadAchievements(string filePath)
        {
            achievements = saveRead.LoadFromFile<List<Achievement>>(filePath) ?? new List<Achievement>();
        }
        public void SaveAchievements()
        {
            saveRead.SaveToFile(achievements, "achievements.json");
        }
        public void AddProgress(string category)
        {


            foreach (var item in achievements)
            {

                if (!(item.IsUnlocked) && item.Category == category && item.Source == "Tasks")
                {
                    item.Progress++;
                    
                }
                

            }
        }
        public void EvaluateAchievements()
        {
            foreach (var item in achievements)
            { 
                if (!item.IsUnlocked)
                {
                    switch (item.Source)
                    {
                        case "Level":
                            if (player.Level >= item.RequiredCount)
                            {
                                item.IsUnlocked = true;
                                item.UnlockedAt = DateTime.Now;
                                MessageBox.Show($"Zdobywasz nowe osiągnięcie : {item.Name}");
                            }
                            break;
                        case "Streak":
                            if (player.CalculateStreak() >= item.RequiredCount)
                            {
                                item.IsUnlocked = true;
                                item.UnlockedAt = DateTime.Now;
                                MessageBox.Show($"Zdobywasz nowe osiągnięcie : {item.Name}");
                            }
                            break;
                        case "Task":
                            if (item.Progress >= item.RequiredCount)
                            {
                                item.IsUnlocked = true;
                                item.UnlockedAt = DateTime.Now;
                                MessageBox.Show($"Zdobywasz nowe osiągnięcie : {item.Name}");
                            }
                            break;
                        default:

                            break;
                    }
                }
            }
            SaveAchievements();
        }
        public List<Achievement> AchievementsUnlocked()
        {
            List<Achievement> achievementsUnlocked = new List<Achievement>();

            foreach (var item in achievements)
            {
                if (item.IsUnlocked)
                {
                    achievementsUnlocked.Add(item);
                }
            }
            return achievementsUnlocked;
        }


    }
}


        

        

        

    

