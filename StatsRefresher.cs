using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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



            string profileImagePath = Path.Combine("Profile", "Profilowe.png");

            if (File.Exists(profileImagePath))
            {
                controls.PictureProfile.Image = Image.FromFile(profileImagePath);
            }
            else
            {
                controls.PictureProfile.Image = Properties.Resources.Level_70;
            }

            controls.PictureProfile.SizeMode = PictureBoxSizeMode.CenterImage;
            controls.PictureProfile.SizeMode = PictureBoxSizeMode.Zoom;

        }


        public Bitmap ChangeImg(int streak)
        {
            var happy_ghost = new List<Bitmap>();
            for (int i = 0; i < 10; i++)
            {
                string name = $"happy_ghost_{i}";
                Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(name);
                if (img != null)
                    happy_ghost.Add(img);
            }

            var sad_ghost = new List<Bitmap>();
            for (int i = 0; i < 10; i++)
            {
                string name = $"sad_ghost_{i}";
                Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(name);
                if (img != null)
                    sad_ghost.Add(img);
            }

            Bitmap imgResult = happy_ghost[0]; // default

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
