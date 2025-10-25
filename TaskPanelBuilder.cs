using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    public class TaskPanelBuilder
    {
        private Form1 form1;
        public TaskPanelBuilder(Form1 form1)
        {
            this.form1 = form1;
        }

        public Panel CreateMyPanel(Task task, int width, int height)
        {
            if (!task.StartDateTime.HasValue)
            {
                // Jeśli zadanie nie ma daty, nie możemy go narysować na osi czasu.
                // Można zwrócić pusty panel lub obsłużyć to w inny sposób.
                return new Panel { Visible = false };
            }

            int timeInMinutes = task.StartDateTime.Value.Hour * 60 + task.StartDateTime.Value.Minute;
            double y = (timeInMinutes / 1440d) * 1440d;

            var panelTask = CreatePanel(new Size(width, task.DurationMinutes), Color.FromArgb(80, 220, 120), new Point(0, (int)y));

            // Colors
            if (task.Priority == "Niski")
            {
                panelTask.BackColor = Color.FromArgb(144, 238, 144);
                if (task.IsCompleted)
                    panelTask.BackColor = Color.FromArgb(80, 220, 120);
            }
            else if (task.Priority == "Średni")
            {
                panelTask.BackColor = Color.FromArgb(255, 213, 100);
                if (task.IsCompleted)
                    panelTask.BackColor = Color.FromArgb(255, 160, 0);
            }
            else if (task.Priority == "Wysoki")
            {
                panelTask.BackColor = Color.FromArgb(239, 97, 93);
                if (task.IsCompleted)
                    panelTask.BackColor = Color.FromArgb(210, 45, 40);
            }

            panelTask.Padding = new Padding(5, 5, 5, 5);

            //Icons
            var image = task.IsCompleted ? Properties.Resources.check_circle_8 : Properties.Resources.check_circle_0;
            var doneIcon = CreateIconPictureBox(image, new Size(14, 14), new Point(49, 42));
            doneIcon.BackColor = Color.Transparent;

            // Height Panel task
            int panelHeight;

            if (task.DurationMinutes < 24)
            {
                panelHeight = 24;
            }
            else if (task.DurationMinutes < 42)
            {
                panelHeight = 42;
            }
            else
            {
                panelHeight = task.DurationMinutes;

                if (task.DurationMinutes > 80)
                {
                    panelTask.Controls.Add(CreateUniversalLabel(task.Category, 10, new Size(50, 18), FontStyle.Regular, true, false));
                }
                panelTask.Controls.Add(CreateUniversalLabel(task.StartDateTime.Value.ToShortTimeString(), 10, new Size(50, 18), FontStyle.Regular, true, true));
            }

            panelTask.Size = new Size(width, panelHeight);
            panelTask.Tag = task;

            // Controls ADD 
            panelTask.Controls.Add(doneIcon);
            panelTask.Controls.Add(CreateUniversalLabel(task.Title, 10, new Size(50, 36), FontStyle.Bold, true, false));

            doneIcon.DoubleClick += form1.MyPanel_DoubleClick;
            panelTask.DoubleClick += form1.MyPanel_DoubleClick;

            panelTask.MouseDown += form1.Panel_MouseDown;
            panelTask.MouseMove += form1.Panel_MouseMove;
            panelTask.MouseUp += form1.Panel_MouseUp;

            foreach (Control control in panelTask.Controls)
            {
                control.MouseDown += form1.Panel_MouseDown;
                control.MouseMove += form1.Panel_MouseMove;
                control.MouseUp += form1.Panel_MouseUp;
            }

            return panelTask;
        }
        public Label CreateUniversalLabel(string text, int fontSize, Size size, FontStyle fontStyle, bool allowClick = false, bool time = false)
        {
            var label = new Label
            {
                Text = text,
                Font = new Font("Arial", fontSize, fontStyle),
                ForeColor = Color.Black,
                AutoSize = false,
                Size = size, // 50,18
                Margin = new Padding(2),
                Dock = DockStyle.Top
            };

            if (allowClick)
            {
                label.DoubleClick += form1.MyPanel_DoubleClick;
            }
            if (time)
            {
                label.Tag = "Time";
            }

            return label;
        }

        public Label CreateLabel(string text, int fontSize, Size size, FontStyle fontStyle, DockStyle dock = DockStyle.None)
        {
            var label = new Label
            {
                Text = text,
                Font = new Font("Arial", fontSize, fontStyle),
                ForeColor = Color.Black,
                AutoSize = false,
                Size = size,
                Margin = new Padding(2),
                Dock = dock
            };

            return label;
        }
        public Label CreateLabel(string text, int fontSize, Size size, FontStyle fontStyle, Point location)
        {
            var label = new Label
            {
                Text = text,
                Font = new Font("Arial", fontSize, fontStyle),
                ForeColor = Color.Black,
                AutoSize = false,
                Size = size,
                Margin = new Padding(2),
                Location = location
            };

            return label;
        }

        public Panel CreatePanel(Size size, Color backColor, Point location)
        {
            var panel = new Panel
            {
                Size = size,
                BackColor = backColor,
                Location = location
            };
            return panel;
        }
        public Panel CreatePanel(Size size, Color backColor, DockStyle dock)
        {
            var panel = new Panel
            {
                Size = size,
                BackColor = backColor,
                Dock = dock
            };
            return panel;
        }

        public PictureBox CreateIconPictureBox(string iconPath, Size size, Point location)
        {
            var icon = new PictureBox
            {
                Size = size,
                Location = location,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.None,
                BackColor = Color.Transparent
            };

            try
            {
                if (File.Exists(iconPath))
                {
                    icon.Image = Image.FromFile(iconPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania ikony: " + ex.Message);
            }

            return icon;
        }

        public PictureBox CreateIconPictureBox(Image image, Size size, Point location)
        {
            var icon = new PictureBox
            {
                Size = size,
                Location = location,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.None,
                BackColor = Color.Transparent,
                Image = image
            };

            return icon;
        }
    }
}
