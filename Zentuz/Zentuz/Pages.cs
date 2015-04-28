using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Zentuz
{
    public static class Pages
    {
        private  static ZentuzMenuPage _first;
        private static GamePage _second;
        
        

        public static Page MenuPage
        {
            get
            {
                if (_first == null)
                    _first = new ZentuzMenuPage();
                return _first;
            }
        }

        public static GamePage GamePage 
        {
            get 
            {
                if(_second == null)
                {
                    _second = new GamePage();
                }
                return _second;
            }
        }
        // ...
    }
}
