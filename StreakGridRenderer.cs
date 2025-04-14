using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    internal class StreakGridRenderer
    {
        private Player player;
        private Panel targetPanel;

        public StreakGridRenderer(Player player, Panel targetPanel)
        {
            this.player = player;
            this.targetPanel = targetPanel;
        }
        public void GenerateStreakGrid()
        {
            
            ToolTip tooltip = new ToolTip();
            targetPanel.BackColor = Color.FromArgb(245, 245, 245);

            int rows = 15;
            int columns = 25;
            int locationX = 0;
            int locationY = 0;
            bool isFirstDayOfStreak = true;
            DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Panel dayPanel = new Panel();
                    dayPanel.Location = new Point(locationX, locationY);
                    dayPanel.Size = new Size(34, 34);
                    dayPanel.BackColor = Color.FromArgb(220, 220, 220);

                    

                    if (player.StreakDays.Contains(startDate.Date))
                    {
                        if (isFirstDayOfStreak && player.StreakDays.Contains(startDate.Date))
                        {
                            dayPanel.BackColor = Color.FromArgb(119, 221, 119);
                            tooltip.SetToolTip(dayPanel, $"Start of streak: {startDate:dd-MM-yyyy}");
                        }
                        else
                        {
                            dayPanel.BackColor = Color.FromArgb(0, 255, 128);
                            tooltip.SetToolTip(dayPanel, $"Date: {startDate:dd-MM-yyyy}");
                        }
                    }
                    
                    isFirstDayOfStreak = false;
                    if (!player.StreakDays.Contains(startDate.Date))
                        isFirstDayOfStreak = true;

                    Label dayLabel = new Label();
                    dayLabel.Text = startDate.Day.ToString();
                    dayLabel.Font = new Font("Arial", 8, FontStyle.Bold);
                    dayLabel.ForeColor = Color.Black;
                    dayLabel.BackColor = Color.Transparent;
                    dayLabel.Location = new Point(17, 17);
                    dayLabel.Dock = DockStyle.Fill;

                    dayPanel.Controls.Add(dayLabel);
                    targetPanel.Controls.Add(dayPanel);

                    locationX += 35;
                    startDate = startDate.AddDays(1);
                }

                locationY += 35;
                locationX = 0;
            }
        }
    }
}
