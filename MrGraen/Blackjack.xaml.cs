using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Holographic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MrGraen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Blackjack : Page
    {
        public Blackjack()
        {
            this.InitializeComponent();

            new Thread(new ThreadStart(PopulateDeck)).Start();

        }

        List<Card> playerCardList = new List<Card>();

        List<Card> dealerCardList = new List<Card>();

        double playerCardMargin = 0;
        double dealerCardMargin = 0;

        int playerCardSum = 0;
        int dealerCardSum = 0;
        Random random = new Random();
        List<Image> playerBox = new List<Image>();
        List<Image> dealerBox = new List<Image>();


        #region Deck


        List<Card> deck1 = new List<Card>()
        {
            #region Clubs

            new Card() { Value = 11, Name = "Ace Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/AC.png")) },
            new Card() { Value = 2, Name = "Two Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/2C.png")) },
            new Card() { Value = 3, Name = "Three Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/3C.png")) },
            new Card() { Value = 4, Name = "Four Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/4C.png")) },
            new Card() { Value = 5, Name = "Five Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/5C.png")) },
            new Card() { Value = 6, Name = "Six Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/6C.png")) },
            new Card() { Value = 7, Name = "Seven Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/7C.png")) },
            new Card() { Value = 8, Name = "Eigth Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/8C.png")) },
            new Card() { Value = 9, Name = "Nine Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/9C.png")) },
            new Card() { Value = 10, Name = "Ten Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/10C.png")) },
            new Card() { Value = 10, Name = "Jack Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/JC.png")) },
            new Card() { Value = 10, Name = "Queen Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/QC.png")) },
            new Card() { Value = 10, Name = "King Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/KC.png")) },

            #endregion

            #region Spades


            new Card() { Value = 11, Name = "Ace Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/AS.png")) },
            new Card() { Value = 2, Name = "Two Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/2S.png")) },
            new Card() { Value = 3, Name = "Three Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/3S.png")) },
            new Card() { Value = 4, Name = "Four Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/4S.png")) },
            new Card() { Value = 5, Name = "Five Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/5S.png")) },
            new Card() { Value = 6, Name = "Six Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/6S.png")) },
            new Card() { Value = 7, Name = "Seven Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/7S.png")) },
            new Card() { Value = 8, Name = "Eigth Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/8S.png")) },
            new Card() { Value = 9, Name = "Nine Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/9S.png")) },
            new Card() { Value = 10, Name = "Ten Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/10S.png")) },
            new Card() { Value = 10, Name = "Jack Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/JS.png")) },
            new Card() { Value = 10, Name = "Queen Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/QS.png")) },
            new Card() { Value = 10, Name = "King Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/KS.png")) },


            #endregion
            
            #region Hearts


            new Card() { Value = 11, Name = "Ace Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/AH.png")) },
            new Card() { Value = 2, Name = "Two Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/2H.png")) },
            new Card() { Value = 3, Name = "Three Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/3H.png")) },
            new Card() { Value = 4, Name = "Four Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/4H.png")) },
            new Card() { Value = 5, Name = "Five Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/5H.png")) },
            new Card() { Value = 6, Name = "Six Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/6H.png")) },
            new Card() { Value = 7, Name = "Seven Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/7H.png")) },
            new Card() { Value = 8, Name = "Eigth Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/8H.png")) },
            new Card() { Value = 9, Name = "Nine Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/9H.png")) },
            new Card() { Value = 10, Name = "Ten Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/10H.png")) },
            new Card() { Value = 10, Name = "Jack Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/JH.png")) },
            new Card() { Value = 10, Name = "Queen Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/QH.png")) },
            new Card() { Value = 10, Name = "King Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/KH.png")) },


            #endregion

            #region Diamonds


            new Card() { Value = 11, Name = "Ace Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/AD.png")) },
            new Card() { Value = 2, Name = "Two Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/2D.png")) },
            new Card() { Value = 3, Name = "Three Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/3D.png")) },
            new Card() { Value = 4, Name = "Four Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/4D.png")) },
            new Card() { Value = 5, Name = "Five Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/5D.png")) },
            new Card() { Value = 6, Name = "Six Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/6D.png")) },
            new Card() { Value = 7, Name = "Seven Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/7D.png")) },
            new Card() { Value = 8, Name = "Eigth Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/8D.png")) },
            new Card() { Value = 9, Name = "Nine Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/9D.png")) },
            new Card() { Value = 10, Name = "Ten Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/10D.png")) },
            new Card() { Value = 10, Name = "Jack Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/JD.png")) },
            new Card() { Value = 10, Name = "Queen Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/QD.png")) },
            new Card() { Value = 10, Name = "King Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/KD.png")) }


            #endregion
        };

        List<Card> deck2 = new List<Card>()
        {
            #region Clubs

            new Card() { Value = 11, Name = "Ace Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/AC.png")) },
            new Card() { Value = 2, Name = "Two Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/2C.png")) },
            new Card() { Value = 3, Name = "Three Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/3C.png")) },
            new Card() { Value = 4, Name = "Four Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/4C.png")) },
            new Card() { Value = 5, Name = "Five Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/5C.png")) },
            new Card() { Value = 6, Name = "Six Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/6C.png")) },
            new Card() { Value = 7, Name = "Seven Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/7C.png")) },
            new Card() { Value = 8, Name = "Eigth Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/8C.png")) },
            new Card() { Value = 9, Name = "Nine Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/9C.png")) },
            new Card() { Value = 10, Name = "Ten Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/10C.png")) },
            new Card() { Value = 10, Name = "Jack Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/JC.png")) },
            new Card() { Value = 10, Name = "Queen Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/QC.png")) },
            new Card() { Value = 10, Name = "King Clubs", Image = new BitmapImage(new Uri("ms-appx:///Resources/KC.png")) },

            #endregion

            #region Spades


            new Card() { Value = 11, Name = "Ace Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/AS.png")) },
            new Card() { Value = 2, Name = "Two Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/2S.png")) },
            new Card() { Value = 3, Name = "Three Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/3S.png")) },
            new Card() { Value = 4, Name = "Four Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/4S.png")) },
            new Card() { Value = 5, Name = "Five Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/5S.png")) },
            new Card() { Value = 6, Name = "Six Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/6S.png")) },
            new Card() { Value = 7, Name = "Seven Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/7S.png")) },
            new Card() { Value = 8, Name = "Eigth Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/8S.png")) },
            new Card() { Value = 9, Name = "Nine Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/9S.png")) },
            new Card() { Value = 10, Name = "Ten Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/10S.png")) },
            new Card() { Value = 10, Name = "Jack Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/JS.png")) },
            new Card() { Value = 10, Name = "Queen Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/QS.png")) },
            new Card() { Value = 10, Name = "King Spades", Image = new BitmapImage(new Uri("ms-appx:///Resources/KS.png")) },


            #endregion
            
            #region Hearts


            new Card() { Value = 11, Name = "Ace Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/AH.png")) },
            new Card() { Value = 2, Name = "Two Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/2H.png")) },
            new Card() { Value = 3, Name = "Three Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/3H.png")) },
            new Card() { Value = 4, Name = "Four Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/4H.png")) },
            new Card() { Value = 5, Name = "Five Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/5H.png")) },
            new Card() { Value = 6, Name = "Six Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/6H.png")) },
            new Card() { Value = 7, Name = "Seven Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/7H.png")) },
            new Card() { Value = 8, Name = "Eigth Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/8H.png")) },
            new Card() { Value = 9, Name = "Nine Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/9H.png")) },
            new Card() { Value = 10, Name = "Ten Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/10H.png")) },
            new Card() { Value = 10, Name = "Jack Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/JH.png")) },
            new Card() { Value = 10, Name = "Queen Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/QH.png")) },
            new Card() { Value = 10, Name = "King Hearts", Image = new BitmapImage(new Uri("ms-appx:///Resources/KH.png")) },


            #endregion

            #region Diamonds


            new Card() { Value = 11, Name = "Ace Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/AD.png")) },
            new Card() { Value = 2, Name = "Two Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/2D.png")) },
            new Card() { Value = 3, Name = "Three Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/3D.png")) },
            new Card() { Value = 4, Name = "Four Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/4D.png")) },
            new Card() { Value = 5, Name = "Five Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/5D.png")) },
            new Card() { Value = 6, Name = "Six Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/6D.png")) },
            new Card() { Value = 7, Name = "Seven Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/7D.png")) },
            new Card() { Value = 8, Name = "Eigth Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/8D.png")) },
            new Card() { Value = 9, Name = "Nine Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/9D.png")) },
            new Card() { Value = 10, Name = "Ten Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/10D.png")) },
            new Card() { Value = 10, Name = "Jack Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/JD.png")) },
            new Card() { Value = 10, Name = "Queen Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/QD.png")) },
            new Card() { Value = 10, Name = "King Diamonds", Image = new BitmapImage(new Uri("ms-appx:///Resources/KD.png")) }


            #endregion
        };

        List<Card> totalDeck = new List<Card>();


        #endregion

        private async void Startbtn_Click(object sender, RoutedEventArgs e)
        {
            playerCardMargin = PlayerCard2.Margin.Left;
            dealerCardMargin = DealerCard2.Margin.Left;
            playerCardSum = 0;
            dealerCardSum = 0;

            Card playerCard1 = totalDeck[SelectRandomCard()];
            totalDeck.Remove(playerCard1);
            playerCardList.Add(playerCard1);

            Card dealerCard1 = totalDeck[SelectRandomCard()];
            totalDeck.Remove(dealerCard1);
            dealerCardList.Add(dealerCard1);

            Card playerCard2 = totalDeck[SelectRandomCard()];
            totalDeck.Remove(playerCard2);
            playerCardList.Add(playerCard2);

            Card dealerCard2 = totalDeck[SelectRandomCard()];
            totalDeck.Remove(dealerCard2);
            dealerCardList.Add(dealerCard2);

            DisplayCard(PlayerCard1, playerCard1.Image);

            await Task.Run(() => Thread.Sleep(500));
            DisplayCard(DealerCard1, dealerCard1.Image);

            await Task.Run(() => Thread.Sleep(500));
            DisplayCard(PlayerCard2, playerCard2.Image);

            await Task.Run(() => Thread.Sleep(500));
            await Task.Run(() =>
            {
                SumPlayerCards();
                SumDealerCards();
            });

            PlayerCardSumLbl.Text = playerCardSum.ToString();
            DealerCardSumLbl.Text = dealerCardList[0].Value.ToString();

            if (playerCardSum == 21 && dealerCardSum != 21)
            {
                DisplayCard(DealerCard2, dealerCard2.Image);
                await new MessageDialog("You Have Blackjack!", "You Win!").ShowAsync();
                ResetGame();
            }
            else if (playerCardSum == 21 && dealerCardSum == 21)
            {
                DisplayCard(DealerCard2, new BitmapImage(new Uri("ms-appx:///Resources/b1fv.png")));
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                DisplayCard(DealerCard2, dealerCard2.Image);
                await new MessageDialog("Both You And The Dealer Has Blackjack Therefore It's a Tie!", "Push!").ShowAsync();
                ResetGame();
            }
            else if (playerCardSum != 21 && dealerCardSum == 21)
            {
                DisplayCard(DealerCard2, new BitmapImage(new Uri("ms-appx:///Resources/b1fv.png")));
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                DisplayCard(DealerCard2, dealerCard2.Image);
                DealerCardSumLbl.Text = dealerCardSum.ToString();
                await new MessageDialog("The Dealer Has Blackjack!", "You Lose!").ShowAsync();
                ResetGame();
            }
            else
            {
                DisplayCard(DealerCard2, new BitmapImage(new Uri("ms-appx:///Resources/b1fv.png")));
            }

            Startbtn.IsEnabled = false;
            Hitbtn.IsEnabled = true;
            Standbtn.IsEnabled = true;
        }

        private void ResetGame()
        {
            PlayerCardSumLbl.Text = "";
            DealerCardSumLbl.Text = "";
            DisplayCard(PlayerCard1, new BitmapImage(new Uri("ms-appx:///null")));
            DisplayCard(DealerCard1, new BitmapImage(new Uri("ms-appx:///null")));
            DisplayCard(PlayerCard2, new BitmapImage(new Uri("ms-appx:///null")));
            DisplayCard(DealerCard2, new BitmapImage(new Uri("ms-appx:///null")));
            foreach (Image img in playerBox)
            {
                blackjackGrid.Children.Remove(img);
            }
            playerBox = new List<Image>();
            foreach (Image img in dealerBox)
            {
                blackjackGrid.Children.Remove(img);
            }
            dealerBox = new List<Image>();

            playerCardSum = 0;
            dealerCardSum = 0;
            playerCardList.Clear();
            dealerCardList.Clear();
            totalDeck.Clear();
            new Thread(new ThreadStart(PopulateDeck)).Start();

            Startbtn.IsEnabled = true;
            Hitbtn.IsEnabled = false;
            Standbtn.IsEnabled = false;
        }

        private async void PlayDealer()
        {
            await Task.Run(() => Thread.Sleep(500));
            await Task.Run(() => SumDealerCards());
            DealerCardSumLbl.Text = dealerCardSum.ToString();
            DisplayCard(DealerCard2, dealerCardList[1].Image);

            while (dealerCardSum < 17)
            {
                await Task.Run(() => Thread.Sleep(500));
                dealerCardMargin += (DealerCard2.Width + 5);
                Card dealerCard = totalDeck[SelectRandomCard()];
                totalDeck.Remove(dealerCard);
                dealerCardList.Add(dealerCard);

                Image dealerCardImage = new Image()
                {
                    Height = 182,
                    Width = 136,
                    Margin = new Thickness(dealerCardMargin, 38, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Name = "DealerCard"
                };
                dealerBox.Add(dealerCardImage);
                blackjackGrid.Children.Add(dealerCardImage);

                DisplayCard(dealerCardImage, dealerCard.Image);

                await Task.Run(() =>
                {
                    SumPlayerCards();
                    SumDealerCards();
                });

                PlayerCardSumLbl.Text = playerCardSum.ToString();
                DealerCardSumLbl.Text = dealerCardSum.ToString();
            }
            if (dealerCardSum > 21)
            {
                await new MessageDialog("The Dealer's Gone Bust!", "You Win!").ShowAsync();
                ResetGame();
            }
            else if (dealerCardSum == playerCardSum && dealerCardSum >= 17)
            {
                await new MessageDialog($"Both Yours And The Dealers Cards Has a Sum of {dealerCardSum} Therefore It's a Tie!", "Push!").ShowAsync();
                ResetGame();
            }
            else if (dealerCardSum > playerCardSum && dealerCardSum >= 17)
            {
                await new MessageDialog("", "You Lose!").ShowAsync();
                ResetGame();
            }
            else if (dealerCardSum < playerCardSum && dealerCardSum >= 17)
            {
                await new MessageDialog("", "You Win!").ShowAsync();
                ResetGame();
            }
        }

        private async void Hitbtn_Click(object sender, RoutedEventArgs e)
        {
            playerCardMargin += (PlayerCard2.Width + 5);
            Card playerCard = totalDeck[SelectRandomCard()];
            totalDeck.Remove(playerCard);
            playerCardList.Add(playerCard);

            Image playerCardImage = new Image()
            {
                Height = 182,
                Width = 136,
                Margin = new Thickness(playerCardMargin, 240, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Name = "PlayerCard"
            };
            playerBox.Add(playerCardImage);
            blackjackGrid.Children.Add(playerCardImage);

            DisplayCard(playerCardImage, playerCard.Image);

            await Task.Run(() =>
            {
                SumPlayerCards();
                SumDealerCards();
            });

            PlayerCardSumLbl.Text = playerCardSum.ToString();

            if (playerCardSum > 21)
            {
                await new MessageDialog("You've Gone Bust!", "You Lose!").ShowAsync();
                ResetGame();
            }
            else if (playerCardSum == 21)
            {
                PlayDealer();
                Hitbtn.IsEnabled = false;
            }
        }

        private void Standbtn_Click(object sender, RoutedEventArgs e)
        {
            Hitbtn.IsEnabled = false;
            PlayDealer();
        }

        private void DisplayCard(Image image, BitmapImage source)
        {
            image.Source = source;
        }


        private void PlaceBetbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private int SelectRandomCard()
        {
            int randomCard;
            randomCard = random.Next(0, totalDeck.Count);
            return randomCard;
        }

        private void PopulateDeck()
        {
            foreach (var card in deck1)
            {
                totalDeck.Add(card);
            }
            foreach (var card in deck2)
            {
                totalDeck.Add(card);
            }
        }

        private void SumPlayerCards()
        {
            playerCardSum = 0;
            for (int i = 0; i < playerCardList.Count; i++)
            {
                playerCardSum += playerCardList[i].Value;
            }
            if (playerCardSum > 21)
            {
                foreach (var c in playerCardList)
                {
                    if (c.Value == 11)
                    {
                        playerCardSum -= 10;
                        if (playerCardSum <= 21)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void SumDealerCards()
        {
            dealerCardSum = 0;
            for (int i = 0; i < dealerCardList.Count; i++)
            {
                dealerCardSum += dealerCardList[i].Value;
            }
            if (dealerCardSum > 21)
            {
                foreach (var c in dealerCardList)
                {
                    if (c.Value == 11)
                    {
                        dealerCardSum -= 10;
                        if (dealerCardSum <= 21)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void Chip1btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Chip5btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Chip25btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Chip100btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Chip500btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Chip1000btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
