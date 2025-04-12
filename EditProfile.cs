using System.Drawing;
using System.Windows.Forms;
using System;

namespace Productivity_Quest_1._0
{
    public partial class EditProfile : Form
    {
        private Player currentPlayer;
        public EditProfile(Player player)
        {
            InitializeComponent();
            this.currentPlayer = player;
            GenerateStreakGrid();
            lb_Streak.Text = $"Streak: {player.CalculateStreak()} dni z rzędu!";
        }
        public string NewPlayerName { get; set; }
        private void btn_Save_Changes_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_Edit_Name.Text))
            {
                NewPlayerName = textBox_Edit_Name.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nazwa nie może być pusta", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GenerateStreakGrid()
        {
            ToolTip tooltip = new ToolTip();
            panel_Main.BackColor = Color.FromArgb(245, 245, 245);

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

                    if (currentPlayer.StreakDays.Contains(startDate.Date))
                    {
                        if (isFirstDayOfStreak && currentPlayer.StreakDays.Contains(startDate.Date))
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
                    if (!currentPlayer.StreakDays.Contains(startDate.Date))
                        isFirstDayOfStreak = true;

                    Label dayLabel = new Label();
                    dayLabel.Text = startDate.Day.ToString();
                    dayLabel.Font = new Font("Arial", 8, FontStyle.Bold);
                    dayLabel.ForeColor = Color.Black;
                    dayLabel.BackColor = Color.Transparent;
                    dayLabel.Location = new Point(17, 17);
                    dayLabel.Dock = DockStyle.Fill;

                    dayPanel.Controls.Add(dayLabel);
                    panel_Main.Controls.Add(dayPanel);

                    locationX += 35;
                    startDate = startDate.AddDays(1);
                }

                locationY += 35;
                locationX = 0;
            }
        }
    }
}