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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace MrGraen
{
    public sealed partial class HorseRace : Page
    {
        public HorseRace()
        {
            this.InitializeComponent();

            BalanceSumLbl.Text = Player.Balance.ToString();

            Setup();
        }

        public async void Setup()
        {
            Race race = await Task.Run(() => new Race(8));

            Number1Win.Text = $"{race.Horses.Where(h => h.Number == 1).First().WinWeight}%";
            Number2Win.Text = $"{race.Horses.Where(h => h.Number == 2).First().WinWeight}%";
            Number3Win.Text = $"{race.Horses.Where(h => h.Number == 3).First().WinWeight}%";
            Number4Win.Text = $"{race.Horses.Where(h => h.Number == 4).First().WinWeight}%";
            Number5Win.Text = $"{race.Horses.Where(h => h.Number == 5).First().WinWeight}%";
            Number6Win.Text = $"{race.Horses.Where(h => h.Number == 6).First().WinWeight}%";
            Number7Win.Text = $"{race.Horses.Where(h => h.Number == 7).First().WinWeight}%";
            Number8Win.Text = $"{race.Horses.Where(h => h.Number == 8).First().WinWeight}%";

            Name1.Text = $"{race.Horses.Where(h => h.Number == 1).First().Name}";
            Name2.Text = $"{race.Horses.Where(h => h.Number == 2).First().Name}";
            Name3.Text = $"{race.Horses.Where(h => h.Number == 3).First().Name}";
            Name4.Text = $"{race.Horses.Where(h => h.Number == 4).First().Name}";
            Name5.Text = $"{race.Horses.Where(h => h.Number == 5).First().Name}";
            Name6.Text = $"{race.Horses.Where(h => h.Number == 6).First().Name}";
            Name7.Text = $"{race.Horses.Where(h => h.Number == 7).First().Name}";
            Name8.Text = $"{race.Horses.Where(h => h.Number == 8).First().Name}";
        }


        #region Bet buttons
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
        #endregion


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

        }

        private void PlaceBetbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Horse8btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Horse7btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Horse6btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Horse5btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Horse4btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Horse3btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Horse2btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Horse1btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    class Horse
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public int WinWeight = (new Random()).Next(1, 100);

        public Horse(int number, string name)
        {
            Number = number;
            Name = name;
        }
    }

    class Race
    {
        public List<Horse> Horses { get; set; }

        public int HorsesAmount { get; set; }

        private List<string> _names = new List<string>() { "Hans", "Grethe", "Kenneth", "Morten", "Hans", "Erape", "Ruth", "Cock", "Jørgen" };

        public Race(int horsesAmount)
        {
            HorsesAmount = horsesAmount;

            Horses = new List<Horse>();

            List<string> unusedNames = new List<string>(_names);

            Random rnd = new Random();
            for (int i = 0; i < HorsesAmount; i++)
            {
                int nameIndex = rnd.Next(0, unusedNames.Count() - 1);
                string name = unusedNames[nameIndex];
                unusedNames.RemoveAt(nameIndex);

                if (unusedNames.Count() <= 0)
                {
                    unusedNames = new List<string>(_names);
                }

                Horses.Add(new Horse(i + 1, name));
            }
        }

        internal Horse GetWinner()
        {
            Random rnd = new Random();

            int totalWeight = 0;
            foreach (Horse horse in Horses)
            {
                totalWeight += horse.WinWeight;
            }

            int winnerWeight = rnd.Next(1, totalWeight);

            foreach (Horse horse in Horses)
            {
                if (winnerWeight <= horse.WinWeight)
                {
                    return horse;
                }
                winnerWeight -= horse.WinWeight;
            }

            return null;
        }

        public void Run()
        {
            return;
        }
    }
}
