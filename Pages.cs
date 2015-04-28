using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Zentuz.Page;

namespace Zentuz
{
    public static class Pages
    {
        private  static ZentuzMenuPage _MenuPage;
        private static ScoresPage _ScorePage;
        private static MathGamePage _MathGamePage;
        private static GamePage _GamePage;
        
        

        public static ZentuzMenuPage MenuPage
        {
            get
            {
                if (_MenuPage == null)
                    _MenuPage = new ZentuzMenuPage();
                return _MenuPage;
            }
        }

        public static ScoresPage ScorePage 
        {
            get
            {
                if (_ScorePage == null)
                    _ScorePage = new ScoresPage();
                return _ScorePage;
            }
        
        }

        public static MathGamePage MathGamePage
        {
            get
            {
                if (_MathGamePage == null)
                    _MathGamePage = new MathGamePage();
                return _MathGamePage;
            }

        }

        public static GamePage GamePage
        {
            get
            {
                if (_GamePage == null)
                {
                    _GamePage = new GamePage();
                }
                return _GamePage;
            }
        }
         
    }
}
