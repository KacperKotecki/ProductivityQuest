using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Productivity_Quest_1._0.UI;

namespace Productivity_Quest_1._0
{
    internal class StatsRefresher
    {
        private StatsControls controls;
        private Player player;
        

        public StatsRefresher(Player player, StatsControls controls)
        {
            this.player = player;
            this.controls = controls;
        }

        public void RefreshStats()
        {
            string streakmessage;
            controls.LabelName.Text = player.Name ?? "Gracz";
            controls.LabelLevel.Text = $"Poziom: {player.Level}";
            controls.LabelXP.Text = $"XP: {player.Experience}/{player.ExperienceToLevelUp}";
            controls.ProgressLevel.Maximum = player.ExperienceToLevelUp;
            controls.ProgressLevel.Value = Math.Min(player.Experience, controls.ProgressLevel.Maximum);


            if (player.CalculateStreak() >= 0)
                streakmessage = $"Streak: {player.CalculateStreak()} dni z rzędu!";
            else
                streakmessage = "Przedłuż streak dzisiaj !!!";

            controls.LabelStreak.Text = streakmessage;
            controls.PictureStreak.Image = ChangeImg(player.CalculateStreak());

            controls.PictureStreak.SizeMode = PictureBoxSizeMode.CenterImage;
            controls.PictureStreak.SizeMode = PictureBoxSizeMode.StretchImage;

            string profileFolderPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
           
            string profilePath = Path.Combine(profileFolderPath, "Profile", "duch.png");
            MessageBox.Show(profileFolderPath + "    " +profilePath);
            //string profileFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Profile", "profile.png");

            Bitmap avatar = IconLoader.LoadSingleOrFallback(profilePath, Properties.Resources.default_profile);

            controls.PictureProfile.Image = avatar;
            controls.PictureProfile.SizeMode = PictureBoxSizeMode.Zoom;
 
        }


        public Bitmap ChangeImg(int streak)
        {
            var happy_ghost = IconLoader.LoadFromResources("happy_ghost", 10);
            var sad_ghost = IconLoader.LoadFromResources("sad_ghost", 10);
            Bitmap imgResult = happy_ghost[0]; 

            int index = streak / 7;

            if (streak > 0)
            {
                imgResult = happy_ghost[Math.Min(index, happy_ghost.Count - 1)];
            }
            else if (streak < 0)
            {
                imgResult = sad_ghost[Math.Min(Math.Abs(index), sad_ghost.Count - 1)];
            }
            else
            {
                imgResult = happy_ghost[0];
            }

            return imgResult;
        }

    }
}
