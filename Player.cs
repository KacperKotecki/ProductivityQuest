using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productivity_Quest_1._0
{
    public class Player
    {
        public string Imie { get; set; }
        public int Poziom { get; set; }
        public int XP { get; set; }
        public int XPNaPoziom { get; set; } = 100;

        public HashSet<DateTime> Streak { get; set; } = new HashSet<DateTime>();
        


        public void DodajXP(int xp)
        {
            XP += xp;
            SprawdzPoziom();

        }

        private void SprawdzPoziom()
        {
            while (XP >= XPNaPoziom)
            {
                XP -= XPNaPoziom;
                Poziom++;
                XPNaPoziom += 50;
               
                
            }
        }

        public void ZarejestrujDzienZadania()
        {
            Streak.Add(DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Unspecified));
        }

        public int ObliczStreak()
        {
            int streak = 0;
            DateTime dzien = DateTime.Now.Date;

            while (Streak.Contains(dzien.Date))
            {
                streak++;
                dzien = dzien.AddDays(-1);
            }

            return streak;
        }

        public void PokazStatystyki()
        {
            Console.WriteLine($"Statystyki gracza: {Imie}");
            Console.WriteLine($"• Poziom: {Poziom}");
            Console.WriteLine($"• XP: {XP}/{XPNaPoziom}");
            Console.WriteLine($"• Streak: {ObliczStreak()} dni z rzędu");

            
        }
    }
}



