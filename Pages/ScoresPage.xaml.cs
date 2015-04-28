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
    /// Interaction logic for ScoresPage.xaml
    /// </summary>
    public partial class ScoresPage : UserControl
    {
        public ScoresPage()
        {
            InitializeComponent();

        }

        private void SkeletonViewerElement_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnReturn_click(object sender, RoutedEventArgs e)
        {
           ((MainWindow)Application.Current.MainWindow).ContentArea.Content = Pages.MenuPage;
        }
    }
}
