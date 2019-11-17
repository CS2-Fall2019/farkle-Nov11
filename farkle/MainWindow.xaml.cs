//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Ian Burroughs, Mike Boudreau, Brandon Biles & James A. Schulze">
//     Copyright (c) Ian Burroughs, Mike Boudreau, Brandon Biles & James A. Schulze. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace farkle
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Media;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// True if one player was selected.
        /// </summary>
        private int difficulty;

        /// <summary>
        /// True if one player was selected.
        /// </summary>
        private bool onePlayer;

        /// <summary>
        /// True if two players was selected.
        /// </summary>
        private bool twoPlayer;

        /// <summary>
        /// True if three players was selected.
        /// </summary>
        private bool threePlayer;

        /// <summary>
        /// True if four players was selected.
        /// </summary>
        private bool fourPlayer;

        /// <summary>
        /// True if player farkled.
        /// </summary>
        private bool playerFarkle = false;

        /// <summary>
        /// True if player farkled.
        /// </summary>
        private int AIcount = 0;

        /// <summary>
        /// The Die 1.
        /// </summary>
        private Dice die1 = new Dice();

        /// <summary>
        /// The Die 2.
        /// </summary>
        private Dice die2 = new Dice();

        /// <summary>
        /// The Die 3.
        /// </summary>
        private Dice die3 = new Dice();

        /// <summary>
        /// The Die 4.
        /// </summary>
        private Dice die4 = new Dice();

        /// <summary>
        /// The Die 5.
        /// </summary>
        private Dice die5 = new Dice();

        /// <summary>
        /// The Die 6.
        /// </summary>
        private Dice die6 = new Dice();

        /// <summary>
        /// The list of Dice.
        /// </summary>
        private List<int> diceList = new List<int>();

        /// <summary>
        /// The list of currently saved dice.
        /// </summary>
        private List<Dice> savedDieList = new List<Dice>();

        /// <summary>
        /// The list of dice still in play on the board.
        /// </summary>
        private List<Dice> diceInPlay = new List<Dice>();

        /// <summary>
        /// List of dice saved on first roll. The locked1 value is true.
        /// </summary>
        private List<Dice> locked1List = new List<Dice>();

        /// <summary>
        /// List of dice saved on second roll. The locked2 value is true.
        /// </summary>
        private List<Dice> locked2List = new List<Dice>();

        /// <summary>
        /// List of dice saved on third roll. The locked3 value is true.
        /// </summary>
        private List<Dice> locked3List = new List<Dice>();

        /// <summary>
        /// List of dice saved on fourth roll. The locked4 value is true.
        /// </summary>
        private List<Dice> locked4List = new List<Dice>();

        /// <summary>
        /// List of dice saved on fifth roll. The locked5 value is true.
        /// </summary>
        private List<Dice> locked5List = new List<Dice>();

        /// <summary>
        /// Incrementer for the number of rolls in that turn. Resets if hotDice is true.
        /// </summary>
        private int rollIncrementer = 0;

        /// <summary>
        /// List of players in the game.
        /// </summary>
        private List<Player> currentPlayerList = new List<Player>();

        /// <summary>
        /// Random generator for dice rolling.
        /// </summary>
        private Random rand = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            // TODO: ScoreDice button needs to be depricated before we turn this in.
            // Score dice button should be disabeled till the roll dice button has been clicked.
            // Dice checkboxes should be dissabled till the roll dice button has been clicked.
        }

        /// <summary>
        /// True if player farkled.
        /// </summary>
        public int AICount
        {
            get => this.AIcount;
            set => this.AIcount = value;
        }

        /// <summary>
        /// True if player farkled.
        /// </summary>
        public int Difficulty
        {
            get => this.difficulty;
            set => this.difficulty = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether playerFarkle is true or false.
        /// </summary>
        public bool PlayerFarkle
        {
            get => this.playerFarkle;
            set => this.playerFarkle = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether onePlayer is true or false.
        /// </summary>
        public bool OnePlayer
        {
            get => this.onePlayer;
            set => this.onePlayer = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether twoPlayer is true or false.
        /// </summary>
        public bool TwoPlayer
        {
            get => this.twoPlayer;
            set => this.twoPlayer = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether threePlayer is true or false.
        /// </summary>
        public bool ThreePlayer
        {
            get => this.threePlayer;
            set => this.threePlayer = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether fourPlayer is true or false.
        /// </summary>
        public bool FourPlayer
        {
            get => this.fourPlayer;
            set => this.fourPlayer = value;
        }

        /// <summary>
        /// Gets or sets die1.
        /// </summary>
        public Dice Die1
        {
            get => this.die1;
            set => this.die1 = value;
        }

        /// <summary>
        /// Gets or sets die2.
        /// </summary>
        public Dice Die2
        {
            get => this.die2;
            set => this.die2 = value;
        }

        /// <summary>
        /// Gets or sets die3.
        /// </summary>
        public Dice Die3
        {
            get => this.die3;
            set => this.die3 = value;
        }

        /// <summary>
        /// Gets or sets die4.
        /// </summary>
        public Dice Die4
        {
            get => this.die4;
            set => this.die4 = value;
        }

        /// <summary>
        /// Gets or sets die5.
        /// </summary>
        public Dice Die5
        {
            get => this.die5;
            set => this.die5 = value;
        }

        /// <summary>
        /// Gets or sets die6.
        /// </summary>
        public Dice Die6
        {
            get => this.die6;
            set => this.die6 = value;
        }

        /// <summary>
        /// Gets or sets this.diceList.
        /// </summary>
        public List<int> DiceList
        {
            get => this.diceList;
            set => this.diceList = value;
        }

        /// <summary>
        /// Gets or sets this.savedDieList.
        /// </summary>
        public List<Dice> SavedDieList
        {
            get => this.savedDieList;
            set => this.savedDieList = value;
        }

        /// <summary>
        /// Gets or sets this.diceInPlay.
        /// </summary>
        public List<Dice> DiceInPlay
        {
            get => this.diceInPlay;
            set => this.diceInPlay = value;
        }

        /// <summary>
        /// Gets or sets locked1List.
        /// </summary>
        public List<Dice> Locked1List
        {
            get => this.locked1List;
            set => this.locked1List = value;
        }

        /// <summary>
        /// Gets or sets locked2List.
        /// </summary>
        public List<Dice> Locked2List
        {
            get => this.locked2List;
            set => this.locked2List = value;
        }

        /// <summary>
        /// Gets or sets locked3List.
        /// </summary>
        public List<Dice> Locked3List
        {
            get => this.locked3List;
            set => this.locked3List = value;
        }

        /// <summary>
        /// Gets or sets locked4List.
        /// </summary>
        public List<Dice> Locked4List
        {
            get => this.locked4List;
            set => this.locked4List = value;
        }

        /// <summary>
        /// Gets or sets locked5List.
        /// </summary>
        public List<Dice> Locked5List
        {
            get => this.locked5List;
            set => this.locked5List = value;
        }

        /// <summary>
        /// Gets or sets this.currentPlayerList.
        /// </summary>
        public List<Player> CurrentPlayerList
        {
            get => this.currentPlayerList;
            set => this.currentPlayerList = value;
        }

        /// <summary>
        /// Gets or sets rand.
        /// </summary>
        public Random Rand
        {
            get => this.rand;
            set => this.rand = value;
        }

        /// <summary>
        /// Method to set the images of the dice.
        /// </summary>
        public void SetDiceImg()
        {
            this.die1.Pips = this.diceList[0];
            this.die2.Pips = this.diceList[1];
            this.die3.Pips = this.diceList[2];
            this.die4.Pips = this.diceList[3];
            this.die5.Pips = this.diceList[4];
            this.die6.Pips = this.diceList[5];

            // For die 1
            if (this.die1.Pips >= 1 && this.die1.Pips <= 6)
            {
                imgRoll1.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + this.die1.Pips.ToString() + "Die.jpg"));
            }
            else
            {
                // die 1 is null and nothing needs to be done
            }

            // For die 2
            if (this.die2.Pips >= 1 && this.die2.Pips <= 6)
            {
                imgRoll2.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + this.die2.Pips.ToString() + "Die.jpg"));
            }
            else
            {
                // die 1 is null and nothing needs to be done
            }

            // For die 3
            if (this.die3.Pips >= 1 && this.die3.Pips <= 6)
            {
                imgRoll3.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + this.die3.Pips.ToString() + "Die.jpg"));
            }
            else
            {
                // die 1 is null and nothing needs to be done
            }

            // For die 4
            if (this.die4.Pips >= 1 && this.die4.Pips <= 6)
            {
                imgRoll4.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + this.die4.Pips.ToString() + "Die.jpg"));
            }
            else
            {
                // die 1 is null and nothing needs to be done
            }

            // For die 5
            if (this.die5.Pips >= 1 && this.die5.Pips <= 6)
            {
                imgRoll5.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + this.die5.Pips.ToString() + "Die.jpg"));
            }
            else
            {
                // die 1 is null and nothing needs to be done
            }

            // For die 6
            if (this.die6.Pips >= 1 && this.die6.Pips <= 6)
            {
                imgRoll6.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + this.die6.Pips.ToString() + "Die.jpg"));
            }
            else
            {
                // die 1 is null and nothing needs to be done
            }
        }

        /// <summary>
        /// Method to Check the Dice.
        /// </summary>
        public int[] CheckDice()     // todo return value for int method. (changed to void to make it work temporarily)
        {
            // Set up a boolean value to hold true if there is a straight.
            bool straight = false;

            // Set up bool values to hold true if counters are pairs.
            bool pairOnes = false;
            bool pairTwos = false;
            bool pairThrees = false;
            bool pairFours = false;
            bool pairFives = false;
            bool pairSixes = false;

            // Set up a bool value to hold true if there are three pairs.
            bool threePairs = false;

            // Set up a bool value to hold true if there are scorable dice.
            bool scoreableDice = false;


            // Clear diceInPlay.
            diceInPlay.Clear();

            // If imgRoll1 is in play.
            if (imgRoll1.IsVisible)
            {
                // Add the first die.
                diceInPlay.Add(die1);
            }

            // If imgRoll2 is in play.
            if (imgRoll2.IsVisible)
            {
                // Add the second die.
                diceInPlay.Add(die2);
            }

            // If imgRoll3 is in play.
            if (imgRoll3.IsVisible)
            {
                // Add the third die.
                diceInPlay.Add(die3);
            }

            // If imgRoll4 is in play.
            if (imgRoll4.IsVisible)
            {
                // Add the fourth die.
                diceInPlay.Add(die4);
            }

            // If imgRoll5 is in play.
            if (imgRoll5.IsVisible)
            {
                // Add the fifth die.
                diceInPlay.Add(die5);
            }

            // If imgRoll6 is in play.
            if (imgRoll6.IsVisible)
            {
                // Add the first die.
                diceInPlay.Add(die6);
            }


            // Counters for each dice number.
            int oneCounter = 0;
            int twoCounter = 0;
            int threeCounter = 0;
            int fourCounter = 0;
            int fiveCounter = 0;
            int sixCounter = 0;

            // Loop through diceInPlay.
            foreach (Dice die in diceInPlay)
            {
                // Increment the counters.
                if (die.Pips == 1)
                {
                    oneCounter++;
                }
                else if (die.Pips == 2)
                {
                    twoCounter++;
                }
                else if (die.Pips == 3)
                {
                    threeCounter++;
                }
                else if (die.Pips == 4)
                {
                    fourCounter++;
                }
                else if (die.Pips == 5)
                {
                    fiveCounter++;
                }
                else
                {
                    // Die is 6, increment the six counter.
                    sixCounter++;
                }
            }

            if (diceInPlay.Count == 6)
            {
                // Check for a straight.
                if (oneCounter == 1 && twoCounter == 1 && threeCounter == 1 &&
                    fourCounter == 1 && fiveCounter == 1 && sixCounter == 1)
                {
                    // Set bool straight to true.
                    straight = true;
                }
                else if (oneCounter > 0 || fiveCounter > 0 || twoCounter >= 3 || threeCounter >= 3 ||
                         fourCounter >= 3 || sixCounter >= 3)
                {
                    // Set scoreableDice to true.
                    scoreableDice = true;
                }
                else
                {
                    // Check for pairs.
                    // If theres a pair of ones.
                    if (oneCounter == 2)
                    {
                        // Set pairOnes as true.
                        pairOnes = true;
                    }

                    // If theres a pair of twos.
                    if (twoCounter == 2)
                    {
                        // Set pairTwos as true.
                        pairTwos = true;
                    }

                    // If theres a pair of threes.
                    if (threeCounter == 2)
                    {
                        // Set pairThrees as true.
                        pairThrees = true;
                    }

                    // If theres a pair of fours.
                    if (fourCounter == 2)
                    {
                        // Set pairFours as true.
                        pairFours = true;
                    }

                    // If theres a pair of fives.
                    if (fiveCounter == 2)
                    {
                        // Set pairFives as true.
                        pairFives = true;
                    }

                    // If theres a pair of sixes.
                    if (sixCounter == 2)
                    {
                        // Set pairSixes as true.
                        pairSixes = true;
                    }

                    // Check for three pairs.
                    // If theres a pair of ones.
                    if (pairOnes)
                    {
                        // Check if theres another pair.
                        if (pairTwos)
                        {
                            // Check if theres a third pair.
                            if (pairThrees)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairFours)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairThrees)
                        {
                            // Check if theres a third pair.
                            if (pairFours)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairFours)
                        {
                            // Check if theres a third pair.
                            if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairFives)
                        {
                            // Check if theres a third pair.
                            if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else
                        {
                            // There are not three pairs.
                        }
                    }
                    else if (pairTwos)
                    {
                        // Check if theres another pair.
                        if (pairThrees)
                        {
                            // Check if theres a third pair.
                            if (pairFours)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairFours)
                        {
                            // Check if theres a third pair.
                            if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairFives)
                        {
                            // Check if theres a third pair.
                            if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else
                        {
                            // There are not three pairs.
                        }
                    }
                    else if (pairThrees)
                    {
                        // Check if theres another pair.
                        if (pairFours)
                        {
                            // Check if theres a third pair.
                            if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairFives)
                        {
                            // Check if theres a third pair.
                            if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else
                        {
                            // There are not three pairs.
                        }
                    }
                    else if (pairFours)
                    {
                        // Check if theres another pair.
                        if (pairFives)
                        {
                            // Check if theres a third pair.
                            if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else
                        {
                            // There are not three pairs.
                        }
                    }
                    else
                    {
                        // There are not three pairs.
                    }
                }

                // Check all bool values to see if there are scorable dice.
                if (straight || threePairs || scoreableDice)
                {
                    // There are scorable dice.
                }
                else
                {
                    // Set farkle to true.
                    playerFarkle = true;
                }

            }
            else if (diceInPlay.Count >= 3)
            {
                if (twoCounter < 3 && threeCounter < 3 && fourCounter < 3 && sixCounter < 3
                    && oneCounter == 0 && fiveCounter == 0)
                {
                    // Set farkle to true.
                    playerFarkle = true;
                }
                else
                {
                    // There are scorable dice.
                }
            }
            else if (diceInPlay.Count < 3 && diceInPlay.Count > 0)
            {
                // Check the one and five counters to see if they are greater than 0.
                if (oneCounter == 0 && fiveCounter == 0)
                {
                    // Set farkle to true.
                    playerFarkle = true;
                }
                else
                {
                    // There are scorable dice.
                }
            }

            bool threeOnes = false;
            bool threeTwos = false;
            bool threeThrees = false;
            bool threeFours = false;
            bool threeFives = false;
            bool threeSixes = false;

            // todo make sure theres not a problem with being greater than 3.
            if (oneCounter >= 3)
            {
                threeOnes = true;
            }

            if (twoCounter >= 3)
            {
                threeTwos = true;
            }

            if (threeCounter >= 3)
            {
                threeThrees = true;
            }

            if (fourCounter >= 3)
            {
                threeFours = true;
            }

            if (fiveCounter >= 3)
            {
                threeFives = true;
            }

            if (sixCounter >= 3)
            {
                threeSixes = true;
            }

            bool threeOfAKinds = false;
            // Check for 2 3-of-a-kinds.
            if (threeOnes)
            {
                if (threeTwos)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else if (threeThrees)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else if (threeFours)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else if (threeFives)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else if (threeSixes)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else
                {
                    // Theres not 2 3-of-a-kinds.
                }
            }
            else if (threeTwos)
            {
                if (threeThrees)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else if (threeFours)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else if (threeFives)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else if (threeSixes)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else
                {
                    // Theres not 2 3-of-a-kinds.
                }
            }
            else if (threeThrees)
            {
                if (threeFours)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else if (threeFives)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else if (threeSixes)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else
                {
                    // Theres not 2 3-of-a-kinds.
                }
            }
            else if (threeFours)
            {
                if (threeFives)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else if (threeSixes)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else
                {
                    // Theres not 2 3-of-a-kinds.
                }
            }
            else if (threeFives)
            {
                if (threeSixes)
                {
                    // There is 2 3-of-a-kinds.
                    // Set threeOfAKinds to true.
                    threeOfAKinds = true;
                }
                else
                {
                    // Theres not 2 3-of-a-kinds.
                }
            }
            else
            {
                // There is not 2 3-of-a-kinds.
            }
            


            /*
          * I didnt know how else to get this information out of the method without copying the whole thing
          * and that doesnt seem effecient. So I decided to make a "packet" like thing. 
          * This packet called AIPackage will store information that is neccessary for the AI to determine whether
          * to take die or not.  
          * the array elements in order are 
          * 0: ScoreableDice
          * 1: oneCounter
          * 2: fiveCounter
          * 3: pairOnes
          * 4: pairTwos
          * 5: pairThrees
          * 6: pairFours
          * 7: pairFives
          * 8: pairSixes
          * 9: straight
          * 10: threePairs
          * 11: threeOfAKinds
          * 12: HotDice
          * 13: threeOnes
          * 14: threeTwos
          * 15: threeThrees
          * 16: threeFours
          * 17: threeFives
          * 18: threeSixes
          * A value 0 means false
          * a value 1 means true
          */

            int[] AIPackage = new int[19];

            // ScoreableDice
            if (scoreableDice == true)
            {
                AIPackage[0] = 1;
            }
            else
            {
                AIPackage[0] = 0;
            }

            AIPackage[1] = oneCounter;
            AIPackage[2] = fiveCounter;

            // pair ones
            if (pairOnes == true)
            {
                AIPackage[3] = 1;
            }
            else
            {
                AIPackage[3] = 0;
            }

            // pair twos
            if (pairTwos == true)
            {
                AIPackage[4] = 1;
            }
            else
            {
                AIPackage[4] = 0;
            }

            // pair threes
            if (pairThrees == true)
            {
                AIPackage[5] = 1;
            }
            else
            {
                AIPackage[5] = 0;
            }

            // pair fours
            if (pairFours == true)
            {
                AIPackage[6] = 1;
            }
            else
            {
                AIPackage[6] = 0;
            }

            // pair fives
            if (pairFives == true)
            {
                AIPackage[7] = 1;
            }
            else
            {
                AIPackage[7] = 0;
            }

            // pair sixes
            if (pairSixes == true)
            {
                AIPackage[8] = 1;
            }
            else
            {
                AIPackage[8] = 0;
            }

            // straight
            if (straight == true)
            {
                AIPackage[9] = 1;
            }
            else
            {
                AIPackage[9] = 0;
            }

            // threePairs
            if (threePairs == true)
            {
                AIPackage[10] = 1;
            }
            else
            {
                AIPackage[10] = 0;
            }

            // Three Of a Kind
            if (threeOfAKinds == true)
            {
                AIPackage[11] = 1;
            }
            else
            {
                AIPackage[11] = 0;
            }

            // Hotdice
            if (currentPlayerList[0].HotDice == true)
            {
                AIPackage[12] = 1;
            }
            else
            {
                AIPackage[12] = 0;
            }

            // ThreeOnes
            if (threeOnes)
            {
                AIPackage[13] = 1;
            }
            else
            {
                AIPackage[13] = 0;
            }

            // ThreeTwos
            if (threeTwos == true)
            {
                AIPackage[14] = 1;
            }
            else
            {
                AIPackage[14] = 0;
            }

            // ThreeThrees
            if (threeThrees == true)
            {
                AIPackage[15] = 1;
            }
            else
            {
                AIPackage[15] = 0;
            }

            // ThreeFours
            if (threeFours == true)
            {
                AIPackage[16] = 1;
            }
            else
            {
                AIPackage[16] = 0;
            }

            // ThreeFives
            if (threeFives == true)
            {
                AIPackage[17] = 1;
            }
            else
            {
                AIPackage[17] = 0;
            }

            // ThreeSixes
            if (threeSixes == true)
            {
                AIPackage[18] = 1;
            }
            else
            {
                AIPackage[18] = 0;
            }

            return AIPackage;
        }

        /// <summary>
        /// Method to roll the dice.
        /// </summary>
        /// <param name="diceRolled">The dice that were rolled.</param>
        public void RollDice(int diceRolled)
        {
            for (int counter = 0; counter < this.diceList.Count(); counter++)
            {
                this.diceList[counter] = this.rand.Next(6) + 1;
            }
        }

        /// <summary>
        /// Method to display the score for the player.
        /// </summary>
        public void DisplayScore()
        {
            // Score the dice for that hand.
            this.currentPlayerList[0].ScoreDice(this.savedDieList, this.locked1List, this.locked2List, this.locked3List, this.locked4List, this.locked5List);

            // If dice are valid.
            if (this.currentPlayerList[0].ValidDice)
            {
                // If the player did not farkle
                if (!this.playerFarkle)
                {
                    // Check if the current player is a human
                    if (!currentPlayerList[0].IsAI)
                    {
                        // If they are enable the roll button.
                        btnRoll.IsEnabled = true;
                    }
                    else
                    {
                        // If its a computer disable the roll button.
                        btnRoll.IsEnabled = false;
                    }
                }

                // Set label to show score.
                lblPendingScore.Content = "Pending Score: " + this.currentPlayerList[0].TempScore.ToString();
            }
            else
            {
                lblPendingScore.Content = "Pending Score: " + this.currentPlayerList[0].TempScore.ToString();
            }

            // Check to see if all dice have been kept and are valid.
            if (imgSavedDie1.IsVisible && imgSavedDie2.IsVisible && imgSavedDie3.IsVisible
                && imgSavedDie4.IsVisible && imgSavedDie5.IsVisible && imgSavedDie6.IsVisible
                && this.currentPlayerList[0].ValidDice)
            {
                // Set hot dice to true.
                this.currentPlayerList[0].HotDice = true;

                // Call resetLockedLists.
                ResetLockedLists();

                // Reset the borders.
                bdrDie1.Visibility = Visibility.Visible;
                bdrDie2.Visibility = Visibility.Visible;
                bdrDie3.Visibility = Visibility.Visible;
                bdrDie4.Visibility = Visibility.Visible;
                bdrDie5.Visibility = Visibility.Visible;
                bdrDie6.Visibility = Visibility.Visible;

                // Reset the roll incrementer.
                rollIncrementer = 0;

                // Messagebox telling the user they can roll again.
                MessageBox.Show("You have hot dice! You can roll again to try and score" +
                                " more points, or you can press the next turn button to end your turn!"
                                + "\n" + "\n" +
                                "If you decide to roll again you could possibly lose all of your points " +
                                "for this turn!!");

                // Play the applause sound.
                Stream strHotDice = Properties.Resources.hot_dice;
                SoundPlayer sndHotDice = new SoundPlayer(strHotDice);
                sndHotDice.Play();
            }
            else
            {
                // Hot dice is already false.
            }

            // Call OkToRoll method and set it equal to a local bool value.
            bool okay = OkToRollCheck();

            // Check the value of okay.
            if (okay)
            {
                // Check if the current player is a human
                if (!currentPlayerList[0].IsAI)
                {
                    // If they are enable the roll button.
                    btnRoll.IsEnabled = true;
                }
                else
                {
                    // If its a computer disable the roll button.
                    btnRoll.IsEnabled = false;
                }
            }
            else
            {
                // If false disable the roll button.
                btnRoll.IsEnabled = false;
            }
        }

        /// <summary>
        /// ImgRoll1 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgRoll1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgSavedDie1.Visibility == Visibility.Hidden)
            {
                imgSavedDie1.Visibility = Visibility.Visible;
                imgSavedDie1.Source = imgRoll1.Source;
                imgRoll1.Visibility = Visibility.Hidden;

                // sixth spot in the array holds die #6
                this.currentPlayerList[0].DieKept[0] = this.die1.Pips;
                this.savedDieList.Add(this.die1);
                this.diceInPlay.Remove(this.die1);

                // Call Display Score method.
                this.DisplayScore();
            }
        }

        /// <summary>
        /// ImgsavedDie1 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgSavedDie1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgRoll1.Visibility == Visibility.Hidden)
            {
                // if (!die1.isLocked)
                if (!this.die1.Locked1 && !this.die1.Locked2 && !this.die1.Locked3 && !this.die1.Locked4 && !this.die1.Locked5)
                {
                    imgRoll1.Source = imgSavedDie1.Source;
                    imgRoll1.Visibility = Visibility.Visible;
                    imgSavedDie1.Visibility = Visibility.Hidden;
                    this.currentPlayerList[0].DieKept[0] = 0;
                    this.diceInPlay.Add(this.die1);
                    this.savedDieList.Remove(this.die1);

                    // Call Display Score method.
                    this.DisplayScore();
                }
            }
        }

        /// <summary>
        /// ImgRoll2 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgRoll2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgSavedDie2.Visibility == Visibility.Hidden)
            {
                imgSavedDie2.Visibility = Visibility.Visible;
                imgSavedDie2.Source = imgRoll2.Source;
                imgRoll2.Visibility = Visibility.Hidden;

                // sixth spot in the array holds die #6
                this.currentPlayerList[0].DieKept[1] = this.die2.Pips;
                this.savedDieList.Add(this.die2);
                this.diceInPlay.Remove(this.die2);

                // Call Display Score method.
                this.DisplayScore();
            }
        }

        /// <summary>
        /// ImgSavedDie2 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgSavedDie2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgRoll2.Visibility == Visibility.Hidden)
            {
                // if (!die2.isLocked)
                if (!this.die2.Locked1 && !this.die2.Locked2 && !this.die2.Locked3 && !this.die2.Locked4 && !this.die2.Locked5)
                {
                    imgRoll2.Source = imgSavedDie2.Source;
                    imgRoll2.Visibility = Visibility.Visible;
                    imgSavedDie2.Visibility = Visibility.Hidden;
                    this.currentPlayerList[0].DieKept[1] = 0;
                    this.diceInPlay.Add(this.die2);
                    this.savedDieList.Remove(this.die2);

                    // Call Display Score method.
                    this.DisplayScore();
                }
            }
        }

        /// <summary>
        /// ImgRoll3 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgRoll3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgSavedDie3.Visibility == Visibility.Hidden)
            {
                imgSavedDie3.Visibility = Visibility.Visible;
                imgSavedDie3.Source = imgRoll3.Source;
                imgRoll3.Visibility = Visibility.Hidden;

                // sixth spot in the array holds die #6
                this.currentPlayerList[0].DieKept[2] = this.die3.Pips;
                this.savedDieList.Add(this.die3);
                this.diceInPlay.Remove(this.die3);

                // Call Display Score method.
                this.DisplayScore();
            }
        }

        /// <summary>
        /// ImgSavedDie3 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgSavedDie3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgRoll3.Visibility == Visibility.Hidden)
            {
                // if (!die3.isLocked)
                if (!this.die3.Locked1 && !this.die3.Locked2 && !this.die3.Locked3 && !this.die3.Locked4 && !this.die3.Locked5)
                {
                    imgRoll3.Source = imgSavedDie3.Source;
                    imgRoll3.Visibility = Visibility.Visible;
                    imgSavedDie3.Visibility = Visibility.Hidden;
                    this.currentPlayerList[0].DieKept[2] = 0;
                    this.diceInPlay.Add(this.die3);
                    this.savedDieList.Remove(this.die3);

                    // Call Display Score method.
                    this.DisplayScore();
                }
            }
        }

        /// <summary>
        /// ImgRoll4 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgRoll4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgSavedDie4.Visibility == Visibility.Hidden)
            {
                imgSavedDie4.Visibility = Visibility.Visible;
                imgSavedDie4.Source = imgRoll4.Source;
                imgRoll4.Visibility = Visibility.Hidden;

                // sixth spot in the array holds die #6
                this.currentPlayerList[0].DieKept[3] = this.die4.Pips;
                this.savedDieList.Add(this.die4);
                this.diceInPlay.Remove(this.die4);

                // Call Display Score method.
                this.DisplayScore();
            }
        }

        /// <summary>
        /// ImgSavedDie4 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgSavedDie4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgRoll4.Visibility == Visibility.Hidden)
            {
                // if (!die4.isLocked)
                if (!this.die4.Locked1 && !this.die4.Locked2 && !this.die4.Locked3 && !this.die4.Locked4 && !this.die4.Locked5)
                {
                    imgRoll4.Source = imgSavedDie4.Source;
                    imgRoll4.Visibility = Visibility.Visible;
                    imgSavedDie4.Visibility = Visibility.Hidden;
                    this.currentPlayerList[0].DieKept[3] = 0;
                    this.diceInPlay.Add(this.die4);
                    this.savedDieList.Remove(this.die4);

                    // Call Display Score method.
                    this.DisplayScore();
                }
            }
        }

        /// <summary>
        /// ImgRoll5 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgRoll5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgSavedDie5.Visibility == Visibility.Hidden)
            {
                imgSavedDie5.Visibility = Visibility.Visible;
                imgSavedDie5.Source = imgRoll5.Source;
                imgRoll5.Visibility = Visibility.Hidden;

                // sixth spot in the array holds die #6
                this.currentPlayerList[0].DieKept[4] = this.die5.Pips;
                this.savedDieList.Add(this.die5);
                this.diceInPlay.Remove(this.die5);

                // Call Display Score method.
                this.DisplayScore();
            }
        }

        /// <summary>
        /// ImgSavedDie5 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgSavedDie5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgRoll5.Visibility == Visibility.Hidden)
            {
                // if (die5.isLocked == false)
                if (!this.die5.Locked1 && !this.die5.Locked2 && !this.die5.Locked3 && !this.die5.Locked4 && !this.die5.Locked5)
                {
                    imgRoll5.Source = imgSavedDie5.Source;
                    imgRoll5.Visibility = Visibility.Visible;
                    imgSavedDie5.Visibility = Visibility.Hidden;
                    this.currentPlayerList[0].DieKept[4] = 0;
                    this.diceInPlay.Add(this.die5);
                    this.savedDieList.Remove(this.die5);

                    // Call Display Score method.
                    this.DisplayScore();
                }
            }
        }

        /// <summary>
        /// ImgRoll6 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgRoll6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgSavedDie6.Visibility == Visibility.Hidden)
            {
                imgSavedDie6.Visibility = Visibility.Visible;
                imgSavedDie6.Source = imgRoll6.Source;
                imgRoll6.Visibility = Visibility.Hidden;

                // sixth spot in the array holds die #6
                this.currentPlayerList[0].DieKept[5] = this.die6.Pips;
                this.savedDieList.Add(this.die6);
                this.diceInPlay.Remove(this.die6);

                // Call Display Score method.
                this.DisplayScore();
            }
        }

        /// <summary>
        /// ImgSavedDie6 Button click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">MouseButtonEventArgs e.</param>
        private void ImgSavedDie6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imgRoll6.Visibility == Visibility.Hidden)
            {
                // if (die6.isLocked == false)
                if (!this.die6.Locked1 && !this.die6.Locked2 && !this.die6.Locked3 && !this.die6.Locked4 && !this.die6.Locked5)
                {
                    imgRoll6.Source = imgSavedDie6.Source;
                    imgRoll6.Visibility = Visibility.Visible;
                    imgSavedDie6.Visibility = Visibility.Hidden;
                    this.currentPlayerList[0].DieKept[5] = 0;
                    this.diceInPlay.Add(this.die6);
                    this.savedDieList.Remove(this.die6);

                    // Call Display Score method.
                    this.DisplayScore();
                }
                else
                {
                    // MessageBox.Show("You've saved this die and it is locked for this round");
                }
            }
        }

        /// <summary>
        /// Method for BtnRoll Click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void BtnRoll_Click(object sender, RoutedEventArgs e)
        {
            if (this.savedDieList.Count > 0 && !this.currentPlayerList[0].ValidDice)
            {
                // Display message that some dice are not scorable.
                MessageBox.Show("Some of your dice are not scorable!");
            }
            else
            {
                // Disable the roll button.
                btnRoll.IsEnabled = false;

                // Check if the current player is a human or computer.
                if (currentPlayerList[0].IsAI)
                {
                    // If its a computer disable the next turn button.
                    btnNextTurn.IsEnabled = false;
                }
                else
                {
                    // If its a human enable the next turn button.
                    btnNextTurn.IsEnabled = true;
                }

                if (this.currentPlayerList[0].ValidDice || this.rollIncrementer == 0)
                {
                    // Loop through this.savedDieList
                    foreach (Dice die in this.savedDieList)
                    {
                        // Check rollIncrementer to see which roll it is.
                        if (this.rollIncrementer == 1)
                        {
                            // Set Locked1 to true.
                            die.Locked1 = true;

                            // Add to Locked1List.
                            this.locked1List.Add(die);
                        }
                        else if (this.rollIncrementer == 2)
                        {
                            // Set Locked2 to true.
                            die.Locked2 = true;

                            // Add to Locked2List.
                            this.locked2List.Add(die);
                        }
                        else if (this.rollIncrementer == 3)
                        {
                            // Set Locked3 to true.
                            die.Locked3 = true;

                            // Add to Locked1List.
                            this.locked3List.Add(die);
                        }
                        else if (this.rollIncrementer == 4)
                        {
                            // Set Locked4 to true.
                            die.Locked4 = true;

                            // Add to Locked1List.
                            this.locked4List.Add(die);
                        }
                        else if (this.rollIncrementer == 5)
                        {
                            // Set Locked5 to true.
                            die.Locked5 = true;

                            // Add to Locked1List.
                            this.locked5List.Add(die);
                        }
                        else
                        {
                            // 6th roll: Either hotDice or Farkle.
                        }
                    }

                    // If die 1 is locked.
                    if (this.die1.Locked1 || this.die1.Locked2 || this.die1.Locked3 || this.die1.Locked4 || this.die1.Locked5)
                    {
                        // Make the border visible.
                        bdrDie1.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        bdrDie1.Visibility = Visibility.Hidden;
                    }

                    // If die 2 is locked.
                    if (this.die2.Locked1 || this.die2.Locked2 || this.die2.Locked3 || this.die2.Locked4 || this.die2.Locked5)
                    {
                        // Make the border visible.
                        bdrDie2.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        bdrDie2.Visibility = Visibility.Hidden;
                    }

                    // If die 3 is locked.
                    if (this.die3.Locked1 || this.die3.Locked2 || this.die3.Locked3 || this.die3.Locked4 || this.die3.Locked5)
                    {
                        // Make the border visible.
                        bdrDie3.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        bdrDie3.Visibility = Visibility.Hidden;
                    }

                    // If die 4 is locked.
                    if (this.die4.Locked1 || this.die4.Locked2 || this.die4.Locked3 || this.die4.Locked4 || this.die4.Locked5)
                    {
                        // Make the border visible.
                        bdrDie4.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        bdrDie4.Visibility = Visibility.Hidden;
                    }

                    // If die 5 is locked.
                    if (this.die5.Locked1 || this.die5.Locked2 || this.die5.Locked3 || this.die5.Locked4 || this.die5.Locked5)
                    {
                        // Make the border visible.
                        bdrDie5.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        bdrDie5.Visibility = Visibility.Hidden;
                    }

                    // If die 6 is locked.
                    if (this.die6.Locked1 || this.die6.Locked2 || this.die6.Locked3 || this.die6.Locked4 || this.die6.Locked5)
                    {
                        // Make the border visible.
                        bdrDie6.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        bdrDie6.Visibility = Visibility.Hidden;
                    }

                    // this used to be in the below if statement check
                    // imgSavedDie1.IsVisible && imgSavedDie2.IsVisible && imgSavedDie3.IsVisible
                    // && imgSavedDie4.IsVisible && imgSavedDie5.IsVisible && imgSavedDie6.IsVisible
                    // && player1.ValidDice
                    // Check to see if all dice have been kept and are valid.
                    if (this.savedDieList.Count == 6)
                    {
                        // Set hot dice to true.
                        this.currentPlayerList[0].HotDice = true;
                        bdrDie1.Visibility = Visibility.Hidden;
                        bdrDie2.Visibility = Visibility.Hidden;
                        bdrDie3.Visibility = Visibility.Hidden;
                        bdrDie4.Visibility = Visibility.Hidden;
                        bdrDie5.Visibility = Visibility.Hidden;
                        bdrDie6.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        // Hot dice is already false.
                    }

                    // If hot dice is true make imgRoll images visible.
                    if (this.currentPlayerList[0].HotDice)
                    {
                        // Make the images visible.
                        imgRoll1.Visibility = Visibility.Visible;
                        imgRoll2.Visibility = Visibility.Visible;
                        imgRoll3.Visibility = Visibility.Visible;
                        imgRoll4.Visibility = Visibility.Visible;
                        imgRoll5.Visibility = Visibility.Visible;
                        imgRoll6.Visibility = Visibility.Visible;

                        // If they do, hide all the saved die images. 
                        imgSavedDie1.Visibility = Visibility.Hidden;
                        imgSavedDie2.Visibility = Visibility.Hidden;
                        imgSavedDie3.Visibility = Visibility.Hidden;
                        imgSavedDie4.Visibility = Visibility.Hidden;
                        imgSavedDie5.Visibility = Visibility.Hidden;
                        imgSavedDie6.Visibility = Visibility.Hidden;

                        // Unlock each die in this.savedDieList. 
                        foreach (Dice die in this.savedDieList)
                        {
                            // die.isLocked = false;
                            die.Locked1 = false;
                            die.Locked2 = false;
                            die.Locked3 = false;
                            die.Locked4 = false;
                            die.Locked5 = false;
                        }

                        // Clear the this.savedDieList. todo new
                        this.savedDieList.Clear();

                        // Set wasHotDice to true.
                        this.currentPlayerList[0].WasHotDice = true;

                        // Set the hotDiceAccumulator equal to the tempScore.
                        this.currentPlayerList[0].HotDiceAccumulator = this.currentPlayerList[0].TempScore;

                        // todo set hotDiceAccumulator to 0 somewhere other than next turn?

                        // Reset players hotdice value to false.
                        this.currentPlayerList[0].HotDice = false;
                    }
                    else
                    {
                        // Nothing needs to be done here.
                    }

                    // Add the die to the this.diceInPlayList.

                    // Add the Die to the list
                    this.diceList.Add(this.die1.Pips);
                    this.diceList.Add(this.die2.Pips);
                    this.diceList.Add(this.die3.Pips);
                    this.diceList.Add(this.die4.Pips);
                    this.diceList.Add(this.die5.Pips);
                    this.diceList.Add(this.die6.Pips);

                    // Call RollDice method using the return value from check dice.
                    this.RollDice(this.diceInPlay.Count);
                    this.die1.Pips = this.diceList[0];
                    this.die2.Pips = this.diceList[1];
                    this.die3.Pips = this.diceList[2];
                    this.die4.Pips = this.diceList[3];
                    this.die5.Pips = this.diceList[4];
                    this.die6.Pips = this.diceList[5];
                    
                    // Play the rolling dice sound
                    Stream strRollDice = Properties.Resources.roll_dice;
                    SoundPlayer sndRollDice = new SoundPlayer(strRollDice);
                    sndRollDice.Play();
                    
                    // Call the SetDiceImg method.
                    this.SetDiceImg();

                    // Clear the diceList.
                    this.diceList.Clear();

                    // Call Check Dice method.
                    this.CheckDice();

                    // If player did or did not farkle.
                    if (!this.playerFarkle)
                    {
                        // There are scorable dice.
                        // Player did not farkle but btnRoll should not be enabled until scoreDice is hit.
                    }
                    else
                    {
                        // The player farkled and it is no longer their turn.

                        // Set the players score tempScore to 0.
                        this.currentPlayerList[0].TempScore = 0;

                        // Play the sad horn sound.
                        Stream strSadHorn = Properties.Resources.sad_trombone;
                        SoundPlayer sndSadHorn = new SoundPlayer(strSadHorn);
                        sndSadHorn.Play();

                        // Messagebox telling the player they farkled.
                        MessageBox.Show("Farkle! You lost all points for this round."
                            + "\n" + "Please hit the next turn button.");

                        // Disable the roll button.
                        btnRoll.IsEnabled = false;

                        // Disable the imgRoll images.
                        imgRoll1.IsEnabled = false;
                        imgRoll2.IsEnabled = false;
                        imgRoll3.IsEnabled = false;
                        imgRoll4.IsEnabled = false;
                        imgRoll5.IsEnabled = false;
                        imgRoll6.IsEnabled = false;

                        // Call Display Score method.
                        this.DisplayScore();
                    }

                    // Check if player has hot dice.
                    if (this.currentPlayerList[0].HotDice)
                    {
                        int i = 0;

                        // if they do reset their dicekept array to 0's
                        while (i < this.currentPlayerList[0].DieKept.Count())
                        {
                            this.currentPlayerList[0].DieKept[i] = 0;
                            i++;
                        }
                    }
                    else
                    {
                        // Nothing needs to be done here.
                    }
                }

                // If the player has hot dice. 
                if (this.currentPlayerList[0].HotDice)
                {
                    // Reset the roll incrementer to 0.
                    this.rollIncrementer = 0;
                }
                else
                {
                    // Otherwise increment the roll counter.
                    this.rollIncrementer++;
                }
            }

            Refresh(farkle);
            System.Threading.Thread.Sleep(300);
        }

        /// <summary>
        /// Method for BtnNextTurn Click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void BtnNextTurn_Click(object sender, RoutedEventArgs e)
        {
            this.rollIncrementer = 0;

            // Call ResetFieldsForNewTurn.
            this.currentPlayerList[0].ResetFieldsForNewTurn();

            // Call ResetLockedLists to reset locked lists and dice.
            this.ResetLockedLists();

            // Disable the imgRoll images.
            imgRoll1.IsEnabled = true;
            imgRoll2.IsEnabled = true;
            imgRoll3.IsEnabled = true;
            imgRoll4.IsEnabled = true;
            imgRoll5.IsEnabled = true;
            imgRoll6.IsEnabled = true;

            // Set i to zero.
            int i = 0;

            // Reset their dikept array to 0's
            while (i < this.currentPlayerList[0].DieKept.Count())
            {
                this.currentPlayerList[0].DieKept[i] = 0;
                i++;
            }

            // Hide all the saved die images.
            imgSavedDie1.Visibility = Visibility.Hidden;
            imgSavedDie2.Visibility = Visibility.Hidden;
            imgSavedDie3.Visibility = Visibility.Hidden;
            imgSavedDie4.Visibility = Visibility.Hidden;
            imgSavedDie5.Visibility = Visibility.Hidden;
            imgSavedDie6.Visibility = Visibility.Hidden;

            // Make the imgRoll images visible.
            imgRoll1.Visibility = Visibility.Visible;
            imgRoll2.Visibility = Visibility.Visible;
            imgRoll3.Visibility = Visibility.Visible;
            imgRoll4.Visibility = Visibility.Visible;
            imgRoll5.Visibility = Visibility.Visible;
            imgRoll6.Visibility = Visibility.Visible;

            // Set current score.
            if (!this.playerFarkle)
            {
                // Add the tempScore returned from the score dice method to current score.
                this.currentPlayerList[0].CurrentScore = this.currentPlayerList[0].TempScore + this.currentPlayerList[0].CurrentScore;
            }
            else
            {
                // Add no points to the current score.
                this.currentPlayerList[0].CurrentScore += 0;

                // Reset farkle to false.
                this.playerFarkle = false;
            }

            // Reset player1s tempScore to 0.
            this.currentPlayerList[0].TempScore = 0;

            // Reset lblPendingScore.
            lblPendingScore.Content = "Pending Score: " + this.currentPlayerList[0].TempScore.ToString();

            // Check if score is greater than or equal to 10000. If it is the player wins.
            if (this.currentPlayerList[0].CurrentScore >= 10000)
            {
                // Close current window.
                this.Hide();

                // Create and show Winner page.
                Winner win = new Winner();

                win.lblWinner.Content = "Congratulations player " + this.currentPlayerList[0].Number + " you win!";
                win.ShowDialog();
            }
            else
            {
                // No players have won yet.
            }

            // Clear the savedDieList.
            this.savedDieList.Clear();

            // Update this players score on the right hand side of the screen / play area
            if (this.currentPlayerList[0].Number == 1)
            {
                lblPlayerOneScore.Content = "Score " + this.currentPlayerList[0].CurrentScore;
            }
            else if (this.currentPlayerList[0].Number == 2)
            {
                lblPlayerTwoScore.Content = "Score " + this.currentPlayerList[0].CurrentScore;
            }
            else if (this.currentPlayerList[0].Number == 3)
            {
                lblPlayerThreeScore.Content = "Score " + this.currentPlayerList[0].CurrentScore;
            }
            else if (this.currentPlayerList[0].Number == 4)
            {
                lblPlayerFourScore.Content = "Score " + this.currentPlayerList[0].CurrentScore;
            }

            this.currentPlayerList.Add(this.currentPlayerList[0]);
            this.currentPlayerList.Remove(this.currentPlayerList[0]);

            // Set text content of where the players information goes.
            // first make sure the player is supposed to be AI
            if (currentPlayerList[0].IsAI == true)
            {
                lblPlayerInformation.Content = "Player " + currentPlayerList[0].Number + "'s Turn (AI)";
            }
            else
            {
                lblPlayerInformation.Content = "Player " + this.currentPlayerList[0].Number.ToString() + "'s Turn";
            }

            // Roll for the next turn
            this.BtnRoll_Click(null, null);

            // Check if the current player is a computer.
            if (currentPlayerList[0].IsAI == true)
            {
                // If it is a computer call the AImakePlay method.
                AImakePlay();
            }

            // Disable the roll button.
            btnRoll.IsEnabled = false;
        }

        /// <summary>
        /// Method for BtnExit Click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            // Close the form.
            this.Close();
        }

        /// <summary>
        /// Method for BtnScoring Click.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void BtnScoring_Click(object sender, RoutedEventArgs e)
        {
            // Show all possible scoreable dice combinations.
            Scoring scoreSheet = new Scoring();
            scoreSheet.Show();
        }

        /// <summary>
        /// Method to reset the locked lists 1-5.
        /// </summary>
        private void ResetLockedLists()
        {
            // Reset locked lists.
            this.locked1List.Clear();
            this.locked2List.Clear();
            this.locked3List.Clear();
            this.locked4List.Clear();
            this.locked5List.Clear();

            // Reset the locked fields of every dice.
            this.die1.ResetLockedDice();
            this.die2.ResetLockedDice();
            this.die3.ResetLockedDice();
            this.die4.ResetLockedDice();
            this.die5.ResetLockedDice();
            this.die6.ResetLockedDice();

            // Reset the borders.
            bdrDie1.Visibility = Visibility.Hidden;
            bdrDie2.Visibility = Visibility.Hidden;
            bdrDie3.Visibility = Visibility.Hidden;
            bdrDie4.Visibility = Visibility.Hidden;
            bdrDie5.Visibility = Visibility.Hidden;
            bdrDie6.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Grid load event.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">RoutedEventArgs e.</param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // Make sure that the difficulty is set. 
            if (difficulty == 0 || difficulty == null)
            {
                difficulty = 1;
            }

            Player tempPlayer = new Player();

            if (this.onePlayer)
            {
                if (AICount == 1)
                {
                    tempPlayer.Number = 1;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                }
                else
                {
                    tempPlayer.Number = 1;
                    this.currentPlayerList.Add(tempPlayer);
                }

                // Hide the last three player score labels and player labels.
                lblPlayerTwo.Visibility = Visibility.Hidden;
                lblPlayerTwoScore.Visibility = Visibility.Hidden;
                lblPlayerThree.Visibility = Visibility.Hidden;
                lblPlayerThreeScore.Visibility = Visibility.Hidden;
                lblPlayerFour.Visibility = Visibility.Hidden;
                lblPlayerFourScore.Visibility = Visibility.Hidden;
            }
            else if (this.twoPlayer)
            {
                tempPlayer = new Player();

                if (AICount == 1)
                {
                    tempPlayer.Number = 1;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                }
                else if (AICount == 2)
                {
                    tempPlayer.Number = 1;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                }
                else
                {
                    tempPlayer.Number = 1;
                    this.currentPlayerList.Add(tempPlayer);

                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    this.currentPlayerList.Add(tempPlayer);
                }

                lblPlayerFour.Visibility = Visibility.Hidden;
                lblPlayerThree.Visibility = Visibility.Hidden;
                lblPlayerFourScore.Visibility = Visibility.Hidden;
                lblPlayerThreeScore.Visibility = Visibility.Hidden;
            }
            else if (this.threePlayer)
            {
                tempPlayer = new Player();

                if (AICount == 1)
                {
                    tempPlayer.Number = 1;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 3;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                }
                else if (AICount == 2)
                {
                    tempPlayer.Number = 1;
                    tempPlayer.IsAI = false;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 3;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                }
                else if (AICount == 3)
                {
                    tempPlayer.Number = 1;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 3;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                }
                else
                {
                    tempPlayer.Number = 1;
                    this.currentPlayerList.Add(tempPlayer);

                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    this.currentPlayerList.Add(tempPlayer);

                    tempPlayer = new Player();
                    tempPlayer.Number = 3;
                    this.currentPlayerList.Add(tempPlayer);
                }

                lblPlayerFour.Visibility = Visibility.Hidden;
                lblPlayerFourScore.Visibility = Visibility.Hidden;
            }
            else if (this.fourPlayer)
            {
                tempPlayer = new Player();

                if (AICount == 1)
                {
                    tempPlayer.Number = 1;
                    tempPlayer.IsAI = false;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    tempPlayer.IsAI = false;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 3;
                    tempPlayer.IsAI = false;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 4;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                }
                else if (AICount == 2)
                {
                    tempPlayer.Number = 1;
                    tempPlayer.IsAI = false;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    tempPlayer.IsAI = false;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 3;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 4;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                }
                else if (AICount == 3)
                {
                    tempPlayer.Number = 1;
                    tempPlayer.IsAI = false;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 3;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 4;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                }
                else if (AICount == 4)
                {
                    tempPlayer.Number = 1;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 3;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                    tempPlayer = new Player();
                    tempPlayer.Number = 4;
                    tempPlayer.IsAI = true;
                    this.currentPlayerList.Add(tempPlayer);
                }
                else
                {
                    tempPlayer.Number = 1;
                    this.currentPlayerList.Add(tempPlayer);

                    tempPlayer = new Player();
                    tempPlayer.Number = 2;
                    this.currentPlayerList.Add(tempPlayer);

                    tempPlayer = new Player();
                    tempPlayer.Number = 3;
                    this.currentPlayerList.Add(tempPlayer);

                    tempPlayer = new Player();
                    tempPlayer.Number = 4;
                    this.currentPlayerList.Add(tempPlayer);
                }
            }

            // Set text content of where the players information goes.
            // first make sure the player is supposed to be AI
            if (currentPlayerList[0].IsAI == true)
            {
                lblPlayerInformation.Content = "Player " + currentPlayerList[0].Number + "'s Turn (AI)";
            }
            else
            {
                lblPlayerInformation.Content = "Player " + this.currentPlayerList[0].Number.ToString() + "'s Turn";
            }

            this.currentPlayerList[0].ValidDice = true;

            if (difficulty == 1)
            {
                lblDifficulty.Content = "Difficulty: Easy";
                lblDifficulty.Foreground = Brushes.LimeGreen;
            }
            else if (difficulty == 2)
            {
                lblDifficulty.Content = "Difficulty: Hard";
                lblDifficulty.Foreground = Brushes.IndianRed;
            }
        }

        public void AImakePlay()
        {
            // first make sure the player is supposed to be AI
            if (currentPlayerList[0].IsAI == true)
            {
                lblPlayerInformation.Content = "Player " + currentPlayerList[0].Number + "'s Turn (AI)";
            }

            int[] AIPackage = new int[19];
            AIPackage = CheckDice().Clone() as int[];
            /*
            * the array elements in order are
            * 0: ScoreableDice
            * 1: oneCounter
            * 2: fiveCounter
            * 3: pairOnes
            * 4: pairTwos
            * 5: pairThrees
            * 6: pairFours
            * 7: pairFives
            * 8: pairSixes
            * 9: straight
            * 10: threePairs
            * 11: threeOfAKinds
            * 12: hotDice
            * A value 0 means false
            * a value 1 means true
            */

            // Check to see if the difficulty is 2 (which would be hard)
            //  If it is the AI will check for all possible ways to score.
            // It will also reroll if it can only take 1/2 dice.
            if (difficulty == 2)
            {
                // if our dice are scoreable then begin our checks
                if (AIPackage[0] == 1)
                {
                    // check for a straight
                    if (AIPackage[9] == 1)
                    {
                        // we have a straight
                        // then set images and check roll incrementer add to saveddielist/lockedlist for scoring
                        // going to call the aisetimg method, which is below, here
                        int counter = 1;
                        while (counter < 6)
                        {
                            System.Threading.Thread.Sleep(150);
                            AISetImg(counter);
                            System.Threading.Thread.Sleep(150);
                            counter++;
                        }
                    }

                    if (AIPackage[10] == 1)
                    {
                        // we have 3 pairs, now we need to check to see which
                        /*
                                * 3: pairOnes
                                * 4: pairTwos
                                * 5: pairThrees
                                * 6: pairFours
                                * 7: pairFives
                                * 8: pairSixes
                        */
                        // then set images and check roll incrementer add to saveddielist/lockedlist for scoring

                        if(AIPackage[3] == 1 && AIPackage[4] == 1 && AIPackage[5] == 1)
                        {
                            // We have a pair of of 1's, a pair of 2's, and a pair of 3's
                            AISetImg(1);
                            AISetImg(1);
                            AISetImg(2);
                            AISetImg(2);
                            AISetImg(3);
                            AISetImg(3);
                        }

                        if (AIPackage[3] == 1 && AIPackage[4] == 1 && AIPackage[6] == 1)
                        {
                            // We have a pair of of 1's, a pair of 2's, and a pair of 4's
                            AISetImg(1);
                            AISetImg(1);
                            AISetImg(2);
                            AISetImg(2);
                            AISetImg(4);
                            AISetImg(4);
                        }

                        if (AIPackage[3] == 1 && AIPackage[4] == 1 && AIPackage[7] == 1)
                        {
                            // We have a pair of of 1's, a pair of 2's, and a pair of 5's
                            AISetImg(1);
                            AISetImg(1);
                            AISetImg(2);
                            AISetImg(2);
                            AISetImg(5);
                            AISetImg(5);
                        }

                        if (AIPackage[3] == 1 && AIPackage[4] == 1 && AIPackage[8] == 1)
                        {
                            // We have a pair of of 1's, a pair of 2's, and a pair of 6's
                            AISetImg(1);
                            AISetImg(1);
                            AISetImg(2);
                            AISetImg(2);
                            AISetImg(6);
                            AISetImg(6);
                        }

                        if (AIPackage[3] == 1 && AIPackage[5] == 1 && AIPackage[6] == 1)
                        {
                            // We have a pair of of 1's, a pair of 3's, and a pair of 4's
                            AISetImg(1);
                            AISetImg(1);
                            AISetImg(3);
                            AISetImg(3);
                            AISetImg(4);
                            AISetImg(4);
                        }

                        if (AIPackage[3] == 1 && AIPackage[5] == 1 && AIPackage[7] == 1)
                        {
                            // We have a pair of of 1's, a pair of 3's, and a pair of 5's
                            AISetImg(1);
                            AISetImg(1);
                            AISetImg(3);
                            AISetImg(3);
                            AISetImg(5);
                            AISetImg(5);
                        }

                        if (AIPackage[3] == 1 && AIPackage[5] == 1 && AIPackage[8] == 1)
                        {
                            // We have a pair of of 1's, a pair of 3's, and a pair of 6's
                            AISetImg(1);
                            AISetImg(1);
                            AISetImg(3);
                            AISetImg(3);
                            AISetImg(6);
                            AISetImg(6);
                        }

                        if (AIPackage[3] == 1 && AIPackage[6] == 1 && AIPackage[7] == 1)
                        {
                            // We have a pair of of 1's, a pair of 4's, and a pair of 5's
                            AISetImg(1);
                            AISetImg(1);
                            AISetImg(4);
                            AISetImg(4);
                            AISetImg(5);
                            AISetImg(5);
                        }

                        if (AIPackage[3] == 1 && AIPackage[6] == 1 && AIPackage[8] == 1)
                        {
                            // We have a pair of of 1's, a pair of 4's, and a pair of 6's
                            AISetImg(1);
                            AISetImg(1);
                            AISetImg(4);
                            AISetImg(4);
                            AISetImg(6);
                            AISetImg(6);
                        }

                        if (AIPackage[3] == 1 && AIPackage[7] == 1 && AIPackage[8] == 1)
                        {
                            // We have a pair of of 1's, a pair of 5's, and a pair of 6's
                            AISetImg(1);
                            AISetImg(1);
                            AISetImg(5);
                            AISetImg(5);
                            AISetImg(6);
                            AISetImg(6);
                        }

                    }

                    // Three Of A Kind
                    if(AIPackage[11] == 1)
                    {

                        // If we have 3 6's
                        if(AIPackage[18] == 1)
                        {
                            int count = 3;
                            while (count > 0)
                            {
                                AISetImg(6);
                                count--;
                            }
                        }

                        // If we have 3 5's
                        if (AIPackage[17] == 1)
                        {
                            int count = 3;
                            while (count > 0)
                            {
                                AISetImg(5);
                                count--;
                            }
                        }

                        // If we have 3 4's
                        if (AIPackage[16] == 1)
                        {
                            int count = 3;
                            while (count > 0)
                            {
                                AISetImg(4);
                                count--;
                            }
                        }

                        // If we have 3 3's
                        if (AIPackage[15] == 1)
                        {
                            int count = 3;
                            while (count > 0)
                            {
                                AISetImg(3);
                                count--;
                            }
                        }

                        // If we have 3 2's
                        if (AIPackage[14] == 1)
                        {
                            int count = 3;
                            while (count > 0)
                            {
                                AISetImg(2);
                                count--;
                            }
                        }

                        // If we have 3 1's
                        if (AIPackage[13] == 1)
                        {
                            int count = 3;
                            while (count > 0)
                            {
                                AISetImg(1);
                                count--;
                            }
                        }
                    }

                    if (AIPackage[1] > 0)
                    {
                        int count = AIPackage[1];
                        while (count > 0)
                        {
                            AISetImg(1);
                            count--;
                        }
                        // we have more than 0 ones 
                    }

                    if (AIPackage[2] > 0)
                    {
                        int count = AIPackage[2];
                        while (count > 0)
                        {
                            System.Threading.Thread.Sleep(100);
                            AISetImg(5);
                            count--;
                        }
                        // we have more than 0 fives 
                    }
                }
                else
                {
                    // our dice are not scoreable
                }
            }
            else
            {
                // if our dice are scoreable then begin our checks
                if (AIPackage[0] == 1)
                {
                    // check for a straight
                    if (AIPackage[9] == 1)
                    {
                        // we have a straight
                        // then set images and check roll incrementer add to saveddielist/lockedlist for scoring
                        // going to call the aisetimg method, which is below, here
                        int counter = 1;
                        while (counter < 6)
                        {
                            System.Threading.Thread.Sleep(150);
                            AISetImg(counter);
                            System.Threading.Thread.Sleep(150);
                            counter++;
                        }
                    }

                    if (AIPackage[1] > 0)
                    {
                        int count = AIPackage[1];
                        while (count > 0)
                        {
                            AISetImg(1);
                            count--;
                        }
                        // we have more than 0 ones 
                    }

                    if (AIPackage[2] > 0)
                    {
                        int count = AIPackage[2];
                        while (count > 0)
                        {
                            System.Threading.Thread.Sleep(100);
                            AISetImg(5);
                            count--;
                        }
                        // we have more than 0 fives 
                    }
                }
                else
                {
                    // our dice are not scoreable
                }
            }

            // difficulty check will go here
            Refresh(farkle);
            System.Threading.Thread.Sleep(650);
            BtnNextTurn_Click(null, null);
        }

        public void AISetImg(int numberToSet)
        {
            // set our dice positions. Die1 will always be for imgroll1, and imgsaveddie1. 
            die1.Position = 1;
            die2.Position = 2;
            die3.Position = 3;
            die4.Position = 4;
            die5.Position = 5;
            die6.Position = 6;

            // int dieLocation = 0;
            // loop through the diceinplay list to find the dice we want to save
            foreach (Dice d in DiceInPlay)
            {
                // if we found the die were looking for then add it to our saveddielist and remove it from the dice in playlist. 
                // Also get the dies location
                if (d.Pips == numberToSet)
                {
                    // Since die1 will always = imgroll1 and imgsaveddie1(the other dice follow the same pattern)
                    // we can get the dies position and then set the correct image control on the form
                    // then set the die to saved
                    if (d.Position == 1)
                    {
                        SavedDieList.Add(d);
                        imgRoll1.Visibility = Visibility.Hidden;
                        imgSavedDie1.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + numberToSet + "Die.jpg"));
                        imgSavedDie1.Visibility = Visibility.Visible;
                        diceInPlay.Remove(d);
                        DisplayScore();
                    }

                    if (d.Position == 2)
                    {
                        SavedDieList.Add(d);
                        imgRoll2.Visibility = Visibility.Hidden;
                        imgSavedDie2.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + numberToSet + "Die.jpg"));
                        imgSavedDie2.Visibility = Visibility.Visible;
                        diceInPlay.Remove(d);
                        DisplayScore();

                    }

                    if (d.Position == 3)
                    {
                        SavedDieList.Add(d);
                        imgRoll3.Visibility = Visibility.Hidden;
                        imgSavedDie3.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + numberToSet + "Die.jpg"));
                        imgSavedDie3.Visibility = Visibility.Visible;
                        diceInPlay.Remove(d);
                        DisplayScore();

                    }

                    if (d.Position == 4)
                    {
                        SavedDieList.Add(d);
                        imgRoll4.Visibility = Visibility.Hidden;
                        imgSavedDie4.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + numberToSet + "Die.jpg"));
                        imgSavedDie4.Visibility = Visibility.Visible;
                        diceInPlay.Remove(d);
                        DisplayScore();

                    }

                    if (d.Position == 5)
                    {
                        SavedDieList.Add(d);
                        imgRoll5.Visibility = Visibility.Hidden;
                        imgSavedDie5.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + numberToSet + "Die.jpg"));
                        imgSavedDie5.Visibility = Visibility.Visible;
                        diceInPlay.Remove(d);
                        DisplayScore();

                    }

                    if (d.Position == 6)
                    {
                        SavedDieList.Add(d);
                        imgRoll6.Visibility = Visibility.Hidden;
                        imgSavedDie6.Source = new BitmapImage(new Uri(@"pack://application:,,,/farkle;component/Resources/" + numberToSet + "Die.jpg"));
                        imgSavedDie6.Visibility = Visibility.Visible;
                        diceInPlay.Remove(d);
                        DisplayScore();

                    }

                    Refresh(farkle);
                    System.Threading.Thread.Sleep(1000);
                    // todo keep an eye on where the break takes you back to: the foreach or out of the foreach
                    break;
                }
            }
        }

        // Below code is used to make the form stop proccesing information and force a redraw of the form
        // use this to refresh and show that the ai is actually doing stuff

        private delegate void Delegate();
        public static void Refresh(DependencyObject objToRefresh)

        {
            objToRefresh.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle,
                (Delegate)delegate { });
        }

        private bool OkToRollCheck()
        {
            // todo copy over AI methods?
            // Counter for all dice that have a locked value.
            int lockedCount = 0;

            // Counter for all dice currently in the save area.
            int totalCount = 0;

            // Loop through each die in the savedDieList
            foreach (Dice die in SavedDieList)
            {
                // If the dice is locked.
                if (die.Locked1 || die.Locked2 || die.Locked3 || die.Locked4 || die.Locked5)
                {
                    // Increment the locked counter.
                    lockedCount++;

                    // Increment the total counter.
                    totalCount++;
                }
                else
                {
                    // If the die is not locked only increment the total counter.
                    totalCount++;
                }
            }

            // Compare the lockedCount variable and the totalCount variable.
            if (lockedCount == totalCount)
            {
                // If they are equal nothing has been added to the save area, return false.
                return false;
            }
            else
            {
                // If they are different something has been added to the save area, return true.
                return true;
            }
        }
    }
}
