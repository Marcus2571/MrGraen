using HorseRace;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
//using static System.Net.Mime.MediaTypeNames;


namespace MrGraen
{
    public sealed partial class HorseRace : Page
    {
        DispatcherTimer dispatcherTimer;
        DateTimeOffset startTime;
        DateTimeOffset lastTime;
        DateTimeOffset stopTime;

        int ticks = 0;

        int bet = 0;

        private List<Horse> _horses = new List<Horse>();
        private List<Image> _raceHorses = new List<Image>();
        private Horse _winningHorse = null;
        private Image _playerHorse = null;

        public HorseRace()
        {
            this.InitializeComponent();

            BalanceSumLbl.Text = Player.Balance.ToString();
            _raceHorses.AddRange(new List<Image>
            {
                Horse1,
                Horse2,
                Horse3,
                Horse4,
                Horse5,
                Horse6,
                Horse7,
                Horse8,
            });


            Setup();
        }

        private void CalculateSpeed()
        {
            Random random = new Random();
            foreach (var horse in _horses)
            {
                if (horse == _winningHorse)
                {
                    ticks++;
                    if (ticks > 70)
                    {
                        horse.Speed = 25;
                    }
                    else
                    {
                        horse.Speed = random.Next(5, 20);
                    }
                }
                else
                {
                    horse.Speed = random.Next(5, 20);
                }
            };
        }

        public async void Setup()
        {
            Race race = await Task.Run(() => new Race(8));

            Number1Win.Text = $"{Math.Round(race.Horses[0].GetWinChance(race.Horses) * 100)}%";
            Number2Win.Text = $"{Math.Round(race.Horses[1].GetWinChance(race.Horses) * 100)}%";
            Number3Win.Text = $"{Math.Round(race.Horses[2].GetWinChance(race.Horses) * 100)}%";
            Number4Win.Text = $"{Math.Round(race.Horses[3].GetWinChance(race.Horses) * 100)}%";
            Number5Win.Text = $"{Math.Round(race.Horses[4].GetWinChance(race.Horses) * 100)}%";
            Number6Win.Text = $"{Math.Round(race.Horses[5].GetWinChance(race.Horses) * 100)}%";
            Number7Win.Text = $"{Math.Round(race.Horses[6].GetWinChance(race.Horses) * 100)}%";
            Number8Win.Text = $"{Math.Round(race.Horses[7].GetWinChance(race.Horses) * 100)}%";

            Name1.Text = $"{race.Horses.Where(h => h.Number == 1).First().Name}";
            Name2.Text = $"{race.Horses.Where(h => h.Number == 2).First().Name}";
            Name3.Text = $"{race.Horses.Where(h => h.Number == 3).First().Name}";
            Name4.Text = $"{race.Horses.Where(h => h.Number == 4).First().Name}";
            Name5.Text = $"{race.Horses.Where(h => h.Number == 5).First().Name}";
            Name6.Text = $"{race.Horses.Where(h => h.Number == 6).First().Name}";
            Name7.Text = $"{race.Horses.Where(h => h.Number == 7).First().Name}";
            Name8.Text = $"{race.Horses.Where(h => h.Number == 8).First().Name}";

            _horses.AddRange(race.Horses);


            _winningHorse = race.GetWinner();
        }

        /// <summary>
        /// Goes back to main page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Startbtn_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimerSetup();
        }


