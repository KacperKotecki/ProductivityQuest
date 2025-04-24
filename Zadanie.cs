
using System;

namespace Productivity_Quest_1._0
{
    public class Zadanie
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public override string ToString()
        {
            return $" {Title} | {Category}  | {Priority} | {(IsCompleted ? "Done" : "To do")}    {Deadline?.ToString("HH:mm")}  {Deadline?.ToString("dd.MM.yyyy")}";
        }
        
    }

}


