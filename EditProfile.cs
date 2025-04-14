using System.Drawing;
using System.Windows.Forms;
using System;

namespace Productivity_Quest_1._0
{
    public partial class EditProfile : Form
    {
        private Player currentPlayer;
        private CalendarControls calendarControls;
        private StreakGridRenderer streakGridRenderer;
        public EditProfile(Player player, CalendarControls calendarControls)
        {
            InitializeComponent();
            this.calendarControls = calendarControls;
            this.currentPlayer = player;
            
            this.calendarControls.PanelMain = panel_Main;
            streakGridRenderer = new StreakGridRenderer(player, panel_Main);
            streakGridRenderer.GenerateStreakGrid();

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

        
    }
}