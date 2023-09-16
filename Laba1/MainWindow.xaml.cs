using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Laba1.Class;

namespace Laba1
{
    public partial class MainWindow : Window
    {
        private List<string> Answers;
        private List<string> motivationalPhrases;
        public MainWindow()
        {
            InitializeComponent();
            Answers = new List<string>()
            {
                "Bella Ciao",
                "L'italiano",
                "Macarena",
                "Despacito",
                "Anthem of Autumn",
                "Custer",
                "Metallll",
                "The last of us",
                "Duel of the Fates",
                "Go Kitty Go Ttversion",
                "Zobmie",
                "Solas"
            };
            motivationalPhrases = new List<string>
            {
                "Ніколи не відступайтеся від своїх мрій.",
                "Сьогодні - перший день решти вашого життя.",
                "Віра в себе - ключ до успіху.",
                "Завжди намагайтеся бути кращим за вчора.",
                "Працюйте наполегливо і досягнете своїх цілей.",
                "Мрійте велико і вірте в свої можливості.",
                "Кожна помилка - це навчальний досвід.",
                "Поставте перед собою завдання та досягайте їх крок за кроком.",
                "Ваша доля - у ваших руках.",
                "Сильніше віруйте у себе, і все буде можливим.",
                "Робіть те, що вас надихає.",
                "Ви здатні на більше, ніж ви думаєте.",
                "Завжди старайтеся досягати нових вершин.",
                "Ніколи не втрачайте віру у себе.",
                "Життя - це можливості, не втрачайте їх.",
                "Працюйте над собою і ростіть щодня."
            };
        }

        private void BTLevelOne_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"F:\VS prj\Construction\Laba1\Laba1\video\Bella Ciao - ORIGINALE.mp4";
            Uri uri = new Uri(filePath);

            AFabric Level1 = new Level1();
            AVideoAndSound videoAndSoundLevel1 = Level1.createVideoAndSound();
            videoAndSoundLevel1.Answers = Answers;
            videoAndSoundLevel1.mediaElement = MediaPlayer;
            videoAndSoundLevel1.mediaElement.Source = uri;
            videoAndSoundLevel1.Play();

            AController ControllerLevel1 = Level1.createController(videoAndSoundLevel1, Window,(Button)sender);
            ControllerLevel1.GenerateButtons();

            APlayer PlayerLevel1 = Level1.createPlayer(motivationalPhrases);
            PlayerLevel1.RandomPhrases = motivationalPhrases;
            PlayerLevel1.Play();
        }
        private void BTLevelTwo_OnClick(object sender, RoutedEventArgs e)
        {
            string filePath = @"F:\VS prj\Construction\Laba1\Laba1\video\L'italiano - Toto Cutugno Video Ufficiale.mp4";
            Uri uri = new Uri(filePath);

            AFabric Level2 = new Level2();
            AVideoAndSound videoAndSoundLevel2 = Level2.createVideoAndSound();
            videoAndSoundLevel2.Answers = Answers;
            videoAndSoundLevel2.mediaElement = MediaPlayer;
            videoAndSoundLevel2.mediaElement.Source = uri;
            videoAndSoundLevel2.Play();

            AController ControllerLevel2 = Level2.createController(videoAndSoundLevel2, Window, (Button)sender);
            ControllerLevel2.GenerateButtons();

            APlayer PlayerLevel2 = Level2.createPlayer(motivationalPhrases);
            PlayerLevel2.RandomPhrases = motivationalPhrases;
            PlayerLevel2.Play();
        }
        private void BTLevelThree_OnClick(object sender, RoutedEventArgs e)
        {
            string filePath = @"F:\VS prj\Construction\Laba1\Laba1\video\Los Del Rio - Macarena (Bayside Boys Remix).mp4";
            Uri uri = new Uri(filePath);

            AFabric Level3 = new Level3();
            AVideoAndSound videoAndSoundLevel3 = Level3.createVideoAndSound();
            videoAndSoundLevel3.Answers = Answers;
            videoAndSoundLevel3.mediaElement = MediaPlayer;
            videoAndSoundLevel3.mediaElement.Source = uri;
            videoAndSoundLevel3.Play();

            AController ControllerLevel3 = Level3.createController(videoAndSoundLevel3, Window, (Button)sender);
            ControllerLevel3.GenerateButtons();

            APlayer PlayerLevel3 = Level3.createPlayer(motivationalPhrases);
            PlayerLevel3.RandomPhrases = motivationalPhrases;
            PlayerLevel3.Play();
        }
        private void BTRestart_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var VARIABLE in Window.GridButtons.Children)
            {
                if (VARIABLE is Button)
                {
                    ((Button)VARIABLE).Foreground = Brushes.Black;
                    ((Button)VARIABLE).IsEnabled = true;
                }
            }
        }
    }
}
