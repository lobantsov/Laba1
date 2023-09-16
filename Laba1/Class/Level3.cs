﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using Timer = System.Timers.Timer;

namespace Laba1.Class
{
    public class VideoAndSound3 : AVideoAndSound
    {
        private MediaElement MediaElement;
        private List<string> Answers;

        public override void Play()
        {
            mediaElement.Visibility = Visibility.Visible;
            mediaElement.Volume = 0.1;
            mediaElement.Play();
        }
    }

    public class Player3 : APlayer
    {
        public List<string> RandomPhrases;

        public override void Play()
        {
            MessageBox.Show(RandomPhrases[new Random().Next(0, RandomPhrases.Count + 1)]);
        }
    }
    public class Contoller3 : AController
    {
        public AVideoAndSound Sound;
        Button[] buttons = new Button[4];
        public MainWindow window;
        public bool corect = true;
        public Button LevelButton;
        override public void CheckAnswers(string CorectAnswer, string UserAnswer)
        {
            int Children = window.GridButto.Children.Count;
            for (int i = 0; i < Children; i++)
            {
                window.GridButto.Children.RemoveAt(0);
            }
            if (CorectAnswer == UserAnswer && corect)
            {
                LevelButton.Foreground = Brushes.Green;
            }
            else
            {
                LevelButton.Foreground = Brushes.Red;
                corect = false;
            }
            LevelButton.IsEnabled = false;
            Sound.mediaElement.Stop();
            Sound.mediaElement.Visibility = Visibility.Hidden;
        }

        override public void GenerateButtons()
        {
            int[] number;
            number = GenerateRandomNumbers().ToArray();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Content = Sound.Answers[number[i]];
                buttons[i].Click += BT_Click;
                buttons[i].Tag = 1;

                Grid.SetRow(buttons[i], i / 2);
                Grid.SetColumn(buttons[i], i % 2);
                buttons[i].Click += BT_Click;
                window.GridButto.Children.Add(buttons[i]);
            }

            List<int> GenerateRandomNumbers()
            {
                List<int> numbers = new List<int>();
                while (numbers.Count < 3)
                {
                    int numb = new Random().Next(3, 11);
                    if (!numbers.Contains(numb))
                    {
                        numbers.Add(numb);
                    }
                }
                numbers.Insert(new Random().Next(0, 4), 2);

                return numbers;
            }
        }

        private void BT_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswers(Sound.Answers[2], ((Button)sender).Content.ToString());
        }
    }

    public class Level3 : AFabric
    {
        public override AController createController(AVideoAndSound DataAboutSound, MainWindow w, Button levelButton)
        {
            Contoller3 c = new Contoller3();
            c.window = w;
            c.Sound = DataAboutSound;
            c.LevelButton = levelButton;
            return c;
        }

        public override APlayer createPlayer(List<string> motivationalPhrases)
        {
            Player3 player3 = new Player3();
            player3.RandomPhrases = motivationalPhrases;
            return player3;
        }

        public override AVideoAndSound createVideoAndSound()
        {
            return new VideoAndSound3();
        }
    }

}
