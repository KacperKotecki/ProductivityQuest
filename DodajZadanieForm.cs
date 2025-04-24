using System;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    public partial class DodajZadanieForm : Form
    {

        private Zadanie EditingTask;
        private Manage manage;
        public Zadanie Task => EditingTask;

        public DodajZadanieForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }
        public DodajZadanieForm(Zadanie taskToEdit, Manage manage)
        {
            InitializeComponent();
            InitializeComboBoxes();
            EditingTask = taskToEdit;
            this.manage = manage;

            

            textBox_Zadanie.Text = taskToEdit.Title;
            comboBox_Category.SelectedItem = taskToEdit.Category;
            comboBox1_Priority.SelectedItem = taskToEdit.Priority;
            numericUpDown_CzasNaZadanie.Value = taskToEdit.DurationMinutes;

            if (taskToEdit.Deadline.HasValue)
            {
                monthCalendar1.SetDate(taskToEdit.Deadline.Value.Date);
                numericUpDown_Hour.Value = taskToEdit.Deadline.Value.Hour;
                numericUpDown_Minutes.Value = taskToEdit.Deadline.Value.Minute;
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
            }

            DateTime selectedDateTime = monthCalendar1.SelectionStart;
            int hour = (int)numericUpDown_Hour.Value;
            int minutes = (int)numericUpDown_Minutes.Value;
            selectedDateTime = new DateTime(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day, hour, minutes, 0);
            if (selectedDateTime < DateTime.Now)
            {
                
                MessageBox.Show("Czy na pewno podałeś dobrą datę !", "Błąd", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
            }

            EditingTask.Title = textBox_Zadanie.Text;
            EditingTask.Category = comboBox_Category.SelectedItem.ToString();
            EditingTask.Priority = comboBox1_Priority.SelectedItem.ToString();
            EditingTask.DurationMinutes = CalculateMinutes((int)numericUpDown_CzasNaZadanie.Value);
            EditingTask.Deadline = selectedDateTime;
            

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
            return duration;


        }

        private void btn_TaskCompleted_Click(object sender, EventArgs e)
        {
            if (EditingTask.IsCompleted)
            {
                MessageBox.Show("To zadanie jest już wykonane!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Czy na pewno wykonałeś to zadanie?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                EditingTask.IsCompleted = true; 
            }
        }

        private void btn_RemoveTask_Click(object sender, EventArgs e)
        {
            string message = EditingTask.IsCompleted ? "Czy na pewno chcesz usunąć wykonane zadanie?": "Czy na pewno chcesz usunąć niewykonane zadanie?";

            var confirm = MessageBox.Show(message, "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                manage.Tasks.Remove(EditingTask);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}

