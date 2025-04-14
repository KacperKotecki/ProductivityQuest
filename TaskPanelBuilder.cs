using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    internal class TaskPanelBuilder
    {
        private Form1 form1;
        public TaskPanelBuilder(Form1 form1)
        {
            this.form1 = form1;
        }

        public Panel CreateMyPanel(Zadanie Tasks)
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

            doneIcon.DoubleClick += form1.MyPanel_DoubleClick;
            panelTask.DoubleClick += form1.MyPanel_DoubleClick;
            
            return panelTask;
        }
        public Label CreateMyLabel(string text, bool allowClick = false)
        {
            var label = new Label();
            label.Text = text;
            label.Font = new Font("Arial", 10, FontStyle.Bold);
            label.ForeColor = Color.Black;
            label.AutoSize = true;
            label.Margin = new Padding(2);
            label.Dock = DockStyle.Top;


            if (allowClick)
                label.DoubleClick += form1.MyPanel_DoubleClick;
            
            return label;
        }
    }
}
