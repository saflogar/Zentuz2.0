using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zentuz.Control;

namespace Zentuz.Page
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : UserControl
    {
        
        public GamePage()
        {
            InitializeComponent();
            ResetGame();
            //GESTURE EVENTS
            Beginning.Kinect.Framework.KinectCursorManager.Instance.WaveGestureDetected += new EventHandler(Instance_WaveGestureDetected);
            //GAME HEADER EVENTS
            this.gameHeader1.OnLevelsEnded += new EventHandler(gameHeader1_OnLevelsEnded);
            this.gameHeader1.OnLivesEnded += new EventHandler(gameHeader1_OnLivesEnded);
            this.gameHeader1.OnTimeFinished += new EventHandler(gameHeader1_OnTimeFinished);
            //GAME EVENTS
            this.mathGamePage1.LiveLosed += new EventHandler(mathGamePage1_LiveLosed);
            this.mathGamePage1.OnAnsweredCorrect += new EventHandler(mathGamePage1_OnAnsweredCorrect);
            //PAUSE MENU EVENTS
            this.pausedMenu1.btnMainMenu.Click += new RoutedEventHandler(btnMainMenu_Click);
      /*      pausedMenu1.IsHitTestVisible = false;
            pausedMenu1.btnMainMenu.IsHitTestVisible = false;
            this.pausedMenu1.lblMessage.IsHitTestVisible = false;
            //GESTURE EVENTS
            Beginning.Kinect.Framework.KinectCursorManager.Instance.WaveGestureDetected += new EventHandler(Instance_WaveGestureDetected);
            //GAME HEADER EVENTS
            this.gameHeader1.OnLevelsEnded += new EventHandler(gameHeader1_OnLevelsEnded);
            this.gameHeader1.OnLivesEnded += new EventHandler(gameHeader1_OnLivesEnded);
            this.gameHeader1.OnTimeFinished += new EventHandler(gameHeader1_OnTimeFinished);
            //GAME EVENTS
            this.mathGamePage1.LiveLosed += new EventHandler(mathGamePage1_LiveLosed);
            this.mathGamePage1.OnAnsweredCorrect += new EventHandler(mathGamePage1_OnAnsweredCorrect);
            //PAUSE MENU EVENTS
            this.pausedMenu1.btnMainMenu.Click += new RoutedEventHandler(btnMainMenu_Click);
            //GENERAL SETTINGS
            GeneralConf.TimeLeft = 120;
            GeneralConf.LiveNumb = 3;
            GeneralConf.NumbOfLevels = 5;
            this.gameHeader1.RefreshComponents();*/
        }

        void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ContentArea.Content = Pages.MenuPage;
        }

        void mathGamePage1_OnAnsweredCorrect(object sender, EventArgs e)
        {
            GeneralConf.GamePoints++;
            GeneralConf.NumbOfLevels--;
            this.gameHeader1.RefreshComponents();
        }

        void mathGamePage1_LiveLosed(object sender, EventArgs e)
        {
            GeneralConf.LiveNumb--;
            this.gameHeader1.RefreshComponents();
        }

        void gameHeader1_OnTimeFinished(object sender, EventArgs e)
        {
            DisplayMenu("Time is over");
            Beginning.Kinect.Framework.KinectCursorManager.Instance.WaveGestureDetected -= Instance_WaveGestureDetected;
            
        }

        void gameHeader1_OnLivesEnded(object sender, EventArgs e)
        {
            DisplayMenu("Game Over");
            Beginning.Kinect.Framework.KinectCursorManager.Instance.WaveGestureDetected -= Instance_WaveGestureDetected;
            
        }

        void gameHeader1_OnLevelsEnded(object sender, EventArgs e)
        {
            DisplayMenu("Congratulations");
            Beginning.Kinect.Framework.KinectCursorManager.Instance.WaveGestureDetected -= Instance_WaveGestureDetected;

        }

        void Instance_WaveGestureDetected(object sender, EventArgs e)
        {
            DisplayMenu("Game Paused");
        }

        private void DisplayMenu(string msg) 
        {
            this.pausedMenu1.lblMessage.Content = msg;
            if (this.pausedMenu1.Visibility == Visibility.Visible)
            {
                this.pausedMenu1.Visibility = Visibility.Hidden;
                pausedMenu1.IsHitTestVisible = false;
                pausedMenu1.btnMainMenu.IsHitTestVisible = false;
                this.pausedMenu1.lblMessage.IsHitTestVisible = false;
                
            }
            else if (this.pausedMenu1.Visibility == Visibility.Hidden)
            {
                this.pausedMenu1.Visibility = Visibility.Visible;
                pausedMenu1.IsHitTestVisible = true;
                pausedMenu1.btnMainMenu.IsHitTestVisible = true;
                this.pausedMenu1.lblMessage.IsHitTestVisible = true;
            }
        }

        public void ResetGame() 
        {
            //PAUSE MENU EVENTS
            this.pausedMenu1.btnMainMenu.Click += new RoutedEventHandler(btnMainMenu_Click);
            pausedMenu1.IsHitTestVisible = false;
            pausedMenu1.btnMainMenu.IsHitTestVisible = false;
            pausedMenu1.Visibility = Visibility.Hidden;
            this.pausedMenu1.lblMessage.IsHitTestVisible = false;
           
            //GENERAL SETTINGS
            GeneralConf.TimeLeft = 120;
            GeneralConf.LiveNumb = 3;
            GeneralConf.NumbOfLevels = 5;
            GeneralConf.GamePoints = 0;
            this.gameHeader1.RefreshComponents();
            
        }

    }
}
