using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productivity_Quest_1._0
{
    public class Achievement
    {
        public string Name { get; set; }              
        public string Category { get; set; }          
        public int Progress { get; set; }        
        public int RequiredCount { get; set; }        
        public string Source { get; set; }            
        public string Description{ get; set; } 
        public string Icon { get; set; }
        public bool IsUnlocked { get; set; } = false;
        public DateTime? UnlockedAt { get; set; }
    }
}
