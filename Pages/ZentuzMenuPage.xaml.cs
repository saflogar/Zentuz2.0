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
using Microsoft.Kinect;
using Beginning.Kinect.Framework.Controls;
using System.Diagnostics;


namespace Zentuz.Page
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ZentuzMenuPage : UserControl
    {


        // private Skeleton _mainSkeleton;

        public ZentuzMenuPage()
        {
            InitializeComponent();
           
        }




        //private void KinectDevice_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        //{
        //    using (SkeletonFrame frame = e.OpenSkeletonFrame())
        //    {
        //        if (frame != null)
        //        {
        //            frame.CopySkeletonDataTo(this._FrameSkeletons);
        //            Skeleton _mainSkeleton = GetPrimarySkeleton(this._FrameSkeletons);
        //            if (_mainSkeleton == null)
        //            {
        //            }
        //            else
        //            {
        //                //Trace.WriteLine("Main Skeleton Detected");

        //                TrackHand(_mainSkeleton.Joints[JointType.HandRight], this.LeftHand);
        //                TrackHand(_mainSkeleton.Joints[JointType.HandLeft], this.RightHand);
        //                BoxSelected(_mainSkeleton.Joints[JointType.HandRight], this.LeftHand);
        //                /* if (BoxSelected(_mainSkeleton.Joints[JointType.HandRight],this.LeftHand))
        //                 {

        //                     MessageBoxResult result = MessageBox.Show("Jugando","test",MessageBoxButton.YesNo,MessageBoxImage.Asterisk);
        //                 }*/
        //            }
        //        }

        //    }
        //}

        //private Point GetPoint(Joint joint, Size containerSize)
        //{
        //    DepthImagePoint point = KinectDevice.MapSkeletonPointToDepth(joint.Position, KinectDevice.DepthStream.Format);
        //    point.X = (int)(point.X * containerSize.Width / KinectDevice.DepthStream.FrameWidth);
        //    point.Y = (int)(point.Y * containerSize.Height / KinectDevice.DepthStream.FrameHeight);
        //    return new Point(point.X, point.Y);
        //}

        //private void BoxSelected(Joint joint, FrameworkElement element)
        //{ /* 
        //    // Trace.WriteLine("Hand.X = "+ joint.Position.X+ "Hand.Y"+ joint.Position.Y);
        //    Point relPoint = LayoutRoot.TranslatePoint(GetPoint(joint, LayoutRoot.RenderSize), playButton);

        //    Trace.WriteLine("Relative to Play Button = X:" + relPoint.X + "Y:" + relPoint.Y);
        //    //this.playButton.InputHitTest(relPoint);
        //  if (this.playButton.InputHitTest(relPoint) != null)
        //    {

        //        Trace.WriteLine("PLAY BUTTON CLICKED");
        //        this.Content = null;
                
        //        //      return true;
        //    }*/
        //    // else return false;

        //}


        //private void TrackHand(Joint hand, FrameworkElement element)
        //{

        //    if (hand.TrackingState == JointTrackingState.NotTracked)
        //    {
        //        element.Visibility = Visibility.Collapsed;

        //    }
        //    else
        //    {


        //        element.Visibility = Visibility.Visible;
        //        Point point = GetPoint(hand, LayoutRoot.RenderSize);

        //        Canvas.SetLeft(element, point.X);
        //        Canvas.SetTop(element, point.Y);
        //    }

        //}

        //private static Skeleton GetPrimarySkeleton(Skeleton[] skeletons)
        //{
        //    Skeleton skeleton = null;

        //    if (skeletons != null)
        //    {
        //        for (int i = 0; i < skeletons.Length; i++)
        //        {
        //            if (skeletons[i].TrackingState == SkeletonTrackingState.Tracked)
        //            {
        //                if (skeleton == null)
        //                {
        //                    skeleton = skeletons[i];
        //                }

        //                else
        //                {
        //                    if (skeleton.Position.Z > skeletons[i].Position.Z)
        //                    {
        //                        skeleton = skeletons[i];
        //                    }
        //                }
        //            }


        //        }

        //    }
        //    return skeleton;
        //}




 

        private void HoverButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Beginning.Kinect.Framework.Controls.KinectButton;
           ((MainWindow)Application.Current.MainWindow).ContentArea.Content= Pages.ScorePage;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Beginning.Kinect.Framework.Controls.KinectButton;
            Environment.Exit(0);
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {

            ((MainWindow)Application.Current.MainWindow).ContentArea.Content = Pages.MathGamePage;
        }


     

     

    }
}

