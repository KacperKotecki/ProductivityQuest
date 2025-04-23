using Productivity_Quest_1._0.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;

using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Productivity_Quest_1._0
{
    //gif kwiatka , ikona aplikacji, powiadomienia, kalenardz streaka XXX, przesuwanie zadań, profilowe 
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
            player = new Player();
            saveRead = new JsonStorageService();
            manage = new Manage();
            manage.LoadTasks();
            
            player = saveRead.LoadFromFile<Player>("player.json") ?? new Player();

            achievementManager = new AchievementManager(player, manage.Tasks, saveRead);
            achievementManager.LoadAchievements("achievements.json");

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

            statsRefresher = new StatsRefresher(player, statsControls);

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
            var editForm = new DodajZadanieForm(newTask, manage);
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
                var editForm = new DodajZadanieForm(task, manage);

                bool zadanie_zrobione = task.IsCompleted; //false
                editForm.Text = "Edycja zadania";
                var result = editForm.ShowDialog();

                // Jeśli zadanie zostało właśnie wykonane (zmiana z false na true)
                if (task.IsCompleted && !zadanie_zrobione)
                {
                    manage.TaskCompleted(task, player);
                    achievementManager.AddProgress(task.Category);
                    achievementManager.EvaluateAchievements();
                     
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
            var editForm = new EditProfile(player, calendarControls, achievementManager, taskPanelBuilder);

            var result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                player.Name = editForm.NewPlayerName;
                MessageBox.Show("Nowa nazwa gracza : " + player.Name);
                MessageBox.Show("Nowa nazwa gracza : " + player.Name, "Zmiana nazwy", MessageBoxButtons.OK, MessageBoxIcon.Information);

                saveRead.SaveToFile(player, "player.json");
                statsRefresher.RefreshStats();
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
        }

        private void btn_PreviousWeek_Click(object sender, EventArgs e)
        {
            currentWeekStart = currentWeekStart.AddDays(-7);
            weekViewRenderer.GenerateWeekView(currentWeekStart);
        }
        public void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = e.Location; // punkt w panelu, gdzie kliknięto
            }
        }

        public void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Control source = sender as Control;
                while (source != null && !(source is Panel))
                {
                    source = source.Parent;
                }
                Panel clickedPanel = source as Panel;

                var zadanie = clickedPanel.Tag as Zadanie;

                // Oblicz nową pozycję

                Point newLocation = clickedPanel.Location;
                newLocation.Y += e.Y - dragStartPoint.Y;
                if (newLocation.Y < 40) 
                { 
                    newLocation.Y = 40; 
                } 
                else if (newLocation.Y > 920)
                {
                    newLocation.Y = 920;
                }
                    

                clickedPanel.Location = newLocation;

                int timelineToMinutes = ((newLocation.Y - 40) * 1440) / calendarControls.FlowLayoutPanel.Height;

                int hours = timelineToMinutes / 60;
                int min = timelineToMinutes % 60;

                zadanie.Deadline = new DateTime(zadanie.Deadline.Value.Year, zadanie.Deadline.Value.Month, zadanie.Deadline.Value.Day, hours, min, 00);
                var timeLabel = clickedPanel.Controls.OfType<Label>().FirstOrDefault(l => (string)l.Tag == "Time");

                if (timeLabel != null)
                {
                    timeLabel.Text = $"{hours}:{min}";
                    if(min < 10) { timeLabel.Text = $"{hours}:0{min}";  }
                }


            }
        }

        public void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            manage.SaveTasks();
        }
    }
}
