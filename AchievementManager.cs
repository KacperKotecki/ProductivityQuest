using System;
using System.Collections.Generic;
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
        public List<string> EvaluateAchievements()
        {
            List<string> unlockedNow = new List<string>();

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
                                unlockedNow.Add(item.Name);
                            }
                            break;

                        case "Streak":
                            if (player.CalculateStreak() >= item.RequiredCount)
                            {
                                item.IsUnlocked = true;
                                item.UnlockedAt = DateTime.Now;
                                unlockedNow.Add(item.Name);
                            }
                            break;

                        case "Tasks":
                            if (item.Progress >= item.RequiredCount)
                            {
                                item.IsUnlocked = true;
                                item.UnlockedAt = DateTime.Now;
                                unlockedNow.Add(item.Name);
                            }
                            break;
                    }
                }
            }

            SaveAchievements();
            return unlockedNow;
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


        

        

        

    

