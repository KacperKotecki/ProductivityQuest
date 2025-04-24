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
                controls.PictureProfile.Image = Properties.Resources.Level_10;
            }

            controls.PictureProfile.SizeMode = PictureBoxSizeMode.CenterImage;
            controls.PictureProfile.SizeMode = PictureBoxSizeMode.Zoom;

        }

        
        public System.Drawing.Bitmap ChangeImg(int streak)
        {
            if (streak < 0 && streak > -7)
                streak = -1;
            else
                streak = streak / 7;

            var happy_ghost = new List<Bitmap>
            {
                Properties.Resources.happy_ghost_0,
                Properties.Resources.happy_ghost_1,
                Properties.Resources.happy_ghost_2,
                Properties.Resources.happy_ghost_3,
                Properties.Resources.happy_ghost_4,
                Properties.Resources.happy_ghost_5,
                Properties.Resources.happy_ghost_6,
                Properties.Resources.happy_ghost_7,
                Properties.Resources.happy_ghost_8,
                Properties.Resources.happy_ghost_9,
            };
            var sad_ghost = new List<Bitmap>
            {
                Properties.Resources.sad_ghost_0,
                Properties.Resources.sad_ghost_1,
                Properties.Resources.sad_ghost_2,
                Properties.Resources.sad_ghost_3,
                Properties.Resources.sad_ghost_4,
                Properties.Resources.sad_ghost_5,
                Properties.Resources.sad_ghost_6,
                Properties.Resources.sad_ghost_7,
                Properties.Resources.sad_ghost_8,
                Properties.Resources.sad_ghost_9,


            };
            System.Drawing.Bitmap img = Properties.Resources.happy_ghost_0;

            switch (streak)
            {

                case -10: img = sad_ghost[9]; break;
                case -9: img = sad_ghost[8]; break;
                case -8: img = sad_ghost[7]; break;
                case -7: img = sad_ghost[6]; break;
                case -6: img = sad_ghost[5]; break;
                case -5: img = sad_ghost[4]; break;
                case -4: img = sad_ghost[3]; break;
                case -3: img = sad_ghost[2]; break;
                case -2: img = sad_ghost[1]; break;
                case -1: img = sad_ghost[0]; break;
                case 0: img = happy_ghost[0]; break;
                case 1: img = happy_ghost[1]; break;
                case 2: img = happy_ghost[2]; break;
                case 3: img = happy_ghost[3]; break;
                case 4: img = happy_ghost[4]; break;
                case 5: img = happy_ghost[5]; break;
                case 6: img = happy_ghost[6]; break;
                case 7: img = happy_ghost[7]; break;
                case 8: img = happy_ghost[8]; break;
                case 9: img = happy_ghost[9]; break;


            }

            return img;
        }

    }
}
