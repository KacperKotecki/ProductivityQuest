using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Productivity_Quest_1._0
{
    public partial class Form1 : Form
    {
        private Player player = new Player();
        private Manage manage = new Manage();
        private Save_read saveRead = new Save_read();

        public Form1()
        {
            InitializeComponent();

            manage.ListaZadan = saveRead.ReadFileJSON<List<Zadanie>>("data.json") ?? new List<Zadanie>();
            player = saveRead.ReadFileJSON<Player>("player.json") ?? new Player();
            
            OdswiezListeZadan();
            OdswiezStatystyki();
        }
        private void OdswiezListeZadan()
        {
            checkedListBoxTasks.Items.Clear();
            foreach (var z in manage.ListaZadan)
            {     
                checkedListBoxTasks.Items.Add($"{z.NameTask} | {z.Category} | {z.Prioryty}/10 | {(z.Done ? "Done" : "To do")}    {z.Deadline?.ToString("HH:mm")}  {z.Deadline?.ToString("dd.MM.yyyy")}");
            }
        }
        private void OdswiezStatystyki()
        {
            lb_Name.Text = player.Imie ?? "Gracz";
            lb_Poziom.Text = $"Poziom: {player.Poziom}";
            lb_XP.Text = $"XP: {player.XP}/{player.XPNaPoziom}";
            Progress_Level.Maximum = player.XPNaPoziom;
            Progress_Level.Value = Math.Min(player.XP, Progress_Level.Maximum);
            lb_Streak.Text = $"Streak: {player.ObliczStreak()} dni z rzędu!";
        }
       

        private void btn_AddTask_Click(object sender, EventArgs e)
        {
            var okno = new DodajZadanieForm();

            var wynik = okno.ShowDialog();

            if (wynik == DialogResult.OK && okno.NoweZadanie != null)
            {
                
                manage.ListaZadan.Add(okno.NoweZadanie);

                
                saveRead.SaveFileJSON(manage.ListaZadan, "data.json");

                
                OdswiezListeZadan();
            }
        }

        private void btn_EditTask_Click(object sender, EventArgs e)
        {
            
            if (checkedListBoxTasks.SelectedIndex != -1 && checkedListBoxTasks.CheckedItems.Count == 1)
            {
                var confirm = MessageBox.Show("Czy na pewno chcesz edytować te zadanie ?", "Uwaga !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int index = checkedListBoxTasks.SelectedIndex;
                if (confirm == DialogResult.Yes)
                {
                    Zadanie oryginalneZadanie = manage.ListaZadan[index];

                    var edycjaForm = new DodajZadanieForm(oryginalneZadanie);
                    edycjaForm.Text = "Edycja zadania";
                    
                    var wynik = edycjaForm.ShowDialog();

                    if (wynik == DialogResult.OK && edycjaForm.NoweZadanie != null)
                    {
                        
                        manage.ListaZadan[index] = edycjaForm.NoweZadanie;

                        saveRead.SaveFileJSON(manage.ListaZadan, "data.json");
                        OdswiezListeZadan();
                    }
                }
            }
            else if (checkedListBoxTasks.CheckedItems.Count > 1)
            {
                MessageBox.Show("Możesz wybrać tylko jedno zadanie", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Zaznacz zadanie które chcesz edytować", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_RemoveTask_Click(object sender, EventArgs e)
        {
            if (checkedListBoxTasks.SelectedIndex != -1 && checkedListBoxTasks.CheckedItems.Count == 1)
            {
                var confirm = MessageBox.Show("Czy na pewno chcesz usunąć te zadanie ?", "Uwaga !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(confirm == DialogResult.Yes)
                {
                    int usun = checkedListBoxTasks.SelectedIndex;
                    manage.ListaZadan.RemoveAt(usun);

                    saveRead.SaveFileJSON(manage.ListaZadan, "data.json");
                    OdswiezListeZadan();
                }
            }
            else if (checkedListBoxTasks.CheckedItems.Count > 1)
            {
                MessageBox.Show("Możesz wybrać tylko jedno zadanie", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Zaznacz zadanie które chcesz usunąć", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_TaskComplited_Click(object sender, EventArgs e)
        {
            if (checkedListBoxTasks.SelectedIndex != -1 && checkedListBoxTasks.CheckedItems.Count == 1 )
            {
                var confirm = MessageBox.Show("Czy na pewno wykonałeś to zadanie ?", "Uwaga !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    int zrobione = checkedListBoxTasks.SelectedIndex;
                    
                    if(manage.ListaZadan[zrobione].Done == true)
                    {
                        MessageBox.Show("To zadanie jest już wykonane !", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    manage.TaskCompleted(zrobione, player); 

                    saveRead.SaveFileJSON(manage.ListaZadan, "data.json");
                    saveRead.SaveFileJSON(player, "player.json");

                    OdswiezListeZadan();
                    OdswiezStatystyki();
                }
            }
            else if (checkedListBoxTasks.CheckedItems.Count > 1)
            {
                MessageBox.Show("Możesz wybrać tylko jedno zadanie", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Zaznacz zadanie które wykonałęś", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Edit_Player_Click(object sender, EventArgs e)
        {
            var okno = new EditProfile();

            var wynik = okno.ShowDialog();

            if (wynik == DialogResult.OK)
            {
                
                player.Imie = okno.NoweImie;
                MessageBox.Show("Nowa nazwa gracza : " + player.Imie);
                MessageBox.Show("Nowa nazwa gracza : " + player.Imie, "Zmiana nazwy", MessageBoxButtons.OK, MessageBoxIcon.Information);

                saveRead.SaveFileJSON(player, "player.json");
                OdswiezStatystyki();
            }
        }
    }
    
}
