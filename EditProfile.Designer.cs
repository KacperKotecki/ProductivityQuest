﻿namespace Productivity_Quest_1._0
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa Gracza:";
            // 
            // textBox_Edit_Name
            // 
            this.textBox_Edit_Name.Location = new System.Drawing.Point(27, 44);
            this.textBox_Edit_Name.Name = "textBox_Edit_Name";
            this.textBox_Edit_Name.Size = new System.Drawing.Size(199, 20);
            this.textBox_Edit_Name.TabIndex = 1;
            // 
            // btn_Save_Changes
            // 
            this.btn_Save_Changes.Location = new System.Drawing.Point(262, 21);
            this.btn_Save_Changes.Name = "btn_Save_Changes";
            this.btn_Save_Changes.Size = new System.Drawing.Size(110, 34);
            this.btn_Save_Changes.TabIndex = 2;
            this.btn_Save_Changes.Text = "Zapisz zmiany";
            this.btn_Save_Changes.UseVisualStyleBackColor = true;
            this.btn_Save_Changes.Click += new System.EventHandler(this.btn_Save_Changes_Click);
            // 
            // EditProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 83);
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
    }
}