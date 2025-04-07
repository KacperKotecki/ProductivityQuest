using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            while (Experience >= ExperienceToLevelUp)
            {
                Experience -= ExperienceToLevelUp;
                Level++;
                ExperienceToLevelUp += 50;
               
                
            }
        }

        public void RegisterTaskDay()
        {
            StreakDays.Add(DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc));
        }

        public int CalculateStreak()
        {
            int streak = 0;
            DateTime todayDate = DateTime.UtcNow.Date;

            while (StreakDays.Contains(todayDate.Date))
            {
                streak++;
                todayDate = todayDate.AddDays(-1);
            }

            return streak;
        }

       
    }
}



