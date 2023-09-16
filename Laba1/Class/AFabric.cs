using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laba1.Class
{
    abstract public class AVideoAndSound
    {
        public MediaElement mediaElement;
        public List<string> Answers;
        abstract public void Play();
    }

    abstract public class APlayer
    {
        public List<string> RandomPhrases;
        abstract public void Play();
    }

    abstract public class AController
    {
        public AVideoAndSound Sound;
        public bool corect;
        public Button LevelButton;
        abstract public void CheckAnswers(string CorectAnswer, string UserAnswer);
        abstract public void GenerateButtons();
    }
    abstract public class AFabric
    {
        abstract public AVideoAndSound createVideoAndSound();
        abstract public APlayer createPlayer(List<string> motivationalPhrases);
        abstract public AController createController(AVideoAndSound DataAboutSound, MainWindow window, Button levelButton);
    }
}
