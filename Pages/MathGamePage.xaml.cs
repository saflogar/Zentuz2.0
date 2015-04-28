using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
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
    /// Interaction logic for MathPage.xaml
    /// </summary>
    public partial class MathGamePage : UserControl
    {

        
        private enum Operation
        {
            multiply,sum,subtraction
        }
        
        private int _CorrectAns;
        private Operation _CurrentOp;
        private int _btnCorrectAns;
        private int _TryNumb;
        private const int _VALIDNUMBOFTRYS = 2;
        //GAME EVENTS
        public event EventHandler LiveLosed;
        public event EventHandler OnAnsweredCorrect;

        public MathGamePage()
        {
            InitializeComponent();
            InitGame();
        }

        private void InitGame() 
        {
            this._TryNumb = 0;
            Random rnd = new Random();
            this._CurrentOp = (Operation)rnd.Next(0, 3);

            //UPDATE GENERAL CONF
            

            if (this._CurrentOp.Equals(Operation.subtraction))
            {
                do
                {
                    this.lblNum1.Text = rnd.Next(1, 10).ToString();
                    this.lblNum2.Text = rnd.Next(1, 10).ToString();
                } while (int.Parse(lblNum2.Text) > int.Parse(lblNum1.Text));

            }
            else
            {
                this.lblNum1.Text = rnd.Next(1, 10).ToString();
                this.lblNum2.Text = rnd.Next(1, 10).ToString();
            }

            switch (_CurrentOp)
            {
                case Operation.multiply:
                    _CorrectAns = int.Parse(lblNum1.Text) * int.Parse(lblNum2.Text);
                    lblOper.Text = "x";
                    break;

                case Operation.sum:
                    _CorrectAns = int.Parse(lblNum1.Text) + int.Parse(lblNum2.Text);
                    lblOper.Text = "+";
                    break;
                case Operation.subtraction:
                    _CorrectAns = int.Parse(lblNum1.Text) - int.Parse(lblNum2.Text);
                    lblOper.Text = "-";
                    break;
                default:
                    throw new InvalidOperationException();
            }

            _btnCorrectAns = rnd.Next(0, 3);

            List<Button> btnArray = new List<Button>() { btnRes1, btnRes2, btnRes3, btnRes4 };

            btnArray[_btnCorrectAns].Content = _CorrectAns;
            int i = 0;
            foreach (Button btn in btnArray)
            {
                if (i.Equals(_btnCorrectAns))
                    btn.Content = _CorrectAns;
                else
                    btn.Content = rnd.Next(0, 100);
                i++;
            }

        }

        

        #region buttons_clicks
        /*
        private void btnRes1_Click(object sender, RoutedEventArgs e)
        {
            if (btnRes1.Content.Equals(_CorrectAns))
            {
                if (this.OnAnsweredCorrect != null)
                    this.OnAnsweredCorrect(this,new EventArgs());
                InitGame();
               
                
            }
            else if (_TryNumb >= (_VALIDNUMBOFTRYS ))
            {
                _TryNumb = 0;
                if (this.LiveLosed != null)
                this.LiveLosed(this,new EventArgs());
                GeneralConf.WrongAnsSound.Play();
            }
            else 
            {
                _TryNumb++;
                GeneralConf.WrongAnsSound.Play();
            }
        }

        private void btnRes3_Click(object sender, RoutedEventArgs e)
        {
            if (btnRes3.Content.Equals(_CorrectAns))
            {
                if (this.OnAnsweredCorrect != null)
                    this.OnAnsweredCorrect(this, new EventArgs());
                InitGame();
             
            }
            else if (_TryNumb >= (_VALIDNUMBOFTRYS))
            {
                GeneralConf.WrongAnsSound.Play();
                _TryNumb = 0;
                if (this.LiveLosed != null)
                this.LiveLosed(this, new EventArgs());
            }
            else
            {
                _TryNumb++;
                GeneralConf.WrongAnsSound.Play();
            }

        }

        private void btnRes4_Click(object sender, RoutedEventArgs e)
        {
            if (btnRes4.Content.Equals(_CorrectAns))
            {
                if (this.OnAnsweredCorrect != null)
                    this.OnAnsweredCorrect(this, new EventArgs());
                InitGame();
                
            }
            else if (_TryNumb >= (_VALIDNUMBOFTRYS))
            {
                GeneralConf.WrongAnsSound.Play();
                _TryNumb = 0;
                if (this.LiveLosed!= null)
                this.LiveLosed(this, new EventArgs());
              
            }
            else
            {
                _TryNumb++;
                GeneralConf.WrongAnsSound.Play();
            }
        }

        private void btnRes2_Click(object sender, RoutedEventArgs e)
        {
            
            if (btnRes2.Content.Equals(_CorrectAns))
            {
                if (this.OnAnsweredCorrect != null)
                    this.OnAnsweredCorrect(this, new EventArgs());
                InitGame();
            
            }
            else if (_TryNumb >= (_VALIDNUMBOFTRYS))
            {
                GeneralConf.WrongAnsSound.Play();
                _TryNumb = 0;
                if (this.LiveLosed != null)
                this.LiveLosed(this, new EventArgs());
                
            }
            else
            {
                _TryNumb++;
                GeneralConf.WrongAnsSound.Play();
            }
        }*/
        #endregion buttons_clicks   

        private void btn_click(object sender, RoutedEventArgs e) 
        {
            Button button = (Button)e.Source;
            if (button.Content.Equals(_CorrectAns))
            {
                GeneralConf.CorrectAnsSound.Play();
                if (this.OnAnsweredCorrect != null)
                    this.OnAnsweredCorrect(this, new EventArgs());
                InitGame();

            }
            else if (_TryNumb >= (_VALIDNUMBOFTRYS))
            {
                GeneralConf.WrongAnsSound.Play();
                _TryNumb = 0;
                if (this.LiveLosed != null)
                    this.LiveLosed(this, new EventArgs());

            }
            else
            {
                _TryNumb++;
                GeneralConf.WrongAnsSound.Play();
            }
        }

  
    }
}
