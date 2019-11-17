//-----------------------------------------------------------------------
// <copyright file="MainMenu.xaml.cs" company="Ian Burroughs, Mike Boudreau, Brandon Biles & James A. Schulze">
//     Copyright (c) Ian Burroughs, Mike Boudreau, Brandon Biles & James A. Schulze. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace farkle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu" /> class.
        /// </summary>
        public MainMenu()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Start button click event.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            int d = 0;

            if (cbxEasy.IsChecked == true)
            {
                d = 1;
            }
            else if(cbxHard.IsChecked == true)
            {
                d = 2;
            }

            if ((bool)rdoOnePlayer.IsChecked == true)
            {
                if(rdoOneAI.IsChecked == true)
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.OnePlayer = true;
                    farkleGame.AICount = 1;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
                else
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.OnePlayer = true;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
            }
            else if ((bool)rdoTwoPlayer.IsChecked == true)
            {
                if (rdoOneAI.IsChecked == true)
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.TwoPlayer = true;
                    farkleGame.AICount = 1;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
                else if (rdoTwoAI.IsChecked == true)
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.TwoPlayer = true;
                    farkleGame.AICount = 2;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
                else
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.TwoPlayer = true;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
            }
            else if ((bool)rdoThreePlayer.IsChecked == true)
            {
                if (rdoOneAI.IsChecked == true)
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.ThreePlayer = true;
                    farkleGame.AICount = 1;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
                else if (rdoTwoAI.IsChecked == true)
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.ThreePlayer = true;
                    farkleGame.AICount = 2;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
                else if (rdoThreeAI.IsChecked == true)
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.ThreePlayer = true;
                    farkleGame.AICount = 3;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
                else
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.ThreePlayer = true;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
            }
            else
            {
                if (rdoOneAI.IsChecked == true)
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.FourPlayer = true;
                    farkleGame.AICount = 1;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
                else if (rdoTwoAI.IsChecked == true)
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.FourPlayer = true;
                    farkleGame.AICount = 2;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
                else if (rdoThreeAI.IsChecked == true)
                {
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.FourPlayer = true;
                    farkleGame.AICount = 3;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
                else if (rdoFourAI.IsChecked == true)
                {
                    // Four players was selected.
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.FourPlayer = true;
                    farkleGame.AICount = 4;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
                else
                {
                    // Four players was selected.
                    MainWindow farkleGame = new MainWindow();
                    farkleGame.FourPlayer = true;
                    farkleGame.Difficulty = d;
                    farkleGame.Show();
                }
            }

            // Close current form.
            this.Close();
        }

        /// <summary>
        /// Scoring button click event.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void BtnScoring_Click(object sender, RoutedEventArgs e)
        {
            Scoring scoringLegend = new Scoring();
            scoringLegend.Show();
        }

        /// <summary>
        /// About button click event.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            // Show message box with developers names and the rules to farkle.
            MessageBox.Show("Developers: Ian Burroughs, Mike Boudreau, Brandon Biles & James A. Schulze." + "Date: October 2019", "Information");

            MessageBox.Show(
                "First player to 10000 points wins." + "\n" +
                            "The player rolls all 6 of their dice at the start of their turn." + "\n" +
                            "After every roll at least 1 scorable die must be set aside." + "\n" +
                            "The player at this point could either end their turn to save their points or roll their remaining dice to try and increase their score." + "\n" +
                            "If the player has recieved a score on all 6 dice then the player gets to roll all 6 dice again, this is called 'Hot Dice'" + "\n" +
                            "There is no limit to the amount of 'Hot Dice' a player can get, but if the player rolls no scoreable dice then the player losses all their points from that round." + "\n" +
                            "If the player has no scoreable dice then there turn is over and the player recieves no point for that turn, this is called a 'farkle'.",
                     "Rules");
        }

        private void RdoOnePlayer_Checked(object sender, RoutedEventArgs e)
        {
            rdoOneAI.Visibility = Visibility.Visible;
            rdoTwoAI.Visibility = Visibility.Hidden;
            rdoThreeAI.Visibility = Visibility.Hidden;
            rdoFourAI.Visibility = Visibility.Hidden;
            rdoTwoAI.IsChecked = false;
            rdoThreeAI.IsChecked = false;
            rdoFourAI.IsChecked = false;
        }

        private void RdoTwoPlayer_Checked(object sender, RoutedEventArgs e)
        {
            rdoOneAI.Visibility = Visibility.Visible;
            rdoTwoAI.Visibility = Visibility.Visible;
            rdoThreeAI.Visibility = Visibility.Hidden;
            rdoFourAI.Visibility = Visibility.Hidden;
            rdoThreeAI.IsChecked = false;
            rdoFourAI.IsChecked = false;
        }

        private void RdoThreePlayer_Checked(object sender, RoutedEventArgs e)
        {
            rdoOneAI.Visibility = Visibility.Visible;
            rdoTwoAI.Visibility = Visibility.Visible;
            rdoThreeAI.Visibility = Visibility.Visible;
            rdoFourAI.Visibility = Visibility.Hidden;
            rdoFourAI.IsChecked = false;
        }

        private void RdoFourPlayers_Checked(object sender, RoutedEventArgs e)
        {
            rdoOneAI.Visibility = Visibility.Visible;
            rdoTwoAI.Visibility = Visibility.Visible;
            rdoThreeAI.Visibility = Visibility.Visible;
            rdoFourAI.Visibility = Visibility.Visible;
        }

        private void CbxEasy_Checked(object sender, RoutedEventArgs e)
        {
            if (cbxHard.IsChecked == true)
            {
                cbxHard.IsChecked = false;
            }
        }

        private void CbxHard_Checked(object sender, RoutedEventArgs e)
        {
            if (cbxEasy.IsChecked == true)
            {
                cbxEasy.IsChecked = false;
            }
        }

        private void RdoZeroAI_Checked(object sender, RoutedEventArgs e)
        {
            cbxHard.IsEnabled = false;
            cbxEasy.IsEnabled = false;
            cbxHard.IsChecked = false;
            cbxEasy.IsChecked = false;
        }

        private void RdoOneAI_Checked(object sender, RoutedEventArgs e)
        {
            cbxHard.IsEnabled = true;
            cbxEasy.IsEnabled = true;
            if (rdoOneAI.IsChecked == true)
            {
                cbxHard.Visibility = Visibility.Visible;
                cbxEasy.Visibility = Visibility.Visible;
            }
            else if (rdoZeroAI.IsChecked == true)
            {
                cbxHard.Visibility = Visibility.Hidden;
                cbxEasy.Visibility = Visibility.Hidden;
            }
        }

        private void RdoTwoAI_Checked(object sender, RoutedEventArgs e)
        {
            cbxHard.IsEnabled = true;
            cbxEasy.IsEnabled = true;
            if (rdoTwoAI.IsChecked == true)
            {
                cbxHard.Visibility = Visibility.Visible;
                cbxEasy.Visibility = Visibility.Visible;
            }
            else if (rdoZeroAI.IsChecked == true)
            {
                cbxHard.Visibility = Visibility.Hidden;
                cbxEasy.Visibility = Visibility.Hidden;
            }
        }

        private void RdoThreeAI_Checked(object sender, RoutedEventArgs e)
        {
            cbxHard.IsEnabled = true;
            cbxEasy.IsEnabled = true;

            if (rdoThreeAI.IsChecked == true)
            {
                cbxHard.Visibility = Visibility.Visible;
                cbxEasy.Visibility = Visibility.Visible;
            }
            else if (rdoZeroAI.IsChecked == true)
            {
                cbxHard.Visibility = Visibility.Hidden;
                cbxEasy.Visibility = Visibility.Hidden;
            }
        }

        private void RdoFourAI_Checked(object sender, RoutedEventArgs e)
        {
            cbxHard.IsEnabled = true;
            cbxEasy.IsEnabled = true;

            if (rdoFourAI.IsChecked == true)
            {
                cbxHard.Visibility = Visibility.Visible;
                cbxEasy.Visibility = Visibility.Visible;
            }
            else if (rdoZeroAI.IsChecked == true)
            {
                cbxHard.Visibility = Visibility.Hidden;
                cbxEasy.Visibility = Visibility.Hidden;
            }
        }
    }
}