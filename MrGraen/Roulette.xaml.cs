using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class Roulette : Page
    {
        double balance = Player.Balance;
        double betAmountChoosen = 0;
        bool betPlaced = false;
        string buttonPressed = "";


        public Roulette()
        {
            this.InitializeComponent();
            updateBalance();
            

            



        }
        public void updateBalance()
        {
            balanceLabel.Text = $"Balance: {balance}";
            Player.Balance = balance;
        }
        public async void chooseBet(Button sender)
        {
            if (betPlaced == false)
            {
                if (betAmountChoosen <= balance)
                {
                    balance -= betAmountChoosen;
                    updateBalance();
                    buttonPressed = sender.Name;
                    betPlaced = true;

                }
                else
                {
                    var error = new MessageDialog("You do not have the required balance to complete this bet, refill your balance or choose a lower amount");
                    await error.ShowAsync();
                }
            }
            else
            {
                var error = new MessageDialog("You have already placed your bet, press 'Spin'");
                await error.ShowAsync();
            }
            
        }
        #region Buttons
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            chooseBet(sender as Button);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button10_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button13_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button14_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button15_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button18_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button17_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button16_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button19_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button20_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button21_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button24_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button23_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button22_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button25_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button26_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button27_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button28_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button29_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button30_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button33_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button32_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button31_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button34_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button35_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button36_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLine1_Click(object sender, RoutedEventArgs e)
        {
            chooseBet(sender as Button);
        }

        private void ButtonLine2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLine3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Green0Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button1to12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button12to24_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button24to36_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button1to18_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EvenButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRed_Click(object sender, RoutedEventArgs e)
        {
            chooseBet(sender as Button);
        }

        private void ButtonBlack_Click(object sender, RoutedEventArgs e)
        {
            chooseBet(sender as Button);
        }

        private void OddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button19to36_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Bet1Button_Click(object sender, RoutedEventArgs e)
        {
            betAmountChoosen = 1;

        }
        private void Bet5Button_Click(object sender, RoutedEventArgs e)
        {
            betAmountChoosen = 5;

        }

        private void Bet25Button_Click(object sender, RoutedEventArgs e)
        {
            betAmountChoosen = 25;
        }

        private void Bet500Button_Click(object sender, RoutedEventArgs e)
        {
            betAmountChoosen = 500;
        }

        private void Bet100Button_Click(object sender, RoutedEventArgs e)
        {
            betAmountChoosen = 100;
        }

        private void Bet1000Button_Click(object sender, RoutedEventArgs e)
        {
            betAmountChoosen = 1000;
        }
        #endregion

        private async void SpinButton_Click(object sender, RoutedEventArgs e)
        {
            if (betPlaced)
            {
                List<int> line1 = new List<int> {3,6,9,12,15,18,21,24,27,30,33,36 };
                List<int> line2 = new List<int> {2,5,8,11,14,17,20,23,26,29,32,35 };
                List<int> line3 = new List<int> {1,4,7,10,13,16,19,22,25,28,31,34};

                betPlaced = false;
                var random = new Random();
                var rNum = random.Next(0, 36);
                #region switchCase
                switch (buttonPressed.Substring(6))
                {
                    case "Red":
                        if (rNum % 2 != 0)
                        {
                            resultLabel.Text = $"You won {betAmountChoosen * 2} \nThe result was {rNum}";
                            balance += betAmountChoosen * 2;
                            updateBalance();
                        }
                        else
                        {
                            resultLabel.Text = $"You lost! The result was {rNum} ";
                        }
                        break;
                    case "Black":
                        if (rNum % 2 == 0)
                        {
                            resultLabel.Text = $"You won {betAmountChoosen * 2} \nThe result was {rNum}";
                            balance += betAmountChoosen * 2;
                            updateBalance();
                        }
                        else
                        {
                            resultLabel.Text = $"You lost! The result was {rNum} ";
                        }
                        break;

                    case "Line1":
                        if (line1.Contains(rNum)) 
                        {
                            resultLabel.Text = $"You won {betAmountChoosen * 3} \nThe result was {rNum}";
                            balance += betAmountChoosen * 3;
                            updateBalance();
                        }
                        else
                        {
                            resultLabel.Text = $"You lost! The result was {rNum} ";
                        }
                        break;
                    case "Line2":
                        if (line2.Contains(rNum))
                        {
                            resultLabel.Text = $"You won {betAmountChoosen * 1.33} \nThe result was {rNum}";
                            balance += betAmountChoosen * 1.33;
                            updateBalance();
                        }
                        else
                        {
                            resultLabel.Text = $"You lost! The result was {rNum} ";
                        }
                        break;

                #endregion




                }




            }
            else
            {
                var error = new MessageDialog("It seems you have not choosen a bet, try again.");
                await error.ShowAsync();
            }

        }

       
    }
}
