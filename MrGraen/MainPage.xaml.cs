using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Holographic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MrGraen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        List<Card> playercardList = new List<Card>()
        {
            new Card() { Value = 0, Name = "null", Image = "null"}
        };

        List<Card> bankercardList = new List<Card>()
        {
            new Card() { Value = 0, Name = "null", Image = "null" }
        };

        int playercardSum = 0;
        int bankercardSum = 0;
        Random random = new Random();
        List<int> usedCards = new List<int>();
        List<Image> bankerbox = new List<Image>();
        List<Image> playerbox = new List<Image>();


        #region Deck


        List<Card> deck = new List<Card>()
        {
            #region Clubs

            new Card() { Value = 11, Name = "Ace Clubs", Image = "Resources/AC.png" },
            new Card() { Value = 2, Name = "Two Clubs", Image = "Resources/2C.png" },
            new Card() { Value = 3, Name = "Three Clubs", Image = "Resources/3C.png" },
            new Card() { Value = 4, Name = "Four Clubs", Image = "Resources/4C.png" },
            new Card() { Value = 5, Name = "Five Clubs", Image = "Resources/5C.png" },
            new Card() { Value = 6, Name = "Six Clubs", Image = "Resources/6C.png" },
            new Card() { Value = 7, Name = "Seven Clubs", Image = "Resources/7C.png" },
            new Card() { Value = 8, Name = "Eigth Clubs", Image = "Resources/8C.png" },
            new Card() { Value = 9, Name = "Nine Clubs", Image = "Resources/9C.png" },
            new Card() { Value = 10, Name = "Ten Clubs", Image = "Resources/10C.png" },
            new Card() { Value = 10, Name = "Jack Clubs", Image = "Resources/JC.png" },
            new Card() { Value = 10, Name = "Queen Clubs", Image = "Resources/QC.png" },
            new Card() { Value = 10, Name = "King Clubs", Image = "Resources/KC.png" }

            #endregion

            #region Spades


            new Card() { Value = 11, Name = "Ace Spades", Image = "Resources/AS.png" },
            new Card() { Value = 2, Name = "Two Spades", Image = "Resources/2S.png" },
            new Card() { Value = 3, Name = "Three Spades", Image = "Resources/3S.png" },
            new Card() { Value = 4, Name = "Four Spades", Image = "Resources/4S.png" },
            new Card() { Value = 5, Name = "Five Spades", Image = "Resources/5S.png" },
            new Card() { Value = 6, Name = "Six Spades", Image = "Resources/6S.png" },
            new Card() { Value = 7, Name = "Seven Spades", Image = "Resources/7S.png" },
            new Card() { Value = 8, Name = "Eigth Spades", Image = "Resources/8S.png" },
            new Card() { Value = 9, Name = "Nine Spades", Image = "Resources/9S.png" },
            new Card() { Value = 10, Name = "Ten Spades", Image = "Resources/10S.png" },
            new Card() { Value = 10, Name = "Jack Spades", Image = "Resources/JS.png" },
            new Card() { Value = 10, Name = "Queen Spades", Image = "Resources/QS.png" },
            new Card() { Value = 10, Name = "King Spades", Image = "Resources/KS.png" }


            #endregion
            
            #region Hearts


            new Card() { Value = 11, Name = "Ace Hearts", Image = "Resources/AH.png" },
            new Card() { Value = 2, Name = "Two Hearts", Image = "Resources/2H.png" },
            new Card() { Value = 3, Name = "Three Hearts", Image = "Resources/3H.png" },
            new Card() { Value = 4, Name = "Four Hearts", Image = "Resources/4H.png" },
            new Card() { Value = 5, Name = "Five Hearts", Image = "Resources/5H.png" },
            new Card() { Value = 6, Name = "Six Hearts", Image = "Resources/6H.png" },
            new Card() { Value = 7, Name = "Seven Hearts", Image = "Resources/7H.png" },
            new Card() { Value = 8, Name = "Eigth Hearts", Image = "Resources/8H.png" },
            new Card() { Value = 9, Name = "Nine Hearts", Image = "Resources/9H.png" },
            new Card() { Value = 10, Name = "Ten Hearts", Image = "Resources/10H.png" },
            new Card() { Value = 10, Name = "Jack Hearts", Image = "Resources/JH.png" },
            new Card() { Value = 10, Name = "Queen Hearts", Image = "Resources/QH.png" },
            new Card() { Value = 10, Name = "King Hearts", Image = "Resources/KH.png" }


            #endregion

            #region Diamonds


            new Card() { Value = 11, Name = "Ace Diamonds", Image = "Resources/AD.png" },
            new Card() { Value = 2, Name = "Two Diamonds", Image = "Resources/2D.png" },
            new Card() { Value = 3, Name = "Three Diamonds", Image = "Resources/3D.png" },
            new Card() { Value = 4, Name = "Four Diamonds", Image = "Resources/4D.png" },
            new Card() { Value = 5, Name = "Five Diamonds", Image = "Resources/5D.png" },
            new Card() { Value = 6, Name = "Six Diamonds", Image = "Resources/6D.png" },
            new Card() { Value = 7, Name = "Seven Diamonds", Image = "Resources/7D.png" },
            new Card() { Value = 8, Name = "Eigth Diamonds", Image = "Resources/8D.png" },
            new Card() { Value = 9, Name = "Nine Diamonds", Image = "Resources/9D.png" },
            new Card() { Value = 10, Name = "Ten Diamonds", Image = "Resources/10D.png" },
            new Card() { Value = 10, Name = "Jack Diamonds", Image = "Resources/JD.png" },
            new Card() { Value = 10, Name = "Queen Diamonds", Image = "Resources/QD.png" },
            new Card() { Value = 10, Name = "King Diamonds", Image = "Resources/KD.png" }


            #endregion
        };


        #endregion

        private void Startbtn_Click(object sender, RoutedEventArgs e)
        {
            if (playercardSum > 0)
            {

            }
        }
    }
}
