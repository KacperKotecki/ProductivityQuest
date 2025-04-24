using System;
using System.Drawing;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    public partial class EditProfile : Form
    {
        private Player player;
        private CalendarControls calendarControls;
        private StreakGridRenderer calendarGridRenderer;
        private StreakGridRenderer achievementsRenderer;
        private AchievementManager achievementManager;
        private TaskPanelBuilder taskPanelBuilder;
        
        public string NewPlayerName { get; set; }
        public EditProfile(Player player, CalendarControls calendarControls, AchievementManager achievementManager, TaskPanelBuilder taskPanelBuilder)
        {
            InitializeComponent();
            this.calendarControls = calendarControls;
            this.player = player;
            this.achievementManager = achievementManager;
            this.calendarControls.PanelMain = panel_Main;
            this.calendarControls.flowLayout_Achievments = flowLayout_Achievments;
            this.taskPanelBuilder = taskPanelBuilder;

            panel1.BackColor = Color.FromArgb(220, 220, 230);

            calendarGridRenderer = new StreakGridRenderer(player, panel_Main, taskPanelBuilder);
            calendarGridRenderer.GenerateStreakGrid();

            achievementsRenderer = new StreakGridRenderer(player, flowLayout_Achievments, taskPanelBuilder);
            achievementsRenderer.GenerateStreakGrid(achievementManager.AchievementsUnlocked());
            

            

            lb_Streak.Text = $"Streak: {player.CalculateStreak()} dni z rzędu!";

        }
        
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

       
    }
}