        /// <summary>
        /// Restart game and reset all values
        /// </summary>
        private void ResetGame()
        {
            bet = 0;

            Horse1.Margin = new Thickness(20, Horse1.Margin.Top, Horse1.Margin.Right, Horse1.Margin.Bottom);
            Horse2.Margin = new Thickness(12, Horse2.Margin.Top, Horse2.Margin.Right, Horse2.Margin.Bottom);
            Horse3.Margin = new Thickness(3, Horse3.Margin.Top, Horse3.Margin.Right, Horse3.Margin.Bottom);
            Horse4.Margin = new Thickness(20, Horse4.Margin.Top, Horse4.Margin.Right, Horse4.Margin.Bottom);
            Horse5.Margin = new Thickness(12, Horse5.Margin.Top, Horse5.Margin.Right, Horse5.Margin.Bottom);
            Horse6.Margin = new Thickness(2, Horse6.Margin.Top, Horse6.Margin.Right, Horse6.Margin.Bottom);
            Horse7.Margin = new Thickness(19, Horse7.Margin.Top, Horse7.Margin.Right, Horse7.Margin.Bottom);
            Horse8.Margin = new Thickness(13, Horse8.Margin.Top, Horse8.Margin.Right, Horse8.Margin.Bottom);

            _horses.Clear();
            _raceHorses.Clear();
            _playerHorse = null;
            _winningHorse = null;

            Startbtn.IsEnabled = false;
            PlaceBetbtn.IsEnabled = true;
            Chip1btn.IsEnabled = true;
            Chip5btn.IsEnabled = true;
            Chip25btn.IsEnabled = true;
            Chip100btn.IsEnabled = true;
            Chip500btn.IsEnabled = true;
            Chip1000btn.IsEnabled = true;
            
            Horse1btn.IsEnabled = true;
            Horse2btn.IsEnabled = true;
            Horse3btn.IsEnabled = true;
            Horse4btn.IsEnabled = true;
            Horse5btn.IsEnabled = true;
            Horse6btn.IsEnabled = true;
            Horse7btn.IsEnabled = true;
            Horse8btn.IsEnabled = true;

            ticks = 0;

            BalanceSumLbl.Text = Player.Balance.ToString();
            BetSumLbl.Text = bet.ToString();
            HorseBetGrid.IsOpen = true;

            Setup();
        }

        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            startTime = DateTimeOffset.Now;
            lastTime = startTime;;
            dispatcherTimer.Start();
        }

        async void dispatcherTimer_Tick(object sender, object e)
        {
            DateTimeOffset time = DateTimeOffset.Now;
            TimeSpan span = time - lastTime;
            lastTime = time;
            // Calculate the speed of the horses
            await Task.Run(CalculateSpeed);

            // Make the horses move
            Horse1.Margin = new Thickness(Horse1.Margin.Left + _horses.Where(h => h.Number == 1).First().Speed, Horse1.Margin.Top, Horse1.Margin.Right, Horse1.Margin.Bottom);
            Horse2.Margin = new Thickness(Horse2.Margin.Left + _horses.Where(h => h.Number == 2).First().Speed, Horse2.Margin.Top, Horse2.Margin.Right, Horse2.Margin.Bottom);
            Horse3.Margin = new Thickness(Horse3.Margin.Left + _horses.Where(h => h.Number == 3).First().Speed, Horse3.Margin.Top, Horse3.Margin.Right, Horse3.Margin.Bottom);
            Horse4.Margin = new Thickness(Horse4.Margin.Left + _horses.Where(h => h.Number == 4).First().Speed, Horse4.Margin.Top, Horse4.Margin.Right, Horse4.Margin.Bottom);
            Horse5.Margin = new Thickness(Horse5.Margin.Left + _horses.Where(h => h.Number == 5).First().Speed, Horse5.Margin.Top, Horse5.Margin.Right, Horse5.Margin.Bottom);
            Horse6.Margin = new Thickness(Horse6.Margin.Left + _horses.Where(h => h.Number == 6).First().Speed, Horse6.Margin.Top, Horse6.Margin.Right, Horse6.Margin.Bottom);
            Horse7.Margin = new Thickness(Horse7.Margin.Left + _horses.Where(h => h.Number == 7).First().Speed, Horse7.Margin.Top, Horse7.Margin.Right, Horse7.Margin.Bottom);
            Horse8.Margin = new Thickness(Horse8.Margin.Left + _horses.Where(h => h.Number == 8).First().Speed, Horse8.Margin.Top, Horse8.Margin.Right, Horse8.Margin.Bottom);

            // Check if a horse has reached the finish line
            if (Horse1.Width + Horse1.Margin.Left >= Finish.Margin.Left)
            {
                if (_playerHorse == Horse1)
                {
                    var payout = bet / _horses.Where(h => h.Number == 1).First().GetWinChance(_horses);
                    Player.Balance += Math.Round(payout);
                }
                stopTime = time;

                dispatcherTimer.Stop();
                span = stopTime - startTime;
                await new MessageDialog($"Horse Number 1 \"{_horses.Where(h => h.Number == 1).First().Name}\" Won With {Number1Win.Text}").ShowAsync();
                ResetGame();
            }
            if (Horse2.Width + Horse2.Margin.Left >= Finish.Margin.Left)
            {
                if (_playerHorse == Horse2)
                {
                    var payout = bet / _horses.Where(h => h.Number == 2).First().GetWinChance(_horses);
                    Player.Balance += Math.Round(payout);
                }
                stopTime = time;

                dispatcherTimer.Stop();
                span = stopTime - startTime;
                await new MessageDialog($"Horse Number 2 \"{_horses.Where(h => h.Number == 2).First().Name}\" Won With {Number2Win.Text}").ShowAsync();
                ResetGame();
            }
            if (Horse3.Width + Horse3.Margin.Left >= Finish.Margin.Left)
            {
                if (_playerHorse == Horse3)
                {
                    var payout = bet / _horses.Where(h => h.Number == 3).First().GetWinChance(_horses);
                    Player.Balance += Math.Round(payout);
                }
                stopTime = time;

                dispatcherTimer.Stop();
                span = stopTime - startTime;
                await new MessageDialog($"Horse Number 3 \"{_horses.Where(h => h.Number == 3).First().Name}\" Won With {Number3Win.Text}").ShowAsync();
                ResetGame();
            }
            if (Horse4.Width + Horse4.Margin.Left >= Finish.Margin.Left)
            {
                if (_playerHorse == Horse4)
                {
                    var payout = bet / _horses.Where(h => h.Number == 4).First().GetWinChance(_horses);
                    Player.Balance += Math.Round(payout);
                }
                stopTime = time;

                dispatcherTimer.Stop();
                span = stopTime - startTime;
                await new MessageDialog($"Horse Number 4 \"{_horses.Where(h => h.Number == 4).First().Name}\" Won With {Number4Win.Text}").ShowAsync();
                ResetGame();
            }
            if (Horse5.Width + Horse5.Margin.Left >= Finish.Margin.Left)
            {
                if (_playerHorse == Horse5)
                {
                    var payout = bet / _horses.Where(h => h.Number == 5).First().GetWinChance(_horses);
                    Player.Balance += Math.Round(payout);
                }
                stopTime = time;

                dispatcherTimer.Stop();
                span = stopTime - startTime;
                await new MessageDialog($"Horse Number 5 \"{_horses.Where(h => h.Number == 5).First().Name}\" Won With {Number5Win.Text}").ShowAsync();
                ResetGame();
            }
            if (Horse6.Width + Horse6.Margin.Left >= Finish.Margin.Left)
            {
                if (_playerHorse == Horse6)
                {
                    var payout = bet / _horses.Where(h => h.Number == 6).First().GetWinChance(_horses);
                    Player.Balance += Math.Round(payout);
                }
                stopTime = time;

                dispatcherTimer.Stop();
                span = stopTime - startTime;
                await new MessageDialog($"Horse Number 6 \"{_horses.Where(h => h.Number == 6).First().Name}\" Won With {Number6Win.Text}").ShowAsync();
                ResetGame();
            }
            if (Horse7.Width + Horse7.Margin.Left >= Finish.Margin.Left)
            {
                if (_playerHorse == Horse7)
                {
                    var payout = bet / _horses.Where(h => h.Number == 7).First().GetWinChance(_horses);
                    Player.Balance += Math.Round(payout);
                }
                stopTime = time;

                dispatcherTimer.Stop();
                span = stopTime - startTime;
                await new MessageDialog($"Horse Number 7 \"{_horses.Where(h => h.Number == 7).First().Name}\" Won With {Number7Win.Text}").ShowAsync();
                ResetGame();
            }
            if (Horse8.Width + Horse8.Margin.Left >= Finish.Margin.Left)
            {
                if (_playerHorse == Horse8)
                {
                    var payout = bet / _horses.Where(h => h.Number == 8).First().GetWinChance(_horses);
                    Player.Balance += Math.Round(payout);
                }
                stopTime = time;

                dispatcherTimer.Stop();
                span = stopTime - startTime;
                await new MessageDialog($"Horse Number 8 \"{_horses.Where(h => h.Number == 8).First().Name}\" Won With {Number8Win.Text}").ShowAsync();
                ResetGame();
            }
        }

        private async void PlaceBetbtn_Click(object sender, RoutedEventArgs e)
        {
            if (bet <= 0 || bet > Player.Balance)
            {
                await new MessageDialog($"You Must Place a Bet Higher Than 0 and Less Than {Player.Balance + 1}!", "Invalid Bet!").ShowAsync();
                bet = 0;
                BetSumLbl.Text = bet.ToString();
                BalanceSumLbl.Text = Player.Balance.ToString();
                return;
            }
            else
            {
                Horse1btn.IsEnabled = false;
                Horse2btn.IsEnabled = false;
                Horse3btn.IsEnabled = false;
                Horse4btn.IsEnabled = false;
                Horse5btn.IsEnabled = false;
                Horse6btn.IsEnabled = false;
                Horse7btn.IsEnabled = false;
                Horse8btn.IsEnabled = false;

                Chip1btn.IsEnabled = false;
                Chip5btn.IsEnabled = false;
                Chip25btn.IsEnabled = false;
                Chip100btn.IsEnabled = false;
                Chip500btn.IsEnabled = false;
                Chip1000btn.IsEnabled = false;
                PlaceBetbtn.IsEnabled = false;
                HorseBetGrid.IsOpen = false;
                
                Startbtn.IsEnabled = true;
                
                
                Player.Balance -= bet;
            }
        }


        /// <summary>
        /// Updates the amount the player is going to bet
        /// </summary>
        /// <param name="playerBet"></param>
        private async void UpdateBet(int playerBet)
        {

            if (bet + playerBet > Player.Balance)
            {
                await new MessageDialog($"You Can Not Afford This Bet!", "Invalid Bet!").ShowAsync();
                return;
            }
            bet += playerBet;
            BetSumLbl.Text = bet.ToString();
            BalanceSumLbl.Text = (Player.Balance - bet).ToString();
        }

        private void Horse8btn_Click(object sender, RoutedEventArgs e)
        {
            PlaceBetbtn.IsEnabled = true;
            Horse1btn.IsEnabled = false;
            Horse2btn.IsEnabled = false;
            Horse3btn.IsEnabled = false;
            Horse4btn.IsEnabled = false;
            Horse5btn.IsEnabled = false;
            Horse6btn.IsEnabled = false;
            Horse7btn.IsEnabled = false;
            Horse8btn.IsEnabled = false;
            _playerHorse = Horse8;
        }

        private void Horse7btn_Click(object sender, RoutedEventArgs e)
        {
            PlaceBetbtn.IsEnabled = true;
            Horse1btn.IsEnabled = false;
            Horse2btn.IsEnabled = false;
            Horse3btn.IsEnabled = false;
            Horse4btn.IsEnabled = false;
            Horse5btn.IsEnabled = false;
            Horse6btn.IsEnabled = false;
            Horse7btn.IsEnabled = false;
            Horse8btn.IsEnabled = false;
            _playerHorse = Horse7;
        }

        private void Horse6btn_Click(object sender, RoutedEventArgs e)
        {
            PlaceBetbtn.IsEnabled = true;
            Horse1btn.IsEnabled = false;
            Horse2btn.IsEnabled = false;
            Horse3btn.IsEnabled = false;
            Horse4btn.IsEnabled = false;
            Horse5btn.IsEnabled = false;
            Horse6btn.IsEnabled = false;
            Horse7btn.IsEnabled = false;
            Horse8btn.IsEnabled = false;
            _playerHorse = Horse6;
        }

        private void Horse5btn_Click(object sender, RoutedEventArgs e)
        {
            PlaceBetbtn.IsEnabled = true;
            Horse1btn.IsEnabled = false;
            Horse2btn.IsEnabled = false;
            Horse3btn.IsEnabled = false;
            Horse4btn.IsEnabled = false;
            Horse5btn.IsEnabled = false;
            Horse6btn.IsEnabled = false;
            Horse7btn.IsEnabled = false;
            Horse8btn.IsEnabled = false;
            _playerHorse = Horse5;
        }

        private void Horse4btn_Click(object sender, RoutedEventArgs e)
        {
            PlaceBetbtn.IsEnabled = true;
            Horse1btn.IsEnabled = false;
            Horse2btn.IsEnabled = false;
            Horse3btn.IsEnabled = false;
            Horse4btn.IsEnabled = false;
            Horse5btn.IsEnabled = false;
            Horse6btn.IsEnabled = false;
            Horse7btn.IsEnabled = false;
            Horse8btn.IsEnabled = false;
            _playerHorse = Horse4;
        }

        private void Horse3btn_Click(object sender, RoutedEventArgs e)
        {
            PlaceBetbtn.IsEnabled = true;
            Horse1btn.IsEnabled = false;
            Horse2btn.IsEnabled = false;
            Horse3btn.IsEnabled = false;
            Horse4btn.IsEnabled = false;
            Horse5btn.IsEnabled = false;
            Horse6btn.IsEnabled = false;
            Horse7btn.IsEnabled = false;
            Horse8btn.IsEnabled = false;
            _playerHorse = Horse3;
        }

        private void Horse2btn_Click(object sender, RoutedEventArgs e)
        {
            PlaceBetbtn.IsEnabled = true;
            Horse1btn.IsEnabled = false;
            Horse2btn.IsEnabled = false;
            Horse3btn.IsEnabled = false;
            Horse4btn.IsEnabled = false;
            Horse5btn.IsEnabled = false;
            Horse6btn.IsEnabled = false;
            Horse7btn.IsEnabled = false;
            Horse8btn.IsEnabled = false;
            _playerHorse = Horse2;
        }

        private void Horse1btn_Click(object sender, RoutedEventArgs e)
        {
            PlaceBetbtn.IsEnabled = true;
            Horse1btn.IsEnabled = false;
            Horse2btn.IsEnabled = false;
            Horse3btn.IsEnabled = false;
            Horse4btn.IsEnabled = false;
            Horse5btn.IsEnabled = false;
            Horse6btn.IsEnabled = false;
            Horse7btn.IsEnabled = false;
            Horse8btn.IsEnabled = false;
            _playerHorse = Horse1;
        }


        #region Bet buttons
        private void Chip1btn_Click(object sender, RoutedEventArgs e)
        {
            UpdateBet(1);
        }

        private void Chip5btn_Click(object sender, RoutedEventArgs e)
        {
            UpdateBet(5);
        }

        private void Chip25btn_Click(object sender, RoutedEventArgs e)
        {
            UpdateBet(25);
        }

        private void Chip100btn_Click(object sender, RoutedEventArgs e)
        {
            UpdateBet(100);
        }

        private void Chip500btn_Click(object sender, RoutedEventArgs e)
        {
            UpdateBet(500);
        }

        private void Chip1000btn_Click(object sender, RoutedEventArgs e)
        {
            UpdateBet(1000);
        }
        #endregion

    }
}
