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

        public int DurationMinutes { get; set; }

        public DateTime? StartDateTime { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return Title;
        }

        
    }
}
