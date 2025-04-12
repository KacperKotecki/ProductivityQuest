using System;
using System.Collections.Generic;
using System.Drawing;
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
            DateTime completedYesterday = DateTime.UtcNow.Date.AddDays(-1);


            while (StreakDays.Contains(todayDate.Date))
            {
                streak++;
                todayDate = todayDate.AddDays(-1);
            }
            
            if (streak == 0 && StreakDays.Contains(completedYesterday.Date))
            {
                streak = -1;
                while(StreakDays.Contains(completedYesterday.Date))
                {
                    completedYesterday = completedYesterday.AddDays(-1);
                    streak--;
                }
            }
            
                return streak;
        }
        
        public System.Drawing.Bitmap ChangeImg(int streak)
        {
            if (streak < 0 && streak > -7)
                streak = -1;
            else 
                streak = streak / 7;
            
            var flowersImgs = new List<Bitmap>
            {
                Properties.Resources.funny_flower_0,
                Properties.Resources.funny_flower_1,
                Properties.Resources.funny_flower_2,
                Properties.Resources.funny_flower_3,
                Properties.Resources.funny_flower_4,
                Properties.Resources.funny_flower_5,
                Properties.Resources.funny_flower_6,
                Properties.Resources.funny_flower_7,
                Properties.Resources.sad_flower_0,
                Properties.Resources.sad_flower_1,
                Properties.Resources.sad_flower_2,
                Properties.Resources.sad_flower_3,
                Properties.Resources.sad_flower_4,
                Properties.Resources.sad_flower_5,
                Properties.Resources.sad_flower_6,
                
                
            };
            System.Drawing.Bitmap img = Properties.Resources.funny_flower_4;
            
            switch (streak)
            {
                
                case -8: img = flowersImgs[14]; break;
                case -7: img = flowersImgs[14]; break;
                case -6: img = flowersImgs[13]; break;
                case -5: img = flowersImgs[12]; break;
                case -4: img = flowersImgs[11]; break;
                case -3: img = flowersImgs[10]; break;
                case -2: img = flowersImgs[9]; break;
                case -1:img = flowersImgs[8]; break;
                case 0: img = flowersImgs[0]; break;
                case 1: img = flowersImgs[1]; break;
                case 2: img = flowersImgs[2]; break;
                case 3: img = flowersImgs[3]; break;
                case 4: img = flowersImgs[4]; break;
                case 5: img = flowersImgs[5]; break;
                case 6: img = flowersImgs[6]; break;
                case 7: img = flowersImgs[7]; break;
                case 8: img = flowersImgs[0]; break;


            }

            return img;
        }
       
    }
}



