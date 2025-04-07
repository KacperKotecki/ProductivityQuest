using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    public partial class DodajZadanieForm : Form
    {
        public Zadanie NoweZadanie { get; private set; }

        public DodajZadanieForm()
        {
            InitializeComponent();
            comboBox1_Priority.Items.Add("Niski");
            comboBox1_Priority.Items.Add("Średni");
            comboBox1_Priority.Items.Add("Wysoki");
            comboBox1_Priority.SelectedIndex = 0;
            comboBox_Time.Items.Add("min");
            comboBox_Time.Items.Add("h");
            comboBox_Time.SelectedIndex = 0;


        }
        public DodajZadanieForm(Zadanie taskToEdit)
        {
            InitializeComponent();
            comboBox1_Priority.Items.Add("Niski");
            comboBox1_Priority.Items.Add("Średni");
            comboBox1_Priority.Items.Add("Wysoki");
            comboBox1_Priority.SelectedIndex = 0;
            comboBox_Time.Items.Add("min");
            comboBox_Time.Items.Add("h");
            comboBox_Time.SelectedIndex = 0;


            textBox_Zadanie.Text = taskToEdit.Title;
            textBox_Kategoria.Text = taskToEdit.Category;
            comboBox1_Priority.SelectedItem = taskToEdit.Priority;
            numericUpDown_CzasNaZadanie.Value = taskToEdit.DurationMinutes;
            monthCalendar1.SetDate(taskToEdit.Deadline.Value.Date);
            numericUpDown_Hour.Value = taskToEdit.Deadline.Value.Hour;
            numericUpDown_Minutes.Value = taskToEdit.Deadline.Value.Minute;
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox_Zadanie.Text) || string.IsNullOrWhiteSpace(textBox_Kategoria.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DateTime selectedDateTime = monthCalendar1.SelectionStart;
            int hour = (int)numericUpDown_Hour.Value;
            int minutes = (int)numericUpDown_Minutes.Value;
            selectedDateTime = new DateTime(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day, hour, minutes, 0);
            if (selectedDateTime < DateTime.Now)
            {
                MessageBox.Show("Czy na pewno podałeś dobrą datę !", "Błąd", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            }


            NoweZadanie = new Zadanie
            {
                Title = textBox_Zadanie.Text,
                Category = textBox_Kategoria.Text,
                Priority = comboBox1_Priority.SelectedItem.ToString(),
                DurationMinutes = CalculateMinutes(((int)numericUpDown_CzasNaZadanie.Value)),
                Deadline = selectedDateTime,
                IsCompleted = false
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private int CalculateMinutes(int duration)
        {
            
            if (comboBox_Time.SelectedItem == "h")
            {
                duration *= 60;
            }
            else
            {
                duration *= 1;
            }
            return duration;


        }
    }
}
