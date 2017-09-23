using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Linq;

namespace WPL_Blind_Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int timeRemaining = 1200;
        public int blindLevel = 1;

        private static System.Timers.Timer aTimer;
        private static SoundPlayer levelUpSound;

        public MainWindow()
        {
            InitializeComponent();

            TimeSpan result = TimeSpan.FromSeconds(timeRemaining);

            timerCountdown.Text = result.ToString(@"mm\:ss");

            ////  Retrieves next blind level
            NextLevel();
        }


        /// <summary>
        ///   Action upon clicking the play button
        /// </summary>
        public void PlayButton(object sender, RoutedEventArgs e)
        {
            if (timerCountdown.Text != "Chip Up")
            {
                TimerCount();
            }
            else if (timerCountdown.Text == "Chip Up")
            {
                blindLevel = blindLevel + 1;
                NextLevel();
                TimerCount();
            }
        }


        /// <summary>
        ///   Action upon clicking the pause button
        /// </summary>
        public void PauseButton(object sender, RoutedEventArgs e)
        {
            aTimer.Stop();
        }




        /// <summary>
        ///   Action upon clicking the replay button.  This starts the current blind over.
        /// </summary>
        public void ReplayButton(object sender, RoutedEventArgs e)
        {
            if (timerCountdown.Text != "Chip Up")
            {
                timeRemaining = 1200;

                TimeSpan result = TimeSpan.FromSeconds(timeRemaining);

                timerCountdown.Text = result.ToString(@"mm\:ss");
            }
        }




        /// <summary>
        ///   Action upon clicking the plus button adds one minute to the clock
        /// </summary>
        public void PlusButton(object sender, RoutedEventArgs e)
        {
            if (timeRemaining <= 1140)
            {
                timeRemaining = timeRemaining + 60;
            }
            else if (timeRemaining < 1200 && timeRemaining > 1140)
            {
                timeRemaining = 1200;
            }
        }




        /// <summary>
        ///   Action upon clicking the minus button removes one minute to the clock
        /// </summary>
        public void MinusButton(object sender, RoutedEventArgs e)
        {
            if (timeRemaining >= 60)
            {
                timeRemaining = timeRemaining - 60;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("There is less than 1 minute remaining.");
            }
        }




        /// <summary>
        ///   Action upon clicking the next button skipping the blind and moving to the next level
        /// </summary>
        public void NextButton(object sender, RoutedEventArgs e)
        {
            blindLevel = blindLevel + 1;
            NextLevel();
            timeRemaining = 1200;
        }




        /// <summary>
        ///   Action upon clicking the back button rewinding the blind level to an earlier blind
        /// </summary>
        public void BackButton(object sender, RoutedEventArgs e)
        {
            blindLevel = blindLevel - 1;
            NextLevel();
            timeRemaining = 1200;
        }




        private void TimerCount()
        {
            
            // Create a timer with a five millisecond interval.
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;

            // Hook up the Elapsed event for the timer. 
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }





        /// <summary>
        ///   Action upon the timer running out.  Moves the blind to the next level, and alerts the need to chip up based on blind level
        /// </summary>
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (timeRemaining != 0)
            {
                timeRemaining = timeRemaining - 1;
                TimeSpan result = TimeSpan.FromSeconds(timeRemaining);

                timerCountdown.Dispatcher.BeginInvoke((Action)(() => timerCountdown.Text = result.ToString(@"mm\:ss")));

                SendKeys.SendWait("{UP}");
            }
            else if (timeRemaining == 0)
            {
                blindLevel = blindLevel + 1;
                if (blindLevel <= 11)
                {
                    timeRemaining = 1200;
                    NextLevel();
                }
                else if (blindLevel == 12)
                {
                    aTimer.Stop();
                }
            }
        }




        /// <summary>
        ///   Action taken on start and when the timer runs out.  Verifies the current blind and moves to the next applicable blind level
        /// </summary>
        private void NextLevel()
        {
            levelUpSound = new SoundPlayer(@"C:\Windows\Media\Triangle Dinner Bell-SoundBible.com-220988408.wav");
            
            int caseSwitch = blindLevel;
            switch (caseSwitch)
            {
                case 1:
                    smallBlind.Dispatcher.BeginInvoke((Action)(() => smallBlind.Text = "5"));
                    bigBlind.Dispatcher.BeginInvoke((Action)(() => bigBlind.Text = "10"));
                    break;
                case 2:
                    levelUpSound.Play();
                    smallBlind.Dispatcher.BeginInvoke((Action)(() => smallBlind.Text = "10"));
                    bigBlind.Dispatcher.BeginInvoke((Action)(() => bigBlind.Text = "20"));
                    break;
                case 3:
                    levelUpSound.Play();
                    smallBlind.Dispatcher.BeginInvoke((Action)(() => smallBlind.Text = "20"));
                    bigBlind.Dispatcher.BeginInvoke((Action)(() => bigBlind.Text = "40"));
                    break;
                case 4:
                    levelUpSound.Play();
                    aTimer.Stop();
                    timerCountdown.Dispatcher.BeginInvoke((Action)(() => timerCountdown.Text = "Chip Up"));
                    break;
                case 5:
                    smallBlind.Dispatcher.BeginInvoke((Action)(() => smallBlind.Text = "25"));
                    bigBlind.Dispatcher.BeginInvoke((Action)(() => bigBlind.Text = "50"));
                    break;
                case 6:
                    levelUpSound.Play();
                    smallBlind.Dispatcher.BeginInvoke((Action)(() => smallBlind.Text = "50"));
                    bigBlind.Dispatcher.BeginInvoke((Action)(() => bigBlind.Text = "100"));
                    break;
                case 7:
                    levelUpSound.Play();
                    smallBlind.Dispatcher.BeginInvoke((Action)(() => smallBlind.Text = "75"));
                    bigBlind.Dispatcher.BeginInvoke((Action)(() => bigBlind.Text = "150"));
                    break;
                case 8:
                    levelUpSound.Play();
                    aTimer.Stop();
                    timerCountdown.Dispatcher.BeginInvoke((Action)(() => timerCountdown.Text = "Chip Up"));
                    break;
                case 9:
                    smallBlind.Dispatcher.BeginInvoke((Action)(() => smallBlind.Text = "100"));
                    bigBlind.Dispatcher.BeginInvoke((Action)(() => bigBlind.Text = "200"));
                    break;
                case 10:
                    levelUpSound.Play();
                    smallBlind.Dispatcher.BeginInvoke((Action)(() => smallBlind.Text = "200"));
                    bigBlind.Dispatcher.BeginInvoke((Action)(() => bigBlind.Text = "400"));
                    break;
                case 11:
                    levelUpSound.Play();
                    smallBlind.Dispatcher.BeginInvoke((Action)(() => smallBlind.Text = "400"));
                    bigBlind.Dispatcher.BeginInvoke((Action)(() => bigBlind.Text = "800"));
                    break;
                case 12:
                    levelUpSound.Play();
                    smallBlind.Dispatcher.BeginInvoke((Action)(() => smallBlind.Text = "800"));
                    bigBlind.Dispatcher.BeginInvoke((Action)(() => bigBlind.Text = "1600"));
                    break;
            }
        }
    }
}
