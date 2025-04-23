namespace Productivity_Quest_1._0
{
    partial class EditProfile
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
            this.textBox_Edit_Name = new System.Windows.Forms.TextBox();
            this.btn_Save_Changes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.lb_Streak = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayout_Achievments = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa Gracza:";
            // 
            // textBox_Edit_Name
            // 
            this.textBox_Edit_Name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Edit_Name.Location = new System.Drawing.Point(27, 44);
            this.textBox_Edit_Name.Name = "textBox_Edit_Name";
            this.textBox_Edit_Name.Size = new System.Drawing.Size(199, 23);
            this.textBox_Edit_Name.TabIndex = 1;
            // 
            // btn_Save_Changes
            // 
            this.btn_Save_Changes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Save_Changes.Location = new System.Drawing.Point(262, 21);
            this.btn_Save_Changes.Name = "btn_Save_Changes";
            this.btn_Save_Changes.Size = new System.Drawing.Size(110, 34);
            this.btn_Save_Changes.TabIndex = 2;
            this.btn_Save_Changes.Text = "Zapisz zmiany";
            this.btn_Save_Changes.UseVisualStyleBackColor = true;
            this.btn_Save_Changes.Click += new System.EventHandler(this.btn_Save_Changes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(23, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Streak:";
            // 
            // panel_Main
            // 
            this.panel_Main.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_Main.Location = new System.Drawing.Point(27, 112);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(1151, 650);
            this.panel_Main.TabIndex = 4;
            // 
            // lb_Streak
            // 
            this.lb_Streak.AutoSize = true;
            this.lb_Streak.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Streak.Location = new System.Drawing.Point(664, 44);
            this.lb_Streak.Name = "lb_Streak";
            this.lb_Streak.Size = new System.Drawing.Size(193, 25);
            this.lb_Streak.TabIndex = 23;
            this.lb_Streak.Text = "Zacznij nowy streak!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(1188, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Achievments";
            // 
            // flowLayout_Achievments
            // 
            this.flowLayout_Achievments.Location = new System.Drawing.Point(1193, 127);
            this.flowLayout_Achievments.Name = "flowLayout_Achievments";
            this.flowLayout_Achievments.Size = new System.Drawing.Size(618, 621);
            this.flowLayout_Achievments.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(1193, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 650);
            this.panel1.TabIndex = 0;
            // 
            // EditProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 961);
            this.Controls.Add(this.flowLayout_Achievments);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_Streak);
            this.Controls.Add(this.panel_Main);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Save_Changes);
            this.Controls.Add(this.textBox_Edit_Name);
            this.Controls.Add(this.label1);
            this.Name = "EditProfile";
            this.Text = "Edycja Profilu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Edit_Name;
        private System.Windows.Forms.Button btn_Save_Changes;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.Label lb_Streak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayout_Achievments;
        private System.Windows.Forms.Panel panel1;
    }
}