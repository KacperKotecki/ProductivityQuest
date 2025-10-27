using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productivity_Quest_1._0
{
    public class Task
    {
        

        public string GoogleId { get; set; }
        public string Title { get; set; }

        public string Category { get; set; }

        public string Priority { get; set; }

        public const int MaxDurationMinutes = 1439; 

        private int _durationMinutes;
        public int DurationMinutes
        {
            get { return _durationMinutes; }
            set
            {
                if (value < 0 || value > MaxDurationMinutes)
                {
                    throw new ArgumentOutOfRangeException(nameof(DurationMinutes), $"Czas trwania musi być pomiędzy 0 a {MaxDurationMinutes} minut.");
                    
                }
                _durationMinutes = value;
            }
        }

        public DateTime? StartDateTime { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return Title;
        }

        
    }
}
