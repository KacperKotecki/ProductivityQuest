using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productivity_Quest_1._0
{
    public class Zadanie
    {
        public string NameTask { get; set; }
        public string Category { get; set; }
        public int Prioryty { get; set; }
        public int TimeToDo { get; set; }
        public DateTime? Deadline { get; set; }
        public bool Done { get; set; }
    }
}


