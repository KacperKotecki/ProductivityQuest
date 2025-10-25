using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    internal class WeekViewRenderer
    {
        private Form1 form1;
        private TaskPanelBuilder taskPanelBuilder;
        private CalendarControls calendarControls;
        private Manage manage;

        public WeekViewRenderer(Form1 form1, TaskPanelBuilder taskPanelBuilder, Manage manage, CalendarControls calendarControls)
        {
            this.form1 = form1;
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

            var culture = new CultureInfo("pl-PL");
            DateTime today = startDate;

            // Uproszczona logika znajdowania poniedziałku
            DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;
            while (today.DayOfWeek != firstDayOfWeek)
            {
                today = today.AddDays(-1);
            }
            DateTime Monday = today;

            int width = ((calendarControls.FlowLayoutPanel.Width - 4 * 7) / 7) - 2;
            int height = 1525;
            string[] dayInWeek = { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };

            for (int i = 0; i < 7; i++)
            {
                Panel dayPanelForm = taskPanelBuilder.CreatePanel(new Size(width, height), Color.FromArgb(220, 230, 240), new Point(0, 0));
                dayPanelForm.Padding = new Padding(0, 5, 0, 0);
                dayPanelForm.Margin = new Padding(2, 0, 2, 0);

                calendarControls.FlowLayoutPanel.Controls.Add(dayPanelForm);

                Panel panelHeader = taskPanelBuilder.CreatePanel(new Size(width, 40), Color.Transparent, DockStyle.Top);

                string formattedDate = Monday.ToString("dd MMMM", culture);
                var labelday = taskPanelBuilder.CreateLabel(dayInWeek[i], 10, new Size(width, 18), FontStyle.Bold, DockStyle.Top);
                var labeldate = taskPanelBuilder.CreateLabel(formattedDate, 10, new Size(width, 18), FontStyle.Bold, DockStyle.Top);

                panelHeader.Controls.Add(labeldate);
                panelHeader.Controls.Add(labelday);

                Panel panelTimeline = taskPanelBuilder.CreatePanel(new Size(width, height - 40), Color.Transparent, DockStyle.Top);

                foreach (var task in manage.Tasks)
                {
                    // Zaktualizowano warunek, aby używał StartDateTime z nowej klasy Task
                    if (task.StartDateTime.HasValue && task.StartDateTime.Value.Date == Monday.Date)
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
