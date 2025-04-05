using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    public partial class EditProfile : Form
    {
        private Player playerEP;
        public EditProfile(Player player)
        {
            InitializeComponent();
            this.playerEP = player;
            ObliczanieStreaka();
        }
        public string NoweImie { get; set; }
        private void btn_Save_Changes_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_Edit_Name.Text))
            {
                NoweImie = textBox_Edit_Name.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Imię nie może być puste!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ObliczanieStreaka()
        {
            ToolTip tt = new ToolTip();
            
            panel_Main.BackColor = Color.FromArgb(245, 245, 245);
            int rows = 15;
            int colums = 25;
            int locationX = 0;
            int locationY = 0;
            bool firstdayofstreak = true;
            DateTime startdateTime = new DateTime(DateTime.Now.Year, 1, 1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    Panel panelStreak = new Panel();
                    panelStreak.Location = new Point(locationX, locationY);
                    panelStreak.Size = new Size(34, 34);
                    panelStreak.BackColor = Color.FromArgb(220, 220, 220); 
                    if (playerEP.Streak.Contains(startdateTime.Date))
                    {
                        if (firstdayofstreak && playerEP.Streak.Contains(startdateTime.Date))
                        {
                            panelStreak.BackColor = Color.FromArgb(119, 221, 119);
                            tt.SetToolTip(panelStreak, $"Początek streaka: {startdateTime:dd-MM-yyyy}");
                        }
                        else
                        {                            
                            panelStreak.BackColor = Color.FromArgb(0, 255, 128);
                            tt.SetToolTip(panelStreak, $"Data: {startdateTime:dd-MM-yyyy}");
                        }
                        
                    }
                    firstdayofstreak = false;
                    if (!playerEP.Streak.Contains(startdateTime.Date))
                    {
                        firstdayofstreak = true;
                    }
                    Label label = new Label();
                    label.Text = startdateTime.Day.ToString();
                    label.Font = new Font("Arial", 8, FontStyle.Bold);
                    label.ForeColor = Color.Black;
                    label.BackColor = Color.Transparent;
                    label.Location = new Point(17, 17);
                    label.Dock = DockStyle.Fill;
                    panelStreak.Controls.Add(label); 
                    panel_Main.Controls.Add(panelStreak); 
                    locationX += 35;
                    startdateTime = startdateTime.AddDays(1);
                }

                locationY += 35;
                locationX = 0;
            }
        }
    }
}
