using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int ExperienceToLevelUp { get; set; } = 100;

        public HashSet<DateTime> StreakDays { get; set; } = new HashSet<DateTime>();
        


        public void AddExperience(int xpToAdd)
        {
            Experience += xpToAdd;
            CheckLevelUp();

        }

        private void CheckLevelUp()
        {
            bool leveledUp = false;
            while (Experience >= ExperienceToLevelUp)
            {
                Experience -= ExperienceToLevelUp;
                Level++;
                ExperienceToLevelUp += 50;
                leveledUp = true;
                
            }
            if (leveledUp)
            {
                MessageBox.Show($"Gratulacje! Awansowałeś na poziom {Level}!");
            }
        }

        public void RegisterTaskDay()
        {
            StreakDays.Add(DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc));
        }

        public int CalculateStreak()
        {
            int streak = 0;
            DateTime yesterday = DateTime.UtcNow.Date.AddDays(-1);

            while (StreakDays.Contains(yesterday.Date))
            {
                streak++;
                yesterday = yesterday.AddDays(-1);
            }

            DateTime today = DateTime.UtcNow.Date;

            if (!StreakDays.Contains(today.Date))
            {
                streak *= -1;
               
            }
            
                return streak;
        }
        
        
       
    }
}



