using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Productivity_Quest_1._0
{


    public static class IconLoader
    {
        public static List<Bitmap> LoadFromResources(string prefix, int count)
        {
            var imageList = new List<Bitmap>();
            for (int i = 0; i < count; i++)
            {
                string name = $"{prefix}_{i}";
                Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(name);
                if (img != null)
                    imageList.Add(img);
            }
            return imageList;
        }

        public static List<Bitmap> LoadFromFolder(string folderPath, Bitmap fallbackImage = null, int maxCount = 200)
        {
            var imageList = new List<Bitmap>();

            string[] extensions = new string[] { ".png", ".jpg" };

            if (!Directory.Exists(folderPath))
                return imageList;

            var files = Directory.GetFiles(folderPath)
                .Where(file => extensions.Contains(Path.GetExtension(file).ToLower()))
                .Take(maxCount);

            foreach (var file in files)
            {
                try
                {
                    Bitmap img = new Bitmap(file);
                    imageList.Add(img);

                    
                }
                catch
                {
                    MessageBox.Show($"Nie udało się wczytać obrazu:\n{file}", "Błąd grafiki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (imageList.Count == 0 && fallbackImage != null)
            {
                try
                {
                    imageList.Add(fallbackImage);
                }
                catch
                {
                    MessageBox.Show("Nie udało się wczytać obrazu domyślnego.", "Krytyczny błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            


            return imageList;
        }
        public static Bitmap LoadSingleOrFallback(string filePath, Bitmap fallbackImage)
        {
            string[] allowedExtensions = new[] { ".png", ".jpg" };

            string extension = Path.GetExtension(filePath).ToLower();

            if (allowedExtensions.Contains(extension) && File.Exists(filePath))
            {
                try
                {
                    return new Bitmap(filePath);
                }
                catch
                {
                    MessageBox.Show($"Nie udało się wczytać obrazu:\n{filePath}", "Błąd grafiki", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return fallbackImage;
        }
    }


}
