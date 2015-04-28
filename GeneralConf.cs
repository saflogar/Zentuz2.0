using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zentuz
{
    public static class GeneralConf
    {
        private static int _GamePoints;

        public static int GamePoints
        {
            get { return _GamePoints; }
            set { _GamePoints = value; }
        }

        private static int _LiveNumb;

        public static int LiveNumb
        {
            get { return _LiveNumb; }
            set { _LiveNumb = value; }
        }

        private static int _TimeLeft;

        public static int TimeLeft
        {
            get { return _TimeLeft; }
            set { _TimeLeft = value; }
        }

        private static int _NumbOfLevels;

        public static int NumbOfLevels
        {
            get { return _NumbOfLevels; }
            set { _NumbOfLevels = value; }
        }

        private static System.Media.SoundPlayer _WrongAnsSound;

        public static System.Media.SoundPlayer WrongAnsSound
        {
            get 
            { 
                if (_WrongAnsSound == null)
                {
                    _WrongAnsSound = new System.Media.SoundPlayer(Resources.WrongAnsSound1);
                }
                return _WrongAnsSound;
            }
          
        }

        private static System.Media.SoundPlayer _CorrectAnsSound;

        public static System.Media.SoundPlayer CorrectAnsSound
        {
            get
            {
                if (_CorrectAnsSound == null)
                {
                    _CorrectAnsSound = new System.Media.SoundPlayer(Resources.CorrectAnsSound);
                }
                return _CorrectAnsSound;
            }
         
        }
        
        
        

     /*   private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }*/
        
        
        
        
        
    }
}
