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
            this.btn_Dodaj_Zadanie = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Zadanie = new System.Windows.Forms.TextBox();
            this.textBox_Kategoria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_Priorytet = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_CzasNaZadanie = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker_Deadline = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Anuluj_Operacje = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Priorytet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CzasNaZadanie)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Dodaj_Zadanie
            // 
            this.btn_Dodaj_Zadanie.Location = new System.Drawing.Point(22, 251);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zadanie";
            // 
            // textBox_Zadanie
            // 
            this.textBox_Zadanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Zadanie.Location = new System.Drawing.Point(22, 33);
            this.textBox_Zadanie.Name = "textBox_Zadanie";
            this.textBox_Zadanie.Size = new System.Drawing.Size(238, 24);
            this.textBox_Zadanie.TabIndex = 2;
            // 
            // textBox_Kategoria
            // 
            this.textBox_Kategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Kategoria.Location = new System.Drawing.Point(22, 91);
            this.textBox_Kategoria.Name = "textBox_Kategoria";
            this.textBox_Kategoria.Size = new System.Drawing.Size(238, 24);
            this.textBox_Kategoria.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(19, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kategoria";
            // 
            // numericUpDown_Priorytet
            // 
            this.numericUpDown_Priorytet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown_Priorytet.Location = new System.Drawing.Point(22, 149);
            this.numericUpDown_Priorytet.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Priorytet.Name = "numericUpDown_Priorytet";
            this.numericUpDown_Priorytet.Size = new System.Drawing.Size(238, 24);
            this.numericUpDown_Priorytet.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(19, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Priorytet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(19, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Czas na to zadanie";
            // 
            // numericUpDown_CzasNaZadanie
            // 
            this.numericUpDown_CzasNaZadanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown_CzasNaZadanie.Location = new System.Drawing.Point(22, 208);
            this.numericUpDown_CzasNaZadanie.Maximum = new decimal(new int[] {
            555,
            0,
            0,
            0});
            this.numericUpDown_CzasNaZadanie.Name = "numericUpDown_CzasNaZadanie";
            this.numericUpDown_CzasNaZadanie.Size = new System.Drawing.Size(238, 24);
            this.numericUpDown_CzasNaZadanie.TabIndex = 7;
            // 
            // dateTimePicker_Deadline
            // 
            this.dateTimePicker_Deadline.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker_Deadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker_Deadline.Location = new System.Drawing.Point(297, 33);
            this.dateTimePicker_Deadline.Name = "dateTimePicker_Deadline";
            this.dateTimePicker_Deadline.Size = new System.Drawing.Size(285, 24);
            this.dateTimePicker_Deadline.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(294, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Deadline";
            // 
            // btn_Anuluj_Operacje
            // 
            this.btn_Anuluj_Operacje.Location = new System.Drawing.Point(297, 251);
            this.btn_Anuluj_Operacje.Name = "btn_Anuluj_Operacje";
            this.btn_Anuluj_Operacje.Size = new System.Drawing.Size(238, 48);
            this.btn_Anuluj_Operacje.TabIndex = 12;
            this.btn_Anuluj_Operacje.Text = "Anuluj Operację";
            this.btn_Anuluj_Operacje.UseVisualStyleBackColor = true;
            // 
            // DodajZadanieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 323);
            this.Controls.Add(this.btn_Anuluj_Operacje);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker_Deadline);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_CzasNaZadanie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_Priorytet);
            this.Controls.Add(this.textBox_Kategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Zadanie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Dodaj_Zadanie);
            this.Name = "DodajZadanieForm";
            this.Text = "Dodaj Zadanie";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Priorytet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CzasNaZadanie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Dodaj_Zadanie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Zadanie;
        private System.Windows.Forms.TextBox textBox_Kategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Priorytet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_CzasNaZadanie;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Deadline;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Anuluj_Operacje;
    }
}