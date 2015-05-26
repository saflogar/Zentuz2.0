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
using System.Windows.Threading;
using System.Timers;

namespace Zentuz.Controls
{
    
    /// <summary>
    /// Interaction logic for GameHeader.xaml
    /// </summary>
    public partial class GameHeader : UserControl
    {
        
        private DispatcherTimer _Timer;
        private int _LevelsLeft;
        //EVENTS
        public event EventHandler OnTimeFinished;
        public event EventHandler OnLivesEnded;
        public event EventHandler OnLevelsEnded;
        
        public class Cow
        {
            //TODO- CowAnimation
            Canvas cnv;
          
            public Cow(Canvas cnv) 
            {
                this.cnv = cnv;
                Image cowImg = new Image();
                cowImg.Source =  new BitmapImage(new Uri("C:\\Users\\Sergio\\Documents\\Visual Studio 2010\\Projects\\Zentuz\\Images\\cow.med"));
                cowImg.Width = 40;
                cowImg.Height = 20;
                cowImg.Stretch = Stretch.Fill;
                cnv.Children.Add(cowImg);
            }

          


        }

        public GameHeader()
        {
            InitializeComponent();
          
            this.txtScore.Text = GeneralConf.GamePoints.ToString();
            this._LevelsLeft = GeneralConf.NumbOfLevels;
            _Timer = new DispatcherTimer();
            _Timer.Tick += new EventHandler(_Timer_Tick);   
            _Timer.Interval = new TimeSpan(0, 0, 1);
            _Timer.Start();
            heartStack.Orientation = Orientation.Horizontal;
            refreshHearts();
        //    Cow cowAnim = new Cow(this.cnvAnimation);
        }

        private void _Timer_Tick(object sender, EventArgs e)
        {
            if (GeneralConf.TimeLeft > 0)
            {
                GeneralConf.TimeLeft--;
                txTime.Text = GeneralConf.TimeLeft.ToString();

            }
            else
            {
                _Timer.Stop();
                this.OnTimeFinished(this,new EventArgs());
            }
               
        }

        public void RefreshComponents() 
        {
            this.txtScore.Text = GeneralConf.GamePoints.ToString();
            this._LevelsLeft = GeneralConf.NumbOfLevels;
            refreshHearts();
            if (this.heartStack.Children.Count <= 0)
            {
                this.OnLivesEnded(this , new EventArgs());
            }
            if (this._LevelsLeft <= 0)
            {
                this.OnLevelsEnded(this, new EventArgs());
            }

        }

        private void refreshHearts() 
        {
            heartStack.Children.Clear();
            for (int i = 0; i < GeneralConf.LiveNumb; i++)
            {
                Image heartImage = new Image();
                heartImage.Source = new BitmapImage(new Uri("C:\\Users\\Sergio\\Documents\\Visual Studio 2010\\Projects\\Zentuz\\Images\\heart.png"));
                heartImage.Width = 60;
                heartImage.Stretch = Stretch.Fill;
                heartStack.Children.Add(heartImage);
            }
        }

        

    }
}
