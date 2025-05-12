using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    internal class StreakGridRenderer
    {
        private Player player;
        private Panel targetPanel;
        private TaskPanelBuilder taskPanelBuilder;

        private AchievementManager achievementManager;

        public StreakGridRenderer(Player player, Panel targetPanel, TaskPanelBuilder taskPanelBuilder)
        {
            this.player = player;
            this.targetPanel = targetPanel;
            this.taskPanelBuilder = taskPanelBuilder;

        }
        
        public void GenerateStreakGrid()
        {
            targetPanel.Controls.Clear();
            targetPanel.BackColor = Color.FromArgb(220, 220, 230);
            

            ToolTip tooltip = new ToolTip();
            string[] months = new string[] {"Styczeń","Luty","Marzec","Kwiecień","Maj", "Czerwiec", "Lipiec","Sierpień","Wrzesień","Październik", "Listopad",    "Grudzień"};
            int k = 0;  
            int rows = 3;
            int columns = 4;
            int margin = 2;
            int monthX = 6;
            int monthY = 6;
            int dayX = 2;
            int dayY = 2;
            bool isFirstDayOfStreak = true;
            DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);
            int dayInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
            int currentDay = 1;


            // Obliczanie wielkości dynamicznie monthContainerPanel

            int monthContainerPanelWidth = (targetPanel.Width - (columns) * margin) / columns;
            int monthContainerPanelHeight = (targetPanel.Height - (rows) * margin) / rows;

            int monthHeaderPanelHeight = 30;
            int monthBodyPanelHeight = monthContainerPanelHeight - monthHeaderPanelHeight;

            int dayPanelWidth = (monthContainerPanelWidth - (7 + 1) * margin) / 7;
            int dayPanelHeight = (monthBodyPanelHeight - (5 + 1) * margin) / 5;

            




            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var monthContainerPanel = taskPanelBuilder.CreatePanel(new Size(monthContainerPanelWidth, monthContainerPanelHeight), Color.FromArgb(245, 245, 245), new Point(monthX, monthY));
                    
                    var monthBodyPanel = taskPanelBuilder.CreatePanel(new Size(monthContainerPanelWidth, monthBodyPanelHeight), Color.FromArgb(228, 232, 240), DockStyle.Top);
                    
                    dayX = margin;
                    dayY = margin;


                    while (currentDay <= dayInMonth)
                    {
                        for (int g = 0; g < 7; g++)
                        {
                            var dayPanel = taskPanelBuilder.CreatePanel(new Size(dayPanelWidth, dayPanelHeight), Color.FromArgb(245, 245, 245), new Point(dayX, dayY));
                            var dayNumberLabel = taskPanelBuilder.CreateLabel(startDate.Day.ToString(),10,new Size(dayPanelWidth, dayPanelHeight), FontStyle.Bold , DockStyle.Top);

                            if (player.StreakDays.Contains(startDate.Date))
                            {
                                if (isFirstDayOfStreak && player.StreakDays.Contains(startDate.Date))
                                {
                                    dayPanel.BackColor = Color.FromArgb(120, 200, 120);
                                    tooltip.SetToolTip(dayPanel, $"Start of streak: {startDate:dd-MM-yyyy}");
                                }
                                else 
                                { 

                                    dayPanel.BackColor = Color.FromArgb(80, 220, 120);
                                    tooltip.SetToolTip(dayPanel, $"Date: {startDate:dd-MM-yyyy}");
                                }
                            }
                            

                            isFirstDayOfStreak = false;
                            if (!player.StreakDays.Contains(startDate.Date))
                                isFirstDayOfStreak = true;


                            dayPanel.Controls.Add(dayNumberLabel);
                            monthBodyPanel.Controls.Add(dayPanel);
                            
                            dayX += dayPanelWidth + margin;

                            if (currentDay > dayInMonth)
                            {
                                break;
                            }

                            currentDay++;
                            startDate = startDate.AddDays(1);

                            
                        }
                        dayX = margin;
                        dayY += dayPanelHeight + margin;
                    }
                    
                    currentDay = 1;
                    dayInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

                    var monthHeaderPanel = taskPanelBuilder.CreatePanel(new Size(monthContainerPanelWidth, 30), Color.FromArgb(255, 70, 70), DockStyle.Top);
                    var monthHeaderLabel = taskPanelBuilder.CreateLabel(months[k],13, new Size(monthContainerPanelWidth, 30),FontStyle.Bold,DockStyle.Top);
                    monthHeaderPanel.Controls.Add(monthHeaderLabel);
                    monthContainerPanel.Controls.Add(monthBodyPanel);
                    monthContainerPanel.Controls.Add(monthHeaderPanel);
                    


                    targetPanel.Controls.Add(monthContainerPanel);

                    monthX += monthContainerPanelWidth + margin;
                    dayY = margin;
                    k++;
                }

                monthY += monthContainerPanelHeight + margin;
                monthX = 6;
            }

        }



        public void GenerateStreakGrid(List<Achievement> achievementsUnlocked)
        {
            targetPanel.Controls.Clear();
            ToolTip tooltip = new ToolTip();
            targetPanel.BackColor = Color.FromArgb(220, 220, 230);
            targetPanel.Padding = new Padding(5);
            targetPanel.AutoScroll = true;


            var culture = new CultureInfo("pl-PL");

            foreach (var item in achievementsUnlocked)
            {
                var achievementsPanel = taskPanelBuilder.CreatePanel(new Size(targetPanel.Width - 35, 180), Color.FromArgb(245, 245, 245),DockStyle.None);
                achievementsPanel.Margin = new Padding(5);
                achievementsPanel.Padding = new Padding(5);

                tooltip.SetToolTip(achievementsPanel, $"{item.Name} | {item.Description} \nOdblokowane: {item.UnlockedAt?.ToString("dd MMMM yyyy HH:mm", culture) ?? "—"}");
                var nameLabel = taskPanelBuilder.CreateLabel(item.Name, 14, new Size(targetPanel.Width - 35, 50), FontStyle.Bold, new Point(200, 50));

                nameLabel.Margin = new Padding(0, 0, 0, 5);


                var descLabel = taskPanelBuilder.CreateLabel(item.Description, 11, new Size(350, 60), FontStyle.Regular, new Point(220, 80));


                descLabel.TextAlign = ContentAlignment.TopLeft;
                descLabel.Margin = new Padding(0, 0, 0, 5);

                string text = item.UnlockedAt.HasValue ? item.UnlockedAt.Value.ToString("dd MMMM yyyy 'godz.' HH:mm", culture) : "";
 
                var dateLabel = taskPanelBuilder.CreateLabel(text, 9, new Size(350, 60), FontStyle.Regular, new Point(200, 150));

                string iconPath = PathHelper.GetProjectPath("Achievements_Icons", item.Icon);

                Bitmap achievementIcon = IconLoader.LoadSingleOrFallback(iconPath, Properties.Resources.deafult_achievement);

                PictureBox iconBox = taskPanelBuilder.CreateIconPictureBox(achievementIcon, new Size(160, 160), new Point(15, 15));


                achievementsPanel.Controls.Add(iconBox); 
                achievementsPanel.Controls.Add(dateLabel);
                achievementsPanel.Controls.Add(descLabel);
                achievementsPanel.Controls.Add(nameLabel);
                targetPanel.Controls.Add(achievementsPanel);
            }
        }

    }
}






