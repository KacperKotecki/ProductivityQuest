using Productivity_Quest_1._0.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                case -1: img = flowersImgs[8]; break;
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
