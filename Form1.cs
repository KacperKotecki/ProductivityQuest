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

namespace Productivity_Quest_1._0
{
    public partial class Form1 : Form
    {
        private Player player = new Player();
        private Manage manage = new Manage();
        private JsonStorageService saveRead = new JsonStorageService();
        private TaskPanelBuilder taskPanelBuilder;
        private StatsRefresher statsRefresher;
        private CalendarControls calendarControls;
        private WeekViewRenderer weekViewRenderer;

        public Form1()
        {
            InitializeComponent();

            manage.Tasks = saveRead.LoadFromFile<List<Zadanie>>("data.json") ?? new List<Zadanie>();
            player = saveRead.LoadFromFile<Player>("player.json") ?? new Player();

            // INICJALIZUJ KONTROLKI TUTAJ
            StatsControls statsControls = new StatsControls
            {
                LabelName = lb_Name,
                LabelLevel = lb_Poziom,
                LabelXP = lb_XP,
                LabelStreak = lb_Streak,
                ProgressLevel = Progress_Level,
                PictureStreak = pictureBox_Streak
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
            weekViewRenderer.GenerateWeekView();
        }

        public void DayPanel_DoubleClick(object sender, EventArgs e)
        {
            var newTask = new Zadanie();
            var editForm = new DodajZadanieForm(newTask, manage);
            var result = editForm.ShowDialog();

            if (result == DialogResult.OK && editForm != null)
            {

                manage.Tasks.Add(newTask);
                saveRead.SaveToFile(manage.Tasks, "data.json");

                taskPanelBuilder.CreateMyPanel(newTask);

                weekViewRenderer.GenerateWeekView();
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
                    
                }
                saveRead.SaveToFile(manage.Tasks, "data.json");
                saveRead.SaveToFile(player, "player.json");
                statsRefresher.RefreshStats();
                weekViewRenderer.GenerateWeekView();
            }
        }

        private void btn_Edit_Player_Click(object sender, EventArgs e)
        {
            var editForm = new EditProfile(player, calendarControls);

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
            
        }

        

    }
}
