using Productivity_Quest_1._0.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        public void GenerateWeekView()
        {

            calendarControls.FlowLayoutPanel.Controls.Clear();
            calendarControls.FlowLayoutPanel.BackColor = Color.FromArgb(240, 240, 245);
            
            List<DateTime> dnitygodnia = new List<DateTime>();
            DateTime today = DateTime.UtcNow;
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
            int height = calendarControls.FlowLayoutPanel.Height;
            int width = (calendarControls.FlowLayoutPanel.Width - 4 * 7) / 7;
            string[] dayInWeek = { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };




            for (int i = 0; i < 7; i++)
            {

                Panel dayPanelForm = new Panel();

                dayPanelForm.Controls.Clear();

                dayPanelForm.Location = new Point(locationX, locationY);
                dayPanelForm.Size = new Size(width, height);
                dayPanelForm.BackColor = Color.FromArgb(220, 230, 240);
                dayPanelForm.Padding = Padding.Empty;
                dayPanelForm.Margin = new Padding(2, 0, 2, 0);
                locationX += width;
                calendarControls.FlowLayoutPanel.Controls.Add(dayPanelForm);

                string formattedDate = Monday.ToString("dd MMMM", culture);
                var labelday = taskPanelBuilder.CreateMyLabel(dayInWeek[i]);
                var labeldate = taskPanelBuilder.CreateMyLabel(formattedDate);
                foreach (var task in manage.Tasks)
                {
                    if (task.Deadline.Value.Date == Monday.Date)
                    {
                        var labeltask = taskPanelBuilder.CreateMyPanel(task);
                        dayPanelForm.Controls.Add(labeltask);



                    }
                }
                Monday = Monday.AddDays(1);



                labelday.ForeColor = Color.FromArgb(30, 30, 40);
                labeldate.ForeColor = Color.FromArgb(30, 30, 40);


                dayPanelForm.Controls.Add(labeldate);
                dayPanelForm.Controls.Add(labelday);

                dayPanelForm.DoubleClick += form1.DayPanel_DoubleClick;
            }




        }
    }
}
