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
            pausedMenu1.IsHitTestVisible = false;
            pausedMenu1.btnMainMenu.IsHitTestVisible = false;
            Beginning.Kinect.Framework.KinectCursorManager.Instance.WaveGestureDetected += new EventHandler(Instance_WaveGestureDetected);
        }

        void Instance_WaveGestureDetected(object sender, EventArgs e)
        {
            if (this.pausedMenu1.Visibility == Visibility.Visible)
            {
                this.pausedMenu1.Visibility = Visibility.Hidden;
            }
            else if (this.pausedMenu1.Visibility == Visibility.Hidden)
            {
                this.pausedMenu1.Visibility = Visibility.Visible;
            }
        }



  

    }
}
