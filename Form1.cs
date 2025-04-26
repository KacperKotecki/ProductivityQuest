using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Productivity_Quest_1._0.UI;

namespace Productivity_Quest_1._0
{
    // TODO: dodać gif kwiatka
    // TODO: ikona aplikacji
    // FIXME: ogarnąć system powiadomień
    public partial class Form1 : Form
    {
        private Player player;
        private JsonStorageService saveRead;
        private Manage manage;
        private AchievementManager achievementManager;
        private StatsControls statsControls;
        private TaskPanelBuilder taskPanelBuilder;
        private StatsRefresher statsRefresher;
        private CalendarControls calendarControls;
        private WeekViewRenderer weekViewRenderer;

        private DateTime currentWeekStart = DateTime.Today;
        private bool isDragging = false;
        private Point dragStartPoint;
        protected int newLocationY;
        public Form1()
        {
            InitializeComponent();
            ShowHelpDialog();
            player = new Player();
            saveRead = new JsonStorageService();
            manage = new Manage();
            manage.LoadTasks();

            player = saveRead.LoadFromFile<Player>("player.json") ?? new Player();

            achievementManager = new AchievementManager(player, manage.Tasks, saveRead);
            achievementManager.LoadAchievements("achievements.json");

            if (lb_Name == null || lb_Poziom == null || lb_XP == null || lb_Streak == null || Progress_Level == null || pictureBox_Streak == null || pictureBox_Profile == null)
            {
                MessageBox.Show("Błąd inicjalizacji kontrolek. Statystyki nie będą działać poprawnie.");
            }

            statsControls = new StatsControls
            {
                LabelName = lb_Name,
                LabelLevel = lb_Poziom,
                LabelXP = lb_XP,
                LabelStreak = lb_Streak,
                ProgressLevel = Progress_Level,
                PictureStreak = pictureBox_Streak,
                PictureProfile = pictureBox_Profile
            };

            calendarControls = new CalendarControls
            {
                FlowLayoutPanel = flowLayoutPanel_Calendar,

            };


            taskPanelBuilder = new TaskPanelBuilder(this);

            statsRefresher = new StatsRefresher(player, statsControls);
            weekViewRenderer = new WeekViewRenderer(this, statsControls, taskPanelBuilder, manage, calendarControls);

            statsRefresher.RefreshStats();
            weekViewRenderer.GenerateWeekView(DateTime.Today);
        }

        public void DayPanel_DoubleClick(object sender, EventArgs e)
        {
            var newTask = new Zadanie();
            using (var editForm = new DodajZadanieForm(newTask, manage))
            {
                var result = editForm.ShowDialog();

                if (result == DialogResult.OK && editForm != null)
                {

                    manage.Tasks.Add(newTask);

                    manage.SaveTasks();
                    taskPanelBuilder.CreateMyPanel(newTask, calendarControls.FlowLayoutPanel.Width, calendarControls.FlowLayoutPanel.Height); // powina być dobra szerokośc 
                    currentWeekStart = newTask.Deadline.Value;
                    weekViewRenderer.GenerateWeekView(currentWeekStart);

                }
            }
        }



        public void MyPanel_DoubleClick(object sender, EventArgs e)
        {
            Control source = sender as Control;
            while (source != null && !(source is Panel))
            {
                source = source.Parent;
            }
            Panel clickedPanel = source as Panel;

            if (clickedPanel != null && clickedPanel?.Tag is Zadanie task)
            {

                bool wasCompletedBefore = task.IsCompleted;

                using (var editForm = new DodajZadanieForm(task, manage))
                {
                    editForm.Text = "Edycja zadania";


                    var result = editForm.ShowDialog();

                    // Po zamknięciu: czy użytkownik wykonał zadanie teraz?
                    if (!wasCompletedBefore && task.IsCompleted)
                    {
                        string message = manage.TaskCompleted(task, player);

                        if (!string.IsNullOrEmpty(message))
                        {
                            MessageBox.Show(message);
                            achievementManager.AddProgress(task.Category);

                            var unlocked = achievementManager.EvaluateAchievements();
                            foreach (var name in unlocked)
                            {
                                MessageBox.Show($"Zdobywasz nowe osiągnięcie: {name}");
                            }
                        }
                    }
                }

                manage.SaveTasks();
                saveRead.SaveToFile(player, "player.json");

                statsRefresher.RefreshStats();

                currentWeekStart = task.Deadline.Value;
                weekViewRenderer.GenerateWeekView(currentWeekStart);
            }
        }


        private void btn_Edit_Player_Click(object sender, EventArgs e)
        {
            using (var editForm = new EditProfile(player, calendarControls, achievementManager, taskPanelBuilder))
            {
                var result = editForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    player.Name = editForm.NewPlayerName;

                    MessageBox.Show("Nowa nazwa gracza : " + player.Name, "Zmiana nazwy", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    saveRead.SaveToFile(player, "player.json");
                    statsRefresher.RefreshStats();
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
        public void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = e.Location; // punkt w panelu, gdzie kliknięto
            }
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
            newLocation.Y = Math.Max(40, Math.Min(920, newLocation.Y));

            return newLocation;
        }
        private DateTime UpdateDeadline(Point panelLocation, Zadanie task)
        {
            if (!task.Deadline.HasValue)
                return DateTime.Now;

            int timelinePositionInMinutes = ((panelLocation.Y - 40) * 1440) / calendarControls.FlowLayoutPanel.Height;
            int hours = timelinePositionInMinutes / 60;
            int minutes = timelinePositionInMinutes % 60;

            return new DateTime(task.Deadline.Value.Year, task.Deadline.Value.Month, task.Deadline.Value.Day, hours, minutes, 0);
        }
        public void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging)
                return;

            Panel clickedPanel = FindParentPanel(sender as Control);
            if (clickedPanel == null)
                return;

            var zadanie = clickedPanel.Tag as Zadanie;
            if (zadanie == null)
                return;
            // Oblicz nową pozycję

            clickedPanel.Location = UpdatePanelPosition(clickedPanel, e);

            zadanie.Deadline = UpdateDeadline(clickedPanel.Location, zadanie);
            

            var timeLabel = clickedPanel.Controls.OfType<Label>().FirstOrDefault(l => (string)l.Tag == "Time");

            if (timeLabel != null)
            {
                timeLabel.Text = $"{zadanie.Deadline.Value.Hour}:{zadanie.Deadline.Value.Minute:D2}";

            }



        }

        public void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            manage.SaveTasks();
        }

        private void ShowHelpDialog()
        {
            string message =
                "Jak korzystać z Productivity Quest?\n\n" +
                " Przesuń panel zadania – zmienisz jego godzinę.\n" +
                " Podwójne kliknięcie na PUSTY panel – dodaje nowe zadanie.\n" +
                " Podwójne kliknięcie na panel z zadaniem – edycja zadania.\n\n" +
                " Kliknij ikonę  ? w prawym górnym rogu, by wrócić do tego okna.";

            MessageBox.Show(message, "Pomoc", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            ShowHelpDialog();
        }
    }
}
