using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Productivity_Quest_1._0.UI;

namespace Productivity_Quest_1._0
{
    internal class WeekViewRenderer
    {
        private Form1 form1;

        private StatsControls statsControls;

        private TaskPanelBuilder taskPanelBuilder;

        private CalendarControls calendarControls;


        private Manage manage;
        public WeekViewRenderer(Form1 form1, StatsControls statsControls, TaskPanelBuilder taskPanelBuilder, Manage manage, CalendarControls calendarControls)
        {
            this.form1 = form1;
            this.statsControls = statsControls;
            this.taskPanelBuilder = taskPanelBuilder;
            this.manage = manage;
            this.calendarControls = calendarControls;
        }


        public void GenerateWeekView(DateTime startDate)
        {

            calendarControls.FlowLayoutPanel.Controls.Clear();
            calendarControls.FlowLayoutPanel.BackColor = Color.FromArgb(240, 240, 245);
            calendarControls.FlowLayoutPanel.AutoScroll = true;
            calendarControls.FlowLayoutPanel.Padding = new Padding(0);
            


            List<DateTime> dnitygodnia = new List<DateTime>();
            DateTime today = startDate;
            var culture = new CultureInfo("pl-PL");
            int sunday = (int)today.DayOfWeek;

            if (sunday == 0)
            {
                sunday = 7;
                while ((int)DayOfWeek.Monday < sunday)
                {
                    today = today.AddDays(-1);
                    sunday--;

                }


            }
            else
            {
                while (DayOfWeek.Monday < today.DayOfWeek)
                {
                    today = today.AddDays(-1);

                }
            }

            DateTime Monday = today;




            int locationX = 100;
            int locationY = 100;
            int FlowLayoutPanelheight = calendarControls.FlowLayoutPanel.Height;
            int width = ((calendarControls.FlowLayoutPanel.Width - 4 * 7) / 7) - 2;
            int height = 1530;
            string[] dayInWeek = { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };



            
            for (int i = 0; i < 7; i++)
            {

                Panel dayPanelForm = new Panel();

                dayPanelForm.Controls.Clear();

                dayPanelForm.Location = new Point(locationX, locationY);
                dayPanelForm.Size = new Size(width, height);
                dayPanelForm.BackColor = Color.FromArgb(220, 230, 240);
                dayPanelForm.Padding = new Padding(0, 5, 0, 0);
                dayPanelForm.Margin = new Padding(2, 0, 2, 0);
                locationX += width;
                calendarControls.FlowLayoutPanel.Controls.Add(dayPanelForm);


                Panel panelHeader = taskPanelBuilder.CreatePanel(new Size(width, 40), Color.Transparent, DockStyle.Top);

                string formattedDate = Monday.ToString("dd MMMM", culture);
                var labelday = taskPanelBuilder.CreateLabel(dayInWeek[i], 10, new Size(width, 18), FontStyle.Bold, DockStyle.Top);
                var labeldate = taskPanelBuilder.CreateLabel(formattedDate, 10, new Size(width, 18), FontStyle.Bold, DockStyle.Top);

                panelHeader.Controls.Add(labelday);
                panelHeader.Controls.Add(labeldate);


                Panel panelTimeline = taskPanelBuilder.CreatePanel(new Size(width, height - 40), Color.Transparent, DockStyle.Top);

                foreach (var task in manage.Tasks)
                {
                    if (task.Deadline.Value.Date == Monday.Date)
                    {
                        var labeltask = taskPanelBuilder.CreateMyPanel(task, width, height);
                        panelTimeline.Controls.Add(labeltask);
                    }
                }
                Monday = Monday.AddDays(1);

                dayPanelForm.Controls.Add(panelTimeline);
                dayPanelForm.Controls.Add(panelHeader);


                panelTimeline.DoubleClick += form1.DayPanel_DoubleClick;

                
            }




        }


    }
}
