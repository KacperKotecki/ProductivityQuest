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
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.lbn_Awans = new System.Windows.Forms.Label();
            this.flowLayoutPanel_Calendar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_NextWeek = new System.Windows.Forms.Button();
            this.btn_PreviousWeek = new System.Windows.Forms.Button();
            this.btn_Help = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar_Form
            // 
            this.monthCalendar_Form.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.monthCalendar_Form.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar_Form.Margin = new System.Windows.Forms.Padding(7);
            this.monthCalendar_Form.Name = "monthCalendar_Form";
            this.monthCalendar_Form.TabIndex = 3;
            this.monthCalendar_Form.UseWaitCursor = true;
            this.monthCalendar_Form.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_Form_DateChanged);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // lbn_Awans
            // 
            this.lbn_Awans.AutoSize = true;
            this.lbn_Awans.Location = new System.Drawing.Point(1592, 529);
            this.lbn_Awans.Name = "lbn_Awans";
            this.lbn_Awans.Size = new System.Drawing.Size(0, 13);
            this.lbn_Awans.TabIndex = 23;
            // 
            // flowLayoutPanel_Calendar
            // 
            this.flowLayoutPanel_Calendar.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel_Calendar.MaximumSize = new System.Drawing.Size(1700, 960);
            this.flowLayoutPanel_Calendar.MinimumSize = new System.Drawing.Size(1224, 960);
            this.flowLayoutPanel_Calendar.Name = "flowLayoutPanel_Calendar";
            this.flowLayoutPanel_Calendar.Size = new System.Drawing.Size(1623, 960);
            this.flowLayoutPanel_Calendar.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Help);
            this.panel1.Controls.Add(this.monthCalendar_Form);
            this.panel1.Controls.Add(this.btn_NextWeek);
            this.panel1.Controls.Add(this.btn_PreviousWeek);
            this.panel1.Location = new System.Drawing.Point(1645, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 960);
            this.panel1.TabIndex = 33;
            // 
            // btn_NextWeek
            // 
            this.btn_NextWeek.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_NextWeek.Location = new System.Drawing.Point(117, 172);
            this.btn_NextWeek.Name = "btn_NextWeek";
            this.btn_NextWeek.Size = new System.Drawing.Size(111, 43);
            this.btn_NextWeek.TabIndex = 36;
            this.btn_NextWeek.Text = ">>>";
            this.btn_NextWeek.UseVisualStyleBackColor = true;
            this.btn_NextWeek.Click += new System.EventHandler(this.btn_NextWeek_Click);
            // 
            // btn_PreviousWeek
            // 
            this.btn_PreviousWeek.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_PreviousWeek.Location = new System.Drawing.Point(0, 172);
            this.btn_PreviousWeek.Name = "btn_PreviousWeek";
            this.btn_PreviousWeek.Size = new System.Drawing.Size(111, 43);
            this.btn_PreviousWeek.TabIndex = 35;
            this.btn_PreviousWeek.Text = "<<<";
            this.btn_PreviousWeek.UseVisualStyleBackColor = true;
            this.btn_PreviousWeek.Click += new System.EventHandler(this.btn_PreviousWeek_Click);
            // 
            // btn_Help
            // 
            this.btn_Help.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Help.Location = new System.Drawing.Point(0, 230);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(228, 43);
            this.btn_Help.TabIndex = 37;
            this.btn_Help.Text = "?";
            this.btn_Help.UseVisualStyleBackColor = true;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 1021);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel_Calendar);
            this.Controls.Add(this.lbn_Awans);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Productivity Quest";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar monthCalendar_Form;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Label lbn_Awans;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Calendar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_NextWeek;
        private System.Windows.Forms.Button btn_PreviousWeek;
        private System.Windows.Forms.Button btn_Help;
    }
}

