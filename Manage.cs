using Productivity_Quest_1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Productivity_Quest_1._0
{
    internal class Manage
    {
        public List<Zadanie> ListaZadan = new List<Zadanie>();
        public void AddTask()
        {
            Zadanie zadanie = new Zadanie();
            Console.WriteLine("Dodawanie zadania \n");
            Console.Write("Podaj treść zadania do wykonania : ");
            zadanie.NameTask = Console.ReadLine();
            Console.Write("Podaj kategorie zadania : ");
            zadanie.Category = Console.ReadLine();
            Console.Write("Podaj priorytet zadania : ");
            zadanie.Prioryty = int.Parse(Console.ReadLine());
            Console.Write("Podaj czas na wykonanie zadania (min): ");
            zadanie.TimeToDo = int.Parse(Console.ReadLine());

            Console.Write("Podaj datę w formacie dd.MM.yyyy HH:mm (np. 01.04.2025 13:30): ");
            string datawykonania = Console.ReadLine();
            zadanie.Deadline = DateTime.ParseExact(datawykonania, "dd.MM.yyyy HH:mm", null);
            zadanie.Done = false;
            ListaZadan.Add(zadanie);
        }
        public void RemoveTask()
        {
            DisplayTasks();
            while (true)
            {
                Console.WriteLine("Wybierz numer zadania do usunięcia : ");
                string input = Console.ReadLine();
                try
                {
                    int number = int.Parse(input);

                    if (number >= 0 && number < ListaZadan.Count)
                    {
                        Console.Write("Czy na pewno chcesz usunąć to zadanie (yes/no)");
                        string confirm = Console.ReadLine().ToLower();
                        if (confirm == "y" || confirm == "yes")
                            ListaZadan.RemoveAt(number);
                        else
                            continue;
                    }
                    else
                    {
                        Console.WriteLine("Podaj prawidłowy numer zadania ");

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Podaj liczbę całkowitą  ");
                }

            }



        }
        public void DisplayTasks()
        {


            for (int i = 0; i < ListaZadan.Count; i++)
            {
                var z = ListaZadan[i];
                Console.WriteLine($"{i}. {z.NameTask} | {z.Category} | {z.Prioryty} | {z.TimeToDo} | {z.Deadline} |  {z.Done}");

            }
        }
        public void DisplayTasks(IEnumerable<Zadanie> lista)
        {

            foreach (var z in lista)
            {
                Console.WriteLine($"{z.NameTask} | {z.Category} | {z.Prioryty} | {z.TimeToDo} | {z.Deadline} |  {z.Done}");

            }

        }
        public void SortTask(int option)
        {
            switch (option - 1)
            {
                case 0:
                    var sortedByCategory = ListaZadan.OrderBy(z => z.Category).ThenBy(z => z.Done);
                    DisplayTasks(sortedByCategory);

                    break;
                case 1:
                    var sortedByPriority = ListaZadan.OrderBy(z => z.Prioryty).ThenBy(z => z.Done);
                    DisplayTasks(sortedByPriority);
                    break;
                case 2:
                    var sortedByDeadline = ListaZadan.OrderBy(z => z.Deadline).ThenBy(z => z.Done);
                    DisplayTasks(sortedByDeadline);
                    break;

            }
        }
        public void TaskCompleted(Player player)
        {

            var sortedByDone = ListaZadan.OrderBy(z => z.Done);
            DisplayTasks(sortedByDone);
            Console.Write("Które zadanie wykonałeś :");
            string input = Console.ReadLine();
            try
            {
                int number = int.Parse(input);
                if (number >= 0 && number < ListaZadan.Count && ListaZadan[number].Done == false)
                {
                    Console.WriteLine("Czy na pewno chcesz zmienić status zadania {0} (yes/no)", number);
                    string confirm = Console.ReadLine().ToLower();
                    if (confirm == "y" || confirm == "yes")
                    {
                        ListaZadan[number].Done = true;

                        int xp = ListaZadan[number].Prioryty * 20 + (int)(ListaZadan[number].TimeToDo * 1.5);
                        player.DodajXP(xp);
                        player.ZarejestrujDzienZadania();
                    }
                    else
                    {
                        return;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Podaj prawidłowy numer");
            }


        }
        public void TaskCompleted(int index, Player player)
        {
            if (index >= 0 && index < ListaZadan.Count && ListaZadan[index].Done == false)
            {
                ListaZadan[index].Done = true;

                int xp = ListaZadan[index].Prioryty * 20 + (int)(ListaZadan[index].TimeToDo * 1.5);
                player.DodajXP(xp);
                player.ZarejestrujDzienZadania();
            }
        }
    }
}



