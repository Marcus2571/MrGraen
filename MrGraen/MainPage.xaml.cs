using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        #region Deck


        #region Clubs


        Card aceC = new Card()
        {
            Value = 11,
            Name = "Ace Clubs",
            Image = "Resources/AC.png"
        };
        Card twoC = new Card()
        {
            Value = 2,
            Name = "Two Clubs",
            Image = "Resources/2C.png"
        };
        Card threeC = new Card()
        {
            Value = 3,
            Name = "Three Clubs",
            Image = "Resources/3C.png"
        };
        Card fourC = new Card()
        {
            Value = 4,
            Name = "Four Clubs",
            Image = "Resources/4C.png"
        };
        Card fiveC = new Card()
        {
            Value = 5,
            Name = "Five Clubs",
            Image = "Resources/5C.png"
        };
        Card sixC = new Card()
        {
            Value = 6,
            Name = "Six Clubs",
            Image = "Resources/6C.png"
        };
        Card sevenC = new Card()
        {
            Value = 7,
            Name = "Seven Clubs",
            Image = "Resources/7C.png"
        };
        Card eightC = new Card()
        {
            Value = 8,
            Name = "Eigth Clubs",
            Image = "Resources/8C.png"
        };
        Card nineC = new Card()
        {
            Value = 9,
            Name = "Nine Clubs",
            Image = "Resources/9C.png"
        };
        Card tenC = new Card()
        {
            Value = 10,
            Name = "Ten Clubs",
            Image = "Resources/10C.png"
        };
        Card jackC = new Card()
        {
            Value = 10,
            Name = "Jack Clubs",
            Image = "Resources/JC.png"
        };
        Card queenC = new Card()
        {
            Value = 10,
            Name = "Queen Clubs",
        };
        Card kingC = new Card()
        {
            Value = 10,
            Name = "King Clubs",
            Image = "Resources/KC.png"
        };


        #endregion

        #region Spades
        Card aceS = new Card()
        {
            Value = 11,
            Name = "Ace Spades",
            Image = "Resources/AS.png"
        };
        Card twoS = new Card()
        {
            Value = 2,
            Name = "Two Spades",
            Image = "Resources/2S.png"
        };
        Card threeS = new Card()
        {
            Value = 3,
            Name = "Three Spades",
            Image = "Resources/3S.png"
        };
        Card fourS = new Card()
        {
            Value = 4,
            Name = "Four Spades",
            Image = "Resources/4S.png"
        };
        Card fiveS = new Card()
        {
            Value = 5,
            Name = "Five Spades",
            Image = "Resources/5S.png"
        };
        Card sixS = new Card()
        {
            Value = 6,
            Name = "Six Spades",
            Image = "Resources/6S.png"
        };
        Card sevenS = new Card()
        {
            Value = 7,
            Name = "Seven Spades",
            Image = "Resources/7S.png"
        };
        Card eightS = new Card()
        {
            Value = 8,
            Name = "Eigth Spades",
            Image = "Resources/8S.png"
        };
        Card nineS = new Card()
        {
            Value = 9,
            Name = "Nine Spades",
            Image = "Resources/9S.png"
        };
        Card tenS = new Card()
        {
            Value = 10,
            Name = "Ten Spades",
            Image = "Resources/10S.png"
        };
        Card jackS = new Card()
        {
            Value = 10,
            Name = "Jack Spades",
            Image = "Resources/JS.png"
        };
        Card queenS = new Card()
        {
            Value = 10,
            Name = "Queen Spades",
            Image = "Resources/QS.png"
        };
        Card kingS = new Card()
        {
            Value = 10,
            Name = "King Spades",
            Image = "Resources/KS.png"
        };
        #endregion

        #region Hearts
        Card aceH = new Card()
        {
            Value = 11,
            Name = "Ace Hearts",
            Image = "Resources/AH.png"
        };
        Card twoH = new Card()
        {
            Value = 2,
            Name = "Two Hearts",
            Image = "Resources/2H.png"
        };
        Card threeH = new Card()
        {
            Value = 3,
            Name = "Three Hearts",
            Image = "Resources/3H.png"
        };
        Card fourH = new Card()
        {
            Value = 4,
            Name = "Four Hearts",
            Image = "Resources/4H.png"
        };
        Card fiveH = new Card()
        {
            Value = 5,
            Name = "Five Hearts",
            Image = "Resources/5H.png"
        };
        Card sixH = new Card()
        {
            Value = 6,
            Name = "Six Hearts",
            Image = "Resources/6H.png"
        };
        Card sevenH = new Card()
        {
            Value = 7,
            Name = "Seven Hearts",
            Image = "Resources/7H.png"
        };
        Card eightH = new Card()
        {
            Value = 8,
            Name = "Eigth Hearts",
            Image = "Resources/8H.png"
        };
        Card nineH = new Card()
        {
            Value = 9,
            Name = "Nine Hearts",
            Image = "Resources/9H.png"
        };
        Card tenH = new Card()
        {
            Value = 10,
            Name = "Ten Hearts",
            Image = "Resources/10H.png"
        };
        Card jackH = new Card()
        {
            Value = 10,
            Name = "Jack Hearts",
            Image = "Resources/JH.png"
        };
        Card queenH = new Card()
        {
            Value = 10,
            Name = "Queen Hearts",
            Image = "Resources/QH.png"
        };
        Card kingH = new Card()
        {
            Value = 10,
            Name = "King Hearts",
            Image = "Resources/KH.png"
        };
        #endregion

        #region Diamonds
        Card aceD = new Card()
        {
            Value = 11,
            Name = "Ace Diamonds",
            Image = "Resources/AD.png"
        };
        Card twoD = new Card()
        {
            Value = 2,
            Name = "Two Diamonds",
            Image = "Resources/2D.png"
        };
        Card threeD = new Card()
        {
            Value = 3,
            Name = "Three Diamonds",
            Image = "Resources/3D.png"
        };
        Card fourD = new Card()
        {
            Value = 4,
            Name = "Four Diamonds",
            Image = "Resources/4D.png"
        };
        Card fiveD = new Card()
        {
            Value = 5,
            Name = "Five Diamonds",
            Image = "Resources/5D.png"
        };
        Card sixD = new Card()
        {
            Value = 6,
            Name = "Six Diamonds",
            Image = "Resources/6D.png"
        };
        Card sevenD = new Card()
        {
            Value = 7,
            Name = "Seven Diamonds",
            Image = "Resources/7D.png"
        };
        Card eightD = new Card()
        {
            Value = 8,
            Name = "Eigth Diamonds",
            Image = "Resources/8D.png"
        };
        Card nineD = new Card()
        {
            Value = 9,
            Name = "Nine Diamonds",
            Image = "Resources/9D.png"
        };
        Card tenD = new Card()
        {
            Value = 10,
            Name = "Ten Diamonds",
            Image = "Resources/10D.png"
        };
        Card jackD = new Card()
        {
            Value = 10,
            Name = "Jack Diamonds",
            Image = "Resources/JD.png"
        };
        Card queenD = new Card()
        {
            Value = 10,
            Name = "Queen Diamonds",
            Image = "Resources/QD.png"
        };
        Card kingD = new Card()
        {
            Value = 10,
            Name = "King Diamonds",
            Image = "Resources/KD.png"
        };
        #endregion


        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
