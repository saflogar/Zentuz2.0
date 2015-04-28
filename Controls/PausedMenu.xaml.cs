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

namespace Zentuz.Control
{
    /// <summary>
    /// Interaction logic for PausedMenu.xaml
    /// </summary>
    public partial class PausedMenu : UserControl
    {
        public PausedMenu()
        {
            InitializeComponent();
            txtScore.Text = Zentuz.GeneralConf.GamePoints.ToString();
            this.IsVisibleChanged += new DependencyPropertyChangedEventHandler(PausedMenu_IsVisibleChanged);
        }

        void PausedMenu_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
            txtScore.Text = Zentuz.GeneralConf.GamePoints.ToString();
        }
    }
}
