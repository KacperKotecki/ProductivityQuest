using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    public partial class Form1 : Form
    {
        private JsonStorageService saveRead;
        private Manage manage;
        private TaskPanelBuilder taskPanelBuilder;

        private CalendarControls calendarControls;
        private WeekViewRenderer weekViewRenderer;

        private DateTime currentWeekStart = DateTime.Today;
        private bool isDragging = false;
        private Point dragStartPoint;

        public Form1()
        {
            InitializeComponent();
            //ShowHelpDialog();
            saveRead = new JsonStorageService();
            manage = new Manage();
            manage.LoadTasks();

            calendarControls = new CalendarControls
            {
                FlowLayoutPanel = flowLayoutPanel_Calendar,
            };

            taskPanelBuilder = new TaskPanelBuilder(this);
            weekViewRenderer = new WeekViewRenderer(this, taskPanelBuilder, manage, calendarControls);

            weekViewRenderer.GenerateWeekView(DateTime.Today);
        }


        public void DayPanel_DoubleClick(object sender, MouseEventArgs e)
        {
            // 1. Pobieramy panel, który został kliknięty
            Panel clickedPanel = sender as Panel;
            if (clickedPanel == null) return;

            // 2. Obliczamy czas na podstawie pozycji Y kliknięcia
            // Wysokość panelu (1485px) odpowiada 1440 minutom dnia.
            double panelHeight = clickedPanel.Height;
            int totalMinutesInDay = 1440;
            int clickedMinute = (int)((e.Y / panelHeight) * totalMinutesInDay);

            int hour = clickedMinute / 60;
            int minute = clickedMinute % 60;

            // 3. Ustalamy datę na podstawie nadrzędnego panelu dnia
            // Tag panelu dnia przechowuje datę, którą ustawiliśmy w WeekViewRenderer
            DateTime dayDate = (DateTime)clickedPanel.Parent.Tag;
            DateTime suggestedStartTime = new DateTime(dayDate.Year, dayDate.Month, dayDate.Day, hour, minute, 0);

            // 4. Tworzymy nowe zadanie z sugerowanym czasem
            var newTask = new Task
            {
                StartDateTime = suggestedStartTime
            };

            // 5. Otwieramy formularz (reszta logiki pozostaje bez zmian)
            using (var editForm = new DodajZadanieForm(newTask))
            {
                var result = editForm.ShowDialog();

                if (result == DialogResult.OK && editForm.CurrentTask != null)
                {
                    manage.Tasks.Add(editForm.CurrentTask);
                    manage.SaveTasks();
                    if (editForm.CurrentTask.StartDateTime.HasValue)
                    {
                        currentWeekStart = editForm.CurrentTask.StartDateTime.Value;
                    }
                    weekViewRenderer.GenerateWeekView(currentWeekStart);
                }
            }
        }

        // Zmiana w MyPanel_DoubleClick (dla edycji)
        public void MyPanel_DoubleClick(object sender, EventArgs e)
        {
            Control source = sender as Control;
            while (source != null && !(source is Panel))
            {
                source = source.Parent;
            }
            Panel clickedPanel = source as Panel;

            if (clickedPanel?.Tag is Task task)
            {
                using (var editForm = new DodajZadanieForm(task)) // Przekazujemy tylko zadanie!
                {
                    var result = editForm.ShowDialog();

                    if (result == DialogResult.OK) // Edycja lub oznaczenie jako wykonane
                    {
                        manage.SaveTasks();
                    }
                    else if (result == DialogResult.Abort) // Nasz nowy sygnał do usunięcia
                    {
                        manage.Tasks.Remove(task);
                        manage.SaveTasks();
                    }

                    // Odświeżamy widok po każdej akcji (edycja, usunięcie, anulowanie)
                    if (task.StartDateTime.HasValue)
                    {
                        currentWeekStart = task.StartDateTime.Value;
                    }
                    weekViewRenderer.GenerateWeekView(currentWeekStart);
                }
            }
        }

        private void monthCalendar_Form_DateChanged(object sender, DateRangeEventArgs e)
        {
            currentWeekStart = monthCalendar_Form.SelectionStart;
            weekViewRenderer.GenerateWeekView(currentWeekStart);
        }

        private void btn_NextWeek_Click(object sender, EventArgs e)
        {
            currentWeekStart = currentWeekStart.AddDays(7);
            weekViewRenderer.GenerateWeekView(currentWeekStart);
            monthCalendar_Form.SetDate(currentWeekStart);
        }

        private void btn_PreviousWeek_Click(object sender, EventArgs e)
        {
            currentWeekStart = currentWeekStart.AddDays(-7);
            weekViewRenderer.GenerateWeekView(currentWeekStart);
            monthCalendar_Form.SetDate(currentWeekStart);
        }

        private Panel FindParentPanel(Control control)
        {
            while (control != null && !(control is Panel))
            {
                control = control.Parent;
            }
            return control as Panel;
        }

        private Point UpdatePanelPosition(Panel clickedPanel, MouseEventArgs e)
        {
            Point newLocation = clickedPanel.Location;
            newLocation.Y += e.Y - dragStartPoint.Y;
            newLocation.Y = Math.Max(0, Math.Min(1439, newLocation.Y));
            return newLocation;
        }

        private DateTime UpdateTaskTime(Point panelLocation, Task task) // Zmieniono nazwę i typ
        {
            if (!task.StartDateTime.HasValue)
                return DateTime.Now;

            int timelinePositionInMinutes = panelLocation.Y;
            int hours = timelinePositionInMinutes / 60;
            int minutes = timelinePositionInMinutes % 60;

            return new DateTime(task.StartDateTime.Value.Year, task.StartDateTime.Value.Month, task.StartDateTime.Value.Day, hours, minutes, 0);
        }

        private string GetFormattedTaskTime(Task task) // Zmieniono typ
        {
            if (!task.StartDateTime.HasValue) return "";
            return $"{task.StartDateTime.Value.Hour}:{task.StartDateTime.Value.Minute:D2}";
        }

        public void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = e.Location;
            }
        }

        public void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging) return;

            Panel clickedPanel = FindParentPanel(sender as Control);
            if (clickedPanel == null) return;

            if (clickedPanel.Tag is Task task) // Używamy nowej klasy Task
            {
                clickedPanel.Location = UpdatePanelPosition(clickedPanel, e);
                task.StartDateTime = UpdateTaskTime(clickedPanel.Location, task);

                var timeLabel = clickedPanel.Controls.OfType<Label>().FirstOrDefault(l => (string)l.Tag == "Time");
                if (timeLabel != null)
                {
                    timeLabel.Text = GetFormattedTaskTime(task);
                }
            }
        }

        public void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            manage.SaveTasks();
        }

        private void ShowHelpDialog()
        {
            string  message =
                "Jak korzystać z Kalendarza?\n\n" +
                "• Przesuń panel zadania, aby zmienić jego godzinę.\n" +
                "• Kliknij dwukrotnie na pusty dzień, aby dodać nowe zadanie.\n" +
                "• Kliknij dwukrotnie na istniejące zadanie, aby je edytować.\n\n" +
                "Kliknij ikonę '?' w prawym górnym rogu, aby ponownie zobaczyć tę pomoc.";
            MessageBox.Show(message, "Pomoc", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            ShowHelpDialog();
        }
    }
}
