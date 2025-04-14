using Productivity_Quest_1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{

    public class Manage
    {
        public List<Zadanie> Tasks = new List<Zadanie>();

        public void TaskCompleted(Zadanie done, Player player)
        {
            if (done != null)
            {
                done.IsCompleted = true;
                int points = 0;
                int multiplier = 0;
                switch (done.Priority)
                {
                    case "Niski":
                        points = 100;
                        multiplier = 3;
                        
                        break;
                    case "Średni":
                        points = 80;
                        multiplier = 2;
                        break;
                    case "Wysoki":
                        points = 50;
                        multiplier = 1;
                        break;
                    default:
                        points = 10;
                        multiplier = 1;
                        break;
                }
                int earnedXP = points * multiplier + (int)done.DurationMinutes;
                player.AddExperience(earnedXP);
                player.RegisterTaskDay();
                MessageBox.Show($"Zadanie wykonane! Zdobyto {earnedXP} XP.", "Brawo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    
}



