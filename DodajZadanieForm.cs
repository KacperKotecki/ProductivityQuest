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
        public DodajZadanieForm(Zadanie zadanieDoEdycji)
        {
            InitializeComponent();
            int timetodo = Oblicz_minuty();
            textBox_Zadanie.Text = zadanieDoEdycji.NameTask;
            textBox_Kategoria.Text = zadanieDoEdycji.Category;
            comboBox1_Priority.SelectedItem = zadanieDoEdycji;
            numericUpDown_CzasNaZadanie.Value = zadanieDoEdycji.TimeToDo;
            
            monthCalendar1.SetDate(zadanieDoEdycji.Deadline ?? DateTime.Now);
            numericUpDown_Hour.Value = zadanieDoEdycji.Deadline.Value.Hour;
            numericUpDown_Minutes.Value = zadanieDoEdycji.Deadline.Value.Minute;
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox_Zadanie.Text) || string.IsNullOrWhiteSpace(textBox_Kategoria.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DateTime wybranadata = monthCalendar1.SelectionStart;
            int hour = (int)numericUpDown_Hour.Value;
            int minutes = (int)numericUpDown_Minutes.Value;
            wybranadata = new DateTime(wybranadata.Year, wybranadata.Month, wybranadata.Day, hour, minutes, 0);
            if (wybranadata < DateTime.Now)
            {
                MessageBox.Show("Czy na pewno podałeś dobrą datę !", "Błąd", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            }


            NoweZadanie = new Zadanie
            {
                NameTask = textBox_Zadanie.Text,
                Category = textBox_Kategoria.Text,
                Prioryty = comboBox1_Priority.SelectedItem.ToString(),
                TimeToDo = Oblicz_minuty(),
                Deadline = wybranadata,
                Done = false
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private int Oblicz_minuty()
        {
            int min = 0;
            if (comboBox_Time.Text == "h")
            {
                min *= 60;
                
            }
            else
            {
                min *= 1;
            }
            return min;


        }
    }
}
