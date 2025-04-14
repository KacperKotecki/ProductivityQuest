namespace Productivity_Quest_1._0
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCalendar_Form = new System.Windows.Forms.MonthCalendar();
            this.Progress_Level = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_Poziom = new System.Windows.Forms.Label();
            this.lb_XP = new System.Windows.Forms.Label();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.lb_Name = new System.Windows.Forms.Label();
            this.lb_Streak = new System.Windows.Forms.Label();
            this.lbn_Awans = new System.Windows.Forms.Label();
            this.btn_Edit_Player = new System.Windows.Forms.Button();
            this.pictureBox_Streak = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel_Calendar = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Streak)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar_Form
            // 
            this.monthCalendar_Form.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.monthCalendar_Form.Location = new System.Drawing.Point(1089, 189);
            this.monthCalendar_Form.Margin = new System.Windows.Forms.Padding(7);
            this.monthCalendar_Form.Name = "monthCalendar_Form";
            this.monthCalendar_Form.TabIndex = 3;
            this.monthCalendar_Form.UseWaitCursor = true;
            this.monthCalendar_Form.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_Form_DateChanged);
            // 
            // Progress_Level
            // 
            this.Progress_Level.AccessibleName = "Poziom";
            this.Progress_Level.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Progress_Level.BackColor = System.Drawing.SystemColors.Desktop;
            this.Progress_Level.ForeColor = System.Drawing.Color.Maroon;
            this.Progress_Level.Location = new System.Drawing.Point(1089, 85);
            this.Progress_Level.Name = "Progress_Level";
            this.Progress_Level.Size = new System.Drawing.Size(534, 39);
            this.Progress_Level.Step = 1;
            this.Progress_Level.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(1084, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Witaj : ";
            // 
            // lb_Poziom
            // 
            this.lb_Poziom.AutoSize = true;
            this.lb_Poziom.BackColor = System.Drawing.Color.Transparent;
            this.lb_Poziom.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Poziom.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_Poziom.Location = new System.Drawing.Point(1085, 54);
            this.lb_Poziom.Name = "lb_Poziom";
            this.lb_Poziom.Size = new System.Drawing.Size(53, 19);
            this.lb_Poziom.TabIndex = 11;
            this.lb_Poziom.Text = "Poziom";
            // 
            // lb_XP
            // 
            this.lb_XP.AutoSize = true;
            this.lb_XP.BackColor = System.Drawing.Color.Transparent;
            this.lb_XP.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_XP.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_XP.Location = new System.Drawing.Point(1532, 54);
            this.lb_XP.Name = "lb_XP";
            this.lb_XP.Size = new System.Drawing.Size(28, 19);
            this.lb_XP.TabIndex = 12;
            this.lb_XP.Text = "XP:";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Name.Location = new System.Drawing.Point(1143, 17);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(61, 25);
            this.lb_Name.TabIndex = 19;
            this.lb_Name.Text = "Imię !";
            // 
            // lb_Streak
            // 
            this.lb_Streak.AutoSize = true;
            this.lb_Streak.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Streak.Location = new System.Drawing.Point(53, 320);
            this.lb_Streak.Name = "lb_Streak";
            this.lb_Streak.Size = new System.Drawing.Size(193, 25);
            this.lb_Streak.TabIndex = 22;
            this.lb_Streak.Text = "Zacznij nowy streak!";
            // 
            // lbn_Awans
            // 
            this.lbn_Awans.AutoSize = true;
            this.lbn_Awans.Location = new System.Drawing.Point(1344, 379);
            this.lbn_Awans.Name = "lbn_Awans";
            this.lbn_Awans.Size = new System.Drawing.Size(0, 13);
            this.lbn_Awans.TabIndex = 23;
            // 
            // btn_Edit_Player
            // 
            this.btn_Edit_Player.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Edit_Player.Location = new System.Drawing.Point(1089, 145);
            this.btn_Edit_Player.Name = "btn_Edit_Player";
            this.btn_Edit_Player.Size = new System.Drawing.Size(227, 34);
            this.btn_Edit_Player.TabIndex = 24;
            this.btn_Edit_Player.Text = "Edytuj Profil";
            this.btn_Edit_Player.UseVisualStyleBackColor = true;
            this.btn_Edit_Player.Click += new System.EventHandler(this.btn_Edit_Player_Click);
            // 
            // pictureBox_Streak
            // 
            this.pictureBox_Streak.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Streak.MaximumSize = new System.Drawing.Size(296, 296);
            this.pictureBox_Streak.Name = "pictureBox_Streak";
            this.pictureBox_Streak.Size = new System.Drawing.Size(296, 296);
            this.pictureBox_Streak.TabIndex = 29;
            this.pictureBox_Streak.TabStop = false;
            // 
            // flowLayoutPanel_Calendar
            // 
            this.flowLayoutPanel_Calendar.Location = new System.Drawing.Point(12, 17);
            this.flowLayoutPanel_Calendar.Name = "flowLayoutPanel_Calendar";
            this.flowLayoutPanel_Calendar.Size = new System.Drawing.Size(1049, 960);
            this.flowLayoutPanel_Calendar.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(1153, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 19);
            this.label3.TabIndex = 31;
            this.label3.Tag = "Default";
            this.label3.Text = "<<<  |";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(1209, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 19);
            this.label4.TabIndex = 32;
            this.label4.Tag = "Default";
            this.label4.Text = "| >>>";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox_Streak);
            this.panel1.Controls.Add(this.lb_Streak);
            this.panel1.Location = new System.Drawing.Point(1326, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 373);
            this.panel1.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1644, 1061);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flowLayoutPanel_Calendar);
            this.Controls.Add(this.btn_Edit_Player);
            this.Controls.Add(this.lbn_Awans);
            this.Controls.Add(this.lb_Name);
            this.Controls.Add(this.lb_XP);
            this.Controls.Add(this.lb_Poziom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.monthCalendar_Form);
            this.Controls.Add(this.Progress_Level);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Productivity Quest";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Streak)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar monthCalendar_Form;
        private System.Windows.Forms.ProgressBar Progress_Level;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_Poziom;
        private System.Windows.Forms.Label lb_XP;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.Label lb_Streak;
        private System.Windows.Forms.Label lbn_Awans;
        private System.Windows.Forms.Button btn_Edit_Player;
        private System.Windows.Forms.PictureBox pictureBox_Streak;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Calendar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}

