using System.Windows.Forms;

namespace Productivity_Quest_1._0.UI
{
    public class StatsControls
    {
        // Pola przypisane do kontrolek na Form1
        public Label LabelName { get; set; }
        public Label LabelLevel { get; set; }
        public Label LabelXP { get; set; }
        public Label LabelStreak { get; set; }
        public ProgressBar ProgressLevel { get; set; }
        public PictureBox PictureStreak { get; set; }
        public PictureBox PictureProfile { get; set; }

        // Konstruktor opcjonalny – możesz przekazać wszystko od razu
        public StatsControls(Label labelName, Label labelLevel, Label labelXP, Label labelStreak,
                             ProgressBar progressLevel, PictureBox pictureStreak, PictureBox pictureProfile)
        {
            LabelName = labelName;
            LabelLevel = labelLevel;
            LabelXP = labelXP;
            LabelStreak = labelStreak;
            ProgressLevel = progressLevel;
            PictureStreak = pictureStreak;
            PictureProfile = pictureProfile;
        }

        // Konstruktor pusty też może być, jeśli chcesz przypisywać później
        public StatsControls() { }
    }
}
