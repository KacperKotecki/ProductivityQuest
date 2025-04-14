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

        public Form1()
        {

            InitializeComponent();
            manage.Tasks = saveRead.LoadFromFile<List<Zadanie>>("data.json") ?? new List<Zadanie>();
            player = saveRead.LoadFromFile<Player>("player.json") ?? new Player();
            RefreshStats();
            GenerateWeekView();

        }
        private void GenerateWeekView()
        {
            flowLayoutPanel_Calendar.Controls.Clear();///
            flowLayoutPanel_Calendar.BackColor = Color.FromArgb(240, 240, 245);
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
            int height = flowLayoutPanel_Calendar.Height;
            int width = (flowLayoutPanel_Calendar.Width - 4 * 7) / 7;
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
                flowLayoutPanel_Calendar.Controls.Add(dayPanelForm);

                string formattedDate = Monday.ToString("dd MMMM", culture);
                var labelday = CreateMyLabel(dayInWeek[i]);
                var labeldate = CreateMyLabel(formattedDate);
                foreach (var task in manage.Tasks)
                {
                    if (task.Deadline.Value.Date == Monday.Date)
                    {
                        var labeltask = CreateMyPanel(task);
                        dayPanelForm.Controls.Add(labeltask);



                    }
                }
                Monday = Monday.AddDays(1);



                labelday.ForeColor = Color.FromArgb(30, 30, 40);
                labeldate.ForeColor = Color.FromArgb(30, 30, 40);


                dayPanelForm.Controls.Add(labeldate);
                dayPanelForm.Controls.Add(labelday);

                dayPanelForm.DoubleClick += DayPanel_DoubleClick;
            }




        }

        private Label CreateMyLabel(string text, bool allowClick = false)
        {
            var label = new Label();
            label.Text = text;
            label.Font = new Font("Arial", 10, FontStyle.Bold);
            label.ForeColor = Color.Black;
            label.AutoSize = true;
            label.Margin = new Padding(2);
            label.Dock = DockStyle.Top;
            

            if (allowClick)
                label.DoubleClick += MyPanel_DoubleClick;

            return label;
        }
        private Panel CreateMyPanel(Zadanie Tasks)
        {
            var panelTask = new Panel();

            if (Tasks.Deadline.Value.Hour == 0) panelTask.Location = new Point(0, 40);
            else if (Tasks.Deadline.Value.Hour == 23) panelTask.Location = new Point(0, 860);
            else panelTask.Location = new Point(0, 40 * Tasks.Deadline.Value.Hour);

            if (Tasks.Priority == "Niski")
            {

                panelTask.BackColor = Color.FromArgb(80, 220, 120);
                if (Tasks.IsCompleted)
                    panelTask.BackColor = Color.FromArgb(120, 200, 120);
            }
            else if (Tasks.Priority == "Średni")
            {

                panelTask.BackColor = Color.FromArgb(255, 160, 0);
                if (Tasks.IsCompleted)
                    panelTask.BackColor = Color.FromArgb(255, 210, 100);
            }
            else if (Tasks.Priority == "Wysoki")
            {

                panelTask.BackColor = Color.FromArgb(255, 70, 70);
                if (Tasks.IsCompleted)
                    panelTask.BackColor = Color.FromArgb(255, 100, 100);
            }

            panelTask.Padding = new Padding(5, 5, 5, 5);
            panelTask.Margin = new Padding(5, 50, 5, 50);

            PictureBox doneIcon;
            doneIcon = new PictureBox();

            doneIcon.Size = new Size(12, 12);
            doneIcon.SizeMode = PictureBoxSizeMode.Zoom;

            doneIcon.BackColor = Color.Transparent;
            doneIcon.Dock = DockStyle.Left;



            if (Tasks.IsCompleted)
            {
                doneIcon.Image = Properties.Resources.check_circle_1;
                panelTask.Controls.Add(doneIcon);
            }
            else
            {
                doneIcon.Image = Properties.Resources.check_circle_0;
                panelTask.Controls.Add(doneIcon);
            }
            if (Tasks.DurationMinutes >= 0 && Tasks.DurationMinutes < 25)
            {
                panelTask.Size = new Size(140, 40);
            }
            else
            {
                panelTask.Size = new Size(140, Tasks.DurationMinutes);
                panelTask.Controls.Add(CreateMyLabel(Tasks.Category, true));
            }


            panelTask.Tag = Tasks;


            panelTask.Controls.Add(CreateMyLabel(Tasks.Deadline.Value.ToShortTimeString(), true));
            
            panelTask.Controls.Add(CreateMyLabel(Tasks.Title, true));

            doneIcon.DoubleClick += MyPanel_DoubleClick;
            panelTask.DoubleClick += MyPanel_DoubleClick;

            return panelTask;
        }
        private void RefreshStats()
        {
            string streakmessage;
            lb_Name.Text = player.Name ?? "Gracz";
            lb_Poziom.Text = $"Poziom: {player.Level}";
            lb_XP.Text = $"XP: {player.Experience}/{player.ExperienceToLevelUp}";
            Progress_Level.Maximum = player.ExperienceToLevelUp;
            Progress_Level.Value = Math.Min(player.Experience, Progress_Level.Maximum);

            if (player.CalculateStreak() >= 0)
                streakmessage = $"Streak: {player.CalculateStreak()} dni z rzędu!";
            else
                streakmessage = "Przedłuż streak dzisiaj !!!";

            lb_Streak.Text = streakmessage;

            pictureBox_Streak.Image = player.ChangeImg(player.CalculateStreak());

            pictureBox_Streak.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_Streak.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void DayPanel_DoubleClick(object sender, EventArgs e)
        {
            var newTask = new Zadanie();
            var editForm = new DodajZadanieForm(newTask, manage);
            var result = editForm.ShowDialog();

            if (result == DialogResult.OK && editForm != null)
            {

                manage.Tasks.Add(newTask);
                saveRead.SaveToFile(manage.Tasks, "data.json");

                CreateMyPanel(newTask);
                GenerateWeekView();
            }
        }


        private void MyPanel_DoubleClick(object sender, EventArgs e)
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
                RefreshStats();
                GenerateWeekView();
            }

        }

        private void btn_Edit_Player_Click(object sender, EventArgs e)
        {
            var editForm = new EditProfile(player);

            var result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {

                player.Name = editForm.NewPlayerName;
                MessageBox.Show("Nowa nazwa gracza : " + player.Name);
                MessageBox.Show("Nowa nazwa gracza : " + player.Name, "Zmiana nazwy", MessageBoxButtons.OK, MessageBoxIcon.Information);

                saveRead.SaveToFile(player, "player.json");
                RefreshStats();
            }

        }

        private void monthCalendar_Form_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        

    }
}
