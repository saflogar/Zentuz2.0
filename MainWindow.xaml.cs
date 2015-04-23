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
using System.Diagnostics;


namespace Zentuz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static event bool GameButtonSelected;

        private KinectSensor _KinectDevice;
        private Skeleton[] _FrameSkeletons;
     

        public MainWindow()
        {
            InitializeComponent();
            KinectSensor.KinectSensors.StatusChanged += KinectSensors_StatusChanged;
            this.KinectDevice = KinectSensor.KinectSensors.FirstOrDefault(x => x.Status == KinectStatus.Connected);
            this.ContentArea.Content = Pages.MenuPage;
        }

        private void KinectSensors_StatusChanged(Object sender, StatusChangedEventArgs e)
        {
            switch (e.Status) { }

        }
        public KinectSensor KinectDevice
        {
            get { return this._KinectDevice; }
            set
            {
                if (this._KinectDevice != value)
                {
                    //Uninitialize
                    if (this._KinectDevice != null)
                    {
                        this._KinectDevice.Stop();
                        //  this._KinectDevice.SkeletonFrameReady -= KinectDevice_SkeletonFrameReady;
                        this._KinectDevice.SkeletonStream.Disable();
                        SkeletonViewerElement.KinectDevice = null;
                        this._FrameSkeletons = null;
                    }

                    this._KinectDevice = value;

                    //Initialize
                    if (this._KinectDevice != null)
                    {
                        if (this._KinectDevice.Status == KinectStatus.Connected)
                        {
                            this._KinectDevice.SkeletonStream.Enable();
                            this._FrameSkeletons = new Skeleton[this._KinectDevice.SkeletonStream.FrameSkeletonArrayLength];

                            this._KinectDevice.Start();

                            SkeletonViewerElement.KinectDevice = this.KinectDevice;
                            // this.KinectDevice.SkeletonFrameReady += KinectDevice_SkeletonFrameReady;
                        }
                    }
                }
            }
        }


    }
    }

