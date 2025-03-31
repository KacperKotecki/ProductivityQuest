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
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.Progress_Level = new System.Windows.Forms.ProgressBar();
            this.checkedListBoxTasks = new System.Windows.Forms.CheckedListBox();
            this.btn_AddTask = new System.Windows.Forms.Button();
            this.btn_TaskComplited = new System.Windows.Forms.Button();
            this.btn_RemoveTask = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_Poziom = new System.Windows.Forms.Label();
            this.lb_XP = new System.Windows.Forms.Label();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lb_Name = new System.Windows.Forms.Label();
            this.btn_EditTask = new System.Windows.Forms.Button();
            this.lb_Streak = new System.Windows.Forms.Label();
            this.lbn_Awans = new System.Windows.Forms.Label();
            this.btn_Edit_Player = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(25, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zadania";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(573, 175);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.TrailingForeColor = System.Drawing.SystemColors.Highlight;
            this.monthCalendar1.UseWaitCursor = true;
            // 
            // Progress_Level
            // 
            this.Progress_Level.AccessibleName = "Poziom";
            this.Progress_Level.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Progress_Level.BackColor = System.Drawing.SystemColors.Desktop;
            this.Progress_Level.ForeColor = System.Drawing.Color.Maroon;
            this.Progress_Level.Location = new System.Drawing.Point(29, 100);
            this.Progress_Level.Name = "Progress_Level";
            this.Progress_Level.Size = new System.Drawing.Size(534, 39);
            this.Progress_Level.Step = 1;
            this.Progress_Level.TabIndex = 5;
            // 
            // checkedListBoxTasks
            // 
            this.checkedListBoxTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkedListBoxTasks.FormattingEnabled = true;
            this.checkedListBoxTasks.Location = new System.Drawing.Point(27, 169);
            this.checkedListBoxTasks.Name = "checkedListBoxTasks";
            this.checkedListBoxTasks.Size = new System.Drawing.Size(533, 251);
            this.checkedListBoxTasks.TabIndex = 6;
            // 
            // btn_AddTask
            // 
            this.btn_AddTask.Location = new System.Drawing.Point(573, 349);
            this.btn_AddTask.Name = "btn_AddTask";
            this.btn_AddTask.Size = new System.Drawing.Size(110, 34);
            this.btn_AddTask.TabIndex = 7;
            this.btn_AddTask.Text = "Dodaj";
            this.btn_AddTask.UseVisualStyleBackColor = true;
            this.btn_AddTask.Click += new System.EventHandler(this.btn_AddTask_Click);
            // 
            // btn_TaskComplited
            // 
            this.btn_TaskComplited.Location = new System.Drawing.Point(689, 349);
            this.btn_TaskComplited.Name = "btn_TaskComplited";
            this.btn_TaskComplited.Size = new System.Drawing.Size(110, 34);
            this.btn_TaskComplited.TabIndex = 8;
            this.btn_TaskComplited.Text = "Wykonane";
            this.btn_TaskComplited.UseVisualStyleBackColor = true;
            this.btn_TaskComplited.Click += new System.EventHandler(this.btn_TaskComplited_Click);
            // 
            // btn_RemoveTask
            // 
            this.btn_RemoveTask.Location = new System.Drawing.Point(689, 392);
            this.btn_RemoveTask.Name = "btn_RemoveTask";
            this.btn_RemoveTask.Size = new System.Drawing.Size(110, 34);
            this.btn_RemoveTask.TabIndex = 9;
            this.btn_RemoveTask.Text = "Usuń";
            this.btn_RemoveTask.UseVisualStyleBackColor = true;
            this.btn_RemoveTask.Click += new System.EventHandler(this.btn_RemoveTask_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(25, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Witaj : ";
            // 
            // lb_Poziom
            // 
            this.lb_Poziom.AutoSize = true;
            this.lb_Poziom.BackColor = System.Drawing.Color.Transparent;
            this.lb_Poziom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Poziom.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_Poziom.Location = new System.Drawing.Point(26, 69);
            this.lb_Poziom.Name = "lb_Poziom";
            this.lb_Poziom.Size = new System.Drawing.Size(54, 17);
            this.lb_Poziom.TabIndex = 11;
            this.lb_Poziom.Text = "Poziom";
            // 
            // lb_XP
            // 
            this.lb_XP.AutoSize = true;
            this.lb_XP.BackColor = System.Drawing.Color.Transparent;
            this.lb_XP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_XP.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lb_XP.Location = new System.Drawing.Point(463, 69);
            this.lb_XP.Name = "lb_XP";
            this.lb_XP.Size = new System.Drawing.Size(30, 17);
            this.lb_XP.TabIndex = 12;
            this.lb_XP.Text = "XP:";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(544, 513);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(328, 20);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Name.Location = new System.Drawing.Point(84, 17);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(61, 24);
            this.lb_Name.TabIndex = 19;
            this.lb_Name.Text = "Imię !";
            // 
            // btn_EditTask
            // 
            this.btn_EditTask.Location = new System.Drawing.Point(573, 392);
            this.btn_EditTask.Name = "btn_EditTask";
            this.btn_EditTask.Size = new System.Drawing.Size(110, 34);
            this.btn_EditTask.TabIndex = 20;
            this.btn_EditTask.Text = "Edytuj";
            this.btn_EditTask.UseVisualStyleBackColor = true;
            this.btn_EditTask.Click += new System.EventHandler(this.btn_EditTask_Click);
            // 
            // lb_Streak
            // 
            this.lb_Streak.AutoSize = true;
            this.lb_Streak.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Streak.Location = new System.Drawing.Point(579, 63);
            this.lb_Streak.Name = "lb_Streak";
            this.lb_Streak.Size = new System.Drawing.Size(199, 24);
            this.lb_Streak.TabIndex = 22;
            this.lb_Streak.Text = "Zacznij nowy streak!";
            // 
            // lbn_Awans
            // 
            this.lbn_Awans.AutoSize = true;
            this.lbn_Awans.Location = new System.Drawing.Point(284, 69);
            this.lbn_Awans.Name = "lbn_Awans";
            this.lbn_Awans.Size = new System.Drawing.Size(0, 13);
            this.lbn_Awans.TabIndex = 23;
            // 
            // btn_Edit_Player
            // 
            this.btn_Edit_Player.Location = new System.Drawing.Point(573, 129);
            this.btn_Edit_Player.Name = "btn_Edit_Player";
            this.btn_Edit_Player.Size = new System.Drawing.Size(226, 34);
            this.btn_Edit_Player.TabIndex = 24;
            this.btn_Edit_Player.Text = "Edytuj Profil";
            this.btn_Edit_Player.UseVisualStyleBackColor = true;
            this.btn_Edit_Player.Click += new System.EventHandler(this.btn_Edit_Player_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 444);
            this.Controls.Add(this.btn_Edit_Player);
            this.Controls.Add(this.lbn_Awans);
            this.Controls.Add(this.lb_Streak);
            this.Controls.Add(this.btn_EditTask);
            this.Controls.Add(this.lb_Name);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lb_XP);
            this.Controls.Add(this.lb_Poziom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_RemoveTask);
            this.Controls.Add(this.btn_TaskComplited);
            this.Controls.Add(this.btn_AddTask);
            this.Controls.Add(this.checkedListBoxTasks);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.Progress_Level);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Productivity Quest";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ProgressBar Progress_Level;
        private System.Windows.Forms.CheckedListBox checkedListBoxTasks;
        private System.Windows.Forms.Button btn_AddTask;
        private System.Windows.Forms.Button btn_TaskComplited;
        private System.Windows.Forms.Button btn_RemoveTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_Poziom;
        private System.Windows.Forms.Label lb_XP;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.Button btn_EditTask;
        private System.Windows.Forms.Label lb_Streak;
        private System.Windows.Forms.Label lbn_Awans;
        private System.Windows.Forms.Button btn_Edit_Player;
    }
}

