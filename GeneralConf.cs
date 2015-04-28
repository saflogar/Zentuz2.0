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
        
        
        
        
    }
}
