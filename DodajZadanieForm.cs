using System;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    public partial class DodajZadanieForm : Form
    {
        // Zmieniono nazwę, aby było jasne, że to jest obiekt, nad którym pracujemy
        public Task CurrentTask { get; private set; }

        /// <summary>
        /// Konstruktor dla NOWEGO zadania.
        /// </summary>
        public DodajZadanieForm()
        {
            InitializeComponent();
            InitializeComboBoxes();

        }

        public DodajZadanieForm(DateTime suggestedStartTime)
        {
            InitializeComponent();
            InitializeComboBoxes();

            this.Text = "Dodaj nowe zadanie";
            this.CurrentTask = new Task(); // Tworzymy nowy, pusty obiekt

            // --- Ustawianie wartości domyślnych ---
            comboBox_Category.SelectedItem = "Ogólne";
            comboBox1_Priority.SelectedIndex = 0; // "Niski"
            numericUpDown_CzasNaZadanie.Value = 60;
            comboBox_Time.SelectedItem = "min";

            // --- Ustawianie czasu na podstawie kliknięcia ---
            CurrentTask.StartDateTime = suggestedStartTime;
            monthCalendar1.SetDate(suggestedStartTime.Date);
            numericUpDown_Hour.Value = suggestedStartTime.Hour;
            numericUpDown_Minutes.Value = suggestedStartTime.Minute;

            // Ukrywamy przyciski, które nie mają sensu przy nowym zadaniu
            btn_TaskComplited.Visible = false;
            btn_RemoveTask.Visible = false;
        }

        /// <summary>
        /// Konstruktor do EDYCJI istniejącego zadania.
        /// </summary>
        public DodajZadanieForm(Task taskToEdit)
        {
            InitializeComponent();
            InitializeComboBoxes();

            this.Text = "Edycja zadania";
            this.CurrentTask = taskToEdit; // Pracujemy na przekazanym obiekcie

            // Wczytywanie danych z istniejącego zadania
            textBox_Zadanie.Text = CurrentTask.Title;
            comboBox_Category.SelectedItem = CurrentTask.Category;
            comboBox1_Priority.SelectedItem = CurrentTask.Priority;

            if (CurrentTask.DurationMinutes >= 60 && CurrentTask.DurationMinutes % 60 == 0)
            {
                numericUpDown_CzasNaZadanie.Value = CurrentTask.DurationMinutes / 60;
                comboBox_Time.SelectedItem = "h";
            }
            else
            {
                numericUpDown_CzasNaZadanie.Value = CurrentTask.DurationMinutes;
                comboBox_Time.SelectedItem = "min";
            }

            if (CurrentTask.StartDateTime.HasValue)
            {
                monthCalendar1.SetDate(CurrentTask.StartDateTime.Value.Date);
                numericUpDown_Hour.Value = CurrentTask.StartDateTime.Value.Hour;
                numericUpDown_Minutes.Value = CurrentTask.StartDateTime.Value.Minute;
            }
        }

        private void InitializeComboBoxes()
        {
            string[] comboboxCategory = new string[] { "Ogólne", "Nauka", "Praca", "Dom", "Zdrowie", "Rozwój osobisty", "Relacje", "Hobby", "Samopoczucie", "Organizacja", "Inne" };
            string[] comboboxPriority = new string[] { "Niski", "Średni", "Wysoki" };
            string[] comboboxTime = new string[] { "min", "h" };

            comboBox_Category.Items.AddRange(comboboxCategory);
            comboBox1_Priority.Items.AddRange(comboboxPriority);
            comboBox_Time.Items.AddRange(comboboxTime);
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Zadanie.Text))
            {
                MessageBox.Show("Tytuł zadania nie może być pusty!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDateTime = monthCalendar1.SelectionStart;
            int hour = (int)numericUpDown_Hour.Value;
            int minutes = (int)numericUpDown_Minutes.Value;
            selectedDateTime = new DateTime(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day, hour, minutes, 0);

            // Aktualizujemy obiekt CurrentTask danymi z formularza
            CurrentTask.Title = textBox_Zadanie.Text;
            CurrentTask.Category = comboBox_Category.SelectedItem.ToString();
            CurrentTask.Priority = comboBox1_Priority.SelectedItem.ToString();
            CurrentTask.DurationMinutes = CalculateMinutes((int)numericUpDown_CzasNaZadanie.Value);
            CurrentTask.StartDateTime = selectedDateTime;

            this.DialogResult = DialogResult.OK;
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
            CurrentTask.IsCompleted = !CurrentTask.IsCompleted;
            MessageBox.Show(CurrentTask.IsCompleted ? "Zadanie zostało oznaczone jako wykonane." : "Cofnięto wykonanie zadania.", "Status zadania", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Odświeżamy widok przycisku, jeśli jest taka potrzeba
        }

        private void btn_RemoveTask_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Czy na pewno chcesz usunąć to zadanie?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Abort; // Używamy nowego wyniku, aby zasygnalizować usunięcie
                this.Close();
            }
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

