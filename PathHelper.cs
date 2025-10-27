using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productivity_Quest_1._0
{
    public static class PathHelper
    {

        public static string GetProjectPath(params string[] subfolders)
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));
            return Path.Combine(new[] { projectRoot }.Concat(subfolders).ToArray());
        }
    
    }
}
