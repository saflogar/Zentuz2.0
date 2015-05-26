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

namespace Zentuz.Page
{
    /// <summary>
    /// Interaction logic for BaseGamePage.xaml
    /// </summary>
    public partial class BaseGamePage : UserControl
    {

        //GAME EVENTS
        public event EventHandler LiveLosed;
        public event EventHandler OnAnsweredCorrect;

        private int _TryNumb;
        private const int _VALIDNUMBOFTRYS = 2;
        public BaseGamePage()
        {
            InitializeComponent();
        }

        public virtual void InitGame() 
        {
        
        }


    }
}
