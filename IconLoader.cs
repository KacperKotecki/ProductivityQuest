using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productivity_Quest_1._0
{


    public static class IconLoader
    {
        public static List<Bitmap> LoadFromResources(string prefix, int count)
        {
            var list = new List<Bitmap>();
            for (int i = 0; i < count; i++)
            {
                string name = $"{prefix}_{i}";
                Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(name);
                if (img != null)
                    list.Add(img);
            }
            return list;
        }
    }


}
