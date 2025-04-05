namespace Productivity_Quest_1._0
{
    partial class DodajZadanieForm
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
            this.components = new System.ComponentModel.Container();
            this.btn_Dodaj_Zadanie = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Zadanie = new System.Windows.Forms.TextBox();
            this.textBox_Kategoria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_CzasNaZadanie = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Anuluj_Operacje = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.numericUpDown_Hour = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_Minutes = new System.Windows.Forms.NumericUpDown();
            this.comboBox1_Priority = new System.Windows.Forms.ComboBox();
            this.comboBox_Time = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CzasNaZadanie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minutes)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Dodaj_Zadanie
            // 
            this.btn_Dodaj_Zadanie.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Dodaj_Zadanie.Location = new System.Drawing.Point(21, 265);
            this.btn_Dodaj_Zadanie.Name = "btn_Dodaj_Zadanie";
            this.btn_Dodaj_Zadanie.Size = new System.Drawing.Size(238, 48);
            this.btn_Dodaj_Zadanie.TabIndex = 0;
            this.btn_Dodaj_Zadanie.Text = "Dodaj Zadanie";
            this.btn_Dodaj_Zadanie.UseVisualStyleBackColor = true;
            this.btn_Dodaj_Zadanie.Click += new System.EventHandler(this.buttonZapisz_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zadanie";
            // 
            // textBox_Zadanie
            // 
            this.textBox_Zadanie.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Zadanie.Location = new System.Drawing.Point(22, 33);
            this.textBox_Zadanie.Name = "textBox_Zadanie";
            this.textBox_Zadanie.Size = new System.Drawing.Size(238, 27);
            this.textBox_Zadanie.TabIndex = 2;
            // 
            // textBox_Kategoria
            // 
            this.textBox_Kategoria.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Kategoria.Location = new System.Drawing.Point(22, 91);
            this.textBox_Kategoria.Name = "textBox_Kategoria";
            this.textBox_Kategoria.Size = new System.Drawing.Size(238, 27);
            this.textBox_Kategoria.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(19, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kategoria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(19, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Priorytet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(19, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Czas na to zadanie";
            // 
            // numericUpDown_CzasNaZadanie
            // 
            this.numericUpDown_CzasNaZadanie.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown_CzasNaZadanie.Location = new System.Drawing.Point(22, 208);
            this.numericUpDown_CzasNaZadanie.Maximum = new decimal(new int[] {
            555,
            0,
            0,
            0});
            this.numericUpDown_CzasNaZadanie.Name = "numericUpDown_CzasNaZadanie";
            this.numericUpDown_CzasNaZadanie.Size = new System.Drawing.Size(91, 27);
            this.numericUpDown_CzasNaZadanie.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(294, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Deadline";
            // 
            // btn_Anuluj_Operacje
            // 
            this.btn_Anuluj_Operacje.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Anuluj_Operacje.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Anuluj_Operacje.Location = new System.Drawing.Point(296, 265);
            this.btn_Anuluj_Operacje.Name = "btn_Anuluj_Operacje";
            this.btn_Anuluj_Operacje.Size = new System.Drawing.Size(238, 48);
            this.btn_Anuluj_Operacje.TabIndex = 12;
            this.btn_Anuluj_Operacje.Text = "Anuluj Operację";
            this.btn_Anuluj_Operacje.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(357, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Minuta";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.monthCalendar1.ForeColor = System.Drawing.Color.Red;
            this.monthCalendar1.Location = new System.Drawing.Point(297, 33);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 13;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.LawnGreen;
            this.monthCalendar1.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            // 
            // numericUpDown_Hour
            // 
            this.numericUpDown_Hour.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown_Hour.Location = new System.Drawing.Point(297, 229);
            this.numericUpDown_Hour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown_Hour.Name = "numericUpDown_Hour";
            this.numericUpDown_Hour.Size = new System.Drawing.Size(46, 27);
            this.numericUpDown_Hour.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(294, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Godzina";
            // 
            // numericUpDown_Minutes
            // 
            this.numericUpDown_Minutes.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown_Minutes.Location = new System.Drawing.Point(360, 229);
            this.numericUpDown_Minutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_Minutes.Name = "numericUpDown_Minutes";
            this.numericUpDown_Minutes.Size = new System.Drawing.Size(46, 27);
            this.numericUpDown_Minutes.TabIndex = 17;
            // 
            // comboBox1_Priority
            // 
            this.comboBox1_Priority.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox1_Priority.FormattingEnabled = true;
            this.comboBox1_Priority.Location = new System.Drawing.Point(22, 150);
            this.comboBox1_Priority.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1_Priority.Name = "comboBox1_Priority";
            this.comboBox1_Priority.Size = new System.Drawing.Size(92, 23);
            this.comboBox1_Priority.TabIndex = 19;
            // 
            // comboBox_Time
            // 
            this.comboBox_Time.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_Time.FormattingEnabled = true;
            this.comboBox_Time.Location = new System.Drawing.Point(118, 210);
            this.comboBox_Time.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Time.Name = "comboBox_Time";
            this.comboBox_Time.Size = new System.Drawing.Size(92, 23);
            this.comboBox_Time.TabIndex = 20;
            // 
            // DodajZadanieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 343);
            this.Controls.Add(this.comboBox_Time);
            this.Controls.Add(this.comboBox1_Priority);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown_Minutes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown_Hour);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.btn_Anuluj_Operacje);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_CzasNaZadanie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Kategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Zadanie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Dodaj_Zadanie);
            this.Name = "DodajZadanieForm";
            this.Text = "Dodaj Zadanie";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CzasNaZadanie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Dodaj_Zadanie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Zadanie;
        private System.Windows.Forms.TextBox textBox_Kategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_CzasNaZadanie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Anuluj_Operacje;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hour;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_Minutes;
        private System.Windows.Forms.ComboBox comboBox1_Priority;
        private System.Windows.Forms.ComboBox comboBox_Time;
    }
}