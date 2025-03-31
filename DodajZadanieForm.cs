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
        }
        public DodajZadanieForm(Zadanie zadanieDoEdycji)
        {
            InitializeComponent();
            textBox_Zadanie.Text = zadanieDoEdycji.NameTask;
            textBox_Kategoria.Text = zadanieDoEdycji.Category;
            numericUpDown_Priorytet.Value = zadanieDoEdycji.Prioryty;
            numericUpDown_CzasNaZadanie.Value = zadanieDoEdycji.TimeToDo;
            dateTimePicker_Deadline.Value = zadanieDoEdycji.Deadline ?? DateTime.Now;
        }

        private void buttonZapisz_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(textBox_Zadanie.Text) || string.IsNullOrWhiteSpace(textBox_Kategoria.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NoweZadanie = new Zadanie
            {
                NameTask = textBox_Zadanie.Text,
                Category = textBox_Kategoria.Text,
                Prioryty = (int)numericUpDown_Priorytet.Value,
                TimeToDo = (int)numericUpDown_CzasNaZadanie.Value,
                Deadline = dateTimePicker_Deadline.Value,
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
    }
}
