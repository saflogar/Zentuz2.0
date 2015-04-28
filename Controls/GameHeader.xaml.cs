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
        
        public GameHeader()
        {
            InitializeComponent();
            this.txtLives.Text = GeneralConf.LiveNumb.ToString();
            this.txtScore.Text = GeneralConf.GamePoints.ToString();
            this._LevelsLeft = GeneralConf.NumbOfLevels;
            _Timer = new DispatcherTimer();
            _Timer.Tick += new EventHandler(_Timer_Tick);   
            _Timer.Interval = new TimeSpan(0, 0, 1);
            _Timer.Start();
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
            this.txtLives.Text = GeneralConf.LiveNumb.ToString();
            this.txtScore.Text = GeneralConf.GamePoints.ToString();
            this._LevelsLeft = GeneralConf.NumbOfLevels;
            if (int.Parse(this.txtLives.Text) <= 0)
            {
                this.OnLivesEnded(this , new EventArgs());
            }
            if (this._LevelsLeft <= 0)
            {
                this.OnLevelsEnded(this, new EventArgs());
            }

        }

    }
}
