using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

        
    {
        String mainString;
        float wrdPerMin;
        int spaceCount = 0;
        long milliSecondCount;
        const int second = 60000;
        Stopwatch s = new Stopwatch();
        string catcherString = "";
        char[] charArray;
        char showChar;
        bool typing = false;
        int charNum = 0;
        int typeCount = 0;
        public MainWindow()
        {
            InitializeComponent();

        }


        //For Top Level
        private void Top_level1(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/TopLevel1.unique";
            FileSelection(filePath);
            ResetSelection('t');

        }

        private void Top_level2(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/TopLevel2.unique";
            FileSelection(filePath);
            ResetSelection('t');
        }

        private void Top_level3(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/TopLevel3.unique";
            FileSelection(filePath);
            ResetSelection('t');
        }

        //For Mid Level
        private void Mid_level1(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/MidLevel1.unique";
            FileSelection(filePath);
            ResetSelection('m');
        }

        private void Mid_level2(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/MidLevel2.unique";
            FileSelection(filePath);
            ResetSelection('m');
        }

        private void Mid_level3(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/MidLevel3.unique";
            FileSelection(filePath);
            ResetSelection('m');
        }

        //For Bottom Level
        private void Bottom_level1(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/BottomLevel1.unique";
            FileSelection(filePath);
            ResetSelection('b');

        }

        private void Bottom_level2(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/BottomLevel2.unique";
            FileSelection(filePath);
            ResetSelection('b');
        }

        private void Bottom_level3(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/BottomLevel3.unique";
            FileSelection(filePath);
            ResetSelection('b');
        }

        //For All Level
        private void All_level1(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/AllLevel1.unique";
            FileSelection(filePath);
            ResetSelection('a');

        }

        private void All_level2(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/AllLevel2.unique";
            FileSelection(filePath);
            ResetSelection('a');
        }

        private void All_level3(object sender, RoutedEventArgs e)
        {
            String filePath = @"Data/AllLevel3.unique";
            FileSelection(filePath);
            ResetSelection('a');
        }

        //reset Selection
        private void ResetSelection(char c)
        {
            if (c.Equals('t'))
            {
                midLevel.SelectedIndex = -1;
                bottomLevel.SelectedIndex = -1;
                allLevel.SelectedIndex = -1;
            }else if (c.Equals('m'))
            {
                topLevel.SelectedIndex = -1;
                bottomLevel.SelectedIndex = -1;
                allLevel.SelectedIndex = -1;
            }else if (c.Equals('b'))
            {
                topLevel.SelectedIndex = -1;
                midLevel.SelectedIndex = -1;
                allLevel.SelectedIndex = -1;
            }else if (c.Equals('a'))
            {
                topLevel.SelectedIndex = -1;
                midLevel.SelectedIndex = -1;
                bottomLevel.SelectedIndex = -1;
            }

            

        }

        // For File selection and sending to other method
        private void FileSelection(String file)
        {
            if (System.IO.File.Exists(file))
            {
                if (typing)
                {
                    DefaultShow();
                }
                mainString = File.ReadAllText(file);
                charArray = mainString.ToCharArray();


                typing = false;
                charNum = 0;
                typeCount = 0;
                thrower.Text = "";
                catcher.Text = "";
                catcherString = "";
                HintShow(charArray[typeCount]);



                SetShowString();
                s.Start();
            }
            else
            {
                thrower.Text = "Codec File Missing";
                catcher.Text = "Please Contact to the Developer.";
            }
        }

        private void Windows_KeyUp(object sender, KeyEventArgs e)
        {
            // For normaalize text when shift button is released
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                if (Console.CapsLock)
                {
                    CapitalizeText(true);
                }
                else
                {
                    CapitalizeText(false);
                }
                DefaultStyle(shift1);
                DefaultStyle(shift2);
            }
            /*
            // for doing default show after click up the key
            DefaultShow();*/

            //for fix bug when start up lunch and key press
            if (typing)
            {
                // for fixing bug when text gone empty and showing hint 
                if (typeCount != mainString.Length)
                {
                    HintShow(charArray[typeCount]);
                }
            }
            
        }

        private void Windows_KeyDown(object sender, KeyEventArgs e)
        {
            // for turning on and off when capsLock button pressed
            if(e.Key == Key.CapsLock)
            {
                if (Console.CapsLock)
                {
                    capslock1.Content = "On\ncapslock";
                    CapitalizeText(true);

                }
                else
                {
                    capslock1.Content = "Off\ncapslock";
                    CapitalizeText(false);

                }
            }
            // for capitalize key shen shift buttons are pressed
            if(e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {

                if(Console.CapsLock)
                {
                    CapitalizeText(false);
                }
                else
                {
                    CapitalizeText(true);
                }
                shift1.FontSize = 40;
                shift2.FontSize = 40;
                shift1.Foreground = Brushes.Cyan;
                shift2.Foreground = Brushes.Cyan;
            }
            

        
        
        
        }

        // For Capitalize text method
        private void CapitalizeText(bool value)
        {
            if (value)
            {
                aButton.Content = "A";
                bButton.Content = "B";
                cButton.Content = "C";
                dButton.Content = "D";
                eButton.Content = "E";
                fButton.Content = "F";
                gButton.Content = "G";
                hButton.Content = "H";
                iButton.Content = "I";
                jButton.Content = "J";
                kButton.Content = "K";
                lButton.Content = "L";
                mButton.Content = "M";
                nButton.Content = "N";
                oButton.Content = "O";
                pButton.Content = "P";
                qButton.Content = "Q";
                rButton.Content = "R";
                sButton.Content = "S";
                tButton.Content = "T";
                uButton.Content = "U";
                vButton.Content = "V";
                wButton.Content = "W";
                xButton.Content = "X";
                yButton.Content = "Y";
                zButton.Content = "Z";
                nearly.Content = "~";
                oneButton.Content = "!";
                twoButton.Content = "@";
                threeButton.Content = "#";
                fourButton.Content = "$";
                fiveButton.Content = "%";
                sixButton.Content = "^";
                sevenButton.Content = "&";
                eightButton.Content = "*";
                nineButton.Content = "(";
                zeroButton.Content = ")";
                minusButton.Content = "_";
                plusButton.Content = "+";
                bracket1.Content = "{";
                bracket2.Content = "}";
                slash1.Content = "|";
                semiColon.Content = ":";
                invertedComma.Content = '"';
                comma.Content = "<";
                dot.Content = ">";
                slash.Content = "?";

            }
            else
            {
                aButton.Content = "a";
                bButton.Content = "b";
                cButton.Content = "c";
                dButton.Content = "d";
                eButton.Content = "e";
                fButton.Content = "f";
                gButton.Content = "g";
                hButton.Content = "h";
                iButton.Content = "i";
                jButton.Content = "j";
                kButton.Content = "k";
                lButton.Content = "l";
                mButton.Content = "m";
                nButton.Content = "n";
                oButton.Content = "o";
                pButton.Content = "p";
                qButton.Content = "q";
                rButton.Content = "r";
                sButton.Content = "s";
                tButton.Content = "t";
                uButton.Content = "u";
                vButton.Content = "v";
                wButton.Content = "w";
                xButton.Content = "x";
                yButton.Content = "y";
                zButton.Content = "z";
                nearly.Content = "`";
                oneButton.Content = "1";
                twoButton.Content = "2";
                threeButton.Content = "3";
                fourButton.Content = "4";
                fiveButton.Content = "5";
                sixButton.Content = "6";
                sevenButton.Content = "7";
                eightButton.Content = "8";
                nineButton.Content = "9";
                zeroButton.Content = "0";
                minusButton.Content = "-";
                plusButton.Content = "=";
                bracket1.Content = "[";
                bracket2.Content = "]";
                slash1.Content = "\\";
                semiColon.Content = ';';
                invertedComma.Content = "'";
                comma.Content = ",";
                dot.Content = ".";
                slash.Content = "/";
            }
        }

        //for showing text in thrower and enable typing
        private void SetShowString()
        {

            String showString = "";

            for (int i = 0; i < 40; i++)
            {

                if (charNum == mainString.Length)
                {
                    break;
                }
                showString += charArray[charNum];
                charNum ++;
                
            }
            thrower.Text = showString;
            typing = true;
            
        }

        // for checking charector when single charector is passed on it and returnin true or false
        private bool CharectorCheck(char c)
        {
            //for initializing again typing to get clean all text and variable
            if (typeCount == mainString.Length)
            {
                charNum = 0;
                typeCount = 0;
                thrower.Text = "";
                catcher.Text = "";

                SetShowString();
            }
            // charector checking start
            char charector = charArray[typeCount];
            if (typing && c.Equals(charector))
            {
                typeCount++;
                return true;

            }
            else
            {
                return false;
            }
            
        }

        private void Windows_TextInput(object sender, TextCompositionEventArgs e)
        {
            // for any other keys combination are pressed
            if(e.Text.Length == 1)
            {
                // Main work starts here
                char tempChar = Convert.ToChar(e.Text);
                ClickedShow(tempChar);
                showChar = tempChar;

                if (CharectorCheck(tempChar))
                {
                    catcherString += tempChar;
                    catcher.Text = catcherString;
                    if(tempChar.Equals(' '))
                    {
                        spaceCount++;
                        milliSecondCount = s.ElapsedMilliseconds;
                        speedCalculation();
                    }
                    // for clearing catcher box when text empty in thrower box
                    if (typeCount == charNum)
                    {
                        SetShowString();
                        catcherString = "";
                        catcher.Text = catcherString;

                    }
                }
                else
                {
                    // For playing sound
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            
            
            
        }

        // for showing when which keys press
        private void ClickedShow(char c)
        {
            switch (c)
            {
                case 'A':
                case 'a':
                    ClickStyle(aButton);
                    break;
                case 'B':
                case 'b':
                    ClickStyle(bButton);
                    break;

                case 'C':
                case 'c':
                    ClickStyle(cButton);
                    break;

                case 'D':
                case 'd':
                    ClickStyle(dButton);
                    break;

                case 'E':
                case 'e':
                    ClickStyle(eButton);
                    break;

                case 'F':
                case 'f':
                    ClickStyle(fButton);
                    break;
                case 'G':
                case 'g':
                    ClickStyle(gButton);
                    break;
                case 'H':
                case 'h':
                    ClickStyle(hButton);
                    break;
                case 'I':
                case 'i':
                    ClickStyle(iButton);
                    break;
                case 'J':
                case 'j':
                    ClickStyle(jButton);
                    break;
                case 'K':
                case 'k':
                    ClickStyle(kButton);
                    break;
                case 'L':
                case 'l':
                    ClickStyle(lButton);
                    break;
                case 'M':
                case 'm':
                    ClickStyle(mButton);
                    break;
                case 'N':
                case 'n':
                    ClickStyle(nButton);
                    break;
                case 'O':
                case 'o':
                    ClickStyle(oButton);
                    break;
                case 'P':
                case 'p':
                    ClickStyle(pButton);
                    break;
                case 'Q':
                case 'q':
                    ClickStyle(qButton);
                    break;
                case 'R':
                case 'r':
                    ClickStyle(rButton);
                    break;
                case 'S':
                case 's':
                    ClickStyle(sButton);
                    break;
                case 'T':
                case 't':
                    ClickStyle(tButton);
                    break;
                case 'U':
                case 'u':
                    ClickStyle(uButton);
                    break;
                case 'V':
                case 'v':
                    ClickStyle(vButton);
                    break;
                case 'W':
                case 'w':
                    ClickStyle(wButton);
                    break;
                case 'X':
                case 'x':
                    ClickStyle(xButton);
                    break;
                case 'Y':
                case 'y':
                    ClickStyle(yButton);
                    break;
                case 'Z':
                case 'z':
                    ClickStyle(zButton);
                    break;
                case '~':
                case '`':
                    ClickStyle(nearly);
                    break;
                case '!':
                case '1':
                    ClickStyle(oneButton);
                    break;
                case '@':
                case '2':
                    ClickStyle(twoButton);
                    break;
                case '#':
                case '3':
                    ClickStyle(threeButton);
                    break;
                case '$':
                case '4':
                    ClickStyle(fourButton);
                    break;
                case '%':
                case '5':
                    ClickStyle(fiveButton);
                    break;
                case '^':
                case '6':
                    ClickStyle(sixButton);
                    break;
                case '&':
                case '7':
                    ClickStyle(sevenButton);
                    break;
                case '*':
                case '8':
                    ClickStyle(eightButton);
                    break;
                case '(':
                case '9':
                    ClickStyle(nineButton);
                    break;
                case ')':
                case '0':
                    ClickStyle(zeroButton);
                    break;
                case '_':
                case '-':
                    ClickStyle(minusButton);
                    break;
                case '+':
                case '=':
                    ClickStyle(plusButton);
                    break;
                case '{':
                case '[':
                    ClickStyle(bracket1);
                    break;
                case '}':
                case ']':
                    ClickStyle(bracket2);
                    break;
                case '|':
                case '\\':
                    ClickStyle(slash1);
                    break;
                case ':':
                case ';':
                    ClickStyle(semiColon);
                    break;
                case '"':
                    ClickStyle(invertedComma);
                    break;
                case '<':
                case ',':
                    ClickStyle(comma);
                    break;
                case '>':
                case '.':
                    ClickStyle(dot);
                    break;
                case '?':
                case '/':
                    ClickStyle(slash);
                    break;
                case ' ':
                    ClickStyle(space);
                    break;



            }


        }

        // for showing hint key of text charector
        private void HintShow(char c)
        {
            if (Char.IsUpper(c))
            {
                HintStyle(shift1);
                HintStyle(shift2);
            }
            if (IsOtherChar(c))
            {
                HintStyle(shift1);
                HintStyle(shift2);
            }
            switch (c)
            {
                case 'A':
                case 'a':
                    HintStyle(aButton);
                    break;
                case 'B':
                case 'b':
                    HintStyle(bButton);
                    break;

                case 'C':
                case 'c':
                    HintStyle(cButton);
                    break;

                case 'D':
                case 'd':
                    HintStyle(dButton);
                    break;

                case 'E':
                case 'e':
                    HintStyle(eButton);
                    break;

                case 'F':
                case 'f':
                    HintStyle(fButton);
                    break;
                case 'G':
                case 'g':
                    HintStyle(gButton);
                    break;
                case 'H':
                case 'h':
                    HintStyle(hButton);
                    break;
                case 'I':
                case 'i':
                    HintStyle(iButton);
                    break;
                case 'J':
                case 'j':
                    HintStyle(jButton);
                    break;
                case 'K':
                case 'k':
                    HintStyle(kButton);
                    break;
                case 'L':
                case 'l':
                    HintStyle(lButton);
                    break;
                case 'M':
                case 'm':
                    HintStyle(mButton);
                    break;
                case 'N':
                case 'n':
                    HintStyle(nButton);
                    break;
                case 'O':
                case 'o':
                    HintStyle(oButton);
                    break;
                case 'P':
                case 'p':
                    HintStyle(pButton);
                    break;
                case 'Q':
                case 'q':
                    HintStyle(qButton);
                    break;
                case 'R':
                case 'r':
                    HintStyle(rButton);
                    break;
                case 'S':
                case 's':
                    HintStyle(sButton);
                    break;
                case 'T':
                case 't':
                    HintStyle(tButton);
                    break;
                case 'U':
                case 'u':
                    HintStyle(uButton);
                    break;
                case 'V':
                case 'v':
                    HintStyle(vButton);
                    break;
                case 'W':
                case 'w':
                    HintStyle(wButton);
                    break;
                case 'X':
                case 'x':
                    HintStyle(xButton);
                    break;
                case 'Y':
                case 'y':
                    HintStyle(yButton);
                    break;
                case 'Z':
                case 'z':
                    HintStyle(zButton);
                    break;
                case '~':
                case '`':
                    HintStyle(nearly);
                    break;
                case '!':
                case '1':
                    HintStyle(oneButton);
                    break;
                case '@':
                case '2':
                    HintStyle(twoButton);
                    break;
                case '#':
                case '3':
                    HintStyle(threeButton);
                    break;
                case '$':
                case '4':
                    HintStyle(fourButton);
                    break;
                case '%':
                case '5':
                    HintStyle(fiveButton);
                    break;
                case '^':
                case '6':
                    HintStyle(sixButton);
                    break;
                case '&':
                case '7':
                    HintStyle(sevenButton);
                    break;
                case '*':
                case '8':
                    HintStyle(eightButton);
                    break;
                case '(':
                case '9':
                    HintStyle(nineButton);
                    break;
                case ')':
                case '0':
                    HintStyle(zeroButton);
                    break;
                case '_':
                case '-':
                    HintStyle(minusButton);
                    break;
                case '+':
                case '=':
                    HintStyle(plusButton);
                    break;
                case '{':
                case '[':
                    HintStyle(bracket1);
                    break;
                case '}':
                case ']':
                    HintStyle(bracket2);
                    break;
                case '|':
                case '\\':
                    HintStyle(slash1);
                    break;
                case ':':
                case ';':
                    HintStyle(semiColon);
                    break;
                case '"':
                    HintStyle(invertedComma);
                    break;
                case '<':
                case ',':
                    HintStyle(comma);
                    break;
                case '>':
                case '.':
                    HintStyle(dot);
                    break;
                case '?':
                case '/':
                    HintStyle(slash);
                    break;
                case ' ':
                    HintStyle(space);
                    break;



            }


        }

        // for hint style
        private void HintStyle(Label l)
        {
            l.FontSize = 34;
            l.Foreground = Brushes.Yellow;
            
        }

        // for click style
        private void ClickStyle(Label l)
        {
            
            l.FontSize = 40;

            var bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.greenNormal.GetHbitmap(),
                                  IntPtr.Zero,
                                  Int32Rect.Empty,
                                  BitmapSizeOptions.FromEmptyOptions());

            l.Foreground = Brushes.Red;


        }

        // for making default show
        private void DefaultShow()
        {
            DefaultStyle(aButton);
            DefaultStyle(bButton);
            DefaultStyle(cButton);
            DefaultStyle(dButton);
            DefaultStyle(eButton);
            DefaultStyle(fButton);
            DefaultStyle(gButton);
            DefaultStyle(hButton);
            DefaultStyle(iButton);
            DefaultStyle(jButton);
            DefaultStyle(kButton);
            DefaultStyle(lButton);
            DefaultStyle(mButton);
            DefaultStyle(nButton);
            DefaultStyle(oButton);
            DefaultStyle(pButton);
            DefaultStyle(qButton);
            DefaultStyle(rButton);
            DefaultStyle(sButton);
            DefaultStyle(tButton);
            DefaultStyle(uButton);
            DefaultStyle(vButton);
            DefaultStyle(wButton);
            DefaultStyle(xButton);
            DefaultStyle(yButton);
            DefaultStyle(zButton);
            DefaultStyle(nearly);
            DefaultStyle(oneButton);
            DefaultStyle(twoButton);
            DefaultStyle(threeButton);
            DefaultStyle(fourButton);
            DefaultStyle(fiveButton);
            DefaultStyle(sixButton);
            DefaultStyle(sevenButton);
            DefaultStyle(eightButton);
            DefaultStyle(nineButton);
            DefaultStyle(zeroButton);
            DefaultStyle(minusButton);
            DefaultStyle(plusButton);
            DefaultStyle(bracket1);
            DefaultStyle(bracket2);
            DefaultStyle(slash1);
            DefaultStyle(semiColon);
            DefaultStyle(invertedComma);
            DefaultStyle(comma);
            DefaultStyle(dot);
            DefaultStyle(slash);
            DefaultStyle(space);
            DefaultStyle(shift1);
            DefaultStyle(shift2);


        }
        
        // for default style
        private void DefaultStyle(Label l)
        {
            
            var blackNormal = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.keyboard.GetHbitmap(),
                                  IntPtr.Zero,
                                  Int32Rect.Empty,
                                  BitmapSizeOptions.FromEmptyOptions());

            l.Foreground = new ImageBrush(blackNormal);

            var shiftNormal = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.shift.GetHbitmap(),
                                  IntPtr.Zero,
                                  Int32Rect.Empty,
                                  BitmapSizeOptions.FromEmptyOptions());

            

            l.FontSize = 25;
            l.Foreground = Brushes.White;


            if(l == space)
            {
                l.FontSize = 12;
                l.Foreground = Brushes.White;
            }
            if (l == shift1 || l == shift2)
            {
                l.FontSize = 12;
                /*l.Background = new ImageBrush(shiftNormal);*/
                l.Foreground = Brushes.White;
            }
        }

        //For understanding other charector to show shift button while hintShow
        private bool IsOtherChar(char c)
        {
            switch (c)
            {
                case '~':
                case '!':
                case '@':
                case '#':
                case '$':
                case '%':
                case '^':
                case '&':
                case '*':
                case '(':
                case ')':
                case '_':
                case '+':
                case '{':
                case '}':
                case '|':
                case ':':
                case '"':
                case '<':
                case '>':
                case '?':
                    return true;
            }
            return false;
        }

        //For calculating Typing speed in word per minut
        private void speedCalculation()
        {
            
            wrdPerMin = (long)(spaceCount * second)/milliSecondCount;
            wordPerMin.Text = wrdPerMin + "";
            if (milliSecondCount == 10000)
            {
                spaceCount = 0;
                milliSecondCount = 0;
                wrdPerMin = 0;
            }
        }

    }

    
}
