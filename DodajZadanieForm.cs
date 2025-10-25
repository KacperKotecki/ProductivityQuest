using System;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    public partial class DodajZadanieForm : Form
    {

        private Task EditingTask;
        private Manage manage;
        public Task Task => EditingTask;

        public DodajZadanieForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }
        public DodajZadanieForm(Task taskToEdit, Manage manage)
        {
            InitializeComponent();
            InitializeComboBoxes();
            EditingTask = taskToEdit;
            this.manage = manage;

            textBox_Zadanie.Text = taskToEdit.Title;
            comboBox_Category.SelectedItem = taskToEdit.Category;
            comboBox1_Priority.SelectedItem = taskToEdit.Priority;
            numericUpDown_CzasNaZadanie.Value = taskToEdit.DurationMinutes;

            if (taskToEdit.StartDateTime.HasValue)
            {
                monthCalendar1.SetDate(taskToEdit.StartDateTime.Value.Date);
                numericUpDown_Hour.Value = taskToEdit.StartDateTime.Value.Hour;
                numericUpDown_Minutes.Value = taskToEdit.StartDateTime.Value.Minute;
            }
            else
            {
                monthCalendar1.SetDate(DateTime.Today);
            }

        }
        private void InitializeComboBoxes()
        {
            string[] comboboxPriority = new string[] {"Niski","Średni","Wysoki"};
            string[] comboboxTime = new string[] {"min","h"};
            string[] comboboxCategory = new string[] {"Nauka","Praca","Dom","Zdrowie","Rozwój osobisty","Relacje","Hobby","Samopoczucie", "Organizacja","Inne"};
            
            
            
            comboBox1_Priority.Items.AddRange(comboboxPriority);
            comboBox_Time.Items.AddRange(comboboxTime);
            comboBox_Category.Items.AddRange(comboboxCategory);


            comboBox1_Priority.SelectedIndex = 0;
            comboBox_Time.SelectedIndex = 0;
            comboBox_Category.SelectedIndex = 0;

            monthCalendar1.SetDate(DateTime.Now);

        }
        private void buttonZapisz_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox_Zadanie.Text) )
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dodano return, aby przerwać wykonywanie metody w przypadku błędu
            }

            DateTime selectedDateTime = monthCalendar1.SelectionStart;
            int hour = (int)numericUpDown_Hour.Value;
            int minutes = (int)numericUpDown_Minutes.Value;
            selectedDateTime = new DateTime(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day, hour, minutes, 0);
            if (selectedDateTime < DateTime.Now)
            {
                var dialogResult = MessageBox.Show("Wybrana data jest z przeszłości. Czy na pewno chcesz kontynuować?", "Ostrzeżenie o dacie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                {
                    return; // Przerwij, jeśli użytkownik nie chce kontynuować
                }
            }

            EditingTask.Title = textBox_Zadanie.Text;
            EditingTask.Category = comboBox_Category.SelectedItem.ToString();
            EditingTask.Priority = comboBox1_Priority.SelectedItem.ToString();
            EditingTask.DurationMinutes = CalculateMinutes((int)numericUpDown_CzasNaZadanie.Value);
            EditingTask.StartDateTime = selectedDateTime;
            

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

            if (comboBox_Time.SelectedItem.ToString() == "h")
            {
                duration *= 60;
            }
            return duration;


        }

        private void btn_TaskCompleted_Click(object sender, EventArgs e)
        {
            if (EditingTask.IsCompleted)
            {
                MessageBox.Show("To zadanie jest już wykonane!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Czy na pewno chcesz oznaczyć to zadanie jako wykonane?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                EditingTask.IsCompleted = true;
                MessageBox.Show("Zadanie zostało oznaczone jako wykonane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_RemoveTask_Click(object sender, EventArgs e)
        {
            string message = EditingTask.IsCompleted ? "Czy na pewno chcesz usunąć wykonane zadanie?": "Czy na pewno chcesz usunąć to zadanie?";

            var confirm = MessageBox.Show(message, "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                manage.Tasks.Remove(EditingTask);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}

