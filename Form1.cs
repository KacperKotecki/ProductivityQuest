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
        private JsonStorageService saveRead = new JsonStorageService();

        public Form1()
        {

            InitializeComponent();

            manage.Tasks = saveRead.LoadFromFile<List<Zadanie>>("data.json") ?? new List<Zadanie>();
            player = saveRead.LoadFromFile<Player>("player.json") ?? new Player();
            RefreshTaskList();
            RefreshStats();

        }
        private void RefreshTaskList(DateTime? filterDate = null)
        {
            checkedListBoxTasks.Items.Clear();
            monthCalendar_Form.RemoveAllBoldedDates();
            foreach (var task in manage.Tasks)
            {
                
                if (task.Deadline != null)
                { 
                    monthCalendar_Form.AddBoldedDate(task.Deadline.Value.Date);
                    
                }
                monthCalendar_Form.UpdateBoldedDates();

                if (filterDate == null || filterDate.Value.Date == task.Deadline.Value.Date)
                {
                   
                    checkedListBoxTasks.Items.Add(task);
                }



            }
        }
        private void RefreshTaskList(List<Zadanie> ListaZadan)
        {

            checkedListBoxTasks.Items.Clear();
            
            foreach (var task in ListaZadan)
            {
                checkedListBoxTasks.Items.Add(task);

            }
        }
        private void RefreshStats()
        {
            lb_Name.Text = player.Name ?? "Gracz";
            lb_Poziom.Text = $"Poziom: {player.Level}";
            lb_XP.Text = $"XP: {player.Experience}/{player.ExperienceToLevelUp}";
            Progress_Level.Maximum = player.ExperienceToLevelUp;
            Progress_Level.Value = Math.Min(player.Experience, Progress_Level.Maximum);
            lb_Streak.Text = $"Streak: {player.CalculateStreak()} dni z rzędu!";
        }


        private void btn_AddTask_Click(object sender, EventArgs e)
        {
            var editForm = new DodajZadanieForm();

            var result = editForm.ShowDialog();

            if (result == DialogResult.OK && editForm.NoweZadanie != null)
            {

                manage.Tasks.Add(editForm.NoweZadanie);


                saveRead.SaveToFile(manage.Tasks, "data.json");


                RefreshTaskList();
            }
        }

        private void btn_EditTask_Click(object sender, EventArgs e)
        {

            if (checkedListBoxTasks.SelectedIndex != -1 && checkedListBoxTasks.CheckedItems.Count == 1)
            {
                var confirm = MessageBox.Show("Czy na pewno chcesz edytować te zadanie ?", "Uwaga !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                var task = (Zadanie)checkedListBoxTasks.SelectedItem;
                
                if (confirm == DialogResult.Yes)
                {
                    var edycjaForm = new DodajZadanieForm(task);
                    edycjaForm.Text = "Edycja zadania";

                    var result = edycjaForm.ShowDialog();
                    if (result == DialogResult.OK && edycjaForm.NoweZadanie != null)
                    {

                        task.Title = edycjaForm.NoweZadanie.Title;
                        task.Category = edycjaForm.NoweZadanie.Category;
                        task.Priority = edycjaForm.NoweZadanie.Priority;
                        task.DurationMinutes = edycjaForm.NoweZadanie.DurationMinutes;
                        task.Deadline = edycjaForm.NoweZadanie.Deadline;

                        saveRead.SaveToFile(manage.Tasks, "data.json");
                        RefreshTaskList();
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
                if (confirm == DialogResult.Yes)
                {
                    var taskToDelete = (Zadanie)checkedListBoxTasks.SelectedItem;
                    manage.Tasks.Remove(taskToDelete);

                    saveRead.SaveToFile(manage.Tasks, "data.json");
                    RefreshTaskList();
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
            if (checkedListBoxTasks.SelectedIndex != -1 && checkedListBoxTasks.CheckedItems.Count == 1)
            {
                var confirm = MessageBox.Show("Czy na pewno wykonałeś to zadanie ?", "Uwaga !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    var completedTask = (Zadanie)checkedListBoxTasks.SelectedItem;

                    if (completedTask.IsCompleted == true)
                    {
                        MessageBox.Show("To zadanie jest już wykonane !", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    manage.TaskCompleted(completedTask, player);

                    saveRead.SaveToFile(manage.Tasks, "data.json");
                    saveRead.SaveToFile(player, "player.json");

                    RefreshTaskList();
                    RefreshStats();
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
            var editForm = new EditProfile(player);

            var result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {

                player.Name = editForm.NewPlayerName;
                MessageBox.Show("Nowa nazwa gracza : " + player.Name);
                MessageBox.Show("Nowa nazwa gracza : " + player.Name, "Zmiana nazwy", MessageBoxButtons.OK, MessageBoxIcon.Information);

                saveRead.SaveToFile(player, "player.json");
                RefreshStats();
            }

        }
        
        private void monthCalendar_Form_DateChanged(object sender, DateRangeEventArgs e)
        {
            RefreshTaskList(monthCalendar_Form.SelectionStart.Date);
        }

        private void lb_SortedByCategory_Click(object sender, EventArgs e)
        {
            SortedBy(manage.Tasks, lb_SortedByCategory.Tag.ToString());


        }

        private void lb_SortedByPriority_Click(object sender, EventArgs e)
        {
            SortedBy(manage.Tasks, lb_SortedByPriority.Tag.ToString());
        }

        private void lb_SortedByTime_Click(object sender, EventArgs e)
        {
            SortedBy(manage.Tasks, lb_SortedByTime.Tag.ToString());
        }
        private void lb_SortedByDefault_Click(object sender, EventArgs e)
        {
            SortedBy(manage.Tasks, lb_SortedByDefault.Tag.ToString());
            
        }
        public void SortedBy(List<Zadanie> taskList, string sortOption)
        {

            
            switch (sortOption)
            {
                case "Category":

                    taskList = taskList.OrderBy(z => z.Category).ThenBy(z => z.IsCompleted).ToList();
                    
                    break;
                case "Priority":
                    taskList = taskList.OrderBy(z => z.IsCompleted).ThenBy(z => z.Priority).ToList();
                    
                    break;
                case "Time":
                    taskList = taskList.OrderBy(z => z.IsCompleted).ThenBy(z => z.Deadline).ToList();
                    break;
                case "Default":
                    taskList = taskList.OrderBy(z => z.CreatedAt).ToList();
                    
                    break;
                default: 
                    break; 
            }
            
                RefreshTaskList(taskList);

            

        }

        
    }
}
